using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class ResourceController : ControllerBase
    {
        private ResourceApp resourceApp = new ResourceApp();
        [HttpGet]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = resourceApp.GetList(Base_WebSiteId),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        public ActionResult GetGridJson()
        {
            var data = resourceApp.GetList(Base_WebSiteId);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = resourceApp.GetForm(Base_WebSiteId, keyValue);
            return Content(data.ToJson());
        }
         
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(string DirName, string keyValue)
        {
            try
            {
                resourceApp.CreateDirById(Base_WebSiteId, keyValue, DirName);

                return Success("操作成功。");

            }
            catch (Exception ex)
            {
                return Error("操作失败。" + ex.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            resourceApp.DeleteForm(Base_WebSiteId, keyValue);
            return Success("删除成功。");
        } 
    }
}
