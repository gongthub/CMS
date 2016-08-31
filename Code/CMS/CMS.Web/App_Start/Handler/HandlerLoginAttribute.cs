using CMS.Code;
using System.Web.Mvc;

namespace CMS.Web
{
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
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
                //filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
                return;
            }
        }
    }
}