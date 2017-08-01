using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class SysColumnsApp
    {
        private ISysColumnsRepository service = new SysColumnsRepository();

        public SysColumnsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public SysColumnsEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public SysColumnsEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true).FirstOrDefault();
        }
        public SysColumnsEntity GetFormByActionName(string actionName, string sysTempletId)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true && m.SysTempletId == sysTempletId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public SysColumnsEntity GetMain()
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public SysColumnsEntity GetMain(string sysTempletId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true && m.SysTempletId == sysTempletId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public SysColumnsEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public SysColumnsEntity GetModelByActionName(string actionName, string sysTempletId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName && m.SysTempletId == sysTempletId).FirstOrDefault();
        }
        public List<SysColumnsEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<SysColumnsEntity> GetList(Expression<Func<SysColumnsEntity, bool>> predicate)
        {
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<SysColumnsEntity> GetListNoDel()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<SysColumnsEntity> GetListNoDel(Expression<Func<SysColumnsEntity, bool>> predicate)
        {
            predicate.And(m => m.DeleteMark != true);
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId)
        {
            return service.IQueryable(m => m.SysTempletId == sysTempletId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除系统模板栏目信息=>" + keyValue, Enums.DbLogType.Delete, "系统模板栏目管理");
        }
        public void SubmitForm(SysColumnsEntity moduleEntity, string keyValue)
        {
            if (!service.IsExistAndMarkName(keyValue, "ActionName", moduleEntity.ActionName, "SysTempletId", moduleEntity.SysTempletId, true))
            {
                if (!Common.IsSystemHaveName(moduleEntity.ActionName) && !Common.IsSearch(moduleEntity.ActionName))
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        if (moduleEntity.MainMark == true)
                        {
                            List<SysColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.SysTempletId == moduleEntity.SysTempletId).ToList();
                            if (models != null && models.Count > 0)
                            {
                                models.ForEach(delegate(SysColumnsEntity model)
                                {
                                    model.MainMark = false;
                                    service.Update(model);
                                });
                            }
                        }

                        service.Update(moduleEntity);
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "修改系统模板栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "系统模板栏目管理");
                    }
                    else
                    {
                        moduleEntity.Create();

                        if (moduleEntity.MainMark == true)
                        {
                            List<SysColumnsEntity> models = service.IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.SysTempletId == moduleEntity.SysTempletId).ToList();
                            if (models != null && models.Count > 0)
                            {
                                models.ForEach(delegate(SysColumnsEntity model)
                                {
                                    model.MainMark = false;
                                    service.Update(model);
                                });
                            }
                        }
                        service.Insert(moduleEntity);
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "添加系统模板栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "系统模板栏目管理");
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
        /// 复制栏目到指定网站
        /// </summary>
        /// <param name="sysTempletId"></param>
        /// <param name="webSiteId"></param>
        public List<ColumnsEntity> CopyToWebSite(string sysTempletId, string webSiteId)
        {
            List<ColumnsEntity> cmodels = new List<ColumnsEntity>();
            if (!string.IsNullOrEmpty(webSiteId))
            {
                List<SysColumnsEntity> models = GetListBySysTempletId(sysTempletId);

                List<TempletEntity> tempModels = new TempletApp().GetListByWebSiteId(webSiteId);
                List<SysTempletItemsEntity> systempsModels = new SysTempletsApp().GetItemList(sysTempletId);

                if (models != null && models.Count > 0)
                {
                    foreach (SysColumnsEntity model in models)
                    {
                        string strNewIds = Guid.NewGuid().ToString();
                        models.ForEach(delegate(SysColumnsEntity m)
                        {
                            if (m.ParentId == model.Id)
                            {
                                m.ParentId = strNewIds;
                            }
                            if (systempsModels != null && systempsModels.Count > 0
                                && tempModels != null && tempModels.Count > 0)
                            {
                                SysTempletItemsEntity systempsModelT = systempsModels.Find(t => t.Id == m.TempletId);
                                SysTempletItemsEntity systempsModelCT = systempsModels.Find(t => t.Id == m.CTempletId);
                                if (systempsModelT != null && !string.IsNullOrEmpty(systempsModelT.Id))
                                {
                                    TempletEntity tempModelT = tempModels.Find(t => t.FullName == systempsModelT.FullName);
                                    if (tempModelT != null && !string.IsNullOrEmpty(tempModelT.Id))
                                    {
                                        m.TempletId = tempModelT.Id;
                                    }
                                }
                                if (systempsModelCT != null && !string.IsNullOrEmpty(systempsModelCT.Id))
                                {
                                    TempletEntity tempModelCT = tempModels.Find(t => t.FullName == systempsModelCT.FullName);
                                    if (tempModelCT != null && !string.IsNullOrEmpty(tempModelCT.Id))
                                    {
                                        m.CTempletId = tempModelCT.Id;
                                    }
                                }
                            }

                        });
                        model.Id = strNewIds;
                    }
                    cmodels = InitColumnsEntity(webSiteId, cmodels, models);
                    new ColumnsApp().AddModels(cmodels);
                }
            }
            return cmodels;
        }

        /// <summary>
        /// 处理网站栏目实体
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="cmodels"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        private static List<ColumnsEntity> InitColumnsEntity(string webSiteId, List<ColumnsEntity> cmodels, List<SysColumnsEntity> models)
        {
            cmodels = (from list in models
                       select new ColumnsEntity
                       {
                           Id = list.Id,
                           WebSiteId = webSiteId,
                           ParentId = list.ParentId,
                           TempletId = list.TempletId,
                           CTempletId = list.CTempletId,
                           SortCode = list.SortCode,
                           FullName = list.FullName,
                           Type = list.Type,
                           ActionName = list.ActionName,
                           Description = list.Description,
                           UrlPath = list.UrlPath,
                           UrlAddress = list.UrlAddress,
                           Icon = list.Icon,
                           EnabledMark = list.EnabledMark,
                           DeleteMark = list.DeleteMark,
                           MainMark = list.MainMark,
                           CreatorUserId = list.CreatorUserId,
                           CreatorTime = list.CreatorTime,
                           DeleteUserId = list.DeleteUserId,
                           DeleteTime = list.DeleteTime,
                           LastModifyUserId = list.LastModifyUserId,
                           LastModifyTime = list.LastModifyTime
                       }).ToList();
            return cmodels;
        }

    }
}
