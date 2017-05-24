using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class RequestHelp
    {
        #region 单例模式创建对象
        //单例模式创建对象
        private static RequestHelp _requestHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        RequestHelp()
        {
        }

        public static RequestHelp requestHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _requestHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _requestHelp)
                        {
                            _requestHelp = new RequestHelp();
                        }
                    }
                }
                return _requestHelp;
            }
        }
        #endregion
        
        #region 处理请求 +void InitRequest(System.Web.HttpContext context)
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void InitRequest(System.Web.HttpContext context)
        {
            string urlHost = context.Request.Url.Host;
            string urlRaw = context.Request.RawUrl.ToString();
            urlRaw = context.Server.UrlDecode(urlRaw);
            if (IsProcess(urlHost, urlRaw))
            {
                string htmls = TempHelp.tempHelp.GetHtmlByUrl(urlHost, urlRaw);
                context.Response.Write(htmls);
                //插入访问日志
                SysPageHelp.sysPageHelp.CreateAccessLog(context, true);
                context.Response.End();
            }
        }
        #endregion

        #region 判断是否需要处理

        /// <summary>
        /// 是否需要处理
        /// </summary>
        /// <returns></returns>
        private bool IsProcess(string urlHost, string urlRaw)
        {
            bool bState = false;
            if (!Common.IsBlackName(urlRaw) && !Common.IsSystemHaveUrlName(urlRaw) && IsWebSiteUrl(urlHost, urlRaw))
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 判断是否为前台
        /// </summary>
        /// <returns></returns>
        private bool IsWebSiteUrl(string urlhost, string urlRaw)
        {
            bool bState = false;
            //判断是否前台url
            if (TempHelp.tempHelp.IsWebSite(urlhost, urlRaw) && Common.IsExistExtended(urlRaw))
            {
                bState = true;
            }
            else
            {
                if (Common.IsExistExtended(urlRaw))
                {
                    bState = true;
                }
                else
                {
                    if (Common.IsExistUrlGuid(urlRaw))
                    {
                        bState = true;
                    }
                }
            }
            if (!bState)
                bState = Common.IsSearchForUrl(urlRaw);
            return bState;
        }
        #endregion
    }
}
