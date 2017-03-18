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

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
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

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
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
            return service.FindEntity(keyValue);
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

                if (!IsExistUrl(keyValue, moduleEntity.UrlAddress))
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        service.Update(moduleEntity);
                    }
                    else
                    {
                        moduleEntity.Create();
                        service.Insert(moduleEntity);
                    }

                    var LoginInfo = OperatorProvider.Provider.GetCurrent();
                    if (LoginInfo != null)
                    {
                        new UserWebSiteApp().AddUserWebSite(LoginInfo.UserId, moduleEntity.Id);
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
        public void SubmitForm(WebSiteEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            int iWebSiteNum = 0;
            if (IsOverNum(out iWebSiteNum))
            {
                if (!IsExistUrl(keyValue, moduleEntity.UrlAddress))
                {
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
                    }
                    //更新上传文件表
                    UpFileApp upFileApp = new UpFileApp();
                    upFileentity.Sys_ParentId = keyValue;
                    upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.WebSites);
                    upFileApp.AddUpFileEntity(upFileentity);

                    var LoginInfo = OperatorProvider.Provider.GetCurrent();
                    if (LoginInfo != null)
                    {
                        new UserWebSiteApp().AddUserWebSite(LoginInfo.UserId, moduleEntity.Id);
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
    }
}
