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
        /// 网站Id
        /// </summary>
        public string WebSiteId { get; set; }
        /// <summary>
        /// 网站对象
        /// </summary>
        public WebSiteEntity webSite { get; set; }
        /// <summary>
        /// 网站配置
        /// </summary>
        public WebSiteConfigEntity webSiteConfig { get; set; }
        /// <summary>
        /// 当前栏目
        /// </summary>
        public ColumnsEntity Column { get; set; }
        /// <summary>
        /// 当前模板
        /// </summary>
        public TempletEntity Templet { get; set; }
        /// <summary>
        /// 解码后模板内容
        /// </summary>
        public string TempletContent { get; set; }
        /// <summary>
        /// 栏目Id
        /// </summary>
        public string ColumnId { get; set; }
        /// <summary>
        /// 详情页Id
        /// </summary>
        public string ContentId { get; set; }
        /// <summary>
        /// 当前请求页数
        /// </summary>
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// 是否搜索页
        /// </summary>
        public bool IsSearch { get; set; } = false;

        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string SearchKeyWord { get; set; }
        /// <summary>
        /// 是否详情页
        /// </summary>
        public bool IsDetailPage { get; set; }
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
