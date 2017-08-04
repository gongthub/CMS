using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.SystemManage
{
    public class SysColumnsRepository : RepositoryBase<SysColumnsEntity>, ISysColumnsRepository
    {
        public List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId)
        {
            return IQueryable(m => m.SysTempletId == sysTempletId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
    }
}
