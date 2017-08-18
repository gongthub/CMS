using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class WebSiteForUrlRepository : MySqlRepositoryBase<WebSiteForUrlEntity>, IWebSiteForUrlRepository
    {
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
                WebSiteForUrlEntity moduleEntity = FindEntity(m => m.Id == keyId);
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
                WebSiteForUrlEntity moduleEntity = FindEntity(m => m.UrlAddress == url && m.DeleteMark != true && m.UrlAddress != null && m.UrlAddress != "");
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

            WebSiteForUrlEntity TwebSiteForUrlEntity = IQueryable(m => m.DeleteMark != true && m.WebSiteId == moduleEntity.Id && m.SortCode == 0).FirstOrDefault();
            if (TwebSiteForUrlEntity != null)
            {
                return IsExist(TwebSiteForUrlEntity.Id, "UrlAddress", moduleEntity.UrlAddress, true);
            }
            else
            {
                return IsExist("", "UrlAddress", moduleEntity.UrlAddress, true);
            }
        }
    }
}
