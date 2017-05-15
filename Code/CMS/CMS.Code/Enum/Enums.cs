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
        /// <summary>
        /// 日志类型
        /// </summary>
        public enum DbLogType
        {
            [Description("其他")]
            Other = 0,
            [Description("登录")]
            Login = 1,
            [Description("退出")]
            Exit = 2,
            [Description("访问")]
            Visit = 3,
            [Description("新增")]
            Create = 4,
            [Description("删除")]
            Delete = 5,
            [Description("修改")]
            Update = 6,
            [Description("提交")]
            Submit = 7,
            [Description("异常")]
            Exception = 8,
        }

        /// <summary>
        /// CMS模块类型
        /// </summary>
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
        /// <summary>
        /// 上传文件模块
        /// </summary>
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

        /// <summary>
        /// 登陆提供者模式
        /// </summary>
        public enum LoginProvider
        {
            [Description("Session")]
            Session = 0,
            [Description("Cookie")]
            Cookie = 1,
            [Description("Redis")]
            Redis = 2
        }
    }
}
