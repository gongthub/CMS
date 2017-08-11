﻿using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.Repository.SystemManage;
using System.Collections.Generic;

namespace CMS.Repository.SystemManage
{
    public class ModuleButtonRepository : SqlServerRepositoryBase<ModuleButtonEntity>, IModuleButtonRepository
    {
        public void SubmitCloneButton(List<ModuleButtonEntity> entitys)
        {
            using (var db = new SqlServerRepositoryBase().BeginTrans())
            {
                foreach (var item in entitys)
                {
                    db.Insert(item);
                }
                db.Commit();
            }
        }
    }
}
