using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    public class WebSiteMgrController : ControllerBase
    {
        private WebSiteApp webSiteApp = new WebSiteApp();


        [HttpGet]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = webSiteApp.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetGridJson()
        {
            var data = webSiteApp.GetList();
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = webSiteApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(WebSiteEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            try
            {
                webSiteApp.SubmitForm(moduleEntity, keyValue, upFileentity);
                return Success("操作成功。");
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
        public ActionResult DeleteForm(string keyValue)
        {
            webSiteApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
