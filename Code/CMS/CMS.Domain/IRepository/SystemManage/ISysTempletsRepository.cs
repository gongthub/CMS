using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository.SystemManage
{
    public interface ISysTempletsRepository : IRepositoryBase<SysTempletsEntity>
    {
        List<SysTempletItemsEntity> GetItemList(string parentIds);
        List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId);
        void DeleteForm(string keyValue);
        void SubmitForm(SysTempletsEntity moduleEntity, string keyValue, UpFileDTO upFileentity);
    }
}
