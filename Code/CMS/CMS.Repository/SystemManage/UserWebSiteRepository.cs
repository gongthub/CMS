using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.SystemManage
{
    public class UserWebSiteRepository : SqlServerRepositoryBase<UserWebSiteEntity>, IUserWebSiteRepository
    {

    }
}
