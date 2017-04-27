using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.SystemManage
{
    public class AccessLogMap : EntityTypeConfiguration<AccessLogEntity>
    {
        public AccessLogMap()
        {
            this.ToTable("Sys_AccessLog");
            this.HasKey(t => t.Id);
        }
    }
}
