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
        /// Sys_ParentId
        /// </summary>		
        public string Sys_ParentId { get; set; }


        /// <summary>
        /// Sys_SortCode
        /// </summary>		
        public int Sys_SortCode { get; set; }

        /// <summary>
        /// Sys_ModuleName
        /// </summary>		
        public string Sys_ModuleName { get; set; }
        /// <summary>
        /// Sys_FileName
        /// </summary>		
        public string Sys_FileName { get; set; }

        /// <summary>
        /// Sys_FileOldName
        /// </summary>		
        public string Sys_FileOldName { get; set; }

        /// <summary>
        /// Sys_ExtName
        /// </summary>		
        public string Sys_ExtName { get; set; }

        /// <summary>
        /// Sys_FilePath
        /// </summary>		
        public string Sys_FilePath { get; set; }

        /// <summary>
        /// Sys_FileMd5
        /// </summary>		
        public string Sys_FileMd5 { get; set; }

        /// <summary>
        /// Sys_Description
        /// </summary>		
        public string Sys_Description { get; set; }

        /// <summary>
        /// Sys_IsMain
        /// </summary>		
        public bool Sys_IsMain { get; set; }
    }
}
