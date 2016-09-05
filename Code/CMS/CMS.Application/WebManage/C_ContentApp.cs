using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class C_ContentApp
    {
        private IC_ContentRepository service = new C_ContentRepository();


        public List<C_ContentEntity> GetList(string itemId = "", string keyword = "")
        {
            List<C_ContentEntity> models = new List<C_ContentEntity>();
            var expression = ExtLinq.True<C_ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.F_ModuleId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
            }
            models = service.IQueryable(expression).OrderBy(t => t.F_SortCode).ToList();
            models.ForEach(delegate(C_ContentEntity model)
            {

                if (model != null && model.F_UrlAddress != null)
                {
                    model.F_UrlPage = model.F_UrlAddress;
                    model.F_UrlPage = model.F_UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }

        public List<C_ContentEntity> GetList()
        {
            List<C_ContentEntity> models = new List<C_ContentEntity>();
            models= service.IQueryable().OrderBy(t => t.F_SortCode).ToList();
            models.ForEach(delegate(C_ContentEntity model)
            {

                if (model != null && model.F_UrlAddress != null)
                {
                    model.F_UrlPage = model.F_UrlAddress;
                    model.F_UrlPage = model.F_UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }

        public List<C_ContentEntity> GetList(Pagination pagination, string keyword)
        {
            List<C_ContentEntity> models = new List<C_ContentEntity>();
            var expression = ExtLinq.True<C_ContentEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
            }
            models= service.FindList(expression, pagination);
            models.ForEach(delegate(C_ContentEntity model)
            {

                if (model != null && model.F_UrlAddress != null)
                {
                    model.F_UrlPage = model.F_UrlAddress;
                    model.F_UrlPage = model.F_UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public C_ContentEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(C_ContentEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                service.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();
                service.Insert(moduleEntity);
            }
        }


        public C_ModulesEntity GetModuleByContentID(string keyValue)
        {
            C_ModulesEntity module = new C_ModulesEntity();
            C_ModulesApp moduleapp = new C_ModulesApp();
            C_ContentEntity content = GetForm(keyValue);
            if (content != null)
            {
                module = moduleapp.GetForm(content.F_ModuleId);
            }
            return module;
        }

        public void GetStaticPage(string keyValue)
        {
            C_ModulesEntity module = GetModuleByContentID(keyValue);
            C_ContentEntity content = GetForm(keyValue);
            if (module != null)
            {
                C_TempletApp templetapp = new C_TempletApp();
                C_TempletEntity templet = templetapp.GetForm(module.F_TempletId);
                if (templet != null)
                {
                    string templets = System.Web.HttpUtility.HtmlDecode(templet.F_Content);
                    TempHelp temphelp = new TempHelp();
                    temphelp.GetHtmlPage(templets, keyValue);
                }
            }
        }
    }
}
