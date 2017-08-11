using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using System.Collections.Generic;

namespace CMS.Domain.IRepository
{
    public interface IModuleButtonRepository : IRepositoryBase<ModuleButtonEntity>
    {
        void SubmitCloneButton(List<ModuleButtonEntity> entitys);
    }
}
