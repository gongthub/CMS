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
        }
        public void SubmitForm(FilterIPEntity filterIPEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify(keyValue);
                service.Update(filterIPEntity);
            }
            else
            {
                filterIPEntity.Create();
                service.Insert(filterIPEntity);
            }
        }
    }
}
