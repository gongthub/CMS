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


        public void WriteDbLog(bool result, string resultLog)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Account = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserCode;
            logEntity.NickName = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            AddDbLog(logEntity);
        }
        public void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Type = type.ToString();
            logEntity.Account = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserCode;
            logEntity.NickName = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            AddDbLog(logEntity);
        }
        public void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type, string moduleName)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Type = type.ToString();
            logEntity.ModuleName = moduleName;
            logEntity.Account = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserCode;
            logEntity.NickName = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            AddDbLog(logEntity);
        }
        public void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type, string moduleName, string userName, string nickName)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Type = type.ToString();
            logEntity.ModuleName = moduleName;
            logEntity.Account = userName;
            logEntity.NickName = nickName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            AddDbLog(logEntity);
        }
    }
}
