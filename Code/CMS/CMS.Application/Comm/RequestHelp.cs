using CMS.Code;
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
            //string url = context.Request.Url.AbsolutePath; 
            //string urlPath = context.Request.Url.GetLeftPart(UriPartial.Authority);

            string urlHost = context.Request.Url.Host;
            string urlRaw = context.Request.RawUrl.ToString();
            if (!Common.IsBlackName(urlRaw))
            {
                if (Common.IsExistExtended(urlRaw) == false && !Common.IsExistUrlGuid(urlRaw))
                {
                    //判断是否后台url 并且 扩展名是否需要处理
                    if (!TempHelp.tempHelp.IsWebSite(urlHost, urlRaw))
                    {
                        return;
                    }
                }
                else
                {
                    string htmls = TempHelp.tempHelp.GetHtmlByUrl(urlHost, urlRaw);
                    context.Response.Write(htmls);
                    context.Response.End();
                }
            }
        }
        #endregion
         
    }
}
