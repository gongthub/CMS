using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.WebManage
{
    public class ColumnsMap : EntityTypeConfiguration<ColumnsEntity>
    {
        public ColumnsMap()
        {
            this.ToTable("C_Columns");
            this.HasKey(t => t.Id);
        }
    }
}
