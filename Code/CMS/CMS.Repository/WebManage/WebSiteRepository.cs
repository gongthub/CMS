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
            List<string> webSiteIds = iUserWebSiteRepository.GetWebSiteIds();
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
            List<string> webSiteIds = iUserWebSiteRepository.GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return FindList(expression, pagination);
        }
    }
}
