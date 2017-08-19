using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using System.Collections.Generic;

namespace CMS.MySqlRepository
{
    public class ModuleButtonRepository : MySqlRepositoryBase<ModuleButtonEntity>, IModuleButtonRepository
    {
        public void SubmitCloneButton(List<ModuleButtonEntity> entitys)
        {
            using (var db = new MySqlRepositoryBase().BeginTrans())
            {
                foreach (var item in entitys)
                {
                    db.Insert(item);
                }
                db.Commit();
            }
        }
    }
}
