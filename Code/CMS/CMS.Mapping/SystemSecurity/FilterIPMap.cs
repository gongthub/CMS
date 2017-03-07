using CMS.Domain.Entity.SystemSecurity;
using System.Data.Entity.ModelConfiguration;

namespace CMS.Mapping.SystemSecurity
{
    public class FilterIPMap : EntityTypeConfiguration<FilterIPEntity>
    {
        public FilterIPMap()
        {
            this.ToTable("Sys_FilterIP");
            this.HasKey(t => t.Id);
        }
    }
}
