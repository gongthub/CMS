using CMS.Application.SystemManage;
using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc; 

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class SysTempletResourceController : ControllerBase
    {
        private SysTempletsApp sysTempletsApp = new SysTempletsApp();


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string parentId)
        {
            var data = sysTempletsApp.GeResourcetList(parentId);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string parentId, string keyValue)
        {
            sysTempletsApp.DeleteResourceForm(parentId, keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        public ActionResult SubmitFormAdd(string parentId, string DirName, string keyValue)
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
