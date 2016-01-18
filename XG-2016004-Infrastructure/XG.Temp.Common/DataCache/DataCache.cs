using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace JDF.Finance.Common
{

    /// <summary>
    /// ������صĲ�����
    /// ����ƽ
    /// 2006.4.1
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// ��ȡ��ǰӦ�ó���ָ��CacheKey��Cacheֵ
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
        /// ��ȡ��ǰӦ�ó���ָ��CacheKey���е�Cacheֵ
        /// </summary>
        /// <returns></returns>
        public static string ShowAllCache()
        {
            string str = " ";
            IDictionaryEnumerator cacheEnumerator = HttpRuntime.Cache.GetEnumerator();

            while (cacheEnumerator.MoveNext())
            {
                str += "������[" + cacheEnumerator.Key + "]<br/>";
            }
            str = "��ǰ�ܻ�����: " + HttpRuntime.Cache.Count + " <br/> " + str;
            return str;
        }

        /// <summary>
        /// ɾ����ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static void RemoveCache(string CacheKey)
        {
            HttpRuntime.Cache.Remove(CacheKey);
        }

        /// <summary>
        /// Clear All Cache
        /// ������л���
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
        /// ���õ�ǰӦ�ó���ָ��CacheKey��Cacheֵ
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ����Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="absoluteExpiration">���Գ���ʱ��,����ָ��ʱ����Զ��ͷ�</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ����Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="absoluteExpiration">���Գ���ʱ��,����ָ��ʱ����Զ��ͷ�</param>
        ///         /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        public static void SetCache(string CacheKey, object objObject, DateTime absoluteExpiration, CacheDependency dependencies)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration);
        }

        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ����Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        /// <param name="onUpdateCallback">���»����ʱ��ص��ĺ���</param>

        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemUpdateCallback onUpdateCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration, onUpdateCallback);
        }

        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ����Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        /// <param name="slidingExpiration">���Գ���ʱ�䣬����ָ��ʱ����Զ��ͷ�</param>
        /// <param name="slidingExpiration">�������ȼ�</param>
        /// <param name="onUpdateCallback">ɾ�������ʱ��ص��ĺ���</param>

        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, DateTime absoluteExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, absoluteExpiration, Cache.NoSlidingExpiration, priority, onRemoveCallback);
        }


        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ��û�з��ʾ��Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="slidingExpiration">��Գ���ʱ�䣬����ָ��ʱ��û�з��ʾ��Զ��ͷ�</param>
        public static void SetCache(string CacheKey, object objObject, TimeSpan slidingExpiration)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, null, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }
        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ��û�з��ʾ��Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="slidingExpiration">��Գ���ʱ�䣬����ָ��ʱ��û�з��ʾ��Զ��ͷ�</param>
        /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        public static void SetCache(string CacheKey, object objObject, TimeSpan slidingExpiration,CacheDependency dependencies)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, System.Web.Caching.Cache.NoAbsoluteExpiration, slidingExpiration);
        }


        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ��û�з��ʾ��Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        /// <param name="slidingExpiration">��Գ���ʱ�䣬����ָ��ʱ��û�з��ʾ��Զ��ͷ�</param>
        /// <param name="onUpdateCallback">���»����ʱ��ص��ĺ���</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemUpdateCallback onUpdateCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies,Cache.NoAbsoluteExpiration, slidingExpiration, onUpdateCallback);
        }

        /// <summary>
        /// ���� ��ǰӦ�ó���ָ��CacheKey��Cacheֵ ����ָ��ʱ��û�з��ʾ��Զ��ͷ�
        /// </summary>
        /// <param name="CacheKey">Ψһ�Ļ��潡ֵ</param>
        /// <param name="objObject">��Ҫ�洢��ֵ</param>
        /// <param name="dependencies">������������������б仯�����Զ��Ƴ��û���</param>
        /// <param name="slidingExpiration">��Գ���ʱ�䣬����ָ��ʱ��û�з��ʾ��Զ��ͷ�</param>
        /// <param name="onUpdateCallback">ɾ�������ʱ��ص��ĺ���</param>
        public static void SetCache(string CacheKey, object objObject, CacheDependency dependencies, TimeSpan slidingExpiration, CacheItemPriority priority, CacheItemRemovedCallback onRemoveCallback)
        {
            Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject, dependencies, Cache.NoAbsoluteExpiration, slidingExpiration, priority, onRemoveCallback);
        }
    }
}
