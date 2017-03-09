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
    public class TempletApp
    {
        private ITempletRepository service = new TempletRepository();

        public List<TempletEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }

        public TempletEntity GetFormByName(string Name)
        {
            TempletEntity model = new TempletEntity();
            model = service.FindEntity(m => m.FullName == Name && m.DeleteMark != true);
            return model;
        }
        public List<TempletEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<TempletEntity>();
            expression = expression.And(m => m.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<TempletEntity> GetListByWebSiteId(string WebSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<TempletEntity> GetListByWebSiteId(Pagination pagination, string keyword, string WebSiteId)
        {
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            return service.FindList(expression, pagination);
        }
        public TempletEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.Id == keyValue);
        }
        public void SubmitForm(TempletEntity moduleEntity, string keyValue)
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
        public TempletEntity GetMain()
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetMain();
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId);
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByActionName(string actionName)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName);
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId);
            }
            return templet;
        }
    }
}
