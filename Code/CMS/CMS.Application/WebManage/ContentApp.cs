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
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace CMS.Application.WebManage
{
    public class ContentApp
    {
        Log log = LogFactory.GetLogger("ContentApp");
        private IContentRepository service = DataAccess.CreateIContentRepository();
        private IUserRepository iUserRepository = DataAccess.CreateIUserRepository();
        private IColumnsRepository iColumnsRepository = DataAccess.CreateIColumnsRepository();

        public ContentEntity GetForm(string keyValue)
        {
            ContentEntity entity = service.FindEntity(keyValue);
            if (entity != null)
            {
                entity.UpImages = new UpFileApp().GetModulesByPid(keyValue, Enums.UploadType.Images);
            }
            return entity;
        }
        public ContentEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.Id == keyValue);
        }
        public ContentEntity GetFormNoDelAndNoEnable(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }

        public ColumnsEntity GetModuleByContentID(string keyValue)
        {
            ColumnsEntity moduleEntity = new ColumnsEntity();
            ContentEntity contentEntity = GetFormNoDel(keyValue);
            ColumnsApp c_ModulesApp = new ColumnsApp();
            if (JudgmentHelp.judgmentHelp.IsNullEntity<ContentEntity>(contentEntity) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(contentEntity.ColumnId))
            {
                moduleEntity = c_ModulesApp.GetFormNoDel(contentEntity.ColumnId);
            }
            return moduleEntity;
        }

        /// <summary>
        /// 根据模块名称获取一个内容
        /// </summary>
        /// <param name="actionCode"></param>
        /// <returns></returns>
        public ContentEntity GetContentByActionCode(string actionCode)
        {
            ColumnsEntity moduleEntity = new ColumnsEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ContentEntity contentEntity = new ContentEntity();
            moduleEntity = c_ModulesApp.GetFormByActionName(actionCode);
            if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(moduleEntity) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(moduleEntity.Id))
            {
                contentEntity = service.IQueryable(m => m.ColumnId == moduleEntity.Id && m.EnabledMark == true && m.DeleteMark != true).FirstOrDefault();

            }
            return contentEntity;
        }
        public List<ContentEntity> GetList()
        {
            List<ContentEntity> models = new List<ContentEntity>();
            models = service.IQueryable(t => t.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public List<ContentEntity> GetList(Pagination pagination, string keyword)
        {
            List<ContentEntity> models = new List<ContentEntity>();
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.FindList(expression, pagination);
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public List<ContentEntity> GetList(string itemId = "", string keyword = "")
        {
            List<ContentEntity> models = new List<ContentEntity>();
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ColumnId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public List<ContentEntity> GetList(string itemId, string keyword, Pagination pagination)
        {
            List<ContentEntity> models = new List<ContentEntity>();
            var expression = ExtLinq.True<ContentEntity>();
            expression = expression.And(t => t.ColumnId == itemId);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);

            models = service.FindList(expression, pagination);
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public List<ContentEntity> GetLists(Expression<Func<ContentEntity, bool>> predicate)
        {
            List<ContentEntity> models = new List<ContentEntity>();
            models = service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public IQueryable<ContentEntity> GetListsIq(Expression<Func<ContentEntity, bool>> predicate)
        {
            IQueryable<ContentEntity> models;
            models = service.IQueryable(predicate).OrderBy(t => t.SortCode);
            return models;
        }

        public IQueryable<ContentEntity> GetListIq(string itemId = "", string keyword = "")
        {
            IQueryable<ContentEntity> models;
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ColumnId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.IQueryable(expression).OrderBy(t => t.SortCode);

            return models;
        }
        public IQueryable<ContentEntity> GetListIqNoEnable(string itemId = "", string keyword = "")
        {
            IQueryable<ContentEntity> models;
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ColumnId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            expression = expression.And(m => m.EnabledMark == true);
            models = service.IQueryable(expression).OrderBy(t => t.SortCode);

            return models;
        }
        public List<ContentEntity> GetListByWebSiteId(string webSiteIds)
        {
            List<ContentEntity> models = new List<ContentEntity>();
            models = service.GetAllEnableModels(webSiteIds);
            models.ForEach(delegate (ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }

        public int GetCountByWebSiteId(string webSiteIds)
        {
            return service.IQueryable(t => t.DeleteMark != true && t.WebSiteId == webSiteIds).Count();
        }
        public void DeleteForm(string keyValue)
        {
            ContentEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.Delete(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除内容信息=>" + keyValue, Enums.DbLogType.Delete, "内容管理");
        }
        public void DeleteFormById(string keyValue)
        {
            ContentEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除内容信息=>" + keyValue, Enums.DbLogType.Delete, "内容管理");
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteFormByIds(string ids)
        {
            string[] sids = ids.Split(',');
            if (sids != null && sids.Length > 0)
            {
                for (int i = 0; i < sids.Length; i++)
                {
                    string id = sids[i];
                    DeleteFormById(id);
                }
            }
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue)
        {
            service.SubmitForm(moduleEntity, keyValue);
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys)
        {
            service.SubmitForm(moduleEntity, keyValue, upFileentitys);
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys, List<string> lstRemoveImgIds)
        {
            if (new WebSiteApp().IsOverSizeByWebSiteId(moduleEntity.WebSiteId))
            {
                throw new Exception("该站点空间已不足，请联系管理员！");
            }
            service.SubmitForm(moduleEntity, keyValue, upFileentitys, lstRemoveImgIds);
            GenStaticPage(moduleEntity.Id);
            GenStaticPageByCol(moduleEntity.ColumnId);
        }

        public void Up(string keyValue)
        {
            ContentEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.Up(keyValue);
        }

        /// <summary>
        /// 批量发布
        /// </summary>
        /// <param name="ids"></param>
        public void Ups(string ids)
        {
            string[] sids = ids.Split(',');
            if (sids != null && sids.Length > 0)
            {
                for (int i = 0; i < sids.Length; i++)
                {
                    string id = sids[i];
                    Up(id);
                }
            }
        }
        public void Down(string keyValue)
        {
            ContentEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.Down(keyValue);
        }

        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="ids"></param>
        public void Downs(string ids)
        {
            string[] sids = ids.Split(',');
            if (sids != null && sids.Length > 0)
            {
                for (int i = 0; i < sids.Length; i++)
                {
                    string id = sids[i];
                    Down(id);
                }
            }
        }

        public void UpdateViewNum(string keyValue)
        {
            ContentEntity moduleEntity = GetForm(keyValue);
            if (moduleEntity != null && !string.IsNullOrEmpty(moduleEntity.Id))
            {
                moduleEntity.ViewNum++;
                service.Update(moduleEntity);
            }
        }
        public void UpdateViewNum(string keyValue, bool IsAsync)
        {
            if (IsAsync)
            {
                Thread thread = new Thread(new ThreadStart(() =>
                {
                    UpdateViewNum(keyValue);
                }));
                thread.Start();

            }
            else
            {
                UpdateViewNum(keyValue);
            }

        }

        /// <summary>
        /// 批量生成静态页
        /// </summary>
        /// <param name="ids"></param>
        public void GenStaticPages(string ids)
        {
            string[] sids = ids.Split(',');
            if (sids != null && sids.Length > 0)
            {
                for (int i = 0; i < sids.Length; i++)
                {
                    string id = sids[i];
                    GenStaticPage(id);
                }
            }
        }
        public void GenStaticPage(string keyValue)
        {
            ContentEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            ColumnsEntity module = GetModuleByContentID(keyValue);
            if (module != null &&
                (module.Type == (int)Enums.ModuleType.List || module.Type == (int)Enums.ModuleType.AdvancedList))
            {
                if (new WebSiteApp().IsOverSizeByWebSiteId(module.WebSiteId))
                {
                    throw new Exception("该站点空间已不足，请联系管理员！");
                }
                WebSiteApp webSiteApp = new WebSiteApp();
                WebSiteEntity webSiteEntity = webSiteApp.GetFormNoDel(module.WebSiteId);
                if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
                {
                    TempletApp templetapp = new TempletApp();
                    TempletEntity templet = templetapp.GetFormNoDel(module.CTempletId);
                    if (templet != null)
                    {
                        string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);

                        new TempHelp().GenHtmlPage(templets, keyValue, webSiteEntity.ShortName);
                    }
                }
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "内容信息=>生成列表详情静态页" + module.FullName, Enums.DbLogType.Submit, "内容管理");
            }
        }
        public void GenAllStaticPage(string webSiteId)
        {
            int fNum = 0;
            List<ContentEntity> models = GetListByWebSiteId(webSiteId);
            if (models != null && models.Count > 0)
            {
                foreach (ContentEntity model in models)
                {
                    try
                    {
                        GenStaticPage(model.Id);
                    }
                    catch (Exception ex)
                    {
                        fNum++;
                        log.Error(ex.Message);
                    }
                }
            }
            if (fNum > 0)
            {
                throw new Exception("失败条数：" + fNum);
            }
        }

        /// <summary>
        /// 生成栏目静态文件
        /// </summary>
        /// <param name="keyValue"></param>
        public void GenStaticPageByCol(string keyValue)
        {
            ColumnsEntity moduleEntity = iColumnsRepository.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            if (moduleEntity != null && moduleEntity.Type == (int)Enums.ModuleType.Content)
            {
                if (new WebSiteApp().IsOverSizeByWebSiteId(moduleEntity.WebSiteId))
                {
                    throw new Exception("该站点空间已不足，请联系管理员！");
                }
                new TempHelp().GenHtmlPageCol(keyValue, moduleEntity.WebSiteId, moduleEntity.TempletId, moduleEntity.ActionName);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "内容信息=>生成栏目静态页" + moduleEntity.FullName, Enums.DbLogType.Submit, "内容管理");
            }
        }
        /// <summary>
        /// 获取静态HTML
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public string GetStaticHtmls(string keyValue)
        {
            string htmls = "";
            ColumnsEntity module = GetModuleByContentID(keyValue);
            if (module != null)
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                WebSiteEntity webSiteEntity = webSiteApp.GetFormNoDel(module.WebSiteId);
                if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
                {
                    TempletApp templetapp = new TempletApp();
                    TempletEntity templet = templetapp.GetFormNoDel(module.CTempletId);
                    if (templet != null)
                    {
                        string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);

                        new TempHelp().GenHtmlPage(templets, keyValue, webSiteEntity.ShortName);
                        htmls = new TempHelp().GetHtmlPages(templets, keyValue, webSiteEntity.ShortName);
                    }
                }
            }

            return htmls;
        }

        /// <summary>
        /// 根据id获取浏览数
        /// </summary>
        /// <param name="actionCode"></param>
        /// <returns></returns>
        public long GetViewNum(string ids)
        {
            long num = 0;
            ContentEntity moduleEntity = GetForm(ids);
            if (moduleEntity != null)
            {
                num = moduleEntity.ViewNum;
            }
            return num;
        }

        /// <summary>
        /// 根据站点ID和虚拟路径获取html
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetHtmlStrs(string webSiteId, string webSiteShortName, string url, out string htmls)
        {
            bool isHave = false;
            htmls = string.Empty;
            isHave = GetHtmlStrsByColUrl(webSiteShortName, url, out htmls);
            if (!isHave)
            {
                ContentEntity contentEntity = service.IQueryable(m => m.WebSiteId == webSiteId
                && (m.UrlAddress == url || m.UrlAddress == url.Replace(@"/", @"\"))).FirstOrDefault();
                if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id))
                {
                    string urlPath = contentEntity.UrlPath;

                    if (Code.FileHelper.IsExistFile(urlPath, true))
                    {
                        htmls = Code.FileHelper.ReadTxtFile(urlPath, true);
                        if (contentEntity.ViewNum < 0)
                        {
                            contentEntity.ViewNum = 0;
                        }
                        //处理页面浏览数
                        htmls = htmls.Replace(TempHelp.STATICHTMLCONTENTNUM, contentEntity.ViewNum.ToString());
                        UpdateViewNum(contentEntity.Id, true);
                        isHave = true;
                    }
                }
            }
            return isHave;
        }

        /// <summary>
        /// 获取栏目静态文件
        /// </summary>
        /// <returns></returns>
        private bool GetHtmlStrsByColUrl(string webSiteShortName, string url, out string htmls)
        {
            bool isHave = false;
            htmls = string.Empty;
            string urlPath = Code.ConfigHelp.configHelp.HTMLSRC + webSiteShortName + @"\" + url + ".html";
            if (Code.FileHelper.IsExistFile(urlPath, true))
            {
                htmls = Code.FileHelper.ReadTxtFile(urlPath, true);
                isHave = true;
            }
            return isHave;
        }
    }
}
