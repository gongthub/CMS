using CMS.Application.Comm;
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
    public class TempletApp
    {
        private ITempletRepository service = DataAccess.CreateITempletRepository();
        private IUserRepository iUserRepository = DataAccess.CreateIUserRepository();

        public TempletEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public TempletEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public TempletEntity GetFormByName(string webSiteShortName, string Name)
        {
            TempletEntity model = new TempletEntity();
            WebSiteEntity entity = new WebSiteApp().GetFormByShortName(webSiteShortName);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                model = service.FindEntity(m => m.FullName == Name && m.WebSiteId == entity.Id && m.DeleteMark != true);
            }
            return model;
        }

        /// <summary>
        /// 获取默认模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetMain(RequestModel requestModel)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetMain(requestModel.webSiteEntity?.Id);
            if (module != null)
            {
                if (requestModel.IsMobile && new WebSiteApp().IsMobile(requestModel.webSiteEntity.Id))
                {
                    templet = service.FindEntity(m => m.Id == module.MTempletId
                    && m.WebSiteId == requestModel.webSiteEntity.Id
                    && m.EnabledMark == true && m.DeleteMark != true);
                }
                else
                {
                    templet = service.FindEntity(m => m.Id == module.TempletId
                    && m.WebSiteId == requestModel.webSiteEntity.Id
                    && m.EnabledMark == true && m.DeleteMark != true);
                }
            }
            return templet;
        }

        /// <summary>
        /// 获取全站搜索模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetSearchModel(string webSiteId, bool isMobile)
        {
            TempletEntity templet = new TempletEntity();
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(webSiteId))
            {
                if (isMobile && new WebSiteApp().IsMobile(webSiteId))
                {
                    expression = expression.And(t => t.WebSiteId == webSiteId
                                    && t.DeleteMark != true
                                    && t.EnabledMark == true
                                    && t.TempletType == (int)Enums.TempletType.MSearch);
                }
                else
                {
                    expression = expression.And(t => t.WebSiteId == webSiteId
                                    && t.DeleteMark != true
                                    && t.EnabledMark == true
                                    && t.TempletType == (int)Enums.TempletType.Search);
                }
            }
            templet = service.FindEntity(expression);
            return templet;
        }
        /// <summary>
        /// 根据路径获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByUrlRaws(RequestModel requestModel, ref int irequestType)
        {
            TempletEntity templet = new TempletEntity();
            if (requestModel.UrlRaws != null)
            {
                if (Common.IsSearchForUrl(requestModel.UrlRaws))
                {
                    if (new WebSiteApp().IsSearch(requestModel.webSiteEntity?.Id)
                        || new WebSiteApp().IsMSearch(requestModel.webSiteEntity?.Id))
                    {
                        templet = GetSearchModel(requestModel.webSiteEntity?.Id, requestModel.IsMobile);
                        irequestType = (int)Enums.TempletType.Search;
                    }
                }
                else
                {

                    string Ids = requestModel.UrlRaws.LastOrDefault();
                    int Id = 0;
                    if (requestModel.UrlRaws.Count == 1 || Int32.TryParse(Ids, out Id))
                    {
                        templet = GetModelByActionName(requestModel.UrlRaws.FirstOrDefault(), requestModel.webSiteEntity?.Id, requestModel.IsMobile);
                    }
                    else
                    {
                        templet = GetCModelByActionName(requestModel.UrlRaws.FirstOrDefault(), requestModel.webSiteEntity?.Id, requestModel.IsMobile);
                    }
                }
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByActionName(string actionName, string webSiteId, bool isMobile)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName, webSiteId);
            if (module != null)
            {
                if (isMobile && new WebSiteApp().IsMobile(webSiteId))
                {
                    templet = service.FindEntity(m => m.Id == module.MTempletId
                                    && m.WebSiteId == webSiteId
                                    && m.EnabledMark == true
                                    && m.DeleteMark != true);
                }
                else
                {
                    templet = service.FindEntity(m => m.Id == module.TempletId
                                    && m.WebSiteId == webSiteId
                                    && m.EnabledMark == true
                                    && m.DeleteMark != true);
                }
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取内容模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetCModelByActionName(string actionName, string webSiteId, bool isMobile)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName, webSiteId);
            if (module != null)
            {
                if (isMobile && new WebSiteApp().IsMobile(webSiteId))
                {
                    templet = service.FindEntity(m => m.Id == module.MCTempletId
                                    && m.WebSiteId == webSiteId
                                    && m.EnabledMark == true
                                    && m.DeleteMark != true);
                }
                else
                {
                    templet = service.FindEntity(m => m.Id == module.CTempletId
                                    && m.WebSiteId == webSiteId
                                    && m.EnabledMark == true
                                    && m.DeleteMark != true);
                }
            }
            return templet;
        }
        public List<TempletEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<TempletEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<TempletEntity>();
            expression = expression.And(m => m.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<TempletEntity> GetListByWebSiteId(string WebSiteId)
        {
            if (new WebSiteApp().IsSearch(WebSiteId)
                || new WebSiteApp().IsMSearch(WebSiteId))
            {
                return service.IQueryable(m => m.WebSiteId == WebSiteId
                && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
            }
            else
            {
                return service.IQueryable(m => m.WebSiteId == WebSiteId
                && m.DeleteMark != true
                && m.TempletType == (int)Code.Enums.TempletType.Common).OrderBy(t => t.SortCode).ToList();
            }
        }
        public List<TempletEntity> GetListByWebSiteId(Pagination pagination, string keyword, string WebSiteId)
        {
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            if (new WebSiteApp().IsSearch(WebSiteId) && new WebSiteApp().IsMSearch(WebSiteId))
            {
                expression = expression.And(t => t.TempletType == (int)Code.Enums.TempletType.Common
                || t.TempletType == (int)Code.Enums.TempletType.Search
                || t.TempletType == (int)Code.Enums.TempletType.MSearch);
            }
            else
            {
                if (new WebSiteApp().IsSearch(WebSiteId))
                {
                    expression = expression.And(t => t.TempletType == (int)Code.Enums.TempletType.Common
                    || t.TempletType == (int)Code.Enums.TempletType.Search);
                }
                else if (new WebSiteApp().IsMSearch(WebSiteId))
                {
                    expression = expression.And(t => t.TempletType == (int)Code.Enums.TempletType.Common
                    || t.TempletType == (int)Code.Enums.TempletType.MSearch);
                }
                else
                {
                    expression = expression.And(t => t.TempletType == (int)Code.Enums.TempletType.Common);
                }
            }
            return service.FindList(expression, pagination).Distinct().ToList();
        }
        public void SubmitForm(TempletEntity moduleEntity, string keyValue)
        {
            service.SubmitForm(moduleEntity, keyValue);
        }

        public void DeleteForm(string keyValue)
        {
            TempletEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除模板信息=>" + keyValue, Enums.DbLogType.Delete, "模板管理");
        }

    }
}
