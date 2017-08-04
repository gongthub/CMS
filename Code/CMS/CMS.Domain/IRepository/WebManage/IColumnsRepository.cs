using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.WebManage
{
    public interface IColumnsRepository : IRepositoryBase<ColumnsEntity>
    {
        ColumnsEntity GetFormNoDel(string keyValue);
        void SubmitForm(ColumnsEntity moduleEntity, string keyValue);
    }
}
