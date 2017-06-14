using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemSecurity;
using CMS.Domain.IRepository.SystemSecurity;
using CMS.Repository.SystemSecurity;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemSecurity
{
    public class FilterIPApp
    {
        private IFilterIPRepository service = new FilterIPRepository();

        public List<FilterIPEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<FilterIPEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.StartIP.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        public List<FilterIPEntity> GetList(string keyword)
        {
            var expression = ExtLinq.True<FilterIPEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.StartIP.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.IQueryable(expression).OrderByDescending(t => t.DeleteTime).ToList();
        }
        public FilterIPEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除IP限制信息=>" + keyValue, Enums.DbLogType.Delete, "IP限制管理");
        }
        public void SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify(keyValue);
                service.Update(filterIPEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改IP限制信息=>" + filterIPEntity.StartIP + "-" + filterIPEntity.EndIP, Enums.DbLogType.Update, "IP限制管理");
            }
            else
            {
                filterIPEntity.Create();
                service.Insert(filterIPEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加IP限制信息=>" + filterIPEntity.StartIP + "-" + filterIPEntity.EndIP, Enums.DbLogType.Create, "IP限制管理");
            }
        }
    }
}
