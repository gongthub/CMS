using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.WebManage
{
    public interface IWebSiteRepository : IRepositoryBase<WebSiteEntity>
    {

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        bool IsExistDefaultWebSite(ref string webSiteId);
        
        List<WebSiteEntity> GetListForUserId();

        List<WebSiteEntity> GetListByCreatorId();
        List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword);
    }
}
