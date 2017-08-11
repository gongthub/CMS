using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.Repository.SystemManage;

namespace CMS.Repository.SystemManage
{
    public class UserLogOnRepository : SqlServerRepositoryBase<UserLogOnEntity>, IUserLogOnRepository
    {

    }
}
