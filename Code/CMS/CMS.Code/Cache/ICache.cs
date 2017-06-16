using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public interface ICache
    {
        List<string> GetAllKey();
        T GetCache<T>(string cacheKey) where T : class;
        void WriteCache<T>(T value, string cacheKey) where T : class;
        void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class;
        void RemoveCache(string cacheKey);
        void RemoveCache();
    }
}
