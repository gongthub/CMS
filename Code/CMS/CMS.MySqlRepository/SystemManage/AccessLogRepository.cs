using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class AccessLogRepository : SqlServerRepositoryBase<AccessLogEntity>, IAccessLogRepository
    {
    }
}
