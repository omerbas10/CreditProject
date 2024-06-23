using Microsoft.Extensions.Caching.Memory;
using System;

namespace CreditApp.Services
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Set<T>(string key, T item, int durationInMinutes)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(durationInMinutes));

            _cache.Set(key, item, cacheEntryOptions);
        }

        public T Get<T>(string key)
        {
            return _cache.TryGetValue(key, out T item) ? item : default(T);
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
    }
}
