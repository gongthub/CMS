﻿using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class MessagesRepository : MySqlRepositoryBase<MessagesEntity>, IMessagesRepository
    {
    }
}