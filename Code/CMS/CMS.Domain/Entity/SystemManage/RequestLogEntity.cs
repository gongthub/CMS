using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.SystemManage
{
    public class RequestLogEntity : IEntity<RequestLogEntity>, IDeleteAudited
    {
        /// <summary>
        /// Id
        /// </summary>		
        public string Id { get; set; }

        /// <summary>
        /// WebSiteId
        /// </summary>		
        public string WebSiteId { get; set; }
        /// <summary>
        /// WebSiteName
        /// </summary>		
        public string WebSiteName { get; set; }
        ///// <summary>
        ///// StartId
        ///// </summary>		
        //public string StartId { get; set; }

        ///// <summary>
        ///// EndId
        ///// </summary>		
        //public string EndId { get; set; }

        /// <summary>
        /// SessionID
        /// </summary>		
        public string SessionID { get; set; }
        /// <summary>
        /// ClientID
        /// </summary>		
        public string ClientID { get; set; }

        /// <summary>
        /// IPAddress
        /// </summary>		
        public string IPAddress { get; set; }

        /// <summary>
        /// Province
        /// </summary>		
        public string Province { get; set; }

        /// <summary>
        /// City
        /// </summary>		
        public string City { get; set; }

        /// <summary>
        /// Area
        /// </summary>		
        public string Area { get; set; }
        /// <summary>
        /// Country
        /// </summary>		
        public string Country { get; set; }
        /// <summary>
        /// CountryNo
        /// </summary>		
        public string CountryNo { get; set; }
        /// <summary>
        /// BigArea
        /// </summary>		
        public string BigArea { get; set; }
        /// <summary>
        /// Isp
        /// </summary>		
        public string Isp { get; set; }
        public bool? IsProcessIp { get; set; }


        /// <summary>
        /// NetType
        /// </summary>		
        public string NetType { get; set; }

        /// <summary>
        /// Browser
        /// </summary>		
        public string Browser { get; set; }
        /// <summary>
        /// BrowserID
        /// </summary>		
        public string BrowserID { get; set; }
        /// <summary>
        /// BrowserVersion
        /// </summary>		
        public string BrowserVersion { get; set; }
        /// <summary>
        /// BrowserType
        /// </summary>		
        public string BrowserType { get; set; }
        /// <summary>
        /// BrowserPlatform
        /// </summary>		
        public string BrowserPlatform { get; set; }

        /// <summary>
        /// PUrlAddress
        /// </summary>		
        public string PUrlAddress { get; set; }

        /// <summary>
        /// UrlAddress
        /// </summary>		
        public string UrlAddress { get; set; }
        /// <summary>
        /// UrlHost
        /// </summary>		
        public string UrlHost { get; set; }
        /// <summary>
        /// UrlRaw
        /// </summary>		
        public string UrlRaw { get; set; }

        /// <summary>
        /// StartDateTime
        /// </summary>		
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// EndDateTime
        /// </summary>		
        public DateTime EndDateTime { get; set; }

        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }

        public bool? EnabledMark { get; set; }

        public bool? DeleteMark { get; set; }
        public DateTime? DeleteTime { get; set; }
        public string DeleteUserId { get; set; }
    }
}
