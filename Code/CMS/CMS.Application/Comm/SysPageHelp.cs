using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class SysPageHelp
    {
        #region 单例模式创建对象
        //单例模式创建对象
        private static SysPageHelp _sysPageHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        SysPageHelp()
        {
        }

        public static SysPageHelp sysPageHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _sysPageHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _sysPageHelp)
                        {
                            _sysPageHelp = new SysPageHelp();
                        }
                    }
                }
                return _sysPageHelp;
            }
        }
        #endregion

        /// <summary>
        /// 获取404错误页
        /// </summary>
        /// <returns></returns>
        public string GetNoFindPage()
        {
            string strHtmls = string.Empty;

            strHtmls = Code.FileHelper.ReadTxtFile(ConfigHelp.configHelp.SYSPAGE_NOFIND, true);

            return strHtmls;
        }
    }
}
