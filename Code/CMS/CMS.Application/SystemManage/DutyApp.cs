using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class DutyApp
    {
        private IRoleRepository service = DataAccess.CreateIRoleRepository;

        public List<RoleEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 2);
            expression = expression.And(t => t.DeleteMark!=true);
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public List<RoleEntity> GetList(string keyword, Pagination pagination)
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 2);
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        public RoleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除岗位信息=>" + keyValue, Enums.DbLogType.Delete, "岗位管理");
        }
        public void SubmitForm(RoleEntity roleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                service.Update(roleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改岗位信息=>" + roleEntity.FullName, Enums.DbLogType.Update, "岗位管理");
            }
            else
            {
                roleEntity.Create();
                roleEntity.Category = 2;
                service.Insert(roleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加岗位信息=>" + roleEntity.FullName, Enums.DbLogType.Create, "岗位管理");
            }
        }
    }
}
