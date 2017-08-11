using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SqlServerRepository
{
    public class UserWebSiteRepository : SqlServerRepositoryBase<UserWebSiteEntity>, IUserWebSiteRepository
    {

    }
}
