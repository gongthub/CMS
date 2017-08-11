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
        private static string LOGINHOSTCONFIGALLMARK = "*";
        private static string LOGINURLMARK = "/Login/Index";
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
            string htmls = string.Empty;
            try
            {
                string urlHost = GetHost(context);
                string urlRaw = context.Request.RawUrl.ToString();
                urlRaw = context.Server.UrlDecode(urlRaw);
                if (IsLoginHost(context) && Code.ConfigHelp.configHelp.LOGINHOST != LOGINHOSTCONFIGALLMARK)
                {
                    if (string.IsNullOrEmpty(urlRaw) || urlRaw == "/")
                    {
                        context.Response.Clear();
                        context.Response.Redirect("/Login/Index", false);
                        context.ApplicationInstance.CompleteRequest();
                    }
                }
                else
                {
                    if (IsProcess(urlHost, urlRaw))
                    {
                        context.Response.Clear();
                        bool isNoFind = false;
                        htmls = TempHelp.tempHelp.GetHtmlByUrl(urlHost, urlRaw, out isNoFind);
                        if (isNoFind)
                        {
                            context.Response.StatusCode = 404;
                        }
                        else
                        {
                            context.Response.Write(htmls);
                        }
                        //插入访问日志
                        SysPageHelp.sysPageHelp.CreateAccessLog(context, true);
                        context.ApplicationInstance.CompleteRequest();
                    }
                    else
                    {
                        if (IsLoginUrl(context))
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = 404;
                            //插入访问日志
                            SysPageHelp.sysPageHelp.CreateAccessLog(context, true);
                            context.ApplicationInstance.CompleteRequest();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Clear();
                context.Response.StatusCode = 500;
                context.ApplicationInstance.CompleteRequest();

                LogFactory.GetLogger(this.GetType()).Error("异常：" + ex.Message + "\r\n");
            }
        }
        #endregion

        #region 处理结束输出
        /// <summary>
        /// 处理结束输出
        /// </summary>
        /// <param name="context"></param>
        public void EndRequest(System.Web.HttpContext context)
        {
            setResponse(context);
        }

        /// <summary>
        /// 设置输出状态
        /// </summary>
        /// <param name="context"></param>
        private void setResponse(System.Web.HttpContext context)
        {
            string htmls = string.Empty;
            switch (context.Response.StatusCode)
            {
                case 403:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "403 Forbidden";
                        context.Response.StatusDescription = "Forbidden";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
                        DoResponse(context, htmls);
                    }
                    break;
                case 404:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "404 Not Found";
                        context.Response.StatusDescription = "Not Found";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
                        DoResponse(context, htmls);
                    }
                    break;
                case 500:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "500 Internal Server Error";
                        context.Response.StatusDescription = "Internal Server Error";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetErrorPage();
                        DoResponse(context, htmls);
                    }
                    break;
            }
        }
        /// <summary>
        /// 请求返回是否需要处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool IsProcessEndStatus(System.Web.HttpContext context)
        {
            bool bState = false;
            if (string.IsNullOrEmpty(context.Response.Status) || context.Request != null && context.Request.AcceptTypes != null && context.Request.AcceptTypes.Contains("text/html"))
            {
                bState = true;
            }
            return bState;
        }

        private void DoResponse(System.Web.HttpContext context, string htmls)
        {
            //context.Response.Clear();
            context.Response.Write(htmls);
            context.ApplicationInstance.CompleteRequest();
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

        #region 域名是否可访问后台
        /// <summary>
        /// 域名是否可访问后台
        /// </summary>
        /// <returns></returns>
        public bool IsLoginHost(System.Web.HttpContext context)
        {
            bool bState = false;
            string urlHost = GetHost(context); ;
            //string urlPath = context.Request.Path.ToString();

            //if (urlPath.Length >= LOGINURLMARK.Length)
            //{
            //    urlPath = urlPath.Substring(0, LOGINURLMARK.Length);
            //}

            //if (!string.IsNullOrEmpty(urlHost) && !string.IsNullOrEmpty(urlPath) && urlPath.ToLower() == LOGINURLMARK.ToLower())
            if (!string.IsNullOrEmpty(urlHost))
            {
                bState = IsContistHost(urlHost);
            }
            return bState;
        }
        /// <summary>
        /// 域名是否可访问后台
        /// </summary>
        /// <returns></returns>
        public bool IsLoginUrl(System.Web.HttpContext context)
        {
            bool bState = false;
            string urlPath = context.Request.Path.ToString();

            if (urlPath.Length >= LOGINURLMARK.Length)
            {
                urlPath = urlPath.Substring(0, LOGINURLMARK.Length);
            }

            if (!string.IsNullOrEmpty(urlPath) && urlPath.ToLower() == LOGINURLMARK.ToLower())
            {
                bState = true;
            }
            return bState;
        }

        public bool IsContistHost(string urlHost)
        {
            bool bState = false;
            string strLoginHostConfigs = Code.ConfigHelp.configHelp.LOGINHOST;
            if (!string.IsNullOrEmpty(strLoginHostConfigs))
            {
                strLoginHostConfigs = strLoginHostConfigs.ToLower();
                if (strLoginHostConfigs == LOGINHOSTCONFIGALLMARK)
                {
                    bState = true;
                }
                else
                {
                    string[] hostconfigs = strLoginHostConfigs.Split('|');
                    if (hostconfigs != null && hostconfigs.Count() > 0)
                    {
                        bState = hostconfigs.Contains(urlHost.ToLower());
                    }
                }
            }
            return bState;
        }
        #endregion

        /// <summary>
        /// 获取请求urlHost
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetHost(System.Web.HttpContext context)
        {
            string urlHost = context.Request.Url.Host;
            if (!context.Request.Url.IsDefaultPort && Code.ConfigHelp.configHelp.ISOPENPORT)
            {
                urlHost = context.Request.Url.Authority;
            }
            return urlHost;
        }


        /// <summary>
        /// 获取请求urlHost
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetHostRequest(System.Web.HttpRequestBase request)
        {
            string urlHost = request.Url.Host;
            if (!request.Url.IsDefaultPort && Code.ConfigHelp.configHelp.ISOPENPORT)
            {
                urlHost = request.Url.Authority;
            }
            return urlHost;
        }
    }
}
