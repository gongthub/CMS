using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class WebSiteConfigApp
    {
        private IWebSiteConfigRepository service = new WebSiteConfigRepository();

        public WebSiteConfigEntity GetFormByWebSiteId(string webSiteId)
        {
            WebSiteConfigEntity webSiteConfigEntity = new WebSiteConfigEntity();
            var expression = ExtLinq.True<WebSiteConfigEntity>();
            expression = expression.And(t => t.DeleteMark != true && t.WebSiteId == webSiteId);
            webSiteConfigEntity = service.IQueryable(expression).FirstOrDefault();
            return webSiteConfigEntity;
        }


        public void AddWebSiteConfig(string webSiteId)
        {
            if (!service.IsExist(string.Empty, "WebSiteId", webSiteId, true))
            {
                WebSiteConfigEntity webSiteConfigEntity = new WebSiteConfigEntity();
                webSiteConfigEntity.WebSiteId = webSiteId;
                webSiteConfigEntity.SearchEnabledMark = false;
                webSiteConfigEntity.Create();
                service.Insert(webSiteConfigEntity);
            }
        }
        public bool UpdateSearchEnableByWebSiteId(string webSiteId, bool searchEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.SearchEnabledMark = searchEnabled;
                    service.Update(webSiteConfigEntity);
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
    }
}
