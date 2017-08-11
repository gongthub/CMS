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
    public class AreaApp
    {
        private IAreaRepository service = DataAccess.CreateIAreaRepository;

        public List<AreaEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public AreaEntity GetForm(string keyValue)
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
            LogHelp.logHelp.WriteDbLog(true, "删除区域信息=>" + keyValue, Enums.DbLogType.Delete, "区域管理");
        }
        public void SubmitForm(AreaEntity areaEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                areaEntity.Modify(keyValue);
                service.Update(areaEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改区域信息=>" + areaEntity.FullName, Enums.DbLogType.Update, "区域管理");
            }
            else
            {
                areaEntity.Create();
                service.Insert(areaEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加区域信息=>" + areaEntity.FullName, Enums.DbLogType.Create, "区域管理");
            }
        }
    }
}
