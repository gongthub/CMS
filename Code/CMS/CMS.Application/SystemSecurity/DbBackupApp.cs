using CMS.Code;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository.SystemSecurity;
using CMS.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemSecurity
{
    public class DbBackupApp
    {
        private IDbBackupRepository service = new DbBackupRepository();

        public List<DbBackupEntity> GetList(string queryJson)
        {
            var expression = ExtLinq.True<DbBackupEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                string keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "DbName":  
                        expression = expression.And(t => t.DbName.Contains(keyword));
                        break;
                    case "FileName":
                        expression = expression.And(t => t.FileName.Contains(keyword));
                        break;
                }
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.IQueryable(expression).OrderByDescending(t => t.BackupTime).ToList();
        }
        public DbBackupEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(m => m.Id == keyValue);
        }
        public void SubmitForm(DbBackupEntity dbBackupEntity)
        {
            dbBackupEntity.Id = Common.GuId();
            dbBackupEntity.EnabledMark = true;
            dbBackupEntity.BackupTime = DateTime.Now;

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                dbBackupEntity.CreatorUserId = LoginInfo.UserId;
            }
            dbBackupEntity.CreatorTime = DateTime.Now;
            service.ExecuteDbBackup(dbBackupEntity);
        }
    }
}
