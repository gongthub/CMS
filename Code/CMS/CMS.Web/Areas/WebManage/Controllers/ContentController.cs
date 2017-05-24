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
        public ActionResult SubmitForm(ContentEntity moduleEntity, string keyValue)
        {
            try
            {
                List<UpFileDTO> upFileentitys = new List<UpFileDTO>();
                if (HttpContext.Request["upFileentitys"] != null)
                {
                    string strupFiles = HttpContext.Request["upFileentitys"].ToString();
                    upFileentitys = JsonConvert.DeserializeObject<List<UpFileDTO>>(strupFiles);
                }
                moduleEntity.WebSiteId = Base_WebSiteId;
                c_contentApp.SubmitForm(moduleEntity, keyValue, upFileentitys);
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
            c_contentApp.GenStaticPage(keyValue);
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
