using Mandegar.Models.Cache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Cache
{
    class MemoryCacheService : IDisposable, IMemoryCacheService
    {
        private readonly MemoryCache cache;
        private readonly TimeSpan duration;

        public MemoryCacheService(CacheConfig config)
        {
            MemoryCacheOptions options = new MemoryCacheOptions();
            options.Clock = new SystemClock();
            options.CompactionPercentage = (float)config.CompactPercentage / 100.0;
            options.ExpirationScanFrequency = config.ScanInterval;
            options.SizeLimit = config.MaxCacheItems;

            this.duration = config.CacheDuration;
            this.cache = new MemoryCache(options);
        }

        public T Get<T>(object key)
        {
            return this.cache.Get<T>(key);
        }

        public Task<T> GetAsync<T>(object key)
        {
            T value = this.cache.Get<T>(key);

            return Task.FromResult(value);
        }

        public T GetOrSet<T>(object key, Func<T> build = default, TimeSpan? duration = default, bool purge = false)
        {
            T factory(ICacheEntry entry)
            {
                entry.SetAbsoluteExpiration(duration ?? this.duration);
                entry.SetPriority(CacheItemPriority.Normal);
                entry.SetSize(1);

                return build();
            }

            if (purge) this.Remove(key);

            return this.cache.GetOrCreate<T>(key, factory);
        }

        public Task<T> GetOrSetAsync<T>(object key, Task<T> build = default, TimeSpan? duration = default, bool purge = false)
        {
            Task<T> factory(ICacheEntry entry)
            {
                entry.SetAbsoluteExpiration(duration ?? this.duration);
                entry.SetPriority(CacheItemPriority.Normal);
                entry.SetSize(1);

                return build;
            }

            if (purge) this.Remove(key);

            return this.cache.GetOrCreateAsync<T>(key, factory);
        }

        public void Remove(object key)
        {
            this.cache.Remove(key);
        }

        public void Dispose()
        {
            this.cache.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}

