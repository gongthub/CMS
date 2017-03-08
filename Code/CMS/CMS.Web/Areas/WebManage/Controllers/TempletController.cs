using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [WebSiteMgr]
    public class TempletController : ControllerBase
    {
        private TempletApp templetApp = new TempletApp();


        [HttpGet]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            //var data = templetApp.GetList();
            //return Content(data.ToJson());
            var data = new
            {
                rows = templetApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetGridJson()
        {
            var data = templetApp.GetList();
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = templetApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(TempletEntity moduleEntity, string keyValue)
        {
            //moduleEntity.Content = Server.HtmlEncode(moduleEntity.Content);

            moduleEntity.WebSiteId = GetSessionByName(WEBSITEID);

            templetApp.SubmitForm(moduleEntity, keyValue);
            return Success("操作成功。");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            templetApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}