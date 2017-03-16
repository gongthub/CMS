using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.Common
{
    public class UpFileDTO
    {

        /// <summary>
        /// FileName
        /// </summary>		
        public string FileName { get; set; }

        /// <summary>
        /// FileOldName
        /// </summary>		
        public string FileOldName { get; set; }

        /// <summary>
        /// ExtName
        /// </summary>		
        public string ExtName { get; set; }

        /// <summary>
        /// FilePath
        /// </summary>		
        public string FilePath { get; set; }

        /// <summary>
        /// FileMd5
        /// </summary>		
        public string FileMd5 { get; set; }
    }
}
