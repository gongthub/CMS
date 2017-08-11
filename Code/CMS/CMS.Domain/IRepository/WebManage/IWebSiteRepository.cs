using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface IWebSiteRepository : IRepositoryBase<WebSiteEntity>
    {
        void DeleteForm(string keyValue);

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        bool IsExistDefaultWebSite(ref string webSiteId);

        List<WebSiteEntity> GetListForUserId();

        List<WebSiteEntity> GetListByCreatorId();
        List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword);
        void SubmitForm(WebSiteEntity moduleEntity, string keyValue);
        void SubmitForm(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue, UpFileDTO upFileentity);
    }
}
