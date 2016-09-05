using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
   public class C_ContentEntity : IEntity<C_ContentEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public string F_ModuleId { get; set; }
        public int F_SortCode { get; set; }
        public string F_FullName { get; set; }
        public string F_Author { get; set; }
        public DateTime F_EditTime { get; set; }
        public string F_Description { get; set; }
        public string F_UrlAddress { get; set; }
        public string F_Icon { get; set; }
        public string F_Content { get; set; }
        public string F_SEOTitle { get; set; }
        public string F_SEOKeyWords { get; set; }
        public string F_SEODesc { get; set; }
        public bool F_EnabledMark { get; set; }
        public bool? F_DeleteMark { get; set; } 
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }

       [NotMapped]
        public string F_UrlPage { get; set; }
    }
}
