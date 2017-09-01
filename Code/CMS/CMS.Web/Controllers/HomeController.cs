using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using CMS.Domain.ViewModel;

namespace CMS.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
        AccessLogApp accessLogApp = new AccessLogApp();
        ContentApp contentApp = new ContentApp();
        MessagesApp messagesApp = new MessagesApp();
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
            string webSiteId = SysLoginObjHelp.sysLoginObjHelp.GetWebSiteId();
            int toDayNum = accessLogApp.GetToDayNum(webSiteId);
            int allNum = accessLogApp.GetAllNum(webSiteId);
            int contentNum = contentApp.GetCountByWebSiteId(webSiteId);
            int messageNum = messagesApp.GetCountByWebSiteId(webSiteId);
            ViewBag.ToDayNum = toDayNum;
            ViewBag.AllNum = allNum;
            ViewBag.ContentNum = contentNum;
            ViewBag.MessageNum = messageNum;

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
            List<EchartSeries> listData = new List<EchartSeries>();
            ReportApp reportApp = new ReportApp();

            List<WebSiteAccessReport> modelsT = reportApp.GetWebSiteAccessDates();
            List<string> webSiteNames = new List<string>();
            if (modelsT != null && modelsT.Count > 0)
            {
                webSiteNames = (from list in modelsT
                                select list.ShortName).Distinct().ToList();
            }
            if (webSiteNames != null && webSiteNames.Count > 0)
            {
                foreach (var webSiteName in webSiteNames)
                {
                    EchartSeries datas = new EchartSeries();
                    datas.name = webSiteName;
                    datas.type = "line";
                    List<int> datasT = new List<int>();
                    for (int i = 1; i <= 12; i++)
                    {
                        WebSiteAccessReport model = modelsT.Find(m => m.ShortName == webSiteName && m.Mont == i);
                        if (model != null && !string.IsNullOrEmpty(model.ShortName))
                        {
                            datasT.Add(model.Nums);
                        }
                        else
                        {
                            datasT.Add(0);
                        }
                    }
                    datas.data = datasT;
                    listData.Add(datas);
                }
            }

            var jsons = new { data = listData, name = webSiteNames };
            return Json(jsons);
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult GetWebSiteAccessToDates()
        {
            string webSiteId = SysLoginObjHelp.sysLoginObjHelp.GetWebSiteId();
            List<EchartSeries> listData = new List<EchartSeries>();
            ReportApp reportApp = new ReportApp();

            List<WebSiteAccessToDayReport> modelsT = reportApp.GetWebSiteAccessToDates(webSiteId);
            List<string> webSiteNames = new List<string>();
            EchartSeries datas = new EchartSeries();
            datas.name = "访问量";
            datas.type = "line";
            List<int> datasT = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                WebSiteAccessToDayReport model = modelsT.Find(m => m.Hours == i);
                if (model != null)
                {
                    datasT.Add(model.Nums);
                }
                else
                {
                    datasT.Add(0);
                }
            }
            datas.data = datasT;
            listData.Add(datas);

            var jsons = new { data = listData, name = webSiteNames };
            return Json(jsons);
        }
    }
}
