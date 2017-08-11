using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class ModuleButtonApp
    {
        private IModuleButtonRepository service = DataAccess.CreateIModuleButtonRepository();

        public List<ModuleButtonEntity> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<ModuleButtonEntity>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.ModuleId == moduleId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public ModuleButtonEntity GetForm(string keyValue)
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
            LogHelp.logHelp.WriteDbLog(true, "删除按钮信息=>" + keyValue, Enums.DbLogType.Delete, "按钮管理");
        }
        public void SubmitForm(ModuleButtonEntity moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.Modify(keyValue);
                service.Update(moduleButtonEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改按钮信息=>" + moduleButtonEntity.FullName, Enums.DbLogType.Update, "按钮管理");
            }
            else
            {
                moduleButtonEntity.Create();
                service.Insert(moduleButtonEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加按钮信息=>" + moduleButtonEntity.FullName, Enums.DbLogType.Create, "按钮管理");
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<ModuleButtonEntity> entitys = new List<ModuleButtonEntity>();
            foreach (string item in ArrayId)
            {
                ModuleButtonEntity moduleButtonEntity = data.Find(t => t.Id == item);
                moduleButtonEntity.Id = Common.GuId();
                moduleButtonEntity.ModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            service.SubmitCloneButton(entitys);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "克隆按钮信息=>" + ArrayId.ToString(), Enums.DbLogType.Create, "按钮管理");
        }
    }
}
