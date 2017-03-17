using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class Enums
    {
        public enum ModuleType
        {
            [Description("导航")]
            Navigation = 0,
            [Description("内容")]
            Content = 1,
            [Description("列表")]
            List = 2,
            [Description("连接")]
            Link = 3
        }
        public enum UpFileModule
        {
            [Description("C_Contents")]
            Contents = 0,
            [Description("Sys_WebSites")]
            WebSites = 1,

        }
        /// <summary>
        /// 用户级别
        /// </summary>
        public enum UserLevel
        {
            [Description("系统用户")]
            SystemUser = 0,
            [Description("站点用户")]
            WebSiteUser = 1,
            [Description("注册用户")]
            RegisterUser = 2,
            [Description("普通会员")]
            OrdinaryUser = 3,
            [Description("金牌会员")]
            GoldUser = 4,
            [Description("钻石会员")]
            DiamondUser = 5,
        }
    }
}
