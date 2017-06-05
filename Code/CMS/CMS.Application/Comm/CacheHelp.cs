using CMS.Code;
using CMS.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class CacheHelp
    {
        private static ICache icache = CacheFactory.cacheFactory.Cache();

        #region 单例模式创建对象
        //单例模式创建对象
        private static CacheHelp _cacheHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        CacheHelp()
        {
        }

        public static CacheHelp cacheHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _cacheHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _cacheHelp)
                        {
                            _cacheHelp = new CacheHelp();
                        }
                    }
                }
                return _cacheHelp;
            }
        }
        #endregion

        /// <summary>
        /// 菜单对象权限
        /// </summary>
        private static string AUTHORIZEURLDATA = "AUTHORIZEURLDATA_";

        /// <summary>
        /// 输出Html缓存
        /// </summary>
        private static string OUTPUTHTML = "OUTPUTHTML_";

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
        public void WriteOutPutHtmls(string htmls, string hosts)
        {
            icache.WriteCache(htmls, OUTPUTHTML + hosts, DateTime.Now.AddMinutes(5));
        }
        /// <summary>
        /// 移除输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public void RemoveOutPutHtmls(string hosts)
        {
            icache.RemoveCache(OUTPUTHTML + hosts);
        }

        /// <summary>
        /// 获取输出Html缓存
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public string GetOutPutHtmls(string url)
        {
            string htmls = string.Empty;
            //if (!string.IsNullOrEmpty(Configs.GetValue("HtmlCacheEnabled")))
            htmls = icache.GetCache<string>(OUTPUTHTML + url);
            return htmls;
        }

        #endregion

    }
}
