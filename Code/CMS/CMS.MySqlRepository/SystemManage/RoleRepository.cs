using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using System.Collections.Generic;

namespace CMS.MySqlRepository
{
    public class RoleRepository : SqlServerRepositoryBase<RoleEntity>, IRoleRepository
    {
        private ILogRepository iLogRepository = new LogRepository();
        public void DeleteForm(string keyValue)
        {
            using (var db = new SqlServerRepositoryBase().BeginTrans())
            {
                db.Delete<RoleEntity>(t => t.Id == keyValue);
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(RoleEntity roleEntity, List<RoleAuthorizeEntity> roleAuthorizeEntitys, string keyValue)
        {
            using (var db = new SqlServerRepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(roleEntity);
                    //添加日志
                    iLogRepository.WriteDbLog(true, "修改角色信息=>" + roleEntity.FullName, Enums.DbLogType.Update, "角色管理");
                }
                else
                {
                    roleEntity.Category = 1;
                    db.Insert(roleEntity);
                    //添加日志
                    iLogRepository.WriteDbLog(true, "添加角色信息=>" + roleEntity.FullName, Enums.DbLogType.Create, "角色管理");
                }
                db.Delete<RoleAuthorizeEntity>(t => t.ObjectId == roleEntity.Id);
                db.Insert(roleAuthorizeEntitys);
                db.Commit();
            }
        }
    }
}
