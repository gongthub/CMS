﻿using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface ISysColumnsRepository : IRepositoryBase<SysColumnsEntity>
    {
        List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId);
    }
}
