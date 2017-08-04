using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.WebManage
{
    public interface IWebSiteConfigRepository : IRepositoryBase<WebSiteConfigEntity>
    {
        WebSiteConfigEntity GetFormByWebSiteId(string webSiteId);
        bool IsSearch(string webSiteId);
        bool IsService(string webSiteId);
        bool IsMessage(string webSiteId);
         bool IsAdvancedContent(string webSiteId);
    }
}
