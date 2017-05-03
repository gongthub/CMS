using CMS.Application.WebManage;
using CMS.Code;
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
    }
}
