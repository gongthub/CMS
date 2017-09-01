using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ViewModel
{
    public class EchartSeries
    {
        public string name { get; set; }
        public string type { get; set; }
        public string stack { get; set; }
        public object data { get; set; }
    }
}
