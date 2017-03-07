using System;

namespace CMS.Domain
{
    public interface IModificationAudited
    {
        string Id { get; set; }
        string LastModifyUserId { get; set; }
        DateTime? LastModifyTime { get; set; }
    }
}