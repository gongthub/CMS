using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.WebManage
{
    public class WebSiteRepository : RepositoryBase<WebSiteEntity>, IWebSiteRepository
    {
        private IUserWebSiteRepository iUserWebSiteRepository = new UserWebSiteRepository();
        public List<WebSiteEntity> GetListForUserId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            List<string> webSiteIds = GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            return IQueryable(expression).ToList();
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
            return IQueryable(expression).ToList();
        }
        public List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            List<string> webSiteIds = GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return FindList(expression, pagination);
        }

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        public bool IsExistDefaultWebSite(ref string webSiteId)
        {
            bool bState = false;
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    List<WebSiteEntity> webSiteEntitys = GetListForUserId();
                    if (webSiteEntitys != null && webSiteEntitys.Count > 0)
                    {
                        if (webSiteEntitys.Count == 1)
                        {
                            bState = true;
                            webSiteId = webSiteEntitys[0].Id;
                        }
                        else
                        {
                            WebSiteEntity webSiteEntity = webSiteEntitys.Find(m => m.MainMark == true);
                            if (webSiteEntity != null)
                            {
                                bState = true;
                                webSiteId = webSiteEntity.Id;
                            }
                        }
                    }
                }
            }
            return bState;
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
                    lstrids = IQueryable(t => t.DeleteMark != true).Select(m => m.Id).ToList();
                }
                else
                {
                    lstrids = iUserWebSiteRepository.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
                }
            }
            return lstrids;
        }
        /// <summary>
        /// 根据用户获取所属站点
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteIds(string userId)
        {
            return iUserWebSiteRepository.IQueryable(t => t.UserId == userId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
        }
    }
}
