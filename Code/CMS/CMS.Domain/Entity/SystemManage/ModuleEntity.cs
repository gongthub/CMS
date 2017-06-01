using CMS.Data;
using System;
using System.ComponentModel;

namespace CMS.Domain.Entity.SystemManage
{
    public class ModuleEntity : IEntity<ModuleEntity>, ICreationAudited, IModificationAudited, IDeleteAudited
    {
        public string Id { get; set; }

        public string ParentId { get; set; }
        public int? Layers { get; set; }
        public string EnCode { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }
        public string Icon { get; set; }
        public string UrlAddress { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("目标")]
        public string Target { get; set; }
        public bool? IsMenu { get; set; }
        public bool? IsExpand { get; set; }
        public bool? IsPublic { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
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
