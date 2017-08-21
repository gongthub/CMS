using CMS.Application.WebManage;
using CMS.Domain.Entity.WebManage;
using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using CMS.Application.Comm;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class WebSiteCommonController : Controller
    {
        private MessagesApp messagesApp = new MessagesApp();
        [HttpPost]
        public ActionResult SubmitMessage(MessagesEntity moduleEntity)
        {
            try
            {
                string webSiteIds = new WebSiteApp().GetWebSiteId(HttpContext.Request);
                moduleEntity.SessionId = HttpContext.Session.SessionID;
                moduleEntity.WebSiteId = webSiteIds;
                messagesApp.AddForm(moduleEntity);
                return Json(new { state = true, message = "提交成功。" });
            }
            catch (Exception e)
            {
                return Json(new { state = false, message = "提交失败。" + e.Message });
            }
        }

        [HttpPost]
        public ActionResult GetContentModels()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            object objDatas = RequestHelp.requestHelp.GetPageModels(context);
            return Json(objDatas);
        }
    }
}
