using CMS.Data;
using System;
using System.ComponentModel;

namespace CMS.Domain.Entity.SystemManage
{
    public class OrganizeEntity : IEntity<OrganizeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("父级")]
        public string ParentId { get; set; }
        public int? Layers { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("编号")]
        public string EnCode { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }
        public string ShortName { get; set; }
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("类型")]
        public string CategoryId { get; set; }
        public string ManagerId { get; set; }
        public string TelePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WeChat { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string AreaId { get; set; }
        public string Address { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowDelete { get; set; }
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
