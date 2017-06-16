using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.Application.Comm;

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class SysSettingController : ControllerBase
    {
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult ClearAll()
        {
            try
            {
                CacheHelp.cacheHelp.RemoveAll();
                return Success("清除成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }


        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult ClearRole()
        {
            try
            {
                CacheHelp.cacheHelp.RemoveAuthorizeurlDatas();
                return Success("清除成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }
    }
}
