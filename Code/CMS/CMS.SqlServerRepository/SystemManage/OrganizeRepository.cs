﻿using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.SqlServerRepository;

namespace CMS.SqlServerRepository
{
    public class OrganizeRepository : SqlServerRepositoryBase<OrganizeEntity>, IOrganizeRepository
    {

    }
}
