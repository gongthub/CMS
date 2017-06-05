using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class CacheFactory
    {
        private readonly string SYSCACHETYPE = Configs.GetValue("Sys_CacheType");
        private CMS.Code.Enums.SysCacheType SYSCACHETYPE_ENUM;


        #region 单例模式创建对象
        //单例模式创建对象
        private static CacheFactory _cacheFactory = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        CacheFactory()
        {
            int iSysCacheType = 0;
            if (int.TryParse(SYSCACHETYPE, out iSysCacheType))
            {
                SYSCACHETYPE_ENUM = (CMS.Code.Enums.SysCacheType)iSysCacheType;
            }
        }

        public static CacheFactory cacheFactory
        {
            get
            {
                // Double-Checked Locking
                if (null == _cacheFactory)
                {
                    lock (SynObject)
                    {
                        if (null == _cacheFactory)
                        {
                            _cacheFactory = new CacheFactory();
                        }
                    }
                }
                return _cacheFactory;
            }
        }
        #endregion
        public ICache Cache()
        {
            ICache icache = new Cache();
            switch (SYSCACHETYPE_ENUM)
            {
                case CMS.Code.Enums.SysCacheType.Cache:
                    icache = new Cache();
                    break;
                case CMS.Code.Enums.SysCacheType.Redis:
                    icache = new RedisCache();
                    break;
            }
            return icache;
        }
    }
}
