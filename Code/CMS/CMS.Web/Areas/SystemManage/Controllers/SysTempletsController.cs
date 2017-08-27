using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class SysTempletsController : ControllerBase
    {
        private SysTempletsApp sysTempletsApp = new SysTempletsApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(string keyword, Pagination pagination)
        {
            var data = new
            {
                rows = sysTempletsApp.GetList(pagination, keyword),
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
            var data = sysTempletsApp.GetList();
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysTempletsApp.GetForm(keyValue);
            return Content(data.ToJson());
        }


        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysTempletsEntity sysTempletsEntity, string keyValue, UpFileDTO upFileentity)
        {
            sysTempletsApp.SubmitForm(sysTempletsEntity, keyValue, upFileentity);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            sysTempletsApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

    }
}
