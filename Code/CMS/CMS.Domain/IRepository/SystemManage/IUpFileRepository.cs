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
    public interface IUpFileRepository : IRepositoryBase<UpFileEntity>
    {
        UpFileEntity InitUpFileEntity(UpFileDTO upFileDtoEntity);
        void DeleteByIds(List<string> keyValues);
    }
}
