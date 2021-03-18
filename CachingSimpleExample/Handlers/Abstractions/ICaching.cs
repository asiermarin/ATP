namespace CachingSimpleExample.Handlers.Abstractions
{
    using Microsoft.Extensions.Caching.Memory;

    public interface ICaching<T>
    {
        T GetItemFromCacheAsync(string itemKey, T entity);

        bool RemoveItemFromCache(string itemKey, T entity);

        bool SetItemInCache(string itemKey, T entity);

        bool SetItemInWithOptions(string itemKey, T entity, MemoryCacheEntryOptions options);
    }
}
