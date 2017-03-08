using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class ColumnsEntity : IEntity<ColumnsEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }
        public string WebSiteId { get; set; }
        public string ParentId { get; set; }
        public string TempletId { get; set; }
        public string CTempletId { get; set; }
        public int SortCode { get; set; }
        public string FullName { get; set; }

        [Description("0:导航 1:内容 2:列表 3:连接")]
        public int Type { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public string UrlAddress { get; set; }
        public string Icon { get; set; }
        public bool EnabledMark { get; set; }
        public bool? DeleteMark { get; set; }
        public bool? MainMark { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? LastModifyTime { get; set; } 
    }
}
