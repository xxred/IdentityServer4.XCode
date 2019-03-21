using System;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using IdentityServer4.Stores.Serialization;
using IdentityServer4.XCode.Entities;
using Microsoft.Extensions.Logging;

namespace IdentityServer4.XCode.Stores
{
    /// <summary>
    /// Implementation of IDeviceFlowStore thats uses XCode.
    /// </summary>
    /// <seealso cref="IdentityServer4.Stores.IDeviceFlowStore" />
    public class DeviceFlowStore : IDeviceFlowStore
    {
        private readonly IPersistentGrantSerializer _serializer;
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceFlowStore"/> class.
        /// </summary>
        /// <param name="serializer">The serializer</param>
        /// <param name="logger">The logger.</param>
        public DeviceFlowStore(
            IPersistentGrantSerializer serializer, 
            ILogger<DeviceFlowStore> logger)
        {
            _serializer = serializer;
            _logger = logger;
        }

        /// <summary>
        /// Stores the device authorization request.
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <param name="userCode">The user code.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public Task StoreDeviceAuthorizationAsync(string deviceCode, string userCode, DeviceCode data)
        {
            ToEntity(data, deviceCode, userCode).Save();

            return Task.FromResult(0);
        }

        /// <summary>
        /// Finds device authorization by user code.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <returns></returns>
        public Task<DeviceCode> FindByUserCodeAsync(string userCode)
        {
            var deviceFlowCodes = DeviceCodes.FindByUserCode(userCode);
            var model = ToModel(deviceFlowCodes?.Data);

            _logger.LogDebug("{userCode} found in database: {userCodeFound}", userCode, model != null);

            return Task.FromResult(model);
        }

        /// <summary>
        /// Finds device authorization by device code.
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <returns></returns>
        public Task<DeviceCode> FindByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = DeviceCodes.FindByDeviceCode(deviceCode);
            var model = ToModel(deviceFlowCodes?.Data);

            _logger.LogDebug("{deviceCode} found in database: {deviceCodeFound}", deviceCode, model != null);

            return Task.FromResult(model);
        }

        /// <summary>
        /// Updates device authorization, searching by user code.
        /// </summary>
        /// <param name="userCode">The user code.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public Task UpdateByUserCodeAsync(string userCode, DeviceCode data)
        {
            var existing = DeviceCodes.FindByUserCode(userCode);
            if (existing == null)
            {
                _logger.LogError("{userCode} not found in database", userCode);
                throw new InvalidOperationException("Could not update device code");
            }

            var entity = ToEntity(data, existing.DeviceCode, userCode);
            _logger.LogDebug("{userCode} found in database", userCode);

            existing.SubjectId = data.Subject?.FindFirst(JwtClaimTypes.Subject).Value;
            existing.Data = entity.Data;

            try
            {
                existing.Save();
            }
            catch (Exception ex)
            {
                _logger.LogWarning("exception updating {userCode} user code in database: {error}", userCode, ex.Message);
            }

            return Task.FromResult(0);
        }

        /// <summary>
        /// Removes the device authorization, searching by device code.
        /// </summary>
        /// <param name="deviceCode">The device code.</param>
        /// <returns></returns>
        public Task RemoveByDeviceCodeAsync(string deviceCode)
        {
            var deviceFlowCodes = DeviceCodes.FindByDeviceCode(deviceCode);

            if(deviceFlowCodes != null)
            {
                _logger.LogDebug("removing {deviceCode} device code from database", deviceCode);

                try
                {
                    deviceFlowCodes.Delete();
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("exception removing {deviceCode} device code from database: {error}", deviceCode, ex.Message);
                }
            }
            else
            {
                _logger.LogDebug("no {deviceCode} device code found in database", deviceCode);
            }

            return Task.FromResult(0);
        }

        private DeviceCodes ToEntity(DeviceCode model, string deviceCode, string userCode)
        {
            if (model == null || deviceCode == null || userCode == null) return null;

            return new DeviceCodes
            {
                DeviceCode = deviceCode,
                UserCode = userCode,
                ClientId = model.ClientId,
                SubjectId = model.Subject?.FindFirst(JwtClaimTypes.Subject).Value,
                CreationTime = model.CreationTime,
                Expiration = model.CreationTime.AddSeconds(model.Lifetime),
                Data = _serializer.Serialize(model)
            };
        }

        private DeviceCode ToModel(string entity)
        {
            if (entity == null) return null;

            return _serializer.Deserialize<DeviceCode>(entity);
        }
    }
}