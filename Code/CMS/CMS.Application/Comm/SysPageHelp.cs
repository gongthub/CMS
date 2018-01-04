using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Application.Comm
{
    public class SysPageHelp
    {
        private const string CLINETID = "CMS_CLIENTID";
        private const string SYSREQUESTSTARTTIME = "CMS_SYSREQUESTSTARTTIME";

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

        #region 获取404错误页 +string GetNoFindPage()
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

        #endregion

        #region 获取500错误页 +string GetErrorPage()
        /// <summary>
        /// 获取500错误页
        /// </summary>
        /// <returns></returns>
        public string GetErrorPage()
        {
            string strHtmls = string.Empty;

            strHtmls = Code.FileHelper.ReadTxtFile(ConfigHelp.configHelp.SYSPAGE_ERROR, true);

            return strHtmls;
        }

        #endregion

        #region 获取维护页 +string GetServicePage()
        /// <summary>
        /// 获取维护页
        /// </summary>
        /// <returns></returns>
        public string GetServicePage()
        {
            string strHtmls = string.Empty;

            strHtmls = Code.FileHelper.ReadTxtFile(ConfigHelp.configHelp.SYSPAGE_SERVICE, true);

            return strHtmls;
        }

        #endregion

        #region 创建前台页面访问日志
        /// <summary>
        /// 创建前台页面访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void CreateAccessLog(System.Web.HttpContext context)
        {
            AccessLogEntity entity = InitAccessLog(context);

            HttpCookie cookie = context.Request.Cookies.Get(CLINETID);
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                entity.ClientID = cookie.Value;
            }
            else
            {
                string clientIds = Guid.NewGuid().ToString();
                entity.ClientID = clientIds;
                cookie = new HttpCookie(CLINETID);
                cookie.Name = CLINETID;
                cookie.Value = clientIds;
                cookie.Expires = DateTime.Now.AddYears(1);
                entity.ClientID = clientIds;

                context.Response.Cookies.Set(cookie);
            }
            InsertAccessLog(entity);
        }

        /// <summary>
        /// 创建前台页面访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void CreateAccessLog(System.Web.HttpContext context, bool IsAsync)
        {
            if (IsAsync)
            {
                AccessLogEntity entity = InitAccessLog(context);
                HttpCookie cookie = context.Request.Cookies.Get(CLINETID);
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    entity.ClientID = cookie.Value;
                }
                else
                {
                    string clientIds = Guid.NewGuid().ToString();
                    entity.ClientID = clientIds;
                    cookie = new HttpCookie(CLINETID);
                    cookie.Name = CLINETID;
                    cookie.Value = clientIds;
                    cookie.Expires = DateTime.Now.AddYears(1);
                    entity.ClientID = clientIds;

                    context.Response.Cookies.Set(cookie);
                }
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    InsertAccessLog(entity);
                }));
                thread.Start();

            }
            else
            {
                AccessLogEntity entity = InitAccessLog(context);
                InsertAccessLog(entity);
            }
        }

        /// <summary>
        /// 创建前台页面访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        private void InsertAccessLog(AccessLogEntity entity)
        {
            entity = InitAccessLog(entity, true);
            AccessLogApp accessLogApp = new AccessLogApp();
            accessLogApp.Createlog(entity);
        }

        /// <summary>
        /// 处理访问参数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private AccessLogEntity InitAccessLog(System.Web.HttpContext context)
        {
            string realIp = GetRealClientIp(context);
            string urlHost = new RequestHelp().GetHost(context);
            string urlRaw = context.Request.RawUrl.ToString();
            AccessLogEntity entity = new AccessLogEntity();
            entity.WebSiteName = urlHost;
            entity.UrlAddress = context.Request.Url.ToString();
            if (context.Session != null)
                entity.SessionID = context.Session.SessionID;
            if (context.Request != null)
            {
                entity.IPAddress = realIp;
                entity.Browser = context.Request.Browser.Browser;
                entity.BrowserID = context.Request.Browser.Id;
                entity.BrowserVersion = context.Request.Browser.Version;
                entity.BrowserType = context.Request.Browser.Type;
                entity.BrowserPlatform = context.Request.Browser.Platform;
                if (context.Request.UrlReferrer != null)
                    entity.PUrlAddress = context.Request.UrlReferrer.ToString();
            }
            entity.EnabledMark = true;
            return entity;
        }
        /// <summary>
        /// 处理访问参数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private AccessLogEntity InitAccessLog(AccessLogEntity entity, bool IsProcessWebSite)
        {
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity webSiteEntity = app.GetModelByUrlHost(entity.WebSiteName);
            if (webSiteEntity != null)
            {
                entity.WebSiteId = webSiteEntity.Id;
            }
            return entity;
        }
        #endregion

        #region 创建系统请求访问日志

        /// <summary>
        /// 创建请求开始日志
        /// </summary>
        /// <param name="context"></param>
        public void AddStartRequestLog(System.Web.HttpContext context)
        {
            if (Code.ConfigHelp.configHelp.ISPROREQUESTLOG)
            {
                InitRequestStartTime(context);
            }
        }

        /// <summary>
        /// 创建请求结束日志
        /// </summary>
        /// <param name="context"></param>
        public void AddEndRequestLog(System.Web.HttpContext context)
        {
            if (Code.ConfigHelp.configHelp.ISPROREQUESTLOG)
            {
                RequestLogEntity entity = InitEndRequestLog(context);
                CreateRequestLog(entity, true);
            }
        }

        /// <summary>
        /// 初始化请求唯一标识
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void InitRequestStartTime(System.Web.HttpContext context)
        {
            context.Request.Cookies.Remove(SYSREQUESTSTARTTIME);
            HttpCookie cookieSysStartTime = new HttpCookie(SYSREQUESTSTARTTIME, DateTime.Now.ToString());
            context.Request.Cookies.Set(cookieSysStartTime);
        }

        /// <summary>
        /// 创建系统请求访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void CreateRequestLog(RequestLogEntity entity)
        {
            InsertRequestLog(entity);
        }

        /// <summary>
        /// 创建前台页面访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void CreateRequestLog(RequestLogEntity entity, bool IsAsync)
        {
            if (IsAsync)
            {
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    InsertRequestLog(entity);
                }));
                thread.Start();

            }
            else
            {
                InsertRequestLog(entity);
            }
        }

        /// <summary>
        /// 创建前台页面访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        private void InsertRequestLog(RequestLogEntity entity)
        {
            entity = InitRequestLog(entity, true);
            RequestLogApp requestLogApp = new RequestLogApp();
            requestLogApp.Createlog(entity);
        }

        private string GetRealClientIp(System.Web.HttpContext context)
        {
            string ipStr = string.Empty;
            if (context.Request.Headers["X-Real-IP"] != null)
            {
                ipStr = context.Request.Headers["X-Real-IP"].ToString();
            }
            else
            {
                ipStr = context.Request.UserHostAddress;
            }
            return ipStr;
        }

        /// <summary>
        /// 处理访问参数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private RequestLogEntity InitEndRequestLog(System.Web.HttpContext context)
        {
            string realIp = GetRealClientIp(context);
            string urlHost = new RequestHelp().GetHost(context);
            string urlRaw = context.Request.RawUrl.ToString();
            RequestLogEntity entity = new RequestLogEntity();
            entity.UrlAddress = context.Request.Url.ToString();
            entity.UrlHost = urlHost;
            entity.UrlRaw = urlRaw;
            entity.WebSiteName = urlHost;
            if (context.Session != null)
                entity.SessionID = context.Session.SessionID;
            if (context.Request != null)
            {
                entity.IPAddress = realIp;
                entity.Browser = context.Request.Browser.Browser;
                entity.BrowserID = context.Request.Browser.Id;
                entity.BrowserVersion = context.Request.Browser.Version;
                entity.BrowserType = context.Request.Browser.Type;
                entity.BrowserPlatform = context.Request.Browser.Platform;
                if (context.Request.UrlReferrer != null)
                    entity.PUrlAddress = context.Request.UrlReferrer.ToString();
            }
            entity.EnabledMark = true;

            HttpCookie cookie = context.Request.Cookies.Get(CLINETID);
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                entity.ClientID = cookie.Value;
            }
            else
            {
                string clientIds = Guid.NewGuid().ToString();
                entity.ClientID = clientIds;
                cookie = new HttpCookie(CLINETID);
                cookie.Name = CLINETID;
                cookie.Value = clientIds;
                cookie.Expires = DateTime.Now.AddYears(1);
                entity.ClientID = clientIds;

                context.Response.Cookies.Set(cookie);
            }
            HttpCookie cookieSys = context.Request.Cookies.Get(SYSREQUESTSTARTTIME);
            if (cookieSys != null && !string.IsNullOrEmpty(cookieSys.Value))
            {
                string startTimes = cookieSys.Value;
                DateTime startTime = DateTime.Now;
                if (DateTime.TryParse(startTimes, out startTime))
                {
                    entity.StartDateTime = startTime;
                }
            }
            return entity;
        }
        /// <summary>
        /// 处理访问参数
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private RequestLogEntity InitRequestLog(RequestLogEntity entity, bool IsProcessWebSite)
        {
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity webSiteEntity = app.GetModelByUrlHost(entity.WebSiteName);
            if (webSiteEntity != null)
            {
                entity.WebSiteId = webSiteEntity.Id;
            }
            return entity;
        }
        #endregion
    }
}
