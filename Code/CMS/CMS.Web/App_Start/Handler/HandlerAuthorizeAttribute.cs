using CMS.Application.SystemManage;
using CMS.Code;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        public bool Ignore { get; set; }
        public HandlerAuthorizeAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (OperatorProvider.Provider.GetCurrent() != null && OperatorProvider.Provider.GetCurrent().IsSystem)
            if (SysLoginObjHelp.sysLoginObjHelp.GetOperator() != null && SysLoginObjHelp.sysLoginObjHelp.GetOperator().IsSystem)
            {
                return;
            }
            if (Ignore == false)
            {
                return;
            }
            if (!this.ActionAuthorize(filterContext))
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            //var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var operatorProvider = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            var roleId = operatorProvider.RoleId;
            var moduleId = WebHelper.GetCookie("cms_currentmoduleid");
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            return new RoleAuthorizeApp().ActionValidate(roleId, moduleId, action);
        }
    }
}