using System;

namespace CMS.Domain.Entity.SystemManage
{
    public class RoleAuthorizeEntity : IEntity<RoleAuthorizeEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public int? ItemType { get; set; }
        public string ItemId { get; set; }
        public int? ObjectType { get; set; }
        public string ObjectId { get; set; }
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
