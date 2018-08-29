using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Common
{
    public class TempleteProcessModel
    {
        /// <summary>
        /// 当前模板块
        /// </summary>
        public string TempletPiece { get; set; }
        /// <summary>
        /// 当前模板块内容
        /// </summary>
        public string TempletPieceContent { get; set; }
        /// <summary>
        /// 当前模板块属性
        /// </summary>
        public Dictionary<string, string> TempletPieceAttrs { get; set; }

        public RequestModel requestModel { get; set; }
    }
}
