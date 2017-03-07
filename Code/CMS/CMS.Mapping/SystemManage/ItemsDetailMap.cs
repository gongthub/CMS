using CMS.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace CMS.Mapping.SystemManage
{
    public class ItemsDetailMap : EntityTypeConfiguration<ItemsDetailEntity>
    {
        public ItemsDetailMap()
        {
            this.ToTable("Sys_ItemsDetail");
            this.HasKey(t => t.Id);
        }
    }
}
