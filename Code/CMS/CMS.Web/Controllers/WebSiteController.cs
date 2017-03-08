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
        //    TempletApp templetApp = new TempletApp();
        //    TempletEntity model = templetApp.GetMain();
        //    string htmls = Server.HtmlDecode(model.Content);
        //    return Content(htmls);
        //}
        public ActionResult Index(string name)
        {
            TempletApp templetApp = new TempletApp();
            TempletEntity model = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity moduleentity = new ColumnsEntity();
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
            string htmls = Server.HtmlDecode(model.Content);
            if (moduleentity != null)
            {
                htmls = TempHelp.tempHelp.GetHtmlPages(htmls, moduleentity.Id);
            }

            return Content(htmls);
        }

    }
}
