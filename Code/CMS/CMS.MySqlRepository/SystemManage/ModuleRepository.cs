﻿using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;

namespace CMS.MySqlRepository
{
    public class ModuleRepository : MySqlRepositoryBase<ModuleEntity>, IModuleRepository
    {
    }
}
