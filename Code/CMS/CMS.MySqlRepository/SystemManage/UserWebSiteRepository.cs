using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class UserWebSiteRepository : MySqlRepositoryBase<UserWebSiteEntity>, IUserWebSiteRepository
    {

    }
}
