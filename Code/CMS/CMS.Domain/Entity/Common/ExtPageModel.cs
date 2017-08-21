using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Common
{
    public class ExtPageModel : PageModel
    {
        /// <summary>
        /// 总显示数据条数
        /// </summary>		
        public int Total { get; set; }
        public string SourceIds { get; set; }
        public string SourceName { get; set; }
        public string Sort { get; set; }
        public string SortDesc { get; set; }
        public string MCodes { get; set; }
        public bool IsHtml { get; set; }
        public string Htmlstr { get; set; }
        public List<ContentEntity> ContentModels { get; set; }
        public Dictionary<string,string> AttrDatas { get; set; }
    }
}
