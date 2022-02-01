using Microsoft.Extensions.Caching.Memory;

namespace Simple.Memory.Cache.Infra.Cache
{
    public interface ICacheService<T>
    {
        Task<T> GetAsync(string cacheKey);

        void SetAsync(string cacheKey, T value, MemoryCacheEntryOptions memoryCacheEntryOptions);

        void RemoveAsync(string cacheKey);
    }
}
