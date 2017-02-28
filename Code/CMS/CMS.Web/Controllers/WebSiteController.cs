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
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            C_ModulesEntity moduleentity = new C_ModulesEntity();
            if (string.IsNullOrEmpty(name))
            {
                model = templetApp.GetMain();
                moduleentity = c_ModulesApp.GetMain();
            }
            else
            {
                model = templetApp.GetModelByActionName(name);
                moduleentity = c_ModulesApp.GetFormByActionName(name);
            }
            string htmls = Server.HtmlDecode(model.F_Content);
            if (moduleentity != null)
            {
                htmls = TempHelp.tempHelp.GetHtmlPages(htmls, moduleentity.F_Id);
            }

            return Content(htmls);
        }
    }
}
