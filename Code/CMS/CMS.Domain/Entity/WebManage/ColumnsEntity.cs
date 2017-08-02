using CMS.Data;
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

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("站点")]
        public string WebSiteId { get; set; }

        [Verify(Code.Enums.VerifyType.IsParentIdOrDefault)]
        [Description("父级")]
        public string ParentId { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("栏目模板")]
        public string TempletId { get; set; }
        public string CTempletId { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsInt)]
        [Description("排序")]
        public int SortCode { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull)]
        [Description("名称")]
        public string FullName { get; set; }

        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsInt)]
        [Description("类别")]
        //[Description("0:导航 1:内容 2:列表 3:连接")]
        public int Type { get; set; }
        public string ActionName { get; set; }
        public string Description { get; set; }
        public string UrlPath { get; set; }
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
