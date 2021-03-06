﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.XCode.Entities;
using IdentityServer4.XCode.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using XCode;

namespace IdentityServer4.XCode
{
    /// <summary>
    /// Helper to perodically cleanup expired persisted grants.
    /// </summary>
    public class TokenCleanup
    {
        private readonly ILogger<TokenCleanup> _logger;
        private readonly IServiceProvider _serviceProvider;
        private readonly OperationalStoreOptions _options;

        private CancellationTokenSource _source;

        private TimeSpan CleanupInterval => TimeSpan.FromSeconds(_options.TokenCleanupInterval);

        /// <summary>
        /// Constructor for TokenCleanup.
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <param name="logger"></param>
        /// <param name="options"></param>
        public TokenCleanup(IServiceProvider serviceProvider, ILogger<TokenCleanup> logger, OperationalStoreOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            if (_options.TokenCleanupInterval < 1) throw new ArgumentException("Token cleanup interval must be at least 1 second");
            if (_options.TokenCleanupBatchSize < 1) throw new ArgumentException("Token cleanup batch size interval must be at least 1");

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// Starts the token cleanup polling.
        /// </summary>
        public void Start()
        {
            Start(CancellationToken.None);
        }

        /// <summary>
        /// Starts the token cleanup polling.
        /// </summary>
        public void Start(CancellationToken cancellationToken)
        {
            if (_source != null) throw new InvalidOperationException("Already started. Call Stop first.");

            _logger.LogDebug("Starting grant removal");

            _source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            Task.Factory.StartNew(() => StartInternalAsync(_source.Token));
        }

        /// <summary>
        /// Stops the token cleanup polling.
        /// </summary>
        public void Stop()
        {
            if (_source == null) throw new InvalidOperationException("Not started. Call Start first.");

            _logger.LogDebug("Stopping grant removal");

            _source.Cancel();
            _source = null;
        }

        private async Task StartInternalAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("CancellationRequested. Exiting.");
                    break;
                }

                try
                {
                    await Task.Delay(CleanupInterval, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    _logger.LogDebug("TaskCanceledException. Exiting.");
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Task.Delay exception: {0}. Exiting.", ex.Message);
                    break;
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    _logger.LogDebug("CancellationRequested. Exiting.");
                    break;
                }

                await RemoveExpiredGrantsAsync();
            }
        }

        /// <summary>
        /// Method to clear expired persisted grants.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveExpiredGrantsAsync()
        {
            try
            {
                _logger.LogTrace("Querying for expired grants to remove");

                var found = Int32.MaxValue;

                using (var serviceScope = _serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var tokenCleanupNotification = ServiceProviderServiceExtensions.GetService<IOperationalStoreNotification>(serviceScope.ServiceProvider);
                    {
                        while (found >= _options.TokenCleanupBatchSize)
                        {
                            var expired = PersistedGrants.FindAllByExpirationAndBatchSize(_options.TokenCleanupBatchSize);

                            found = expired.Count;
                            _logger.LogInformation("Removing {grantCount} grants", found);

                            if (found > 0)
                            {
                                try
                                {
                                    expired.Delete();

                                    if (tokenCleanupNotification != null)
                                    {
                                        await tokenCleanupNotification.PersistedGrantsRemovedAsync(expired);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // we get this if/when someone else already deleted the records
                                    // we want to essentially ignore this, and keep working
                                    _logger.LogDebug("Concurrency exception removing expired grants: {exception}", ex.Message);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception removing expired grants: {exception}", ex.Message);
            }
        }
    }
}