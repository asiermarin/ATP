namespace CachingSimpleExample.Handlers
{
    using System;

    using CachingSimpleExample.Handlers.Abstractions;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class CachingHandler<T> : ICaching<T>
        where T : class
    {
        public IMemoryCache memoryCache;
        private readonly ILogger logger;

        public CachingHandler(
            IMemoryCache memoryCache,
            ILogger logger)
        {
            this.memoryCache = memoryCache;
            this.logger = logger;
        }

        public T GetItemFromCacheAsync(string itemKey, T entity)
        {
            try
            {
                return this.memoryCache.Get<T>(itemKey);
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("get entity", ex));
                return null;
            }
        }

        public bool RemoveItemFromCache(string itemKey, T entity)
        {
            try
            {
                this.memoryCache.Remove(itemKey);
                var result = this.memoryCache.TryGetValue<T>(itemKey, out entity);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("remove entity", ex));
                return false;
            }
        }

        public bool SetItemInCache(string itemKey, T entity)
        {
            try
            {
                var result = this.memoryCache.Set<T>(itemKey, entity);
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("set entity", ex));
                return false;
            }
        }

        public bool SetItemInWithOptions(string itemKey, T entity, MemoryCacheEntryOptions options)
        {
            try
            {
                var result = this.memoryCache.Set<T>(itemKey, entity, options);
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("set entity", ex));
                return false;
            }
        }

        private static string GetErrorMessage(string action, Exception ex)
        {
            return $"Could not {action} entity of type {typeof(T).Name} due to exception: {ex.GetType().Name} - {ex.Message}";
        }
    }
}
