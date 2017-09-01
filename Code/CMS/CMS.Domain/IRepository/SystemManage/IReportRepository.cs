using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.SystemManage
{
    public interface IReportRepository
    {
        List<WebSiteAccessReport> GetWebSiteAccessDates(string userIds);
        List<WebSiteAccessToDayReport> GetWebSiteAccessToDates(string webSiteId);
    }
}
