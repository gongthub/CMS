using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface IWebSiteForUrlRepository : IRepositoryBase<WebSiteForUrlEntity>
    {
        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExistUrl(string keyId, string url);

        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsExistUrl(WebSiteEntity moduleEntity, string url);
    }
}
