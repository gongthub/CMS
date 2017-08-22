using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
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
            if (ConfigHelp.configHelp.ISPROREQUEST)
            {
                string htmls = string.Empty;
                try
                {
                    string urlHost = GetHost(context);
                    string urlRaw = context.Request.RawUrl.ToString();
                    urlRaw = context.Server.UrlDecode(urlRaw);
                    bool isShoudPre = false;
                    if (IsLoginHost(context))
                    {
                        if (Code.ConfigHelp.configHelp.LOGINHOST != LOGINHOSTCONFIGALLMARK)
                        {
                            if (string.IsNullOrEmpty(urlRaw) || urlRaw == "/")
                            {
                                context.Response.Clear();
                                context.Response.Redirect("/Login/Index", false);
                                context.ApplicationInstance.CompleteRequest();
                            }
                            else
                                if (!IsLoginUrl(context))
                                {
                                    isShoudPre = true;
                                }
                        }
                        else
                            if (!IsLoginUrl(context))
                            {
                                isShoudPre = true;
                            }
                    }
                    else
                    {
                        isShoudPre = true;
                    }
                    if (isShoudPre == true)
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
            //if (TempHelp.tempHelp.IsWebSite(urlhost, urlRaw) && Common.IsExistExtended(urlRaw))
            if (TempHelp.tempHelp.IsWebSite(urlhost, urlRaw))
            {
                bState = true;
            }
            else
            {
                if (Common.IsExistUrlRaw(urlRaw))
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
            string urlHost = GetHost(context); 
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

        #region 获取分页内容 +ExtPageModel GetPageModels(System.Web.HttpContext context)
        /// <summary>
        /// 获取分页内容
        /// </summary>
        /// <returns></returns>
        public ExtPageModel GetPageModels(System.Web.HttpContext context)
        {
            ExtPageModel extPageModel = new ExtPageModel();
            string strRqs = context.Request["pageDatas"];
            if (!string.IsNullOrEmpty(strRqs))
            {
                ExtPageModel extPageModelReq = Json.ToObject<ExtPageModel>(strRqs);
                string cIds = GetColumnIds(context);
                extPageModelReq.SourceIds = cIds;

                string attrDatas = context.Request["attrDatas"];
                if (!string.IsNullOrEmpty(attrDatas))
                {
                    extPageModelReq.AttrDatas = Json.ToObject<Dictionary<string, string>>(attrDatas);
                }
                extPageModel = TempHelp.tempHelp.GetContentModels(extPageModelReq);
            }
            return extPageModel;
        }
        
        #endregion

        #region 获取请求路径栏目Id -string GetColumnIds(System.Web.HttpContext context)
        /// <summary>
        /// 获取请求路径栏目Id
        /// </summary>
        /// <returns></returns>
        private string GetColumnIds(System.Web.HttpContext context)
        {
            string cIds = string.Empty;
            string urlHost = GetHost(context);
            string urlRaw = context.Request.RawUrl.ToString();
            urlRaw = context.Server.UrlDecode(urlRaw);

            //处理Url参数
            urlRaw = Common.HandleUrlRaw(urlRaw);
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            WebSiteApp app = new WebSiteApp();
            ColumnsApp c_ColumnsApp = new ColumnsApp();
            WebSiteEntity entity = app.GetModelByUrlHost(urlHost);
            if (urlRaws == null || urlRaws.Count == 0)
            {
                ColumnsEntity columnsEntity = c_ColumnsApp.GetMain(entity.Id);
                if (columnsEntity != null)
                    cIds = columnsEntity.Id;
            }
            else
            {
                if (urlRaws.Count > 0)
                {
                    ColumnsEntity columnsEntity = c_ColumnsApp.GetFormByActionName(urlRaws.FirstOrDefault(), entity.Id);
                    if (columnsEntity != null)
                        cIds = columnsEntity.Id;
                }
            }

            return cIds;
        } 
        #endregion

        #region 获取请求urlHost +string GetHost(System.Web.HttpContext context)
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
        
        #endregion

        #region 获取请求urlHost +string GetHostRequest(System.Web.HttpRequestBase request)
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
        #endregion
    }
}
