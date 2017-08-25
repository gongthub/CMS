using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Mapping.SystemManage
{
    public class RequestLogMap : EntityTypeConfiguration<RequestLogEntity>
    {
       public RequestLogMap()
        {
            this.ToTable("Sys_RequestLog");
            this.HasKey(t => t.Id);
        }
    }
}
