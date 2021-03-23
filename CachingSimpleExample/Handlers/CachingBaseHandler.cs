namespace CachingSimpleExample.Handlers
{
    using System;
    using CachingSimpleExample.Handlers.Abstractions;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Logging;

    public class CachingBaseHandler<TKey, TValue> : ICachingBase<TKey, TValue>
        where TValue : class
    {
        public IMemoryCache memoryCache;
        private readonly ILogger logger;

        public CachingBaseHandler(
            IMemoryCache memoryCache,
            ILoggerFactory loggerFactory)
        {
            this.memoryCache = memoryCache;
            this.logger = loggerFactory.CreateLogger(typeof(CachingBaseHandler<TKey, TValue>).Name);
        }

        public bool RemoveFromCache(TKey key, TValue value)
        {
            try
            {
                this.memoryCache.Remove(key);
                var result = this.memoryCache.TryGetValue<TValue>(key, out value);
                return result == true ? false : true;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage($"remove {typeof(TValue).Name} item", ex));
                return false;
            }
        }

        public bool UpdateInCache(TKey key, TValue value)
        {
            try
            {
                var getResult = GetFromCache(key);

                if (getResult != null)
                {
                    var result = this.memoryCache.Set<TValue>(key, value);
                    return result != null ? true : false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage($"set {typeof(TValue).Name} item", ex));
                return false;
            }
        }

        public TValue GetFromCache(TKey key)
        {
            try
            {
                return this.memoryCache.Get<TValue>(key);
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage($"get {typeof(TValue).Name} item", ex));
                return null;
            }
        }

        /*
         * Set a new object o update with the same Key
         */

        public bool SetOrUpdateInCache(TKey key, TValue value)
        {
            try
            {
                var result = this.memoryCache.Set<TValue>(key, value);
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage($"set {typeof(TValue).Name} item", ex));
                return false;
            }
        }

        public bool SetOrUpdateInCacheWithOptions(TKey key, TValue value, MemoryCacheEntryOptions options)
        {
            try
            {
                var result = this.memoryCache.Set<TValue>(key, value, options);
                return result != null ? true : false;
            }
            catch (Exception ex)
            {
                this.logger.LogError(GetErrorMessage($"set {typeof(TValue).Name} item", ex));
                return false;
            }
        }

        private static string GetErrorMessage(string action, Exception ex)
        {
            return $"Could not {action} entity of type {typeof(TValue).Name} " +
                $"with key {typeof(TKey).Name} due to exception: {ex.GetType().Name} - {ex.Message}";
        }
    }
}