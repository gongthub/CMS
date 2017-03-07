using CMS.Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace CMS.Mapping.SystemManage
{
    public class UserMap : EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            this.ToTable("Sys_User");
            this.HasKey(t => t.Id);
        }
    }
}
