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

        /// <summary>
        /// 上传图片文件夹
        /// </summary>
        public string UPLOADIMG
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadImg"].ToString();
            }
        }
        /// <summary>
        /// 上传图片格式
        /// </summary>
        public string UPLOADIMGFORMAT
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadImgFormat"].ToString();
            }
        }
        /// <summary>
        /// 上传图片大小
        /// </summary>
        public string UPLOADIMGSIZE
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadImgSize"].ToString();
            }
        }
    }
}
