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
    public class ItemsApp
    {
        private IItemsRepository service = new ItemsRepository();

        public List<ItemsEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public ItemsEntity GetForm(string keyValue)
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
            LogHelp.logHelp.WriteDbLog(true, "删除字典信息=>" + keyValue, Enums.DbLogType.Delete, "字典管理");
        }
        public void SubmitForm(ItemsEntity itemsEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsEntity.Modify(keyValue);
                service.Update(itemsEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改字典信息=>" + itemsEntity.FullName, Enums.DbLogType.Update, "字典管理");
            }
            else
            {
                itemsEntity.Create();
                service.Insert(itemsEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加字典信息=>" + itemsEntity.FullName, Enums.DbLogType.Create, "字典管理");
            }
        }
    }
}
