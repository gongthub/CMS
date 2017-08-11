using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface ITempletRepository : IRepositoryBase<TempletEntity>
    {
        bool IsExistSearchModel(string WebSiteId);
        void SubmitForm(TempletEntity moduleEntity, string keyValue);
    }
}
