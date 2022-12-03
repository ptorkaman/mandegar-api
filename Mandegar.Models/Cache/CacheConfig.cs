using System;

namespace Mandegar.Models.Cache
{
    public class CacheConfig
    {
        /// <summary>
        /// Cache duration, default value is 2 minutes
        /// </summary>
        public TimeSpan CacheDuration { get; set; } = TimeSpan.FromMinutes(2);

        /// <summary>
        /// Scan interval to cleanup storage, default value is 2 minutes
        /// </summary>
        public TimeSpan ScanInterval { get; set; } = TimeSpan.FromMinutes(2);

        /// <summary>
        /// Compact percentage after reaching the limits, default value is 20
        /// </summary>
        public byte CompactPercentage { get; set; } = 20;

        /// <summary>
        /// Maximum number of cache items to store, default value is 8192
        /// </summary>
        public int MaxCacheItems { get; set; } = 8192;
    }
}
