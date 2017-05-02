using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<ColumnsEntity> GetList(Expression<Func<ColumnsEntity, bool>> predicate)
        {
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListByWebSiteId(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public ColumnsEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true).FirstOrDefault();
        }
        public ColumnsEntity GetFormByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.WebSiteId == webSiteId).FirstOrDefault();
        }
        public ColumnsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
        }
        public void SubmitForm(ColumnsEntity moduleEntity, string keyValue)
        {
            //if (!IsExistActionName(keyValue, moduleEntity.ActionName))
            if (!service.IsExist(keyValue, "ActionName", moduleEntity.ActionName, moduleEntity.WebSiteId, true))
            {
                if (!Common.IsSystemHaveName(moduleEntity.ActionName))
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
                else
                {
                    throw new Exception("简称已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("简称不能为系统保留名称，请重新输入！");
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
        public ColumnsEntity GetMain(string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.WebSiteId == webSiteId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.ActionName == actionName).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.ActionName == actionName && m.WebSiteId == webSiteId).FirstOrDefault();
        }


        /// <summary>
        /// 判断简称是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistActionName(string keyId, string name)
        {
            name = name.Trim();
            bool retBool = false;
            int flay = 0;   //标示位 判断是否需要查询
            if (!string.IsNullOrEmpty(keyId))
            {
                Guid id = Guid.Empty;
                ColumnsEntity moduleEntity = service.FindEntity(m => m.Id == keyId);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    if (moduleEntity.ActionName != name)
                    {
                        flay = 1;
                    }
                }
            }
            else
            {
                flay = 1;
            }
            //需要判断
            if (flay == 1)
            {
                Guid id = Guid.Empty;
                ColumnsEntity moduleEntity = service.FindEntity(m => m.ActionName == name && m.DeleteMark != true);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    retBool = true;
                }
            }
            return retBool;
        }
    }
}
