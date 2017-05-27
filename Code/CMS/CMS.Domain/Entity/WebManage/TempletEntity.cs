using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class TempletEntity : IEntity<TempletEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("站点")]
        public string WebSiteId { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsInt)]
        [Description("排序")]
        public int SortCode { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int TempletType { get; set; }
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
