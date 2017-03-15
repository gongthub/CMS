using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.Entity.SystemManage
{
    public class UpFileEntity : IEntity<AreaEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {

        /// <summary>
        /// Id
        /// </summary>		
        public string Id { get; set; }

        /// <summary>
        /// ParentId
        /// </summary>		
        public string ParentId { get; set; }

        /// <summary>
        /// SortCode
        /// </summary>		
        public int SortCode { get; set; }

        /// <summary>
        /// ModuleName
        /// </summary>		
        public string ModuleName { get; set; }

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

        /// <summary>
        /// Description
        /// </summary>		
        public string Description { get; set; }

        /// <summary>
        /// IsMain
        /// </summary>		
        public bool IsMain { get; set; }

        /// <summary>
        /// EnabledMark
        /// </summary>		
        public bool EnabledMark { get; set; }

        /// <summary>
        /// DeleteMark
        /// </summary>		
        public bool? DeleteMark { get; set; }

        /// <summary>
        /// CreatorUserId
        /// </summary>		
        public string CreatorUserId { get; set; }

        /// <summary>
        /// CreatorTime
        /// </summary>		
        public DateTime? CreatorTime { get; set; }

        /// <summary>
        /// DeleteUserId
        /// </summary>		
        public string DeleteUserId { get; set; }

        /// <summary>
        /// DeleteTime
        /// </summary>		
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// LastModifyUserId
        /// </summary>		
        public string LastModifyUserId { get; set; }

        /// <summary>
        /// LastModifyTime
        /// </summary>		
        public DateTime? LastModifyTime { get; set; }
         
    }
}