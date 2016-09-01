using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.WebManage
{
    public class C_ContentMap : EntityTypeConfiguration<C_ContentEntity>
    {
      public C_ContentMap()
        {
            this.ToTable("C_Contents");
            this.HasKey(t => t.F_Id);
        }
    }
}
