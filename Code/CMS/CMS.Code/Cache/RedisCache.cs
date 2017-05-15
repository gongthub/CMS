using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class RedisCache : ICache
    {
        public T GetCache<T>(string cacheKey) where T : class
        {
            throw new NotImplementedException();
        }

        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            throw new NotImplementedException();
        }

        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            throw new NotImplementedException();
        }

        public void RemoveCache(string cacheKey)
        {
            throw new NotImplementedException();
        }

        public void RemoveCache()
        {
            throw new NotImplementedException();
        }
    }
}
