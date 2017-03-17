using System;

namespace CMS.Domain.Entity.SystemSecurity
{
    public class LogEntity : IEntity<LogEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public DateTime? Date { get; set; }
        public string Account { get; set; }
        public string NickName { get; set; }
        public string Type { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressName { get; set; }
        public string ModuleId { get; set; }
        public string ModuleName { get; set; }
        public bool? Result { get; set; }
        public string Description { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? EnabledMark { get; set; } 
        public DateTime? CreatorTime { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
