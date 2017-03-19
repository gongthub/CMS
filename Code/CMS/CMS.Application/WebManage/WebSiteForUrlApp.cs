using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
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
        private IWebSiteForUrlRepository service = new WebSiteForUrlRepository();


        public void Save(List<WebSiteForUrlEntity> webSiteForUrlEntitys)
        {
            if (webSiteForUrlEntitys != null && webSiteForUrlEntitys.Count > 0)
            {
                foreach (var webSiteForUrlEntity in webSiteForUrlEntitys)
                {
                    webSiteForUrlEntity.UrlAddress = webSiteForUrlEntity.UrlAddress.Trim();

                    WebSiteForUrlEntity TwebSiteForUrlEntity = service.IQueryable(m => m.DeleteMark != true && m.WebSiteId == webSiteForUrlEntity.WebSiteId && m.SortCode == webSiteForUrlEntity.SortCode).FirstOrDefault();
                    string TwebIds = string.Empty;
                    if (TwebSiteForUrlEntity != null)
                    {
                        TwebIds = TwebSiteForUrlEntity.Id;
                    }
                    if (!IsExistUrl(TwebIds, webSiteForUrlEntity.UrlAddress))
                    {
                        if (TwebSiteForUrlEntity != null && !string.IsNullOrEmpty(TwebSiteForUrlEntity.Id))
                        {
                            TwebSiteForUrlEntity.Modify(TwebSiteForUrlEntity.Id);
                            TwebSiteForUrlEntity.UrlAddress = webSiteForUrlEntity.UrlAddress;
                            service.Update(TwebSiteForUrlEntity);
                        }
                        else
                        {
                            webSiteForUrlEntity.Create();
                            service.Insert(webSiteForUrlEntity);
                        }
                    }
                    else
                    {

                        throw new Exception("域名：" + webSiteForUrlEntity.UrlAddress + "已绑定站点，请重新输入！");
                    }
                }
            }
        }

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


        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistUrl(string keyId, string url)
        {
            url = url.Trim();
            bool retBool = false;
            int flay = 0;   //标示位 判断是否需要查询
            if (!string.IsNullOrEmpty(keyId))
            {
                Guid id = Guid.Empty;
                WebSiteForUrlEntity moduleEntity = service.FindEntity(m => m.Id == keyId);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    if (moduleEntity.UrlAddress != url)
                    {
                        flay = 1;
                    }
                }
            }
            else
            {
                flay = 1;
            }
            //需要判断
            if (flay == 1)
            {
                Guid id = Guid.Empty;
                WebSiteForUrlEntity moduleEntity = service.FindEntity(m => m.UrlAddress == url && m.DeleteMark != true && m.UrlAddress != null && m.UrlAddress != "");
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    retBool = true;
                }
            }

            return retBool;
        }

        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistUrl(WebSiteEntity moduleEntity, string url)
        {
            moduleEntity.UrlAddress = moduleEntity.UrlAddress.Trim();

            WebSiteForUrlEntity TwebSiteForUrlEntity = service.IQueryable(m => m.DeleteMark != true && m.WebSiteId == moduleEntity.Id && m.SortCode == 0).FirstOrDefault();
            if (TwebSiteForUrlEntity != null)
                return IsExistUrl(TwebSiteForUrlEntity.Id, moduleEntity.UrlAddress);
            else
            {
                return IsExistUrl("", moduleEntity.UrlAddress);
            }
        }
    }
}
