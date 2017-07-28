using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.SystemManage
{
    public class SysTempletsEntity : IEntity<SysTempletsEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; } 

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsInt)]
        [Description("排序")]
        public int SortCode { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("简称")]
        public string ShortName { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool EnabledMark { get; set; }
        public bool? DeleteMark { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; } 
    }
}
