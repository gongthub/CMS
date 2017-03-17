using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class UserWebSiteApp
    {
        private IUserWebSiteRepository service = new UserWebSiteRepository();

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
                    UserWebSiteEntity entity = new UserWebSiteEntity();
                    entity.Create();
                    entity.UserId = UserId;
                    entity.WebSiteId = webSiteId;
                    entity.EnabledMark = true;
                    entitys.Add(entity);
                }
                service.Insert(entitys);
            }
        }

        /// <summary>
        /// 根据UserId删除关系
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string userId)
        {
            service.DeleteById(m => m.UserId == userId);
        }
    }
}
