using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class UpFileRepository : SqlServerRepositoryBase<UpFileEntity>, IUpFileRepository
    {
        /// <summary>
        /// 保存上传文件信息
        /// </summary>
        /// <param name="upFileEntity"></param>
        /// <returns></returns>
        public UpFileEntity InitUpFileEntity(UpFileDTO upFileDtoEntity)
        {
            UpFileEntity upFileEntity = new UpFileEntity();
            if (!string.IsNullOrEmpty(upFileDtoEntity.Sys_FileName))
            {

                upFileEntity.WebSiteId = upFileDtoEntity.Sys_WebSiteId;
                upFileEntity.ParentId = upFileDtoEntity.Sys_ParentId;
                upFileEntity.SortCode = upFileDtoEntity.Sys_SortCode;
                upFileEntity.ModuleName = upFileDtoEntity.Sys_ModuleName;
                upFileEntity.FileName = upFileDtoEntity.Sys_FileName;
                upFileEntity.FileOldName = upFileDtoEntity.Sys_FileOldName;
                upFileEntity.ExtName = upFileDtoEntity.Sys_ExtName;
                upFileEntity.FilePath = upFileDtoEntity.Sys_FilePath;
                upFileEntity.FileMd5 = upFileDtoEntity.Sys_FileMd5;
                upFileEntity.UploadType = upFileDtoEntity.UploadType;
                upFileEntity.Description = upFileDtoEntity.Sys_Description;
                upFileEntity.IsMain = upFileDtoEntity.Sys_IsMain;
            }
            return upFileEntity;
        }

        /// <summary>
        /// 根据Ids逻辑删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteByIds(List<string> keyValues)
        {
            if (keyValues != null && keyValues.Count > 0)
            {
                DeleteById(t => keyValues.Contains(t.Id));
            }
        }
    }
}
