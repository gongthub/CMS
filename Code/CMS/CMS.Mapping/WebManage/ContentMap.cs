using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.WebManage
{
    public class ContentMap : EntityTypeConfiguration<ContentEntity>
    {
      public ContentMap()
        {
            this.ToTable("C_Contents");
            this.HasKey(t => t.Id);
        }
    }
}
