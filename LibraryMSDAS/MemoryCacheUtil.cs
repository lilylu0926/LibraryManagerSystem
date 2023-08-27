using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// Memory cache until based on MemoryCache
    /// </summary>
    public class MemoryCacheUtil
    {
        private static readonly Object _locker = new object(), _locker2 = new object();

        /// <summary>
        /// get cache item, return null if not existed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetCacheItem<T>(String key)
        {
            try
            {
                return (T)MemoryCache.Default[key];
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// if contains the cache item with the given key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Contains(string key)
        {
            return MemoryCache.Default.Contains(key);
        }

        /// <summary>
        /// get cache item; create cache item if not existed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="slidingExpiration"></param>
        /// <param name="absoluteExpiration"></param>
        /// <returns></returns>
        public static T GetOrAddCacheItem<T>(String key, Func<T> cachePopulate, TimeSpan? slidingExpiration = null, DateTime? absoluteExpiration = null)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");
            if (slidingExpiration == null && absoluteExpiration == null) throw new ArgumentException("Either a sliding expiration or absolute must be provided");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        T cacheValue = cachePopulate();
                        if (!typeof(T).IsValueType && ((object)cacheValue) == null) //no cache for null reference type
                        {
                            return cacheValue;
                        }

                        var item = new CacheItem(key, cacheValue);
                        var policy = CreatePolicy(slidingExpiration, absoluteExpiration);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// get cache item; create cache item if not existed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cachePopulate"></param>
        /// <param name="dependencyFilePath"></param>
        /// <returns></returns>
        public static T GetOrAddCacheItem<T>(String key, Func<T> cachePopulate, string dependencyFilePath)
        {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentException("Invalid cache key");
            if (cachePopulate == null) throw new ArgumentNullException("cachePopulate");

            if (MemoryCache.Default[key] == null)
            {
                lock (_locker2)
                {
                    if (MemoryCache.Default[key] == null)
                    {
                        T cacheValue = cachePopulate();
                        if (!typeof(T).IsValueType && ((object)cacheValue) == null) //no cache for null reference type
                        {
                            return cacheValue;
                        }

                        var item = new CacheItem(key, cacheValue);
                        var policy = CreatePolicy(dependencyFilePath);

                        MemoryCache.Default.Add(item, policy);
                    }
                }
            }

            return (T)MemoryCache.Default[key];
        }

        /// <summary>
        /// Remove the cache item with given key
        /// </summary>
        /// <param name="key"></param>
        public static void RemoveCacheItem(string key)
        {
            try
            {
                MemoryCache.Default.Remove(key);
            }
            catch
            { }
        }

        private static CacheItemPolicy CreatePolicy(TimeSpan? slidingExpiration, DateTime? absoluteExpiration)
        {
            var policy = new CacheItemPolicy();

            if (absoluteExpiration.HasValue)
            {
                policy.AbsoluteExpiration = absoluteExpiration.Value;
            }
            else if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            policy.Priority = CacheItemPriority.Default;

            return policy;
        }

        private static CacheItemPolicy CreatePolicy(string filePath)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { filePath }));
            policy.Priority = CacheItemPriority.Default;
            return policy;
        }
    }
}
