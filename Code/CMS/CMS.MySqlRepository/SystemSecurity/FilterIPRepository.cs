using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;

namespace CMS.MySqlRepository
{
    public class FilterIPRepository : SqlServerRepositoryBase<FilterIPEntity>, IFilterIPRepository
    {
       
    }
}
