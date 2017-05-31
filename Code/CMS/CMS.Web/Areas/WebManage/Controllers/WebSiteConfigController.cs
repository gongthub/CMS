using CMS.Application.Comm;
using CMS.Code;
using CMS.Application.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class WebSiteConfigController : ControllerBase
    {
        private WebSiteConfigApp webSiteConfigApp = new WebSiteConfigApp();

        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Index()
        {
            var data = webSiteConfigApp.GetFormByWebSiteId(Base_WebSiteId);
            return View(data);
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson()
        {
            var data = webSiteConfigApp.GetFormByWebSiteId(Base_WebSiteId);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult MessageConfig()
        {
            return View();
        }


        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult IsMessage()
        {
            try
            {
                bool bState = webSiteConfigApp.IsMessage(Base_WebSiteId);
                return Success(bState.ToString().ToLower());
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSearchEnabled(bool searchEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateSearchEnableByWebSiteId(Base_WebSiteId, searchEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMessageEnabled(bool messageEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateMessageEnableByWebSiteId(Base_WebSiteId, messageEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateServiceEnabled(bool serviceEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateServiceEnableByWebSiteId(Base_WebSiteId, serviceEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }


        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSearchIndex()
        {
            try
            {
                LucenceHelp.CreateIndex(Base_WebSiteId, Base_WebSiteShortName);
                return Success("生成成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }
    }
}
