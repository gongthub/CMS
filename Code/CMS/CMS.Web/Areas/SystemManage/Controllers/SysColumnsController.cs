using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class SysColumnsController : ControllerBase
    {
        private SysColumnsApp sysColumnsApp = new SysColumnsApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson(string sysTempletId)
        {
            var data = sysColumnsApp.GetListBySysTempletId(sysTempletId);
            var treeList = new List<TreeSelectModel>();
            foreach (SysColumnsEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.Id;
                treeModel.text = item.FullName;
                treeModel.parentId = item.ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson(string sysTempletId)
        {
            var data = sysColumnsApp.GetListBySysTempletId(sysTempletId);
            var treeList = new List<TreeViewModel>();
            foreach (SysColumnsEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                tree.id = item.Id;
                tree.text = item.FullName;
                tree.value = item.Type.ToString();
                tree.parentId = item.ParentId;
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTypeSelectJson()
        {
            List<EnumModel> models = EnumHelp.enumHelp.EnumToList(typeof(CMS.Code.Enums.ModuleType));
            //bool bState = new WebSiteConfigApp().IsAdvancedContent(Base_WebSiteId);
            //if (!bState)
            //{
            //    models = models.FindAll(m => m.Value != (int)CMS.Code.Enums.ModuleType.AdvancedList);
            //}
            return Content(models.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string sysTempletId,string keyword)
        {
            var data = sysColumnsApp.GetListBySysTempletId(sysTempletId);
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.FullName.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (SysColumnsEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.ParentId == item.Id) == 0 ? false : true;
                treeModel.id = item.Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.ParentId;
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = sysColumnsApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysColumnsEntity moduleEntity, string sysTempletId, string keyValue)
        {
            try
            {
                moduleEntity.SysTempletId = sysTempletId;
                sysColumnsApp.SubmitForm(moduleEntity, keyValue);
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
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            sysColumnsApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}
