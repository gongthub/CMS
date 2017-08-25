using CMS.Application.Comm;
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
            var operatorProvider = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (operatorProvider != null && SysLoginObjHelp.sysLoginObjHelp.GetOperator().IsSystem)
            {
                return;
            }
            if (operatorProvider == null)
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
                //判断是否ajax请求
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    sbScript.Append("NoAuthorize");
                    filterContext.Result = new JavaScriptResult() { Script = sbScript.ToString() };
                }
                else
                {
                    sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                    filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                }
                return;
            }
        }
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            var operatorProvider = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            var roleId = operatorProvider.RoleId;
            var moduleId = WebHelper.GetCookie("cms_currentmoduleid");
            var moduleName = WebHelper.GetCookie("cms_currentmodulename");
            moduleName = HttpUtility.UrlDecode(moduleName);
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            bool bStatus = new RoleAuthorizeApp().ActionValidate(roleId, moduleId, action);
            //添加日志
            LogHelp.logHelp.WriteDbLog(bStatus, "访问菜单=>" + moduleName + "=>路径：" + action, Enums.DbLogType.Visit, moduleName);
            return bStatus;
        }
    }
}