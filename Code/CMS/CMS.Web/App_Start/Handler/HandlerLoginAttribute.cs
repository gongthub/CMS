using CMS.Code;
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
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }
            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("cms_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '" + WEBURL + "/Login/Index';</script>");
                return;
            }
        }
    }
}