using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class SysColumnsRepository : SqlServerRepositoryBase<SysColumnsEntity>, ISysColumnsRepository
    {
        public List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId)
        {
            return IQueryable(m => m.SysTempletId == sysTempletId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
    }
}
