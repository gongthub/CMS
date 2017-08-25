using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class RequestLogRepository : MySqlRepositoryBase<RequestLogEntity>, IRequestLogRepository
    {
    }
}
