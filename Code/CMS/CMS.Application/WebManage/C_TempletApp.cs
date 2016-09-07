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
    public class C_TempletApp
    {
        private IC_TempletRepository service = new C_TempletRepository();

        public List<C_TempletEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_SortCode).ToList();
        }

        public C_TempletEntity GetFormByName(string Name)
        {
            C_TempletEntity model = new C_TempletEntity(); 
            model = service.FindEntity(m => m.F_FullName == Name && m.F_DeleteMark != true);
            return model;
        }
        public List<C_TempletEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<C_TempletEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_FullName.Contains(keyword)); 
            } 
            return service.FindList(expression, pagination);
        }
        public C_TempletEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(C_TempletEntity moduleEntity, string keyValue)
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

        /// <summary>
        /// 获取默认模板
        /// </summary>
        /// <returns></returns>
        public C_TempletEntity GetMain()
        {
            C_TempletEntity templet = new C_TempletEntity();
            C_ModulesApp moduleApp=new C_ModulesApp();
            C_ModulesEntity module = moduleApp.GetMain();
            if (module != null)
            {
                templet = service.FindEntity(m => m.F_Id == module.F_TempletId);
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取模板
        /// </summary>
        /// <returns></returns>
        public C_TempletEntity GetModelByActionName(string actionName)
        {
            C_TempletEntity templet = new C_TempletEntity();
            C_ModulesApp moduleApp = new C_ModulesApp();
            C_ModulesEntity module = moduleApp.GetModelByActionName(actionName);
            if (module != null)
            {
                templet = service.FindEntity(m => m.F_Id == module.F_TempletId);
            }
            return templet;
        }
    }
}
