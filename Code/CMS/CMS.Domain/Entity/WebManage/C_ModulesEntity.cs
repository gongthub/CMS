using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class C_ModulesEntity : IEntity<C_ModulesEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string F_Id { get; set; }
        public string F_ParentId { get; set; }
        public string F_TempletId { get; set; }
        public string F_CTempletId { get; set; }
        public int F_SortCode { get; set; }
        public string F_FullName { get; set; }

        [Description("0:导航 1:内容 2:列表 3:连接")]
        public int F_Type { get; set; }
        public string F_ActionName { get; set; }
        public string F_Description { get; set; }
        public string F_UrlAddress { get; set; }
        public string F_Icon { get; set; }
        public bool F_EnabledMark { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_MainMark { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_DeleteUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; } 
    }
}
