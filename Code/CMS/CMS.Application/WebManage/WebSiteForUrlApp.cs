using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class WebSiteForUrlApp
    {
        private IWebSiteForUrlRepository service = DataAccess.CreateIWebSiteForUrlRepository;

        public List<WebSiteForUrlEntity> GetListByWebSiteId(string webSiteId)
        {
            List<WebSiteForUrlEntity> webSiteForUrlEntitys = new List<WebSiteForUrlEntity>();
            webSiteForUrlEntitys = service.IQueryable(m => m.DeleteMark != true && m.WebSiteId == webSiteId).OrderBy(m => m.SortCode).ToList();
            return webSiteForUrlEntitys;
        }

        public void InitWebSiteUrl(ref WebSiteEntity webSiteEntity)
        {
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                List<WebSiteForUrlEntity> webSiteForUrlEntitys = GetListByWebSiteId(webSiteEntity.Id);
                if (webSiteForUrlEntitys != null && webSiteForUrlEntitys.Count > 0)
                {
                    PropertyInfo[] props = webSiteEntity.GetType().GetProperties();
                    foreach (var webSiteForUrlEntity in webSiteForUrlEntitys)
                    {
                        string propNames = "SpareUrlAddress";
                        if (webSiteForUrlEntity.SortCode != 0 && webSiteForUrlEntity.SortCode < 10)
                        {
                            propNames = propNames + "0" + webSiteForUrlEntity.SortCode;
                        }
                        else
                        {
                            propNames = propNames + webSiteForUrlEntity.SortCode;
                        }
                        PropertyInfo prop = props.FirstOrDefault(m => m.Name.ToLower() == propNames.ToLower());
                        if (prop != null)
                        {
                            prop.SetValue(webSiteEntity, webSiteForUrlEntity.UrlAddress, null);
                        }
                    }
                }
            }
        }

    }
}
