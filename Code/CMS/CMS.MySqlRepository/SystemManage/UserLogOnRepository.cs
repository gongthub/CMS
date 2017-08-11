﻿using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;

namespace CMS.MySqlRepository
{
    public class UserLogOnRepository : SqlServerRepositoryBase<UserLogOnEntity>, IUserLogOnRepository
    {

        public void Init()
        {
            throw new System.NotImplementedException();
        }
    }
}
