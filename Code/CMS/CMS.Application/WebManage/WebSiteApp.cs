using CMS.Application.Comm;
using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class WebSiteApp
    {
        private IWebSiteRepository service = DataAccess.CreateIWebSiteRepository;
        private IWebSiteForUrlRepository serviceWebSiteForUrl = DataAccess.CreateIWebSiteForUrlRepository;

        private static string LUCENCEINDEXPATH = Configs.GetValue("LucenceIndexPath");
        /// <summary>
        /// 静态页面缓存路径
        /// </summary>
        private static readonly string HTMLSRC = Code.Configs.GetValue("htmlSrc");
        /// <summary>
        /// 网站资源文件根目录
        /// </summary>
        private static readonly string HTMLCONTENTSRC = Code.Configs.GetValue("htmlContentSrc");

        /// <summary>
        /// 上传图片保存路径
        /// </summary>
        private static readonly string UPLOADIMGPATH = Code.ConfigHelp.configHelp.UPLOADIMG;
        /// <summary>
        /// 上传文件保存路径
        /// </summary>
        private static readonly string UPLOADFILEPATH = Code.ConfigHelp.configHelp.UPLOADFILE;

        public WebSiteEntity GetForm(string keyValue)
        {
            WebSiteEntity webSiteEntity = service.FindEntity(keyValue);

            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                new WebSiteForUrlApp().InitWebSiteUrl(ref webSiteEntity);
            }

            return webSiteEntity;
        }

        public WebSiteEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        /// <summary>
        /// 根据域名获取实体
        /// </summary>
        /// <returns></returns>
        public WebSiteEntity GetModelByUrlHost(string urlHost)
        {
            WebSiteEntity webSiteEntity = new WebSiteEntity();
            WebSiteForUrlEntity webSiteForUrlEntity = serviceWebSiteForUrl.IQueryable(m => m.UrlAddress == urlHost && m.DeleteMark != true).FirstOrDefault();
            if (webSiteForUrlEntity != null && !string.IsNullOrEmpty(webSiteForUrlEntity.WebSiteId))
            {
                webSiteEntity = service.FindEntity(webSiteForUrlEntity.WebSiteId);
            }

            return webSiteEntity;
        }
        /// <summary>
        /// 根据域名获取实体
        /// </summary>
        /// <returns></returns>
        public string GetWebSiteId(System.Web.HttpRequestBase request)
        {
            string webSiteIds = string.Empty;
            string hosturl = Comm.RequestHelp.requestHelp.GetHostRequest(request);
            WebSiteEntity webSiteEntity = GetModelByUrlHost(hosturl);
            if (webSiteEntity != null)
            {
                webSiteIds = webSiteEntity.Id;
            }
            return webSiteIds;
        }

        public List<WebSiteEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<WebSiteEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<WebSiteEntity> GetListForUserId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
            List<string> webSiteIds = userWebSiteApp.GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id) && t.DeleteMark != true);
            return service.IQueryable(expression).ToList();
        }

        public List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
            List<string> webSiteIds = userWebSiteApp.GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id) && t.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除站点信息=>" + keyValue, Enums.DbLogType.Delete, "站点管理");
        }
        public void SubmitForm(WebSiteEntity moduleEntity, string keyValue)
        {
            service.SubmitForm(moduleEntity, keyValue);
        }
        public void SubmitForm(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue, UpFileDTO upFileentity)
        {
            service.SubmitForm(moduleEntity, webSiteForUrlEntitys, keyValue, upFileentity);
        }

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        public bool IsExistDefaultWebSite(ref string webSiteId)
        {
            bool bState = service.IsExistDefaultWebSite(ref webSiteId);
            return bState;
        }

        /// <summary>
        /// 获取站点资源文件所占大小
        /// </summary>
        /// <returns></returns>
        public long GetWebSiteDirSize(string webSiteShortName)
        {
            long dirSize = 0;

            string lucenceFilePaths = FileHelper.MapPath(string.Format(LUCENCEINDEXPATH, webSiteShortName));
            string htmlSrcPaths = FileHelper.MapPath(HTMLSRC + @"\" + webSiteShortName + @"\");
            string htmlContentSrcPaths = FileHelper.MapPath(HTMLCONTENTSRC + @"\" + webSiteShortName + @"\");
            string uploadImgPaths = FileHelper.MapPath(UPLOADIMGPATH + @"\" + webSiteShortName + @"\");
            string uploadFilePaths = FileHelper.MapPath(UPLOADFILEPATH + @"\" + webSiteShortName + @"\");

            dirSize += FileHelper.GetDirectoryLength(lucenceFilePaths);
            dirSize += FileHelper.GetDirectoryLength(htmlSrcPaths);
            dirSize += FileHelper.GetDirectoryLength(htmlContentSrcPaths);
            dirSize += FileHelper.GetDirectoryLength(uploadImgPaths);
            dirSize += FileHelper.GetDirectoryLength(uploadFilePaths);

            return dirSize;
        }
    }
}
