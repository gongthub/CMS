using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class ReportApp
    {
        private static IReportRepository service = DataAccess.CreateIReportRepository();

        public List<WebSiteAccessReport> GetWebSiteAccessDates()
        {
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            string userIds = string.Empty;
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    userIds = null;
                }
                else
                {
                    userIds = LoginInfo.UserId;
                }
            }
            return service.GetWebSiteAccessDates(userIds);
        }
    }
}
