using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class WebSiteEntity : IEntity<WebSiteEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        /// <summary>
        /// Id
        /// </summary>		
        public string Id { get; set; }
        /// <summary>
        /// ParentId
        /// </summary>		
        public string ParentId { get; set; }

        /// <summary>
        /// FullName
        /// </summary>		
        public string FullName { get; set; }

        /// <summary>
        /// UrlAddress
        /// </summary>		
        public string UrlAddress { get; set; }

        /// <summary>
        /// Point
        /// </summary>		
        public string Point { get; set; }
        /// <summary>
        /// SortCode
        /// </summary>		
        public int SortCode { get; set; }

        /// <summary>
        /// ShortName
        /// </summary>		
        public string ShortName { get; set; }

        /// <summary>
        /// Icon
        /// </summary>		
        public string Icon { get; set; }

        /// <summary>
        /// UserName
        /// </summary>		
        public string UserName { get; set; }

        /// <summary>
        /// Phone
        /// </summary>		
        public string Phone { get; set; }

        /// <summary>
        /// Email
        /// </summary>		
        public string Email { get; set; }

        /// <summary>
        /// Record
        /// </summary>		
        public string Record { get; set; }

        /// <summary>
        /// VisitorNum
        /// </summary>		
        public long VisitorNum { get; set; }

        /// <summary>
        /// LastVistorTime
        /// </summary>		
        public DateTime? LastVistorTime { get; set; }

        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }

        /// <summary>
        /// EnabledMark
        /// </summary>		
        public bool EnabledMark { get; set; }

        /// <summary>
        /// DeleteMark
        /// </summary>		
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// MainMark
        /// </summary>		
        public bool MainMark { get; set; }

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
