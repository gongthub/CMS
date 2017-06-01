using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class MessageConfigEntity : IEntity<MessageConfigEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("站点")]
        public string WebSiteId { get; set; }

        public int SortCode { get; set; }

        public string ColumnName { get; set; }

        public string ColumnShowName { get; set; }
        public bool ListShowMark { get; set; }
        public bool ViewShowMark { get; set; }
        public bool EnabledMark { get; set; }
        public bool? DeleteMark { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? LastModifyTime { get; set; } 
    }
}
