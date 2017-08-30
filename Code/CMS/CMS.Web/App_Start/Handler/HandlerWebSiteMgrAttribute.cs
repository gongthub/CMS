using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web
{

    public class HandlerWebSiteMgrAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        private static string WEBURL = "";
        public HandlerWebSiteMgrAttribute(bool ignore = true)
        {
            Ignore = ignore;
            WEBURL = Configs.GetValue("WebUrl");
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.Url.Authority))
            {
                if (Code.ConfigHelp.configHelp.ISOPENPORT)
                {
                    WEBURL = string.Format(WEBURL, HttpContext.Current.Request.Url.Authority);
                }
                else
                {
                    WEBURL = string.Format(WEBURL, HttpContext.Current.Request.Url.Host);
                }
            }
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            Guid Ids = Guid.Empty;
            if (SysLoginObjHelp.sysLoginObjHelp.GetWebSiteId() == null || !Guid.TryParse(SysLoginObjHelp.sysLoginObjHelp.GetWebSiteId(), out Ids))
            {

                StringBuilder sbScript = new StringBuilder();
                //判断是否ajax请求
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    sbScript.Append("WebSiteLogout");
                    filterContext.Result = new JavaScriptResult() { Script = sbScript.ToString() };
                }
                else
                {
                    sbScript.Append("<script>alert('站点信息丢失！请重新选择站点！');top.location.href = '" + WEBURL + "/Home/Index';</script>");
                    filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                }
                return;
            }
        }
    }
}