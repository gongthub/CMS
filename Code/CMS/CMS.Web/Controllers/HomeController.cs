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
        [HttpGet]
        public ActionResult Index(string strLoginMark)
        {
            if (!string.IsNullOrEmpty(strLoginMark))
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                string strWebSiteIds = string.Empty;
                if (webSiteApp.IsExistDefaultWebSite(ref strWebSiteIds))
                {
                    return RedirectToAction("WebSite", "Home", new { key = strWebSiteIds });
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult WebSite(string key)
        {
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity entity = app.GetForm(key);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                SysLoginObjHelp.sysLoginObjHelp.AddWebSiteId(entity.Id);
                SysLoginObjHelp.sysLoginObjHelp.AddWebSiteName(entity.FullName);
                SysLoginObjHelp.sysLoginObjHelp.AddWebSiteShortName(entity.ShortName);
                if (!string.IsNullOrEmpty(entity.UrlAddress))
                {
                    string strUrlAddress = entity.UrlAddress.ToLower().Replace("http://", "");
                    SysLoginObjHelp.sysLoginObjHelp.AddWebSiteAddress(strUrlAddress);
                }
                SysLoginObjHelp.sysLoginObjHelp.AddWebSite<WebSiteEntity>(entity);
            }

            return RedirectToAction("WebSiteMgr");
        }
        [HttpGet]
        [HandlerWebSiteMgr]
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
