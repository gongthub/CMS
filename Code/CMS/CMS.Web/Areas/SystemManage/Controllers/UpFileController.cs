using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class UpFileController : ControllerBase
    {

        private static readonly string HTMLCONTENTSRC = ConfigHelp.configHelp.HTMLCONTENTSRC;
        private static readonly string HTMLSYSCONTENTSRC = Code.ConfigHelp.configHelp.HTMLSYSCONTENTSRC;

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadSysImg()
        {
            try
            {
                UpFileDTO entity = new UpFileDTO();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadImg(upFiles);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entity);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadSysImgs()
        {
            try
            {
                List<UpFileDTO> entitys = new List<UpFileDTO>();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files;
                    if (upFiles != null && upFiles.Count > 0)
                    {
                        for (int i = 0; i < upFiles.Count; i++)
                        {
                            CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                            UpFileDTO entity = upfileApp.UpLoadImg(upFiles[i]);
                            entity.UploadType = (int)Code.Enums.UploadType.Images;
                            entitys.Add(entity);
                        }
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entitys);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadSysFile()
        {
            try
            {
                UpFileDTO entity = new UpFileDTO();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadFile(upFiles);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entity);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadSysFiles()
        {
            try
            {
                List<UpFileDTO> entitys = new List<UpFileDTO>();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files;
                    for (int i = 0; i < upFiles.Count; i++)
                    {
                        UpFileDTO entity = new UpFileDTO();
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadFile(upFiles[i]);
                        entity.UploadType = (int)Code.Enums.UploadType.Files;
                        entitys.Add(entity);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entitys);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }
        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadImg()
        {
            try
            {
                UpFileDTO entity = new UpFileDTO();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadImg(upFiles, Base_WebSiteShortName);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entity);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadImgs()
        {
            try
            {
                List<UpFileDTO> entitys = new List<UpFileDTO>();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files;
                    if (upFiles != null && upFiles.Count > 0)
                    {
                        for (int i = 0; i < upFiles.Count; i++)
                        {
                            CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                            UpFileDTO entity = upfileApp.UpLoadImg(upFiles[i], Base_WebSiteShortName);
                            entity.UploadType = (int)Code.Enums.UploadType.Images;
                            entitys.Add(entity);
                        }
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entitys);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadFile()
        {
            try
            {
                UpFileDTO entity = new UpFileDTO();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadFile(upFiles, Base_WebSiteShortName);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entity);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadFiles()
        {
            try
            {
                List<UpFileDTO> entitys = new List<UpFileDTO>();
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files;
                    for (int i = 0; i < upFiles.Count; i++)
                    {
                        UpFileDTO entity = new UpFileDTO();
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        entity = upfileApp.UpLoadFile(upFiles[i], Base_WebSiteShortName);
                        entity.UploadType = (int)Code.Enums.UploadType.Files;
                        entitys.Add(entity);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", entitys);

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        /// <summary>
        /// 上传网站资源文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadResourceFiles()
        {
            try
            {
                if (HttpContext.Request["resourceId"] != null)
                {
                    string resourceId = HttpContext.Request["resourceId"];

                    ResourceApp resourceApp = new ResourceApp();

                    ResourceEntity resourceEntity = resourceApp.GetForm(Base_WebSiteId, resourceId);
                    if (resourceEntity != null)
                    {
                        UpFileDTO entity = new UpFileDTO();
                        if (HttpContext.Request.Files.Count > 0)
                        {
                            var upFiles = HttpContext.Request.Files;
                            for (int i = 0; i < upFiles.Count; i++)
                            {
                                if (new WebSiteApp().IsOverSizeByWebSiteId(Base_WebSiteId, upFiles[i].ContentLength))
                                {
                                    throw new Exception("该站点空间已不足，请联系管理员！");
                                }
                                CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                                string savePaths = HTMLCONTENTSRC + resourceEntity.UrlAddress + @"\\";
                                upfileApp.UpLoadFile(upFiles[i], savePaths, true, false);
                            }
                        }
                        else
                        {
                            return Success("true");
                        }
                    }
                    return Success("true");
                }
                else
                {
                    return Success("false", "未选择资源文件夹！");
                }

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }

        /// <summary>
        /// 上传系统模板资源文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadSysResourceFiles()
        {
            try
            {
                if (HttpContext.Request["resourceId"] != null && HttpContext.Request["parentId"] != null)
                {
                    string resourceId = HttpContext.Request["resourceId"];
                    string parentId = HttpContext.Request["parentId"];

                    SysTempletsApp sysTempletsApp = new SysTempletsApp();

                    ResourceEntity resourceEntity = sysTempletsApp.GetResourcetForm(parentId, resourceId);
                    if (resourceEntity != null)
                    {
                        UpFileDTO entity = new UpFileDTO();
                        if (HttpContext.Request.Files.Count > 0)
                        {
                            var upFiles = HttpContext.Request.Files;
                            for (int i = 0; i < upFiles.Count; i++)
                            {
                                CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                                string savePaths = HTMLSYSCONTENTSRC + resourceEntity.UrlAddress + @"\\";
                                upfileApp.UpLoadFile(upFiles[i], savePaths, true, false);
                            }
                        }
                        else
                        {
                            return Success("true");
                        }
                    }
                    return Success("true");
                }
                else
                {
                    return Success("false", "未选择资源文件夹！");
                }

            }
            catch (Exception ex)
            {
                return Success("false", ex.Message);
            }
        }
    }
}
