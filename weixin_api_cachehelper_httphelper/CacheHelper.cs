using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;


public class CacheHelper
{
    /// <summary>
    /// 创建缓存项的文件依赖
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="obj">object对象</param>
    /// <param name="fileName">文件绝对路径</param>
    public static void Insert(string key, object obj, string fileName)
    {
        //创建缓存依赖项
        CacheDependency dep = new CacheDependency(fileName);
        //创建缓存
        HttpContext.Current.Cache.Insert(key, obj, dep);
    }

    /// <summary>
    /// 创建缓存项过期
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <param name="obj">object对象</param>
    /// <param name="expires">滑动过期时间(秒)</param>
    public static void Insert(string key, object obj, int expires)
    {
        HttpContext.Current.Cache.Insert(key, obj, null, Cache.NoAbsoluteExpiration,new TimeSpan(0, 0, expires));
    }

    /// <summary>
    /// 获取缓存对象
    /// </summary>
    /// <param name="key">缓存Key</param>
    /// <returns>object对象</returns>
    public static object Get(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }
        return HttpContext.Current.Cache.Get(key);
    }

    /// <summary>
    /// 获取缓存对象
    /// </summary>
    /// <typeparam name="T">T对象</typeparam>
    /// <param name="key">缓存Key</param>
    /// <returns></returns>
    public static T Get<T>(string key)
    {
        object obj = Get(key);
        return obj == null ? default(T) : (T)obj;
    }


    /// <summary>
    /// 设定绝对的过期时间
    /// </summary>
    /// <param name="CacheKey"></param>
    /// <param name="objObject"></param>
    /// <param name="seconds">超过多少秒后过期</param>
    public static void SetCacheDateTime(string CacheKey, object objObject, long Seconds)
    {
        System.Web.Caching.Cache objCache = HttpRuntime.Cache;
        objCache.Insert(CacheKey, objObject, null, System.DateTime.Now.AddSeconds(Seconds), TimeSpan.Zero);
    }
}
