using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    public class WebSiteMgrController : ControllerBase
    {
        private WebSiteApp webSiteApp = new WebSiteApp();
        private UserWebSiteApp userWebSiteApp = new UserWebSiteApp();


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGrid(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = webSiteApp.GetListForUserId(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string userId)
        {
            var data = webSiteApp.GetListForUserId();
            var treeList = new List<TreeViewModel>();
            var userWebSitedata = new List<UserWebSiteEntity>();
            if (!string.IsNullOrEmpty(userId))
            {
                userWebSitedata = userWebSiteApp.GetList(userId);
            }
            foreach (WebSiteEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.ShortName;
                tree.parentId = item.ParentId == null ? "0" : item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.hasChildren = true;
                tree.checkstate = userWebSitedata.Count(t => t.WebSiteId == item.Id);
                tree.img = "";
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        public ActionResult GetGridJson()
        {
            var data = webSiteApp.GetList();
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = webSiteApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SubmitForm(WebSiteEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            try
            { 
                webSiteApp.SubmitForm(moduleEntity, GetSpareUrlAddress(),keyValue, upFileentity);
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
            webSiteApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        /// <summary>
        /// 获取备用域名集合
        /// </summary>
        /// <returns></returns>
        private List<WebSiteForUrlEntity> GetSpareUrlAddress()
        {
            List<WebSiteForUrlEntity> webSiteForUrlEntitys = new List<WebSiteForUrlEntity>();
            List<string> strsUrlAddress = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                WebSiteForUrlEntity webSiteForUrlEntity = new WebSiteForUrlEntity();
                webSiteForUrlEntity.SortCode = i;
                webSiteForUrlEntity.MainMark = false;
                string paraNames = "SpareUrlAddress";
                if (i != 10)
                {
                    paraNames = paraNames + "0" + i;
                }
                else
                {
                    paraNames = paraNames + i;
                }
                string strurlAddress = HttpContext.Request[paraNames];
                if (strurlAddress != null)
                {

                    strurlAddress = strurlAddress.Trim();
                    if (strurlAddress == "&nbsp;")
                    {
                        strurlAddress = "";
                    }
                }
                webSiteForUrlEntity.UrlAddress = strurlAddress;
                webSiteForUrlEntitys.Add(webSiteForUrlEntity);
            }
            return webSiteForUrlEntitys;
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult ModifyForm()
        {
            return View();
        }
    }
}
