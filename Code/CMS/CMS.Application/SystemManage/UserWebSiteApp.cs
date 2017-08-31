using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class UserWebSiteApp
    {
        private IUserWebSiteRepository service = DataAccess.CreateIUserWebSiteRepository();
        private IWebSiteRepository webSiteservice = DataAccess.CreateIWebSiteRepository();

        public List<UserWebSiteEntity> GetList(Pagination pagination, string userId)
        {
            var expression = ExtLinq.True<UserWebSiteEntity>();
            if (!string.IsNullOrEmpty(userId))
            {
                expression = expression.And(t => t.UserId == userId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }

        public List<UserWebSiteEntity> GetList(string userId)
        {
            return service.IQueryable(t => t.UserId == userId && t.DeleteMark != true).ToList();
        }
        /// <summary>
        /// 获取当前用户所有站点简称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteShortName()
        {
            List<string> lstshortNames = new List<string>();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    lstshortNames = webSiteservice.IQueryable(t => t.DeleteMark != true).Select(m => m.ShortName).ToList();
                }
                else
                {
                    List<string> ids = service.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
                    lstshortNames = webSiteservice.IQueryable(t => t.DeleteMark != true && ids.Contains(t.Id)).Select(m => m.ShortName).ToList();
                }
            }
            return lstshortNames;
        }
        /// <summary>
        /// 获取当前用户所有站点简称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteShortName(out List<string> webSiteIds)
        {
            List<string> lstshortNames = new List<string>();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            webSiteIds = new List<string>();
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    List<WebSiteEntity> webSiteEntitys = webSiteservice.IQueryable(t => t.DeleteMark != true).ToList();
                    lstshortNames = webSiteEntitys.Select(m => m.ShortName).ToList();
                    webSiteIds = webSiteEntitys.Select(m => m.Id).ToList();
                }
                else
                {
                    List<string> ids = service.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();

                    List<WebSiteEntity> webSiteEntitys = webSiteservice.IQueryable(t => t.DeleteMark != true && ids.Contains(t.Id)).ToList();
                    lstshortNames = webSiteEntitys.Select(m => m.ShortName).ToList();
                    webSiteIds = webSiteEntitys.Select(m => m.Id).ToList();
                }
            }
            return lstshortNames;
        }
        /// <summary>
        /// 获取当前用户所有站点Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteIds()
        {
            List<string> lstrids = new List<string>();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    lstrids = webSiteservice.IQueryable(t => t.DeleteMark != true).Select(m => m.Id).ToList();
                }
                else
                {
                    lstrids = service.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
                }
            }
            return lstrids;
        }
        /// <summary>
        /// 获取当前用户所有站点数量
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int GetWebSiteNums()
        {
            int num = 0;
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    num = webSiteservice.IQueryable(t => t.DeleteMark != true).Select(m => m.Id).Count();
                }
                else
                {
                    num = service.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).Count();
                }
            }
            return num;
        }
        /// <summary>
        /// 根据用户获取所属站点
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteIds(string userId)
        {
            return service.IQueryable(t => t.UserId == userId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
        }
        /// <summary>
        /// 保存用户站点关系
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="webSiteIds"></param>
        public void SaveUserWebSite(string UserId, string[] webSiteIds)
        {
            DeleteForm(UserId);

            if (webSiteIds != null && webSiteIds.Length > 0)
            {
                List<UserWebSiteEntity> entitys = new List<UserWebSiteEntity>();
                foreach (var webSiteId in webSiteIds)
                {
                    AddUserWebSite(UserId, webSiteId);
                }
            }
        }

        /// <summary>
        /// 添加用户站点关系
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="webSiteIds"></param>
        public void AddUserWebSite(string UserId, string webSiteIds)
        {
            if (!string.IsNullOrEmpty(webSiteIds))
            {
                UserWebSiteEntity entity = new UserWebSiteEntity();
                entity.Create();
                entity.UserId = UserId;
                entity.WebSiteId = webSiteIds;
                entity.EnabledMark = true;
                service.Insert(entity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加用户站点信息=>用户：" + UserId + "=>站点：" + webSiteIds, Enums.DbLogType.Create, "用户站点管理");
            }
        }
        /// <summary>
        /// 根据UserId删除关系
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string userId)
        {
            service.DeleteById(m => m.UserId == userId);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除用户站点信息=>" + userId, Enums.DbLogType.Delete, "用户站点管理");
        }
    }
}
