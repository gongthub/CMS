using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Configuration;
using NServiceKit.Redis;

namespace CMS.Code.Redis
{
    /// <summary>
    /// Redis配置
    /// </summary>
    public class RedisProvider
    {

        private static string READWRITEHOSTS = "ReadWriteHosts";
        private static string READONLYHOSTS = "ReadOnlyHosts";
        private static string MAXWRITEPLLOSIZE = "MaxWritePoolSize";
        private static string MAXREADPLLOSIZE = "MaxReadPoolSize";
        private static string CONNECTTIMEOUT = "ConnectTimeout";

        #region 获取配置节 
        /// <summary>
        /// 主IP端口
        /// </summary>
        private static List<string> ResReadWriteHosts
        {
            get
            {
                string vals = Configs.GetValue(READWRITEHOSTS);
                return vals.Split(',').ToList();
            }
        }
        /// <summary>
        /// 从集群IP端口
        /// </summary>
        private static List<string> ResReadOnlyHosts
        {
            get
            {
                string vals = Configs.GetValue(READONLYHOSTS);
                return vals.Split(',').ToList();
            }
        }

        /// <summary>
        /// 最大写连接池数量
        /// </summary>
        private static int ResMaxWritePoolSize { get { return Configs.GetValue(MAXWRITEPLLOSIZE).ToInt(); } }
        /// <summary>
        /// 最大读连接池数量
        /// </summary>
        private static int ResMaxReadPoolSize { get { return Configs.GetValue(MAXREADPLLOSIZE).ToInt(); } }
        /// <summary>
        /// 连接超时时间
        /// </summary>
        private static int ResConnectTimeout { get { return Configs.GetValue(CONNECTTIMEOUT).ToInt(); } }

        //private readonly static Lazy<ICacheProvider> redisClient = new Lazy<ICacheProvider>(() => ObjectContainer.Instance.GetService<ICacheProvider>(), LazyThreadSafetyMode.ExecutionAndPublication);

        ///// <summary>
        ///// mem缓存时间
        ///// </summary>
        //protected const int defaultCacheExpiration = 60 * 60 * 2;

        private static ConcurrentDictionary<Type, bool> atrrProtobufCache = new ConcurrentDictionary<Type, bool>();

        #region 连接池
        public static PooledRedisClientManager prcm = CreateManager();
        private static PooledRedisClientManager CreateManager()//string[] readWriteHosts, string[] readOnlyHosts
        {
            // 读写分离，均衡负载 
            PooledRedisClientManager prcm = new PooledRedisClientManager(ResReadWriteHosts, ResReadOnlyHosts,
                new RedisClientManagerConfig
                {
                    MaxWritePoolSize = ResMaxWritePoolSize,
                    MaxReadPoolSize = ResMaxReadPoolSize,
                    AutoStart = true
                })
            {
                ConnectTimeout = ResConnectTimeout
            };
            return prcm;
        }

        #endregion

        #endregion

    }
}
