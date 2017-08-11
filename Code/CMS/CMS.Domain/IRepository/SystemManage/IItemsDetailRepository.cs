using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace CMS.Domain.IRepository
{
    public interface IItemsDetailRepository : IRepositoryBase<ItemsDetailEntity>
    {
        List<ItemsDetailEntity> GetItemList(string enCode);
    }
}
