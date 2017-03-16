using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [WebSiteMgr]
    public class ContentController : ControllerBase
    {
         
        private ContentApp c_contentApp = new ContentApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string itemId, string keyword)
        {
            var data = c_contentApp.GetList(itemId, keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = c_contentApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContentEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            try
            {
                moduleEntity.WebSiteId = Base_WebSiteId;
                c_contentApp.SubmitForm(moduleEntity, keyValue, upFileentity);
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            c_contentApp.DeleteFormById(keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult GetStaticPage(string keyValue)
        {
            c_contentApp.GetStaticPage(keyValue);
            return Success("生成成功。");
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult LinkForm()
        {
            return View();
        }
         
    }
}
