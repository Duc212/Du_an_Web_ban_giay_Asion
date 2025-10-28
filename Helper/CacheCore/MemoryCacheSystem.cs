using Helper.CacheCore.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Helper.CacheCore
{
    public class MemoryCacheSystem : IMemoryCacheSystem
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheSystem(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void AddOrUpdate<T>(string key, T value)
        {
            _memoryCache.Set(key, value);
        }

        public void AddOrUpdate<T>(string key, T value, TimeSpan expiration)
        {
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            _memoryCache.Set(key, value, cacheOptions);
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }

        public bool Remove(string key)
        {
            if (_memoryCache.TryGetValue(key, out _))
            {
                _memoryCache.Remove(key);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            if (_memoryCache is MemoryCache memoryCache)
            {
                memoryCache.Compact(1.0);
            }
        }

    }
}
