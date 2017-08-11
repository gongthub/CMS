﻿using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;

namespace CMS.Domain.IRepository
{
    public interface IDbBackupRepository : IRepositoryBase<DbBackupEntity>
    {
        void DeleteForm(string keyValue);
        void ExecuteDbBackup(DbBackupEntity dbBackupEntity);
    }
}
