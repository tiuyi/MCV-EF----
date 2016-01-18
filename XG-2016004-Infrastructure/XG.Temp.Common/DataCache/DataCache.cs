using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace JDF.Finance.Common
{

    /// <summary>
    /// 缓存相关的操作类
    /// 李天平
    /// 2006.4.1
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 获取当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }
        /// <summary>
        /// Get All Cache
        /// 获取当前应用程序指定CacheKey所有的Cache值
        /// </summary>
        /// <returns></returns>
        public static string ShowAllCache()
        {
            string str = " ";
            IDictionaryEnumerator cacheEnumerator = HttpRuntime.Cache.GetEnumerator();

            while (cacheEnumerator.MoveNext())
            {
                str += "缓存名[" + cacheEnumerator.Key + "]<br/>";
            }
            str = "当前总缓存数: " + HttpRuntime.Cache.Count + " <br/> " + str;
            return str;
        }

        /// <summary>
        /// 删除当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static void RemoveCache(string CacheKey)
        {
            HttpRuntime.Cache.Remove(CacheKey);
        }

        /// <summary>
        /// Clear All Cache
        /// 清除所有缓存
        /// </summary>
        public static void RemoveAllCache()
        {
            System.Web.Caching.Cache cache = HttpRuntime.Cache;
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            ArrayList arrayList = new ArrayList();
            while (CacheEnum.MoveNext())
            {
                arrayList.Add(CacheEnum.Key);
            }
            foreach (string key in arrayList)
            {
                cache.Remove(key);
            }
        }

        /// <summary>
        /// 设置当前应用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 到了指定时间就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="absoluteExpiration">绝对超期时间,到了指定时间就自动释放</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 到了指定时间就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="absoluteExpiration">绝对超期时间,到了指定时间就自动释放</param>
        ///         /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, CacheDependency dependencies)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 到了指定时间就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        /// <param name="onUpdateCallback">更新缓存的时候回调的函数</param>

        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemUpdateCallback onUpdateCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration, onUpdateCallback);
        }

        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 到了指定时间就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        /// <param name="slidingExpiration">绝对超期时间，到了指定时间就自动释放</param>
        /// <param name="slidingExpiration">缓存优先级</param>
        /// <param name="onUpdateCallback">删除缓存的时候回调的函数</param>

        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration, priority, onRemoveCallback);
        }


        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 超过指定时间没有访问就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="slidingExpiration">相对超期时间，超过指定时间没有访问就自动释放</param>
        public static void SetCache(string CacheKey, object objObject, TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }
        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 超过指定时间没有访问就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="slidingExpiration">相对超期时间，超过指定时间没有访问就自动释放</param>
        /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        public static void SetCache(string CacheKey, object objObject, TimeSpan slidingExpiration,CacheDependency dependencies)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }


        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 超过指定时间没有访问就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        /// <param name="slidingExpiration">相对超期时间，超过指定时间没有访问就自动释放</param>
        /// <param name="onUpdateCallback">更新缓存的时候回调的函数</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemUpdateCallback onUpdateCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies,Cache.NoAbsoluteExpiration, slidingExpiration, onUpdateCallback);
        }

        /// <summary>
        /// 设置 当前应用程序指定CacheKey的Cache值 超过指定时间没有访问就自动释放
        /// </summary>
        /// <param name="CacheKey">唯一的缓存健值</param>
        /// <param name="objObject">将要存储的值</param>
        /// <param name="dependencies">缓存依赖，如果依赖有变化，将自动移除该缓存</param>
        /// <param name="slidingExpiration">相对超期时间，超过指定时间没有访问就自动释放</param>
        /// <param name="onUpdateCallback">删除缓存的时候回调的函数</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, Cache.NoAbsoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }
    }
}
