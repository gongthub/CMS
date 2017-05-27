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
        /// 字段验证类型
        /// </summary>
        public enum VerifyType
        {
            [Description("非Null")]
            IsNull = 0,
            [Description("非Null或者空")]
            IsNullOrEmpty = 1,
            [Description("数字有效性")]
            IsInt = 2,
            [Description("身份证有效性")]
            IsIdCard = 3,
            [Description("邮箱有效性")]
            IsEmail = 4,
            [Description("手机号有效性")]
            IsPhone = 5,
            [Description("Url有效性")]
            IsUrl = 6,
            [Description("IP有效性")]
            IsIP = 7,
            [Description("域名有效性")]
            IsDomain = 8,
            [Description("GUID有效性")]
            IsGuid = 9,
            [Description("日期有效性")]
            IsDate = 10,
            [Description("可空域名有效性")]
            IsDomainOrEmpty = 11
        }
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
        /// <summary>
        /// 系统缓存类型
        /// </summary>
        public enum SysCacheType
        {
            [Description("Cache")]
            Cache = 0,
            [Description("Redis")]
            Redis = 1
        }
        /// <summary>
        /// 模板类型
        /// </summary>
        public enum TempletType
        {
            [Description("Common")]
            Common = 0,
            [Description("Search")]
            Search = 1
        }
    }
}
