using CMS.Application.Comm;
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
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加站点配置信息=>" + webSiteConfigEntity.WebSiteId, Enums.DbLogType.Create, "站点配置");
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
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置全站搜索=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + searchEnabled, Enums.DbLogType.Create, "站点配置=>全站搜索");
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
        public bool UpdateMessageEnableByWebSiteId(string webSiteId, bool messageEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.MessageEnabledMark = messageEnabled;
                    service.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置留言板=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + messageEnabled, Enums.DbLogType.Create, "站点配置=>留言板");
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

        public bool UpdateServiceEnableByWebSiteId(string webSiteId, bool serviceEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.ServiceEnabledMark = serviceEnabled;
                    service.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置站点维护=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + serviceEnabled, Enums.DbLogType.Create, "站点配置=>站点维护");
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
    }
}
