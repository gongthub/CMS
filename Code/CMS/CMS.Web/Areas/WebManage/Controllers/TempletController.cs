using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class TempletController : ControllerBase
    {
        private TempletApp templetApp = new TempletApp();


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = templetApp.GetListByWebSiteId(pagination, keyword, Base_WebSiteId),
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
            var data = templetApp.GetListByWebSiteId(Base_WebSiteId);
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
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(TempletEntity moduleEntity, string keyValue)
        {
            try
            {
                moduleEntity.WebSiteId = Base_WebSiteId;
                moduleEntity.TempletType = (int)Code.Enums.TempletType.Common;
                templetApp.SubmitForm(moduleEntity, keyValue);
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
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            templetApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}