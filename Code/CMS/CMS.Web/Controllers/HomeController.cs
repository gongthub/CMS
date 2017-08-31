using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
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
            int userWebSiteNum = userWebSiteApp.GetWebSiteNums();
            ViewBag.WebSiteNum = userWebSiteNum;

            return View();
        }
        [HttpGet]
        public ActionResult DefaultWebSite()
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

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult GetWebSiteAccessDates()
        {
            ReportApp reportApp = new ReportApp();

            List<WebSiteAccessReport> modelsT = reportApp.GetWebSiteAccessDates();

            List<string> webSiteIds = new List<string>();
            List<string> webSiteNames = userWebSiteApp.GetWebSiteShortName(out webSiteIds);

            DateTime StartDate = new DateTime(DateTime.Now.Year);
            DateTime EndDate = StartDate.AddYears(1);
            AccessLogApp accessLogApp = new AccessLogApp();
            List<CommonSeries> listData = new List<CommonSeries>();

            foreach (var webSiteId in webSiteIds)
            {
                List<AccessLogEntity> models = accessLogApp.GetListByDate(webSiteId, StartDate, EndDate);
            }

            CommonSeries datas = new CommonSeries();
            //datas.name = "Name1";
            //datas.type = "line";
            //datas.stack = "总量";
            //datas.data = datasT;

            listData.Add(datas);
            var jsons = new { data = listData };
            return Json(jsons);
        }
    }

    public class CommonSeries
    {
        public string name { get; set; }
        public string type { get; set; }
        public string stack { get; set; }
        public object data { get; set; }
    }
}
