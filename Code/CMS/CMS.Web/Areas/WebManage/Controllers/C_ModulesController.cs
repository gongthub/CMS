using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc; 

namespace CMS.Web.Areas.WebManage.Controllers
{
    public class C_ModulesController : ControllerBase
    {
         

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            var data = c_ModulesApp.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (C_ModulesEntity item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_FullName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeJson()
        {
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            var data = c_ModulesApp.GetList();
            var treeList = new List<TreeViewModel>();
            foreach (C_ModulesEntity item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                tree.id = item.F_Id;
                tree.text = item.F_FullName;
                tree.value = item.F_Type.ToString();
                tree.parentId = item.F_ParentId;
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
             
            return Content(models.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeGridJson(string keyword)
        {
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            var data = c_ModulesApp.GetList();
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_FullName.Contains(keyword));
            }
            var treeList = new List<TreeGridModel>();
            foreach (C_ModulesEntity item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.F_ParentId == item.F_Id) == 0 ? false : true;
                treeModel.id = item.F_Id;
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.F_ParentId;
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
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            var data = c_ModulesApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(C_ModulesEntity moduleEntity, string keyValue)
        {
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            c_ModulesApp.SubmitForm(moduleEntity, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            c_ModulesApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }
    }
}