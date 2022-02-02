namespace Simple.Memory.Cache.Infra.Cache
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string cacheKey);

        void SetAsync<T>(string cacheKey, T value);

        void RemoveAsync(string cacheKey);
    }
}
