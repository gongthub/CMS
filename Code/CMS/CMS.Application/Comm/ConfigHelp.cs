using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class ConfigHelp
    {
        #region 单例模式创建对象
        //单例模式创建对象
        private static ConfigHelp _configHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        ConfigHelp()
        {
        }

        public static ConfigHelp configHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _configHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _configHelp)
                        {
                            _configHelp = new ConfigHelp();
                        }
                    }
                }
                return _configHelp;
            }
        }
        #endregion

        #region 系统相关
        /// <summary>
        /// 可登录后台域名控制
        /// </summary>
        public string LOGINHOST
        {
            get
            {
                return Code.Configs.GetValue("LoginHost").ToString();
            }
        }
        /// <summary>
        /// 是否启用端口
        /// </summary>
        public bool ISOPENPORT
        {
            get
            {
                bool bIsOpenPort = false;
                bool.TryParse(Code.Configs.GetValue("IsOpenPort").ToString(), out bIsOpenPort);
                return bIsOpenPort;
            }
        }
        /// <summary>
        /// 设置留言间隔时长 单位：秒
        /// </summary>
        public int MESSAGETIME
        {
            get
            {
                int timenum = 0;
                int.TryParse(Code.Configs.GetValue("MessageTime").ToString(), out timenum);
                return timenum;
            }
        }
        #endregion

        #region 上传图片配置
        /// <summary>
        /// 上传图片文件夹
        /// </summary>
        public string UPLOADIMG
        {
            get
            {
                return Code.Configs.GetValue("UploadImg").ToString();
            }
        }
        /// <summary>
        /// 上传图片格式
        /// </summary>
        public string UPLOADIMGFORMAT
        {
            get
            {
                return Code.Configs.GetValue("UploadImgFormat").ToString();
            }
        }
        /// <summary>
        /// 上传图片大小
        /// </summary>
        public string UPLOADIMGSIZE
        {
            get
            {
                return Code.Configs.GetValue("UploadImgSize").ToString();
            }
        }
        #endregion

        #region 上传文件配置
        /// <summary>
        /// 上传文件文件夹
        /// </summary>
        public string UPLOADFILE
        {
            get
            {
                return Code.Configs.GetValue("UploadFile").ToString();
            }
        }
        /// <summary>
        /// 上传文件格式
        /// </summary>
        public string UPLOADFILEFORMAT
        {
            get
            {
                return Code.Configs.GetValue("UploadFileFormat").ToString();
            }
        }
        /// <summary>
        /// 上传文件大小
        /// </summary>
        public string UPLOADFILESIZE
        {
            get
            {
                return Code.Configs.GetValue("UploadFileSize").ToString();
            }
        }
        #endregion

        #region 系统错误页

        /// <summary>
        /// 系统 404 错误页
        /// </summary>
        public string SYSPAGE_NOFIND
        {
            get
            {
                return Code.Configs.GetValue("SysPage_NoFind").ToString();
            }
        }
        /// <summary>
        /// 系统 500 错误页
        /// </summary>
        public string SYSPAGE_ERROR
        {
            get
            {
                return Code.Configs.GetValue("SysPage_Error").ToString();
            }
        }
        /// <summary>
        /// 系统 维护页
        /// </summary>
        public string SYSPAGE_SERVICE
        {
            get
            {
                return Code.Configs.GetValue("SysPage_Service").ToString();
            }
        }
        #endregion

        #region 用户可添加站点数配置

        /// <summary>
        /// 系统用户可添加网站数
        /// </summary>
        public string WEBSITENUM_SYSTEMUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_SystemUser").ToString();
            }
        }

        /// <summary>
        /// 站点用户可添加网站数
        /// </summary>
        public string WEBSITENUM_WEBSITEUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_WebSiteUser").ToString();
            }
        }

        /// <summary>
        /// 注册用户可添加网站数
        /// </summary>
        public string WEBSITENUM_REGISTERUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_RegisterUser").ToString();
            }
        }

        /// <summary>
        /// 普通会员可添加网站数
        /// </summary>
        public string WEBSITENUM_ORDINARYUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_OrdinaryUser").ToString();
            }
        }

        /// <summary>
        /// 金牌会员可添加网站数
        /// </summary>
        public string WEBSITENUM_GOLDUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_GoldUser").ToString();
            }
        }

        /// <summary>
        /// 钻石会员可添加网站数
        /// </summary>
        public string WEBSITENUM_DIAMONDUSER
        {
            get
            {
                return Code.Configs.GetValue("WebSiteNum_DiamondUser").ToString();
            }
        }
        #endregion

        #region 系统请求URl模块黑名单
        /// <summary>
        /// 系统请求URl模块黑名单
        /// </summary>
        public string URLBLACKNAME
        {
            get
            {
                return Code.Configs.GetValue("UrlBlackName").ToString();
            }
        }
        #endregion

        #region 全站搜索相关配置
        /// <summary>
        /// 全站搜索地址
        /// </summary>
        public string WEBSITESEARCHPATH
        {
            get
            {
                return Code.Configs.GetValue("WebSiteSearchPath").ToString();
            }
        }
        #endregion
    }
}
