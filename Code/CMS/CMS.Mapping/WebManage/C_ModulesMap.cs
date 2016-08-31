using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.WebManage
{
    public class C_ModulesMap : EntityTypeConfiguration<C_ModulesEntity>
    {
        public C_ModulesMap()
        {
            this.ToTable("C_Modules");
            this.HasKey(t => t.F_Id);
        }
    }
}
