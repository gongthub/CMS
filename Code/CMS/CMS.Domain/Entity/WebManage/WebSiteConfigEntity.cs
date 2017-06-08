using CMS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class WebSiteConfigEntity : IEntity<WebSiteConfigEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// Id
        /// </summary>		
        public string Id { get; set; }
        /// <summary>
        /// WebSiteId
        /// </summary>		
        [Verify(Code.Enums.VerifyType.IsNullOrEmpty, Code.Enums.VerifyType.IsNull, Code.Enums.VerifyType.IsGuid)]
        [Description("站点")]
        public string WebSiteId { get; set; }

        /// <summary>
        /// 全站搜索标识
        /// </summary>		
        public bool SearchEnabledMark { get; set; }
        /// <summary>
        /// 网站维护中标识
        /// </summary>		
        public bool ServiceEnabledMark { get; set; }
        /// <summary>
        /// 网站留言板标识
        /// </summary>		
        public bool MessageEnabledMark { get; set; }
        /// <summary>
        /// 高级列表标识
        /// </summary>		
        public bool AdvancedContentEnabledMark { get; set; }

        /// <summary>
        /// EnabledMark
        /// </summary>		
        public bool EnabledMark { get; set; }

        /// <summary>
        /// DeleteMark
        /// </summary>		
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// CreatorUserId
        /// </summary>		
        public string CreatorUserId { get; set; }

        /// <summary>
        /// CreatorTime
        /// </summary>		
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// DeleteUserId
        /// </summary>		
        public string DeleteUserId { get; set; }

        /// <summary>
        /// DeleteTime
        /// </summary>		
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// LastModifyTime
        /// </summary>		
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// LastModifyUserId
        /// </summary>		
        public string LastModifyUserId { get; set; }
    }
}
