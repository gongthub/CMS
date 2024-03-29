﻿using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage
{
    public class WebManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WebManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
              this.AreaName + "_Default",
              this.AreaName + "/{controller}/{action}/{id}",
              new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
              new string[] { "CMS.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }
    }
}
