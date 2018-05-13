using CMS.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;


namespace CMS.Mapping.SystemManage
{
    public class OrganizeColumnMap : EntityTypeConfiguration<OrganizeColumnEntity>
    {
        public OrganizeColumnMap()
        {
            this.ToTable("Sys_OrganizeColumns");
            this.HasKey(t => t.Id);
        }
    }
}