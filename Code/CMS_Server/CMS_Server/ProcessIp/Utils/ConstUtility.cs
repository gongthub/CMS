using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessIp.Utils
{
    public class ConstUtility
    {
        #region 属性
        /// <summary>
        /// 任务组接口
        /// </summary>
        private static DJS.SDK.IConfigMgr iConfigMgr = Achieve.iConfigMgr;

        #endregion

        #region 构造函数

        public ConstUtility()
        {
            iConfigMgr = Achieve.iConfigMgr;

            DbType = iConfigMgr.GetConfig("DbType");
            IDBRepository = iConfigMgr.GetConfig("IDBRepository");
            AppCode = iConfigMgr.GetConfig("AppCode");
        }

        #endregion

        /// <summary>
        /// mysql sqlserver
        /// </summary>
        public static string DbType = "";
        public static string IDBRepository = "";
        public static string AppCode = "";
    }
}
