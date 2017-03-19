using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        /// KeyWords
        /// </summary>		
        public string KeyWords { get; set; }

        /// <summary>
        /// SiteDesc
        /// </summary>		
        public string SiteDesc { get; set; }

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

        #region 业务实体

        //[NotMapped]
        //public  List<WebSiteForUrlEntity> webSiteForUrlEntitys { get; set; }

        /// <summary>
        /// SpareUrlAddress01
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress01 { get; set; }
        /// <summary>
        /// SpareUrlAddress02
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress02 { get; set; }
        /// <summary>
        /// SpareUrlAddress03
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress03 { get; set; }
        /// <summary>
        /// SpareUrlAddress04
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress04 { get; set; }
        /// <summary>
        /// SpareUrlAddress05
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress05 { get; set; }
        /// <summary>
        /// SpareUrlAddress06
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress06 { get; set; }
        /// <summary>
        /// SpareUrlAddress07
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress07 { get; set; }
        /// <summary>
        /// SpareUrlAddress08
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress08 { get; set; }
        /// <summary>
        /// SpareUrlAddress09
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress09 { get; set; }
        /// <summary>
        /// SpareUrlAddress10
        /// </summary>	
        [NotMapped]
        public string SpareUrlAddress10 { get; set; }
        
        #endregion
    }
}
