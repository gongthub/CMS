using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Common
{
    public class RequestModel
    {
        /// <summary>
        /// 网站对象
        /// </summary>
        public WebSiteEntity webSiteEntity { get; set; }
        /// <summary>
        /// 访问者域名
        /// </summary>
        public string UrlHost { get; set; }
        /// <summary>
        /// 访问者请求路径
        /// </summary>
        public string UrlRaw { get; set; }
        /// <summary>
        /// 处理后访问者请求路径
        /// </summary>
        public List<string> UrlRaws { get; set; }
        /// <summary>
        /// 访问者是否为手机
        /// </summary>
        public bool IsMobile { get; set; }
    }
}
