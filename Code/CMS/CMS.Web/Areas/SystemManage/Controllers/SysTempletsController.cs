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
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysTempletsEntity sysTempletsEntity, string keyValue, UpFileDTO upFileentity)
        {
            sysTempletsApp.SubmitForm(sysTempletsEntity, keyValue, upFileentity);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            sysTempletsApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ManageIndex()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ManageForm()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ManageDetails()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetItemGrid(string parentId, string keyword, Pagination pagination)
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
        public ActionResult GetItemFormJson(string keyValue)
        {
            var data = sysTempletsApp.GetItemForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitItemForm(SysTempletItemsEntity sysTempletItemsEntity, string keyValue)
        {
            sysTempletsApp.SubmitItemForm(sysTempletItemsEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult ManageDeleteForm(string keyValue)
        {
            sysTempletsApp.DeleteItemForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ResourceIndex()
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ResourceForm()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetResourceGridJson(string parentId)
        {
            var data = sysTempletsApp.GeResourcetList(parentId);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult ResourceDeleteForm(string parentId, string keyValue)
        {
            sysTempletsApp.DeleteResourceForm(parentId, keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitResourceFormAdd(string parentId, string DirName, string keyValue)
        {
            try
            {
                sysTempletsApp.CreateDirById(parentId, keyValue, DirName);
                return Success("操作成功。");
            }
            catch (Exception ex)
            {
                return Error("操作失败。" + ex.Message);
            }
        }
    }
}
