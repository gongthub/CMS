using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class ModuleApp
    {
        private IModuleRepository service = new ModuleRepository();

        public List<ModuleEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public ModuleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.DeleteById(t => t.Id == keyValue);
            }
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除菜单信息=>" + keyValue, Enums.DbLogType.Delete, "菜单管理");
        }
        public void SubmitForm(ModuleEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                service.Update(moduleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改菜单信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "菜单管理");
            }
            else
            {
                moduleEntity.Create();
                service.Insert(moduleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加菜单信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "菜单管理");
            }
        }
    }
}
