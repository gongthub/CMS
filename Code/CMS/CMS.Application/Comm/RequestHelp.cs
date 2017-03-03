using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            string urlHost = context.Request.Url.GetLeftPart(UriPartial.Authority);
            string urlRaw = context.Request.RawUrl.ToString();
            if (!TempHelp.tempHelp.IsWebSite(urlRaw))
            {
                return;
            }
            string htmls = TempHelp.tempHelp.GetHtmlByUrl(urlRaw);
            context.Response.Write(htmls);
            context.Response.End();
        } 
        #endregion


    }
}
