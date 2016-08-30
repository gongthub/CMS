using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class C_TempletEntity : IEntity<C_TempletEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public int F_SortCode { get; set; }
        public string F_FullName { get; set; }
        public string F_Description { get; set; }
        public string F_Content { get; set; }
        public bool F_EnabledMark { get; set; }
        public bool? F_DeleteMark { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public  DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; } 
    }
}
