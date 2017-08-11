using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
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
        private ISysColumnsRepository service = DataAccess.CreateISysColumnsRepository;

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


    }
}
