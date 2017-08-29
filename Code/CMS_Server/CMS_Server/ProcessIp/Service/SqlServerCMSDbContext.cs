using ProcessIp.Model;
using ProcessIp.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessIp.Service
{
    public class SqlServerCMSDbContext : DbContext
    {
        public SqlServerCMSDbContext()
            : base(ConstUtility.IDBRepository)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccessLogEntity>().ToTable("Sys_AccessLog");
            modelBuilder.Entity<RequestLogEntity>().ToTable("Sys_RequestLog");
        }
        public DbSet<AccessLogEntity> AccessLogEntitys { get; set; }
        public DbSet<RequestLogEntity> RequestLogEntitys { get; set; }
    }
}
