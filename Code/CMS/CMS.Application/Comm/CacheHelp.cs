using CMS.Code;
using CMS.Domain.IRepository;
using CMS.Domain.ViewModel;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class CacheHelp
    {

        private static CacheHelp _cacheHelp = new CacheHelp();
        private static ICacheRepository iCacheRepository = DataAccess.CreateICacheRepository();
        public CacheHelp()
        {
        }
        /// <summary>
        /// 移除所有缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAll()
        {
            iCacheRepository.RemoveAll();
        }

        #region 菜单对象权限

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void WriteAuthorizeurlDatas(List<AuthorizeActionModel> authorizeurldata, string roleId)
        {
            iCacheRepository.WriteAuthorizeurlDatas(authorizeurldata, roleId);
        }
        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAuthorizeurlDatas(string roleId)
        {
            iCacheRepository.RemoveAuthorizeurlDatas(roleId);
        }

        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAuthorizeurlDatas()
        {
            iCacheRepository.RemoveAuthorizeurlDatas();

        }

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AuthorizeActionModel> GetAuthorizeurlDatas(string roleId)
        {
            List<AuthorizeActionModel> datas = iCacheRepository.GetAuthorizeurlDatas(roleId);
            return datas;
        }

        #endregion

        #region 输出Html缓存

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void WriteOutPutHtmls(string htmls, string webSiteIds, string urlRaws)
        {
            iCacheRepository.WriteOutPutHtmls(htmls, webSiteIds, urlRaws);
        }
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveOutPutHtmls(string webSiteIds)
        {
            iCacheRepository.RemoveOutPutHtmls(webSiteIds);
        }
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveOutPutHtmls(string webSiteIds, string urlRaws)
        {
            iCacheRepository.RemoveOutPutHtmls(webSiteIds, urlRaws);
        }

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetOutPutHtmls(string url)
        {
            string htmls = string.Empty;
            htmls = iCacheRepository.GetOutPutHtmls(url);
            return htmls;
        }
        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetOutPutHtmls(string webSiteIds, string urlRaws)
        {
            string htmls = string.Empty;
            htmls = iCacheRepository.GetOutPutHtmls(webSiteIds, urlRaws);
            return htmls;
        }

        #endregion

    }
}
