using CMS.Code;
using System;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        private static string WEBURL = "";
        public HandlerLoginAttribute(bool ignore = true)
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
            //if (OperatorProvider.Provider.GetCurrent() == null)
            if (SysLoginObjHelp.sysLoginObjHelp.GetOperator() == null || SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserId == null)
            {
                WebHelper.WriteCookie("cms_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '" + WEBURL + "/Login/Index';</script>"); 
                return;
            }
        }
    }
}