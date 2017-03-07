using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class TempletEntity : IEntity<TempletEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public int SortCode { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public bool EnabledMark { get; set; }
        public bool? DeleteMark { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public  DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; } 
    }
}
