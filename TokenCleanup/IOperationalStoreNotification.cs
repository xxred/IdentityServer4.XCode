﻿using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.XCode.Entities;

namespace IdentityServer4.XCode
{
    /// <summary>
    /// Interface to model notifications from the TokenCleanup feature.
    /// </summary>
    public interface IOperationalStoreNotification
    {
        /// <summary>
        /// Notification for persisted grants being removed.
        /// </summary>
        /// <param name="persistedGrants"></param>
        /// <returns></returns>
        Task PersistedGrantsRemovedAsync(IEnumerable<PersistedGrants> persistedGrants);
    }
}