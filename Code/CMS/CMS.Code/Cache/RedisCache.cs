using CMS.Code.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class RedisCache : ICache
    {

        public List<string> GetAllKey()
        { 
            List<string> allKeys = RedisHelp.redisHelp.GetAllKey();
            return allKeys;
        }
        public T GetCache<T>(string cacheKey) where T : class
        {
            return RedisHelp.redisHelp.GetCache<T>(cacheKey);
        }

        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            RedisHelp.redisHelp.SetCache<T>(cacheKey, value);
        }

        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            RedisHelp.redisHelp.SetCacheExp<T>(cacheKey, value, expireTime);
        }

        public void RemoveCache(string cacheKey)
        {
            RedisHelp.redisHelp.RemoveCache(cacheKey);
        }

        public void RemoveCache()
        {
            List<string> allKeys = RedisHelp.redisHelp.GetAllKey();
            RedisHelp.redisHelp.RemoveAll(allKeys);
        }

    }
}
