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
    public class ColumnsApp
    {
        private IColumnsRepository service = new ColumnsRepository();

        public List<ColumnsEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListByWebSiteId(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public ColumnsEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true).FirstOrDefault();
        }
        public ColumnsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.Id == keyValue);
        }
        public void SubmitForm(ColumnsEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                if (moduleEntity.MainMark == true)
                {
                    List<ColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        models.ForEach(delegate(ColumnsEntity model)
                        {
                            model.MainMark = false;
                            service.Update(model);
                        });
                    }
                }
                service.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();

                if (moduleEntity.MainMark == true)
                {
                    List<ColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        models.ForEach(delegate(ColumnsEntity model)
                        {
                            model.MainMark = false;
                            service.Update(model);
                        });
                    }
                }
                service.Insert(moduleEntity);
            }
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetMain()
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.ActionName == actionName).FirstOrDefault();
        }


    }
}
