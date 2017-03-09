﻿using CMS.Code;
using System;
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


    public class WebSiteMgrAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        private static string WEBURL = "";
        public WebSiteMgrAttribute(bool ignore = true)
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
            Guid Ids = Guid.Empty;
            if (WebHelper.GetCookie("WEBSITEID") == null || !Guid.TryParse(WebHelper.GetCookie("WEBSITEID").ToString(), out Ids))
            {

                WebHelper.WriteCookie("cms_login_error", "nowebsite");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '" + WEBURL + "/Home/Index';</script>");
                return;
            }
        }
    }
}