using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Common
{
    public class PageModel
    {
        /// <summary>
        /// 总数据条数
        /// </summary>		
        public int TotalCount { get; set; }
        /// <summary>
        /// 每页数据条数
        /// </summary>		
        public int CurrCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>		
        public int TotalPage { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>		
        public int CurrPage { get; set; }
        /// <summary>
        /// 控件ID
        /// </summary>		
        public string EleId { get; set; }
    }
}
