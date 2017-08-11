using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.SystemManage
{
    public class AccessLogRepository
    {
        public AccessLogRepository()
        {
            new SqlServerRepository.UserWebSiteRepository();
        }
    }
}
