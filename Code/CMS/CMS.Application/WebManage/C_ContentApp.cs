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
        private static IC_ContentRepository service = new C_ContentRepository();
         

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

        public IQueryable<C_ContentEntity> GetListIq(string itemId = "", string keyword = "")
        {
            IQueryable<C_ContentEntity> models;
            var expression = ExtLinq.True<C_ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.F_ModuleId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword));
            }
            models = service.IQueryable(expression).OrderBy(t => t.F_SortCode);

            return models;
        }

        public List<C_ContentEntity> GetList()
        {
            List<C_ContentEntity> models = new List<C_ContentEntity>();
            models = service.IQueryable().OrderBy(t => t.F_SortCode).ToList();
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
            models = service.FindList(expression, pagination);
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

                string mIds = moduleEntity.F_ModuleId;
                C_ModulesApp c_ModulesApp = new C_ModulesApp();
                C_ModulesEntity cmModel = c_ModulesApp.GetForm(mIds);
                if (JudgmentHelp.judgmentHelp.IsNullEntity<C_ModulesEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.F_Id))
                {
                    string urlAddress = @"\" + cmModel.F_ActionName + @"\" + moduleEntity.F_Id;
                    moduleEntity.F_UrlAddress = urlAddress;
                    SubmitForm(moduleEntity, moduleEntity.F_Id);
                }
            }
        }


        public C_ModulesEntity GetModuleByContentID(string keyValue)
        {
            C_ModulesEntity moduleEntity = new C_ModulesEntity();
            C_ContentEntity contentEntity = GetForm(keyValue);
            C_ModulesApp c_ModulesApp = new C_ModulesApp();
            if (JudgmentHelp.judgmentHelp.IsNullEntity<C_ContentEntity>(contentEntity) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(contentEntity.F_ModuleId))
            {
                moduleEntity = c_ModulesApp.GetForm(contentEntity.F_ModuleId);
            }
            return moduleEntity;
        }

        public void GetStaticPage(string keyValue)
        {
            C_ModulesEntity module = GetModuleByContentID(keyValue);
            C_ContentEntity content = GetForm(keyValue);
            if (module != null)
            {
                C_TempletApp templetapp = new C_TempletApp();
                C_TempletEntity templet = templetapp.GetForm(module.F_CTempletId);
                if (templet != null)
                {
                    string templets = System.Web.HttpUtility.HtmlDecode(templet.F_Content);

                    TempHelp.tempHelp.GenHtmlPage(templets, keyValue);
                }
            }
        }

        /// <summary>
        /// 获取静态HTML
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public string GetStaticHtmls(string keyValue)
        {
            string htmls = "";
            C_ModulesEntity module = GetModuleByContentID(keyValue);
            C_ContentEntity content = GetForm(keyValue);
            if (module != null)
            {
                C_TempletApp templetapp = new C_TempletApp();
                C_TempletEntity templet = templetapp.GetForm(module.F_CTempletId);
                if (templet != null)
                {
                    string templets = System.Web.HttpUtility.HtmlDecode(templet.F_Content);

                    TempHelp.tempHelp.GenHtmlPage(templets, keyValue);
                    htmls = TempHelp.tempHelp.GetHtmlPages(templets, keyValue);
                }
            }

            return htmls;
        }
    }
}
