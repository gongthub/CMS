using CMS.Application.SystemSecurity;
using CMS.Code;
using CMS.Domain.Entity.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class LogHelp
    {
        private static LogApp logApp = new LogApp();


        #region 单例模式创建对象
        //单例模式创建对象
        private static LogHelp _logHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        LogHelp()
        {
        }

        public static LogHelp logHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _logHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _logHelp)
                        {
                            _logHelp = new LogHelp();
                        }
                    }
                }
                return _logHelp;
            }
        }
        #endregion

        public void WriteDbLog(bool result, string resultLog)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Account = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserCode;
            logEntity.NickName = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            logApp.AddDbLog(logEntity);
        }
        public void WriteDbLog(bool result, string resultLog, CMS.Code.Enums.DbLogType type)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.Type = type.ToString();
            logEntity.Account = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserCode;
            logEntity.NickName = SysLoginObjHelp.sysLoginObjHelp.GetOperator().UserName;
            logEntity.Result = result;
            logEntity.Description = resultLog;
            logApp.AddDbLog(logEntity);
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
            logApp.AddDbLog(logEntity);
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
            logApp.AddDbLog(logEntity);
        }
    }
}
