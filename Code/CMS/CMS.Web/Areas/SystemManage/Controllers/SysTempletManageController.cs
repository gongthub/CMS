using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc; 

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class SysTempletManageController : ControllerBase
    {
        private SysTempletsApp sysTempletsApp = new SysTempletsApp();
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(string parentId, string keyword, Pagination pagination)
        {
            var data = new
            {
                rows = sysTempletsApp.GetItemList(pagination, parentId, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string parentId)
        {
            var data = sysTempletsApp.GetItemList(parentId);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysTempletsApp.GetItemForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysTempletItemsEntity sysTempletItemsEntity, string keyValue)
        {
            sysTempletsApp.SubmitItemForm(sysTempletItemsEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            sysTempletsApp.DeleteItemForm(keyValue);
            return Success("删除成功。");
        }

    }
}
