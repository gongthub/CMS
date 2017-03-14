using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        public static readonly string WEBSITEID = "WEBSITEID";
        [HttpGet]
        public ActionResult Index()
        { 
            return View();
        }
        [HttpGet] 
        public ActionResult WebSite(string key)
        {
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity entity = app.GetForm(key);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                Session["WEBSITEID"] = entity.Id;
                Session["WEBSITENAME"] = entity.FullName;
                Session["WEBSITEENTITY"] = entity;
            } 

            return RedirectToAction("WebSiteMgr");
        }
        [HttpGet]
        [WebSiteMgr]
        public ActionResult WebSiteMgr()
        { 
            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ModulM(string id)
        {
            string srcs = @"/html/" + id + ".html";
            srcs = Server.MapPath(srcs);
            string strLine;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(srcs))
            {
                strLine = sr.ReadToEnd();
            }


            return Content(strLine);
        }
    }
}
