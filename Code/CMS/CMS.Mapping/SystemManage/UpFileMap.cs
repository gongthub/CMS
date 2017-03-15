using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.SystemManage
{
    public class UpFileMap : EntityTypeConfiguration<UpFileEntity>
    {
        public UpFileMap()
        {
            this.ToTable("Sys_UpFiles");
            this.HasKey(t => t.Id);
        }
    }
}
