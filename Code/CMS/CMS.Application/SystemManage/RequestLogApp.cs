using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class RequestLogApp
    {
        private static IRequestLogRepository service = DataAccess.CreateIRequestLogRepository();

        public List<RequestLogEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public List<RequestLogEntity> GetListByDate(DateTime startDate, DateTime endDate)
        {
            endDate = endDate.AddDays(1);
            return service.IQueryable(m => m.DeleteMark != true && m.StartDateTime >= startDate && m.StartDateTime < endDate).ToList();
        }
        public RequestLogEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void SubmitForm(RequestLogEntity accessLogEntity, string keyValue)
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
        public void Createlog(RequestLogEntity accessLogEntity)
        {
            accessLogEntity.Id = Common.GuId();
            accessLogEntity.EndDateTime = DateTime.Now;
            service.Insert(accessLogEntity);
            LogFactory.GetLogger(this.GetType()).Info("异常：结束插入请求日志111\r\n");
        }
    }
}
