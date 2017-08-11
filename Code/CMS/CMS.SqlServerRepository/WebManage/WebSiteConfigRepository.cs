using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SqlServerRepository
{
    public class WebSiteConfigRepository : SqlServerRepositoryBase<WebSiteConfigEntity>, IWebSiteConfigRepository
    {
        public WebSiteConfigEntity GetFormByWebSiteId(string webSiteId)
        {
            WebSiteConfigEntity webSiteConfigEntity = new WebSiteConfigEntity();
            var expression = ExtLinq.True<WebSiteConfigEntity>();
            expression = expression.And(t => t.DeleteMark != true && t.WebSiteId == webSiteId);
            webSiteConfigEntity = IQueryable(expression).FirstOrDefault();
            return webSiteConfigEntity;
        }
        public bool IsSearch(string webSiteId)
        {
            bool bState = false;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    bState = webSiteConfigEntity.SearchEnabledMark;
                }
                else
                {
                    bState = false;
                }
            }
            catch
            {
                bState = false;
            }
            return bState;
        }
        public bool IsService(string webSiteId)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    bState = webSiteConfigEntity.ServiceEnabledMark;
                }
                else
                {
                    bState = true;
                }
            }
            catch
            {
                bState = true;
            }
            return bState;
        }
        public bool IsMessage(string webSiteId)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    bState = webSiteConfigEntity.MessageEnabledMark;
                }
                else
                {
                    bState = true;
                }
            }
            catch
            {
                bState = true;
            }
            return bState;
        }
        public bool IsAdvancedContent(string webSiteId)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    bState = webSiteConfigEntity.AdvancedContentEnabledMark;
                }
                else
                {
                    bState = true;
                }
            }
            catch
            {
                bState = true;
            }
            return bState;
        }
    }
}
