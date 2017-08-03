using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository.SystemSecurity;
using CMS.Repository.SystemSecurity;
using System;

namespace CMS.Repository.SystemSecurity
{
    public class LogRepository : RepositoryBase<LogEntity>, ILogRepository
    {
        public void AddDbLog(LogEntity logEntity)
        {
            logEntity.Id = Common.GuId();
            logEntity.Date = DateTime.Now;
            logEntity.IPAddress = Net.Ip;
            logEntity.IPAddressName = Net.GetLocation(logEntity.IPAddress);
            logEntity.Create();
            Insert(logEntity);
        }
    }
}
