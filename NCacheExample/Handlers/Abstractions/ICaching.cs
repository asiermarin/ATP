namespace NCacheExample.Handlers.Abstractions
{
    using Microsoft.Extensions.Caching.Memory;
    using System.Collections.Generic;

    public interface ICaching<T>
    {
        List<T> GetAllFromCache();

        T GetFromCache(string itemKey, T entity);

        bool RemoveFromCache(string itemKey, T entity);

        bool SetInCache(string itemKey, T entity);

        bool SetInCacheWithOptions(string itemKey, T entity, MemoryCacheEntryOptions options);
    }
}
