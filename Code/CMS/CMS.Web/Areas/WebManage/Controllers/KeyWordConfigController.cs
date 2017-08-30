using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class KeyWordConfigController : ControllerBase
    {
        private KeyWordsApp keyWordApp = new KeyWordsApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = keyWordApp.GetListByWebSiteId(Base_WebSiteId, pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var data = keyWordApp.GetListByWebSiteId(Base_WebSiteId);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = keyWordApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitForm(KeyWordsEntity moduleEntity, string keyValue)
        {
            try
            {
                moduleEntity.WebSiteId = Base_WebSiteId;
                keyWordApp.SubmitForm(moduleEntity, keyValue);
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
            keyWordApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

    }
}
