using CMS.Data;
using System;
using System.ComponentModel;

namespace CMS.Domain.Entity.SystemManage
{
    public class AreaEntity : IEntity<AreaEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsNullOrGuid)]
        [Description("父级")]
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }
        public string SimpleSpelling { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsInt)]
        [Description("排序")]	
        public int? SortCode { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? EnabledMark { get; set; }
        public string Description { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
