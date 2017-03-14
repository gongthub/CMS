using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = true;
            routes.MapRoute(
                name: "Default",
                url: "{name}",
                //defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
                 defaults: new { controller = "WebSite", action = "Index", name = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional } 
            );
          
        }
    }
}