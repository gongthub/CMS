using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    public class Enums
    {
        public enum ModuleType
        { 
            [Description("导航")]
            Navigation = 0,
            [Description("内容")]
            Content = 1,
            [Description("列表")]
            List = 2,
            [Description("连接")]
            Link = 3
        }
        public enum UpFileModule
        {
            [Description("C_Contents")]
            Contents = 0,
            [Description("Sys_WebSites")]
            WebSites = 1,

        }
    }
}
