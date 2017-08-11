using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository;
using CMS.SqlServerRepository;

namespace CMS.SqlServerRepository
{
    public class FilterIPRepository : SqlServerRepositoryBase<FilterIPEntity>, IFilterIPRepository
    {
       
    }
}
