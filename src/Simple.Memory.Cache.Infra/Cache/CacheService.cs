using Microsoft.Extensions.Caching.Memory;

namespace Simple.Memory.Cache.Infra.Cache
{
    public class CacheService : ICacheService
    {
        protected readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<T> GetAsync<T>(string cacheKey)
        {
            _memoryCache.TryGetValue(cacheKey, out T entry);

            return Task.FromResult(entry);
        }

        public void RemoveAsync(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
        }

        public void SetAsync<T>(string cacheKey, T value)
        {
            var options = GetMemoryCacheEntryOptions();

            _memoryCache.Set(cacheKey, value, options);
        }

        private static MemoryCacheEntryOptions GetMemoryCacheEntryOptions()
        {
            return new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(1),
                SlidingExpiration = TimeSpan.FromMinutes(1)
            };
        }
    }
}
