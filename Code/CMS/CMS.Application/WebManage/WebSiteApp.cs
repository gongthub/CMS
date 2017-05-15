using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class WebSiteApp
    {
        private IWebSiteRepository service = new WebSiteRepository();
        private IWebSiteForUrlRepository serviceWebSiteForUrl = new WebSiteForUrlRepository();

        public List<WebSiteEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }

        public WebSiteEntity GetFormByName(string Name)
        {
            WebSiteEntity model = new WebSiteEntity();
            model = service.FindEntity(m => m.FullName == Name && m.DeleteMark != true);
            return model;
        }
        public WebSiteEntity GetFormByUrl(string url)
        {
            WebSiteEntity model = new WebSiteEntity();
            model = service.FindEntity(m => m.UrlAddress == url && m.DeleteMark != true);
            return model;
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
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            return service.IQueryable(expression).ToList();
        }

        public List<WebSiteEntity> GetListByCreatorId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            expression = expression.And(t => t.DeleteMark != true);

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                expression = expression.And(t => t.CreatorUserId == LoginInfo.UserId);
            }
            return service.IQueryable(expression).ToList();
        }
        public int GetCountByCreatorId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            expression = expression.And(t => t.DeleteMark != true);

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                expression = expression.And(t => t.CreatorUserId == LoginInfo.UserId);
            }
            return service.IQueryable(expression).Count();
        }
        public List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
            List<string> webSiteIds = userWebSiteApp.GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public WebSiteEntity GetForm(string keyValue)
        {
            WebSiteEntity webSiteEntity = service.FindEntity(keyValue);

            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                new WebSiteForUrlApp().InitWebSiteUrl(ref webSiteEntity);
            }

            return webSiteEntity;
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
        }
        public void SubmitForm(WebSiteEntity moduleEntity, string keyValue)
        {
            int iWebSiteNum = 0;
            if (IsOverNum(out iWebSiteNum))
            {
                moduleEntity.UrlAddress = moduleEntity.UrlAddress.Trim();
                if (!new WebSiteForUrlApp().IsExistUrl(moduleEntity, moduleEntity.UrlAddress))
                {
                    InitSpareUrl(ref moduleEntity);
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        service.Update(moduleEntity);
                    }
                    else
                    {
                        moduleEntity.Create();
                        service.Insert(moduleEntity);

                        //var LoginInfo = OperatorProvider.Provider.GetCurrent();
                        var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                        if (LoginInfo != null)
                        {
                            new UserWebSiteApp().AddUserWebSite(LoginInfo.UserId, moduleEntity.Id);
                        }
                    }
                }
                else
                {
                    throw new Exception("域名已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("当前用户最多可添加" + iWebSiteNum + "个站点，如需添加更多站点，请联系管理员！");
            }
        }
        public void SubmitForm(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue, UpFileDTO upFileentity)
        {
            int iWebSiteNum = 0;
            if (IsOverNum(out iWebSiteNum))
            {
                moduleEntity.UrlAddress = moduleEntity.UrlAddress.Trim();
                moduleEntity.Id = keyValue;
                if (!new WebSiteForUrlApp().IsExistUrl(moduleEntity, moduleEntity.UrlAddress))
                {
                    if (!service.IsExist(keyValue, "ShortName", moduleEntity.ShortName, true))
                    {
                        InitSpareUrl(ref moduleEntity);
                        if (!string.IsNullOrEmpty(keyValue))
                        {
                            moduleEntity.Modify(keyValue);
                            service.Update(moduleEntity);
                        }
                        else
                        {
                            moduleEntity.Create();
                            service.Insert(moduleEntity);
                            keyValue = moduleEntity.Id;

                            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
                            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                            if (LoginInfo != null)
                            {
                                new UserWebSiteApp().AddUserWebSite(LoginInfo.UserId, moduleEntity.Id);
                            }
                        }
                        //更新上传文件表
                        UpFileApp upFileApp = new UpFileApp();
                        upFileentity.Sys_WebSiteId = moduleEntity.Id;
                        upFileentity.Sys_ParentId = keyValue;
                        upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.WebSites);
                        upFileApp.AddUpFileEntity(upFileentity);
                        SaveWebSiteSpareUrl(moduleEntity, webSiteForUrlEntitys, keyValue);
                    }
                    else
                    {
                        throw new Exception("简称已存在，请重新输入！");
                    }
                }
                else
                {
                    throw new Exception("域名已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("当前用户最多可添加" + iWebSiteNum + "个站点，如需添加更多站点，请联系管理员！");
            }
        }

        /// <summary>
        /// 保存备用域名
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="keyValue"></param>
        private static void SaveWebSiteSpareUrl(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue)
        {
            if (webSiteForUrlEntitys != null && webSiteForUrlEntitys.Count() > 0)
            {
                webSiteForUrlEntitys.ForEach(m => m.WebSiteId = keyValue);

                WebSiteForUrlEntity webSiteForUrlEntity = new WebSiteForUrlEntity();
                webSiteForUrlEntity.SortCode = 0;
                webSiteForUrlEntity.MainMark = true;
                webSiteForUrlEntity.WebSiteId = keyValue;
                webSiteForUrlEntity.UrlAddress = moduleEntity.UrlAddress;
                webSiteForUrlEntitys.Add(webSiteForUrlEntity);
                new WebSiteForUrlApp().Save(webSiteForUrlEntitys);
            }

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
        public WebSiteEntity GetModelByShortName(string shortName)
        {
            WebSiteEntity webSiteEntity = new WebSiteEntity();

            webSiteEntity = service.FindEntity(m => m.ShortName == shortName && m.DeleteMark != true);
            return webSiteEntity;
        }
        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistUrl(string keyId, string url)
        {
            url = url.Trim();
            bool retBool = false;
            int flay = 0;   //标示位 判断是否需要查询
            if (!string.IsNullOrEmpty(keyId))
            {
                Guid id = Guid.Empty;
                WebSiteEntity moduleEntity = service.FindEntity(m => m.Id == keyId);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    if (moduleEntity.UrlAddress != url)
                    {
                        flay = 1;
                    }
                }
            }
            else
            {
                flay = 1;
            }
            //需要判断
            if (flay == 1)
            {
                Guid id = Guid.Empty;
                WebSiteEntity moduleEntity = service.FindEntity(m => m.UrlAddress == url && m.DeleteMark != true);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    retBool = true;
                }
            }

            return retBool;
        }
        /// <summary>
        /// 判断当前用户添加网站数量
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsOverNum(out int iWebSiteNum)
        {
            bool retBool = false;

            iWebSiteNum = new UserApp().GetUserWebSiteMaxNum();
            int userWebSiteNum = GetCountByCreatorId();
            if (userWebSiteNum < iWebSiteNum)
            {
                retBool = true;
            }

            return retBool;
        }
        /// <summary>
        /// 初始化备用域名字段为Null
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void InitSpareUrl(ref WebSiteEntity moduleEntity)
        {
            moduleEntity.SpareUrlAddress01 = null;
            moduleEntity.SpareUrlAddress02 = null;
            moduleEntity.SpareUrlAddress03 = null;
            moduleEntity.SpareUrlAddress04 = null;
            moduleEntity.SpareUrlAddress05 = null;
            moduleEntity.SpareUrlAddress06 = null;
            moduleEntity.SpareUrlAddress07 = null;
            moduleEntity.SpareUrlAddress08 = null;
            moduleEntity.SpareUrlAddress09 = null;
            moduleEntity.SpareUrlAddress10 = null;
        }
    }
}
