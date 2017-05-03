using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.WebManage
{
    public class ResourceEntity
    {
        public string id { get; set; }
        public string DirName { get; set; }
        public int Type { get; set; }
        public int level { get; set; }
        public string UrlAddress { get; set; }
        public string parent { get; set; }
        public bool isLeaf { get; set; }
        public bool expanded { get; set; }
        public bool loaded { get; set; }
    }
}
