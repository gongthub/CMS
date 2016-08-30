using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.WebManage
{
    public class C_TempletMap : EntityTypeConfiguration<C_TempletEntity>
    {
        public C_TempletMap()
        {
            this.ToTable("C_Templets");
            this.HasKey(t => t.F_Id);
        }
    }
}
