using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.SystemManage
{
    public class UserWebSiteEntity : IEntity<UserWebSiteEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {

        /// <summary>
        /// Id
        /// </summary>		
        public string Id { get; set; }

        /// <summary>
        /// UserId
        /// </summary>		
        public string UserId { get; set; }

        /// <summary>
        /// WebSiteId
        /// </summary>		
        public string WebSiteId { get; set; }

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
