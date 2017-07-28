using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.SystemManage
{
    public class SysTempletItemsMap: EntityTypeConfiguration<SysTempletItemsEntity>
    {
        public SysTempletItemsMap()
        {
            this.ToTable("Sys_TempletItems");
            this.HasKey(t => t.Id);
        }
    }
}