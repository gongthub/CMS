using CMS.Application.Comm;
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

        public ColumnsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public ColumnsEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public ColumnsEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true).FirstOrDefault();
        }
        public ColumnsEntity GetFormByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true && m.WebSiteId == webSiteId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetMain()
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetMain(string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true && m.WebSiteId == webSiteId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName && m.WebSiteId == webSiteId).FirstOrDefault();
        }
        public List<ColumnsEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetList(Expression<Func<ColumnsEntity, bool>> predicate)
        {
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListNoDel()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListNoDel(Expression<Func<ColumnsEntity, bool>> predicate)
        {
            predicate.And(m => m.DeleteMark != true);
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListByWebSiteId(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除栏目信息=>" + keyValue, Enums.DbLogType.Delete, "栏目管理");
        }
        public void SubmitForm(ColumnsEntity moduleEntity, string keyValue)
        {
            if (!service.IsExist(keyValue, "ActionName", moduleEntity.ActionName, moduleEntity.WebSiteId, true))
            {
                if (!Common.IsSystemHaveName(moduleEntity.ActionName) && !Common.IsSearch(moduleEntity.ActionName))
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        if (moduleEntity.MainMark == true)
                        {
                            List<ColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.WebSiteId == moduleEntity.WebSiteId).ToList();
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
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "修改栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "栏目管理");
                    }
                    else
                    {
                        moduleEntity.Create();

                        if (moduleEntity.MainMark == true)
                        {
                            List<ColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.WebSiteId == moduleEntity.WebSiteId).ToList();
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
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "添加栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "栏目管理");
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
        public void AddModels(List<ColumnsEntity> moduleEntitys)
        {
            if (moduleEntitys != null && moduleEntitys.Count > 0)
            {
                foreach (var moduleEntity in moduleEntitys)
                {
                    AddModel(moduleEntity);
                }
            }
        }
        public void AddModel(ColumnsEntity moduleEntity)
        {
            if (!service.IsExist(null, "ActionName", moduleEntity.ActionName, moduleEntity.WebSiteId, true))
            {
                if (!Common.IsSystemHaveName(moduleEntity.ActionName) && !Common.IsSearch(moduleEntity.ActionName))
                {
                    moduleEntity.CreateNotId();

                    if (moduleEntity.MainMark == true)
                    {
                        List<ColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.WebSiteId == moduleEntity.WebSiteId).ToList();
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
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "添加栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "栏目管理");

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

    }
}
