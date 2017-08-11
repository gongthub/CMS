using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class AccessLogApp
    {
        private static IAccessLogRepository service = DataAccess.CreateIAccessLogRepository;

        public List<AccessLogEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public AccessLogEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void SubmitForm(AccessLogEntity accessLogEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                accessLogEntity.Modify(keyValue);
                service.Update(accessLogEntity);
            }
            else
            {
                accessLogEntity.Create();
                service.Insert(accessLogEntity);
            }
        }

        /// <summary>
        /// 创建访问日志
        /// </summary>
        /// <param name="accessLogEntity"></param>
        public void Createlog(AccessLogEntity accessLogEntity)
        {
            accessLogEntity.Id = Common.GuId();
            accessLogEntity.Date = DateTime.Now;
            service.Insert(accessLogEntity);
        }
    }
}
