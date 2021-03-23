namespace CachingSimpleExample.Handlers.Abstractions
{
    using Microsoft.Extensions.Caching.Memory;

    public interface ICachingBase<TKey, TValue>
    {
        TValue GetFromCache(TKey key);

        bool RemoveFromCache(TKey key, TValue value);

        bool UpdateInCache(TKey key, TValue value);

        bool SetOrUpdateInCache(TKey key, TValue value);

        bool SetOrUpdateInCacheWithOptions(TKey key, TValue value, MemoryCacheEntryOptions options);
    }
}
