namespace CachingSimpleExample.Handlers
{
    using System;
    using System.Collections.Generic;
    using CachingSimpleExample.Handlers.Abstractions;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class CachingHandler<T> : ICaching<T>
        where T : class
    {
        public IMemoryCache memoryCache;
        public List<string> keysList;
        private readonly ILogger logger;

        public CachingHandler(
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
        {
            this.memoryCache = memoryCache;
            this.keysList = new List<string>();
            this.logger = loggerFactory.CreateLogger(typeof(CachingHandler<T>).Name);
        }

        public List<T> GetAllFromCache()
        {
            var entitiesList = new List<T>();
            foreach (var key in this.keysList)
            {
                entitiesList.Add(GetFromCache(key, null));
            }

            return entitiesList;
        }

        public T GetFromCache(string itemKey, T entity)
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

        public bool RemoveFromCache(string itemKey, T entity)
        {
            try
            {
                this.memoryCache.Remove(itemKey);
                this.keysList.Remove(itemKey);
                var result = this.memoryCache.TryGetValue<T>(itemKey, out entity);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("remove entity", ex));
                return false;
            }
        }

        public bool SetInCache(string itemKey, T entity)
        {
            try
            {
                var result = this.memoryCache.Set<T>(itemKey, entity);
                this.keysList.Add(itemKey);
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage("set entity", ex));
                return false;
            }
        }

        public bool SetInCacheWithOptions(string itemKey, T entity, MemoryCacheEntryOptions options)
        {
            try
            {
                var result = this.memoryCache.Set<T>(itemKey, entity, options);
                this.keysList.Add(itemKey);
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
