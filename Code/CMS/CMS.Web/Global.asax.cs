using CMS.Application.Comm;
using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace CMS.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            //string oldimgpath = Code.FileHelper.MapPath("/Uploads/Files/1.png");
            //string newimgpath = Code.FileHelper.MapPath("/Uploads/Files/2.png");
            //Code.Image.ImageHelper.imageHelperp.GetPicThumbnail(oldimgpath, newimgpath, 50);
            HttpContext context = HttpContext.Current;
            new RequestHelp().InitRequest(context);
        }
        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            new RequestHelp().EndRequest(context);
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //在出现未处理的错误时运行的代码         
            Exception objError = Server.GetLastError().GetBaseException();
            string errortime = string.Empty;
            string erroraddr = string.Empty;
            string errorinfo = string.Empty;
            string errorsource = string.Empty;
            string errortrace = string.Empty;
            string errormethodname = string.Empty;
            string errorclassname = string.Empty;

            errortime = "发生时间:" + System.DateTime.Now.ToString();
            erroraddr = "发生异常页: " + System.Web.HttpContext.Current.Request.Url.ToString();
            errorinfo = "异常信息: " + objError.Message;
            errorsource = "错误源:" + objError.Source;
            errortrace = "堆栈信息:" + objError.StackTrace;
            errorclassname = "发生错误的类名" + objError.TargetSite.DeclaringType.FullName;
            errormethodname = "发生错误的方法名：" + objError.TargetSite.Name;
            //清除当前异常 使之不返回到请求页面
            Server.ClearError();
            LogFactory.GetLogger(this.GetType()).Error("异常：" + errortime + erroraddr + errorinfo + errorsource + errortrace + errorclassname + errormethodname + "\r\n");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }

}