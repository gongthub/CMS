using CMS.Code;
using CMS.Domain.IRepository;
using CMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.Comm
{
    public class CacheRepository : ICacheRepository
    {
        private static ICache icache = CacheFactory.cacheFactory.Cache();
         
        /// <summary>
        /// 菜单对象权限
        /// </summary>
        private static string AUTHORIZEURLDATA = "AUTHORIZEURLDATA_";

        /// <summary>
        /// 输出Html缓存
        /// </summary>
        private static string OUTPUTHTML = "OUTPUTHTML_";

        /// <summary>
        /// 移除所有缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAll()
        {
            icache.RemoveCache();
        }

        #region 菜单对象权限

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void WriteAuthorizeurlDatas(List<AuthorizeActionModel> authorizeurldata, string roleId)
        {
            icache.WriteCache(authorizeurldata, AUTHORIZEURLDATA + roleId, DateTime.Now.AddMinutes(5));
        }
        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAuthorizeurlDatas(string roleId)
        {
            icache.RemoveCache(AUTHORIZEURLDATA + roleId);
        }

        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveAuthorizeurlDatas()
        {
            List<string> allkeys = icache.GetAllKey();
            foreach (var keys in allkeys)
            {
                if (keys.Contains(AUTHORIZEURLDATA))
                {
                    icache.RemoveCache(keys);
                }
            }

        }

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<AuthorizeActionModel> GetAuthorizeurlDatas(string roleId)
        {
            List<AuthorizeActionModel> datas = icache.GetCache<List<AuthorizeActionModel>>(AUTHORIZEURLDATA + roleId);
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
            icache.WriteCache(htmls, OUTPUTHTML + webSiteIds + urlRaws, DateTime.Now.AddMinutes(5));
        }
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveOutPutHtmls(string webSiteIds)
        {
            icache.RemoveCache(OUTPUTHTML + webSiteIds);
        }
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveOutPutHtmls(string webSiteIds, string urlRaws)
        {
            icache.RemoveCache(OUTPUTHTML + webSiteIds + urlRaws);
        }

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetOutPutHtmls(string url)
        {
            string htmls = string.Empty;
            htmls = icache.GetCache<string>(OUTPUTHTML + url);
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
            htmls = icache.GetCache<string>(OUTPUTHTML + webSiteIds + urlRaws);
            return htmls;
        }

        #endregion

    }
}
