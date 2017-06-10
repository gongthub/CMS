using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class ContentEntity : IEntity<ContentEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string Id { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("站点")]
        public string WebSiteId { get; set; }
        public string ColumnId { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsInt)]
        [Description("排序")]
        public int SortCode { get; set; }
        public string ShortName { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }
        public string Author { get; set; }

        public DateTime? EditTime { get; set; }
        public string Description { get; set; }
        public string UrlPath { get; set; }
        public string UrlAddress { get; set; }
        public string FilePath { get; set; }
        public string Icon { get; set; }
        public string Content { get; set; }
        public string SEOTitle { get; set; }
        public string SEOKeyWords { get; set; }
        public string SEODesc { get; set; }
        public long ViewNum { get; set; }
        public bool EnabledMark { get; set; }
        public bool? DeleteMark { get; set; }
        public string CreatorUserId { get; set; }
        public DateTime? CreatorTime { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string LastModifyUserId { get; set; }
        public DateTime? LastModifyTime { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string Description6 { get; set; }
        public string Description7 { get; set; }
        public string Description8 { get; set; }
        public string Description9 { get; set; }
        public string Description10 { get; set; }

        [NotMapped]
        public string UrlPage { get; set; }

        [NotMapped]
        public List<Entity.SystemManage.UpFileEntity> UpImages { get; set; }
    }
}
