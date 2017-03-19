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
    }
}
