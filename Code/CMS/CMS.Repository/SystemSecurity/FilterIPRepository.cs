using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository;
using CMS.Repository.SystemSecurity;

namespace CMS.Repository.SystemSecurity
{
    public class FilterIPRepository : SqlServerRepositoryBase<FilterIPEntity>, IFilterIPRepository
    {
       
    }
}
