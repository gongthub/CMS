using NServiceKit.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMS.Code.Redis
{
    public class RedisHelp
    {

        #region 单例模式创建对象
        //单例模式创建对象
        private static RedisHelp _redisHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        RedisHelp()
        {
        }

        public static RedisHelp redisHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _redisHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _redisHelp)
                        {
                            _redisHelp = new RedisHelp();
                        }
                    }
                }
                return _redisHelp;
            }
        }
        #endregion

        /// <summary>
        /// 获取并且重置缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="query"></param>
        /// <param name="action"></param>
        /// <param name="successHandler"></param>
        /// <param name="errorHandler"></param>
        /// <returns></returns>
        public bool WatchUpdate<T>(string key, Func<bool> query, Func<T, bool> action, Func<T, bool> successHandler, Func<T, bool> errorHandler)
        {
            int count = 0;
            int limit = 2;
            T cacheValue = default(T);
            while (count < limit)
            {
                count++;
                using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
                {
                    redisClient.Watch(key);

                    cacheValue = redisClient.Get<T>(key);

                    if (cacheValue == null)
                    {
                        if (query == null)
                        {
                            return false;
                        }
                        if (!query())
                        {
                            return false;
                        }
                        continue;
                    }
                    bool result = action(cacheValue);
                    if (!result)
                    {
                        return false;
                    }

                    using (var trans = redisClient.CreateTransaction())
                    {
                        trans.QueueCommand((x) => x.Set(key, cacheValue));
                        if (trans.Commit())
                        {
                            if (successHandler != null)
                            {
                                return successHandler(cacheValue);
                            }
                            return true;
                        }
                    }
                }
            }
            if (count == limit)
            {
                LogFactory.GetLogger(this.GetType()).Info(string.Format("WatchUpdate重试次数超过限制,参数：key:{0},query:{1},action:{2},FunName:{3}",
                                                 key, query.ToString(), action.ToString(), action.Method.Name));
                //logger.Info(string.Format("WatchUpdate重试次数超过限制,参数：key:{0},query:{1},action:{2},FunName:{3}",
                //                                 key, query.ToString(), action.ToString(), action.Method.Name), "WatchUpdate");
                Thread.Sleep(5);
            }
            if (errorHandler != null)
            {
                return errorHandler(cacheValue);
            }
            return false;
        }

        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        public bool AddCache<T>(string key, T value)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Add(key, value);
            }
        }

        /// <summary>
        /// 添加缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiration"></param>
        /// <returns></returns>
        public bool AddCache<T>(string key, T value, DateTime expireTime)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Add(key, value, expireTime);
            }
        }
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool RemoveCache(string key)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Remove(key);
            }
        }

        /// <summary>
        /// 删除集合的Key的值
        /// </summary>
        /// <param name="keys"></param>
        public void RemoveAll(IEnumerable<string> keys)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                redisClient.RemoveAll(keys);
            }
        }

        /// <summary>
        /// 获取多个Key的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.GetAll<T>(keys);
            }
        }

        /// <summary>
        /// 重置缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetCache<T>(string key, T value)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Set(key, value);
            }
        }

        /// <summary>
        /// 重置缓存带过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetCacheExp<T>(string key, T value, DateTime expireTime)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Set(key, value, expireTime);
            }
        }

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T GetCache<T>(string key)
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.Get<T>(key);
            }
        }

        /// <summary>
        /// 获取缓存项
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<string> GetAllKey()
        {
            using (IRedisClient redisClient = RedisProvider.prcm.GetClient())
            {
                return redisClient.GetAllKeys();
            }
        }

    }
}
