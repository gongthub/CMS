using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class WebSiteController : Controller
    {
        //public ActionResult Index()
        //{
        //    C_TempletApp templetApp = new C_TempletApp();
        //    C_TempletEntity model = templetApp.GetMain();
        //    string htmls = Server.HtmlDecode(model.F_Content);
        //    return Content(htmls);
        //}
        public ActionResult Index(string name)
        {
            C_TempletApp templetApp = new C_TempletApp();
            C_TempletEntity model = new C_TempletEntity();
            C_ModulesApp modulesApp = new C_ModulesApp();
            C_ModulesEntity moduleentity = new C_ModulesEntity();
            if (string.IsNullOrEmpty(name))
            {
                model = templetApp.GetMain();
            }
            else
            {
                model = templetApp.GetModelByActionName(name);
            }
            string htmls = Server.HtmlDecode(model.F_Content);
            moduleentity = modulesApp.GetFormByActionName(name);
            if (moduleentity != null)
            {
                TempHelp temphelp = new TempHelp();
                htmls = temphelp.GetHtmlPages(htmls, moduleentity.F_Id);
            }

            return Content(htmls);
        }
    }
}
