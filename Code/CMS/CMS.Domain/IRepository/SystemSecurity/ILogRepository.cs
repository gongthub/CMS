using CMS.Data;
using CMS.Domain.Entity.SystemSecurity;

namespace CMS.Domain.IRepository
{
    public interface ILogRepository : IRepositoryBase<LogEntity>
    {
        void AddDbLog(LogEntity logEntity);

        void WriteDbLog(bool result, string resultLog);
        void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type);
        void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type, string moduleName);
        void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type, string moduleName, string userName, string nickName);
    }
}
