using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class SysTempletItemsApp
    {
        private ISysTempletItemsRepository service = DataAccess.CreateISysTempletItemsRepository();

        public List<SysTempletItemsEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public List<SysTempletItemsEntity> GetList(string parentIds)
        {
            var expression = ExtLinq.True<SysTempletItemsEntity>(); 
            expression = expression.And(t => t.DeleteMark != true && t.ParentId == parentIds);
            return service.IQueryable(expression).ToList();
        }
        public List<SysTempletItemsEntity> GetList(Pagination pagination, string parentIds, string keyword)
        {
            var expression = ExtLinq.True<SysTempletItemsEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true && t.ParentId == parentIds);
            return service.FindList(expression, pagination);
        }
        public SysTempletItemsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public bool IsExist(string parentIds)
        {
            bool bState = false;
            List<SysTempletItemsEntity> models = service.IQueryable(m => m.DeleteMark != true && m.ParentId == parentIds).ToList();
            if (models != null && models.Count > 0)
            {
                bState = true;
            }
            return bState;
        }

        public void DeleteForm(string keyValue)
        { 
            if (IsExist(keyValue))
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.DeleteById(t => t.Id == keyValue);
            }
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除系统模板内容信息=>" + keyValue, Enums.DbLogType.Delete, "系统模板内容管理");
        }
        public void SubmitForm(SysTempletItemsEntity moduleEntity, string keyValue)
        {
            if (moduleEntity.FullName.ToLower() != ConfigHelp.configHelp.WEBSITESEARCHPATH.ToLower())
            {
                if (!service.IsExist(keyValue, "FullName", moduleEntity.FullName, true))
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        service.Update(moduleEntity);
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "修改模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "模板管理");
                    }
                    else
                    {
                        moduleEntity.Create();
                        service.Insert(moduleEntity);
                        //添加日志
                        LogHelp.logHelp.WriteDbLog(true, "添加模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "模板管理");
                    }
                }
                else
                {
                    throw new Exception("名称已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("名称不能为系统保留名称，请重新输入！");
            }
        }
    }
}
