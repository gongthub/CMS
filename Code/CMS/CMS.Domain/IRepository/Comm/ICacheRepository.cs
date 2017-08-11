using CMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface ICacheRepository
    {
        /// <summary>
        /// 移除所有缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void RemoveAll();

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void WriteAuthorizeurlDatas(List<AuthorizeActionModel> authorizeurldata, string roleId);
        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void RemoveAuthorizeurlDatas(string roleId);

        /// <summary>
        /// 移除菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void RemoveAuthorizeurlDatas();

        /// <summary>
        /// 获取菜单对象权限缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<AuthorizeActionModel> GetAuthorizeurlDatas(string roleId);

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void WriteOutPutHtmls(string htmls, string webSiteIds, string urlRaws);
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void RemoveOutPutHtmls(string webSiteIds);
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        void RemoveOutPutHtmls(string webSiteIds, string urlRaws);

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        string GetOutPutHtmls(string url);
        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        string GetOutPutHtmls(string webSiteIds, string urlRaws);
    }
}
