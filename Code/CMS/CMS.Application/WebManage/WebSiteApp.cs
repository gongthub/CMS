﻿using CMS.Application.Comm;
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
        private IWebSiteRepository service = DataAccess.CreateIWebSiteRepository();
        private IWebSiteForUrlRepository serviceWebSiteForUrl = DataAccess.CreateIWebSiteForUrlRepository();
        private IWebSiteConfigRepository webSiteConfigRepository = DataAccess.CreateIWebSiteConfigRepository();

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
        public WebSiteEntity GetFormByShortName(string shortName)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.ShortName == shortName);
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


        public WebSiteConfigEntity GetWebSiteConfigFormByWebSiteId(string webSiteId)
        {
            WebSiteConfigEntity webSiteConfigEntity = new WebSiteConfigEntity();
            var expression = ExtLinq.True<WebSiteConfigEntity>();
            expression = expression.And(t => t.DeleteMark != true && t.WebSiteId == webSiteId);
            webSiteConfigEntity = webSiteConfigRepository.IQueryable(expression).FirstOrDefault();
            webSiteConfigEntity.WebSiteUseResourceSize = GetWebSiteDirSizeByWebSiteId(webSiteId);
            return webSiteConfigEntity;
        }


        public bool UpdateSearchEnableByWebSiteId(string webSiteId, bool searchEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetWebSiteConfigFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.SearchEnabledMark = searchEnabled;
                    webSiteConfigRepository.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置全站搜索=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + searchEnabled, Enums.DbLogType.Create, "站点配置=>全站搜索");
                }
                else
                {
                    bState = false;
                }
            }
            catch
            {
                bState = false;
            }
            return bState;
        }
        public bool UpdateMessageEnableByWebSiteId(string webSiteId, bool messageEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetWebSiteConfigFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.MessageEnabledMark = messageEnabled;
                    webSiteConfigRepository.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置留言板=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + messageEnabled, Enums.DbLogType.Create, "站点配置=>留言板");
                }
                else
                {
                    bState = false;
                }
            }
            catch
            {
                bState = false;
            }
            return bState;
        }
        public bool UpdateAdvancedContentEnableByWebSiteId(string webSiteId, bool advancedContentEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetWebSiteConfigFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.AdvancedContentEnabledMark = advancedContentEnabled;
                    webSiteConfigRepository.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置高级列表=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + advancedContentEnabled, Enums.DbLogType.Create, "站点配置=>高级列表");
                }
                else
                {
                    bState = false;
                }
            }
            catch
            {
                bState = false;
            }
            return bState;
        }

        public bool UpdateServiceEnableByWebSiteId(string webSiteId, bool serviceEnabled)
        {
            bool bState = true;
            try
            {
                WebSiteConfigEntity webSiteConfigEntity = GetWebSiteConfigFormByWebSiteId(webSiteId);
                if (webSiteConfigEntity != null && !string.IsNullOrEmpty(webSiteConfigEntity.Id))
                {
                    webSiteConfigEntity.Modify(webSiteConfigEntity.Id);
                    webSiteConfigEntity.ServiceEnabledMark = serviceEnabled;
                    webSiteConfigRepository.Update(webSiteConfigEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "更新站点配置站点维护=>" + webSiteConfigEntity.WebSiteId + "=>状态：" + serviceEnabled, Enums.DbLogType.Create, "站点配置=>站点维护");
                }
                else
                {
                    bState = false;
                }
            }
            catch
            {
                bState = false;
            }
            return bState;
        }
        public bool IsSearch(string webSiteId)
        {
            return webSiteConfigRepository.IsSearch(webSiteId);
        }
        public bool IsService(string webSiteId)
        {
            return webSiteConfigRepository.IsService(webSiteId);
        }
        public bool IsMessage(string webSiteId)
        {
            return webSiteConfigRepository.IsMessage(webSiteId);
        }
        public bool IsAdvancedContent(string webSiteId)
        {
            return webSiteConfigRepository.IsAdvancedContent(webSiteId);
        }


        /// <summary>
        /// 站点空间是否超过可使用大小
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public bool IsOverSize(string webSiteShortName)
        {
            bool bState = false;
            decimal webSize = GetWebSiteSize(webSiteShortName);
            decimal webSizeDir = GetWebSiteDirSize(webSiteShortName);
            if (webSizeDir >= webSize)
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 站点空间是否超过可使用大小
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public bool IsOverSize(string webSiteShortName, long fileSize)
        {
            bool bState = false;
            decimal webSize = GetWebSiteSize(webSiteShortName);
            decimal webSizeDir = GetWebSiteDirSize(webSiteShortName);
            if (fileSize > 0)
            {
                decimal fileSizeT = fileSize;
                fileSizeT = Math.Round((fileSizeT / 1024 / 1024), 2);
                webSizeDir += fileSizeT;
            }
            if (webSizeDir >= webSize)
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 站点空间是否超过可使用大小
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public bool IsOverSizeByWebSiteId(string webSiteId)
        {
            bool bState = false;
            decimal webSize = GetWebSiteSizeByWebSiteId(webSiteId);
            decimal webSizeDir = GetWebSiteDirSizeByWebSiteId(webSiteId);
            if (webSizeDir >= webSize)
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 站点空间是否超过可使用大小
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public bool IsOverSizeByWebSiteId(string webSiteId, long fileSize)
        {
            bool bState = false;
            decimal webSize = GetWebSiteSizeByWebSiteId(webSiteId);
            decimal webSizeDir = GetWebSiteDirSizeByWebSiteId(webSiteId);
            if (fileSize > 0)
            {
                decimal fileSizeT = fileSize;
                fileSizeT = Math.Round((fileSizeT / 1024 / 1024), 2);
                webSizeDir += fileSizeT;
            }
            if (webSizeDir >= webSize)
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 获取站点空间大小
        /// </summary>
        /// <returns></returns>
        public decimal GetWebSiteSize(string webSiteShortName)
        {
            decimal websiteSize = 0;
            WebSiteEntity webSiteEntity = GetFormByShortName(webSiteShortName);
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                WebSiteConfigEntity model = GetWebSiteConfigFormByWebSiteId(webSiteEntity.Id);
                websiteSize = model.WebSiteResourceSize;
            }
            return websiteSize;
        }
        /// <summary>
        /// 获取站点空间大小
        /// </summary>
        /// <returns></returns>
        public decimal GetWebSiteSizeByWebSiteId(string webSiteId)
        {
            WebSiteConfigEntity model = GetWebSiteConfigFormByWebSiteId(webSiteId);
            return model.WebSiteResourceSize;
        }
        /// <summary>
        /// 获取站点资源文件所占大小
        /// </summary>
        /// <returns></returns>
        public decimal GetWebSiteDirSize(string webSiteShortName)
        {
            decimal dirSize = 0;

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

            if (dirSize > 0)
            {
                dirSize = Math.Round(dirSize / 1024 / 1024, 2);
            }
            return dirSize;
        }


        /// <summary>
        /// 获取站点资源文件所占大小 单位m
        /// </summary>
        /// <returns></returns>
        public decimal GetWebSiteDirSizeByWebSiteId(string webSiteId)
        {
            decimal dirSize = 0;
            WebSiteEntity webSiteEntity = GetForm(webSiteId);
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                string lucenceFilePaths = FileHelper.MapPath(string.Format(LUCENCEINDEXPATH, webSiteEntity.ShortName));
                string htmlSrcPaths = FileHelper.MapPath(HTMLSRC + @"\" + webSiteEntity.ShortName + @"\");
                string htmlContentSrcPaths = FileHelper.MapPath(HTMLCONTENTSRC + @"\" + webSiteEntity.ShortName + @"\");
                string uploadImgPaths = FileHelper.MapPath(UPLOADIMGPATH + @"\" + webSiteEntity.ShortName + @"\");
                string uploadFilePaths = FileHelper.MapPath(UPLOADFILEPATH + @"\" + webSiteEntity.ShortName + @"\");

                dirSize += FileHelper.GetDirectoryLength(lucenceFilePaths);
                dirSize += FileHelper.GetDirectoryLength(htmlSrcPaths);
                dirSize += FileHelper.GetDirectoryLength(htmlContentSrcPaths);
                dirSize += FileHelper.GetDirectoryLength(uploadImgPaths);
                dirSize += FileHelper.GetDirectoryLength(uploadFilePaths);

                if (dirSize > 0)
                {
                    dirSize = Math.Round(dirSize / 1024 / 1024, 2);
                }
            }
            return dirSize;
        }
    }
}
