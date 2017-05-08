using CMS.Application.WebManage;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace CMS.Application.SystemManage
{
    public class UpFileApp
    {
        /// <summary>
        /// 上传图片保存路径
        /// </summary>
        private static readonly string UPLOADIMGPATH = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADIMG;
        /// <summary>
        /// 上传文件保存路径
        /// </summary>
        private static readonly string UPLOADFILEPATH = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADFILE;

        private IUpFileRepository service = new UpFileRepository();

        #region 通用方法
        /// <summary>
        /// 根据时间获取文件名称 时间格式yyyyMMddHHmmss
        /// </summary>
        /// <returns></returns>
        private string GetFileNameByTime()
        {
            string strName = string.Empty;
            Random random = new Random();
            string randomStr = random.Next(0000, 9999).ToString();
            strName = DateTime.Now.ToString("yyyyMMddHHmmss") + randomStr;
            return strName;
        }

        /// <summary>
        /// 根据时间获取图片保存路径 时间格式yyyyMMdd
        /// </summary>
        /// <returns></returns>
        private string GetImgPathByDate()
        {
            string strPath = string.Empty;
            string dates = DateTime.Now.ToString("yyyyMMdd");
            strPath = UPLOADIMGPATH + dates + "/";
            return strPath;
        }
        /// <summary>
        /// 根据时间获取图片保存路径 时间格式yyyyMMdd
        /// </summary>
        /// <returns></returns>
        private string GetImgPathByDate(string strWebSiteShotName)
        {
            string strPath = string.Empty;
            string dates = DateTime.Now.ToString("yyyyMMdd");
            if (!string.IsNullOrEmpty(strWebSiteShotName))
            {
                strPath = UPLOADIMGPATH + "/" + strWebSiteShotName + "/" + dates + "/";
            }
            else
            {
                strPath = UPLOADIMGPATH + dates + "/";
            }
            return strPath;
        }
        /// <summary>
        /// 根据时间获取文件保存路径 时间格式yyyyMMdd
        /// </summary>
        /// <returns></returns>
        private string GetFilePathByDate()
        {
            string strPath = string.Empty;
            string dates = DateTime.Now.ToString("yyyyMMdd");
            strPath = UPLOADFILEPATH + dates + "/";
            return strPath;
        }
        /// <summary>
        /// 根据时间获取文件保存路径 时间格式yyyyMMdd
        /// </summary>
        /// <returns></returns>
        private string GetFilePathByDate(string strWebSiteShotName)
        {
            string strPath = string.Empty;
            string dates = DateTime.Now.ToString("yyyyMMdd");
            if (!string.IsNullOrEmpty(strWebSiteShotName))
            {
                strPath = UPLOADFILEPATH + "/" + strWebSiteShotName + "/" + dates + "/";
            }
            else
            {
                strPath = UPLOADFILEPATH + dates + "/";
            }
            return strPath;
        }

        /// <summary>
        /// 根据路径初始化保存文件夹
        /// </summary>
        /// <param name="filePaths"></param>
        private string InitSavePath(string filePaths)
        {
            // 文件上传后的保存路径 
            string filePath = Code.FileHelper.MapPath(filePaths);
            if (!Code.FileHelper.IsExistDirectory(filePath))
            {
                Code.FileHelper.CreateDirectory(filePath);

            }

            return filePath;
        }
        #endregion

        #region 上传图片
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public UpFileDTO UpLoadImg(HttpPostedFileBase file)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = GetImgPathByDate();
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyImg(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();

                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
            }
            return entity;
        }
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="file"></param>
        /// <param name="strWebSiteShotName">站点简称</param>
        /// <returns></returns>
        public UpFileDTO UpLoadImg(HttpPostedFileBase file, string strWebSiteShotName)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = GetImgPathByDate(strWebSiteShotName);
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyImg(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();

                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
            }
            return entity;
        }

        #region 上传图片验证
        /// <summary>
        /// 上传图片验证
        /// </summary>
        public void VerifyImg(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);// 原始文件名称
            string fileExtension = Path.GetExtension(fileName); // 文件扩展名  

            //验证格式
            string formatImgs = string.Empty;
            if (!VerifyImgFormat(fileExtension, out formatImgs))
            {
                throw new Exception("上传图片格式不符合要求，请重新上传！允许上传格式：" + formatImgs);
            }

            //验证大小
            int maxSize = 0;
            if (!VerifyImgSize(file.ContentLength, out maxSize))
            {
                throw new Exception("上传图片大小不符合要求，请重新上传！最大上传：" + maxSize + "KB");
            }
        }

        /// <summary>
        /// 验证图片格式是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyImgFormat(string formats)
        {
            bool bState = false;
            string formatImgs = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADIMGFORMAT;
            if (!string.IsNullOrEmpty(formats))
            {
                if (formatImgs != "*")
                {
                    string[] imgs = formatImgs.Split('|');
                    bState = imgs.Contains(formats);
                }
                else
                {
                    bState = true;
                }
            }
            return bState;
        }

        /// <summary>
        /// 验证图片格式是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyImgFormat(string formats, out string formatStr)
        {
            bool bState = false;
            string formatImgs = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADIMGFORMAT;
            if (!string.IsNullOrEmpty(formats))
            {
                if (formatImgs != "*")
                {
                    string[] imgs = formatImgs.Split('|');
                    bState = imgs.Contains(formats);
                }
                else
                {
                    bState = true;
                }
            }
            formatStr = formatImgs;
            return bState;
        }

        /// <summary>
        /// 验证图片大小是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyImgSize(int size)
        {
            bool bState = false;
            string sizes = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADIMGSIZE;
            int sizeT = 0;
            if (!string.IsNullOrEmpty(sizes) && int.TryParse(sizes, out sizeT))
            {
                if (sizeT != 0)
                {
                    if (size / 1024 <= sizeT)
                        bState = true;
                }
                else
                {
                    bState = true;
                }
            }
            return bState;
        }
        /// <summary>
        /// 验证图片大小是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyImgSize(int size, out int maxSize)
        {
            bool bState = false;
            string sizes = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADIMGSIZE;
            int sizeT = 0;
            if (!string.IsNullOrEmpty(sizes) && int.TryParse(sizes, out sizeT))
            {
                if (sizeT != 0)
                {
                    if (size / 1024 <= sizeT)
                        bState = true;
                }
                else
                {
                    bState = true;
                }
            }
            maxSize = sizeT;
            return bState;
        }

        #endregion

        #endregion

        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public UpFileDTO UpLoadFile(HttpPostedFileBase file)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = GetFilePathByDate();
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyFile(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();

                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
            }
            return entity;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="strWebSiteShotName">站点简称</param>
        /// <returns></returns>
        public UpFileDTO UpLoadFile(HttpPostedFileBase file, string strWebSiteShotName)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = GetFilePathByDate(strWebSiteShotName);
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyFile(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();

                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
            }
            return entity;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="strWebSiteShotName">站点简称</param>
        /// <returns></returns>
        public UpFileDTO UpLoadFile(HttpPostedFileBase file, string savePath, bool IsSave)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = savePath;
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyFile(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();

                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
                if (IsSave)
                {
                    string Ids = Guid.Empty.ToString();
                    if (HttpContext.Current.Session["WEBSITEID"] != null)
                    {
                        Ids = HttpContext.Current.Session["WEBSITEID"].ToString();
                        entity.Sys_WebSiteId = Ids;
                    }
                    UpFileApp upFileApp = new UpFileApp();
                    upFileApp.AddUpFileEntity(entity);
                }
            }
            return entity;
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="strWebSiteShotName">站点简称</param>
        /// <returns></returns>
        public UpFileDTO UpLoadFile(HttpPostedFileBase file, string savePath, bool IsSave, bool IsModifyName)
        {
            UpFileDTO entity = new UpFileDTO();
            string filePaths = string.Empty;
            string upPaths = savePath;
            string upPathsT = upPaths.Replace("~", "");
            if (file != null)
            {
                //验证 
                VerifyFile(file);

                string fileName = Path.GetFileName(file.FileName);// 原始文件名称
                string fileExtension = Path.GetExtension(fileName); // 文件扩展名  
                string newFileName = GetFileNameByTime();
                // 文件上传后的保存路径 
                string filePath = InitSavePath(upPaths);
                string saveName = newFileName + fileExtension; // 保存文件名称
                if (IsModifyName)
                {
                    saveName = newFileName + fileExtension; // 保存文件名称
                }
                else
                {
                    saveName = fileName; // 保存文件名称
                }
                filePaths = upPathsT + saveName;
                file.SaveAs(filePath + saveName);

                entity.Sys_FileName = saveName;
                entity.Sys_FileOldName = fileName;
                entity.Sys_ExtName = fileExtension;
                entity.Sys_FilePath = filePaths;
                entity.Sys_FileMd5 = Code.Md5.MD5File(filePaths);
                if (IsSave)
                {
                    string Ids = Guid.Empty.ToString();
                    if (HttpContext.Current.Session["WEBSITEID"] != null)
                    {
                        Ids = HttpContext.Current.Session["WEBSITEID"].ToString();
                        entity.Sys_WebSiteId = Ids;
                    }
                    UpFileApp upFileApp = new UpFileApp();
                    upFileApp.AddUpFileEntity(entity);
                }
            }
            return entity;
        }

        #region 上传文件验证
        /// <summary>
        /// 上传文件验证
        /// </summary>
        public void VerifyFile(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);// 原始文件名称
            string fileExtension = Path.GetExtension(fileName); // 文件扩展名  

            //验证格式
            string formatFiles = string.Empty;
            if (!VerifyFileFormat(fileExtension, out formatFiles))
            {
                throw new Exception("上传文件格式不符合要求，请重新上传！允许上传格式：" + formatFiles);
            }

            //验证大小
            int maxSize = 0;
            if (!VerifyFileSize(file.ContentLength, out maxSize))
            {
                throw new Exception("上传文件大小不符合要求，请重新上传！最大上传：" + maxSize + "KB");
            }
        }

        /// <summary>
        /// 验证文件格式是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyFileFormat(string formats)
        {
            bool bState = false;
            string formatImgs = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADFILEFORMAT;
            if (!string.IsNullOrEmpty(formats))
            {
                if (formatImgs != "*")
                {
                    string[] imgs = formatImgs.Split('|');
                    bState = imgs.Contains(formats);
                }
                else
                {
                    bState = true;
                }
            }
            return bState;
        }

        /// <summary>
        /// 验证文件格式是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyFileFormat(string formats, out string formatStr)
        {
            bool bState = false;
            string formatImgs = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADFILEFORMAT;
            if (!string.IsNullOrEmpty(formats))
            {
                if (formatImgs != "*")
                {
                    string[] imgs = formatImgs.Split('|');
                    bState = imgs.Contains(formats);
                }
                else
                {
                    bState = true;
                }
            }
            formatStr = formatImgs;
            return bState;
        }

        /// <summary>
        /// 验证文件大小是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyFileSize(int size)
        {
            bool bState = false;
            string sizes = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADFILESIZE;
            int sizeT = 0;
            if (!string.IsNullOrEmpty(sizes) && int.TryParse(sizes, out sizeT))
            {
                if (sizeT != 0)
                {
                    if (size / 1024 <= sizeT)
                        bState = true;
                }
                else
                {
                    bState = true;
                }
            }
            return bState;
        }
        /// <summary>
        /// 验证文件大小是否满足条件
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        public bool VerifyFileSize(int size, out int maxSize)
        {
            bool bState = false;
            string sizes = CMS.Application.Comm.ConfigHelp.configHelp.UPLOADFILESIZE;
            int sizeT = 0;
            if (!string.IsNullOrEmpty(sizes) && int.TryParse(sizes, out sizeT))
            {
                if (sizeT != 0)
                {
                    if (size / 1024 <= sizeT)
                        bState = true;
                }
                else
                {
                    bState = true;
                }
            }
            maxSize = sizeT;
            return bState;
        }

        #endregion

        #endregion

        /// <summary>
        /// 根据ParentId逻辑删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteByParentId(string keyValue)
        {
            service.DeleteById(t => t.ParentId == keyValue);
        }

        /// <summary>
        /// 根据WebSiteId逻辑删除
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteByWebSiteId(string keyValue)
        {
            service.DeleteById(t => t.WebSiteId == keyValue);
        }

        /// <summary>
        /// 保存上传文件信息
        /// </summary>
        /// <param name="upFileEntity"></param>
        /// <returns></returns>
        public bool AddUpFileEntity(UpFileDTO upFileDtoEntity)
        {
            bool bState = false;
            if (!string.IsNullOrEmpty(upFileDtoEntity.Sys_FileName))
            {
                UpFileEntity upFileEntity = new UpFileEntity();

                upFileEntity.WebSiteId = upFileDtoEntity.Sys_WebSiteId;
                upFileEntity.ParentId = upFileDtoEntity.Sys_ParentId;
                upFileEntity.SortCode = upFileDtoEntity.Sys_SortCode;
                upFileEntity.ModuleName = upFileDtoEntity.Sys_ModuleName;
                upFileEntity.FileName = upFileDtoEntity.Sys_FileName;
                upFileEntity.FileOldName = upFileDtoEntity.Sys_FileOldName;
                upFileEntity.ExtName = upFileDtoEntity.Sys_ExtName;
                upFileEntity.FilePath = upFileDtoEntity.Sys_FilePath;
                upFileEntity.FileMd5 = upFileDtoEntity.Sys_FileMd5;
                upFileEntity.Description = upFileDtoEntity.Sys_Description;
                upFileEntity.IsMain = upFileDtoEntity.Sys_IsMain;
                upFileEntity.Create();
                if (service.Insert(upFileEntity) > 0)
                {
                    bState = true;
                }
            }
            else
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 保存上传文件信息
        /// </summary>
        /// <param name="upFileEntity"></param>
        /// <returns></returns>
        public bool AddUpFileEntity(string webSiteId, string filePath, string fileName, string fileOldName, string fileExtension, string fileMd5)
        {
            bool bState = false;
            UpFileEntity upFileEntity = new UpFileEntity();
            if (!string.IsNullOrEmpty(fileName))
            {
                upFileEntity.FileName = fileName;
                upFileEntity.FileOldName = fileOldName;
                upFileEntity.ExtName = fileExtension;
                upFileEntity.FilePath = filePath;
                upFileEntity.FileMd5 = fileMd5;

                if (!string.IsNullOrEmpty(webSiteId))
                {
                    upFileEntity.WebSiteId = webSiteId;
                }
                upFileEntity.Create();
                if (service.Insert(upFileEntity) > 0)
                {
                    bState = true;
                }
            }
            else
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 保存上传文件信息
        /// </summary>
        /// <param name="upFileEntity"></param>
        /// <returns></returns>
        public void AddUpFileEntity(string webSiteId, string filePath, string fileName, string fileOldName, string fileExtension, string fileMd5, bool isAsync)
        {
            if (isAsync)
            {
                Thread thread = new Thread(() =>
                {
                    AddUpFileEntity(webSiteId, filePath, fileName, fileOldName, fileExtension, fileMd5);
                });
                thread.Start();
            }
        }
    }
}
