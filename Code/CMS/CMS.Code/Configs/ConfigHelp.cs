using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
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
        /// 是否处理url
        /// </summary>
        public bool ISPROREQUEST
        {
            get
            {
                bool IsProRequest = false;
                bool.TryParse(Code.Configs.GetValue("IsProRequest").ToString(), out IsProRequest);
                return IsProRequest;
            }
        }
        /// <summary>
        /// 是否记录请求记录
        /// </summary>
        public bool ISPROREQUESTLOG
        {
            get
            {
                bool IsProRequestLog = false;
                bool.TryParse(Code.Configs.GetValue("IsProRequestLog").ToString(), out IsProRequestLog);
                return IsProRequestLog;
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
        /// <summary>
        /// 登陆用户超时时间 分钟
        /// </summary>
        public int USERLOGINTIMEOUT
        {
            get
            {
                int UserLoginTimeOut = 0;
                int.TryParse(Code.Configs.GetValue("UserLoginTimeOut").ToString(), out UserLoginTimeOut);
                return UserLoginTimeOut;
            }
        }

        /// <summary>
        /// 系统模板路径
        /// </summary>
        public string HTMLSYSCONTENTSRC
        {
            get
            {
                return Code.Configs.GetValue("htmlSysContentSrc").ToString();
            }
        }
        /// <summary>
        /// 系统删除文件保存路径
        /// </summary>
        public string SYSFILEFORDEL
        {
            get
            {
                return Code.Configs.GetValue("SysFileForDel").ToString();
            }
        }
        /// <summary>
        /// 系统数据库类型
        /// </summary>
        public string SYSDBTYPE
        {
            get
            {
                return Code.Configs.GetValue("Sys_DBType").ToString();
            }
        }
        /// <summary>
        /// 网站空间默认大小 单位 M
        /// </summary>
        public decimal WEBSITESIZE
        {
            get
            {
                decimal WebSiteSize = 0;
                decimal.TryParse(Code.Configs.GetValue("WebSiteSize").ToString(), out WebSiteSize);
                return WebSiteSize;
            }
        }
        /// <summary>
        /// PanGu配置路径
        /// </summary>
        public string PANGUXML
        {
            get
            {
                return Code.Configs.GetValue("PanguXml").ToString();
            }
        }
        /// <summary>
        /// PanGu字典路径
        /// </summary>
        public string PANGUDICPATH
        {
            get
            {
                return Code.Configs.GetValue("PanguDicPath").ToString();
            }
        }
        /// <summary>
        /// Lucence索引路径
        /// </summary>
        public string LUCENCEINDEXPATH
        {
            get
            {
                return Code.Configs.GetValue("LucenceIndexPath").ToString();
            }
        }
        /// <summary>
        /// 静态页面缓存路径
        /// </summary>
        public string HTMLSRC
        {
            get
            {
                return Code.Configs.GetValue("htmlSrc").ToString();
            }
        }
        /// <summary>
        /// 网站资源文件路径
        /// </summary>
        public string HTMLCONTENTSRC
        {
            get
            {
                return Code.Configs.GetValue("htmlContentSrc").ToString();
            }
        }
        /// <summary>
        /// 网站根目录资源文件路径
        /// </summary>
        public string HTMLROOTCONTENTSRC
        {
            get
            {
                return Code.Configs.GetValue("htmlRootContentSrc").ToString();
            }
        }
        /// <summary>
        /// 静态页面相对路径
        /// </summary>
        public string HTMLSRCPATH
        {
            get
            {
                return Code.Configs.GetValue("htmlSrcPath").ToString();
            }
        }

        /// <summary>
        /// 系统超级用户用户名
        /// </summary>
        public string SYSTEMADMINUSERNAME
        {
            get
            {
                return Code.Configs.GetValue("SystemUserName").ToString();
            }
        }
        /// <summary>
        /// 系统超级用户密码
        /// </summary>
        public string SYSTEMADMINUSERPASSWORD
        {
            get
            {
                return Code.Configs.GetValue("SystemUserPassword").ToString();
            }
        }
        /// <summary>
        /// 系统url前缀
        /// </summary>
        public string WEBURLHTTP
        {
            get
            {
                return Code.Configs.GetValue("WebUrlHttp").ToString();
            }
        }

        /// <summary>
        /// 是否压缩上传图片
        /// </summary>
        public bool ISCOMPRESSIONIMG
        {
            get
            {
                bool IsCompressionImg = false;
                bool.TryParse(Code.Configs.GetValue("IsCompressionImg").ToString(), out IsCompressionImg);
                return IsCompressionImg;
            }
        }

        /// <summary>
        /// 压缩上传图片 压缩比 1-100
        /// </summary>
        public int COMPRESSIONIMGFLAG
        {
            get
            {
                int CompressionImgFlag = 0;
                int.TryParse(Code.Configs.GetValue("CompressionImgFlag").ToString(), out CompressionImgFlag);
                return CompressionImgFlag;
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
