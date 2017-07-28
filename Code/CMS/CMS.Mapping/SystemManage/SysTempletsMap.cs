using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.SystemManage
{
    public class SysTempletsMap : EntityTypeConfiguration<SysTempletsEntity>
    {
        public SysTempletsMap()
        {
            this.ToTable("Sys_Templets");
            this.HasKey(t => t.Id);
        }
    }
}