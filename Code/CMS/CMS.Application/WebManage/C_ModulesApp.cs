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
    public class C_ModulesApp
    {
        private IC_ModulesRepository service  = new C_ModulesRepository();
         
        public List<C_ModulesEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.F_SortCode).ToList();
        }
        public C_ModulesEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.F_ActionName.ToLower() == actionName.ToLower() && m.F_DeleteMark != true).FirstOrDefault();
        }
        public C_ModulesEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.F_Id == keyValue);
        }
        public void SubmitForm(C_ModulesEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                if (moduleEntity.F_MainMark == true)
                {
                    List<C_ModulesEntity> models = service.IQueryable().Where(m => m.F_DeleteMark != true && m.F_Id != moduleEntity.F_Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        models.ForEach(delegate(C_ModulesEntity model)
                        {
                            model.F_MainMark = false;
                            service.Update(model);
                        });
                    }
                }
                service.Update(moduleEntity);
            }
            else
            {
                moduleEntity.Create();

                if (moduleEntity.F_MainMark == true)
                {
                    List<C_ModulesEntity> models = service.IQueryable().Where(m => m.F_DeleteMark != true && m.F_Id != moduleEntity.F_Id).ToList();
                    if (models != null && models.Count > 0)
                    {
                        models.ForEach(delegate(C_ModulesEntity model)
                        {
                            model.F_MainMark = false;
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
        public C_ModulesEntity GetMain()
        {
            return service.IQueryable().Where(m => m.F_DeleteMark != true && m.F_MainMark == true).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public C_ModulesEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.F_DeleteMark != true && m.F_ActionName == actionName).FirstOrDefault();
        }


    }
}
