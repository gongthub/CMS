using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class MessageController : ControllerBase
    {
        private MessagesApp messagesApp = new MessagesApp();
        private MessageConfigApp messageConfigApp = new MessageConfigApp();


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetListTitle()
        {
            object strJson = new MessageConfigApp().GetListTitleJsonStr(Base_WebSiteId);
            return Content(strJson.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = messagesApp.GetListByWebSiteId(pagination, keyword, Base_WebSiteId),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson()
        {
            var models = messagesApp.GetListByWebSiteId(Base_WebSiteId);
            return Content(models.ToJson());
        }
        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Index()
        {
            List<MessagesEntity> models = messagesApp.GetListByWebSiteId(Base_WebSiteId);
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            messagesApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult MessageDetails(string keyValue)
        {
            var models = messageConfigApp.GetViewShow(Base_WebSiteId, keyValue);
            return View(models);
        }
    }
}
