using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.SystemManage
{
    public interface IUserWebSiteRepository : IRepositoryBase<UserWebSiteEntity>
    {
        /// <summary>
        /// 获取当前用户所有站点Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<string> GetWebSiteIds();
        /// <summary>
        /// 根据用户获取所属站点
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<string> GetWebSiteIds(string userId);
         
    }
}
