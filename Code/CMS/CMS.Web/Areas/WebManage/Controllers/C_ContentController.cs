using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    public class C_ContentController : ControllerBase
    {

        private C_ContentApp c_contentApp = new C_ContentApp();

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string itemId, string keyword)
        {
            var data = c_contentApp.GetList(itemId, keyword);
            return Content(data.ToJson());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = c_contentApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(C_ContentEntity c_ContentEntity, string keyValue)
        {
            try
            {
                string upPaths = "~/Uploads/";
                if (HttpContext.Request.Files.Count > 0 && HttpContext.Request.Files["F_Icon"] != null)
                {
                    var iconFile = HttpContext.Request.Files["F_Icon"];
                    if (iconFile != null)
                    {
                        // 文件上传后的保存路径
                        string filePath = Server.MapPath(upPaths);
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        string fileName = Path.GetFileName(iconFile.FileName);// 原始文件名称
                        string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                        Random random = new Random();
                        string randomStr = random.Next(0000, 9999).ToString();
                        string saveName = DateTime.Now.ToString("yyyyMMddHHmmss") + randomStr + fileExtension; // 保存文件名称
                        string filePaths = upPaths + saveName;
                        iconFile.SaveAs(filePaths);
                        c_ContentEntity.F_Icon = filePaths;
                    }

                }
                c_contentApp.SubmitForm(c_ContentEntity, keyValue);
                return Success("操作成功。");

            }
            catch (Exception ex)
            {
                return Error("操作失败。" + ex.Message);
            }
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            c_contentApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult GetStaticPage(string keyValue)
        {
            c_contentApp.GetStaticPage(keyValue);
            return Success("生成成功。");
        }


        //[ValidateAntiForgeryToken]
        public ActionResult UploadImg()
        {
            try
            {
                string upPaths = "~/Uploads/";
                string upPathsT = "/Uploads/";
                string filePaths = string.Empty;
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        // 文件上传后的保存路径
                        string filePath = Server.MapPath(upPaths);
                        if (!Directory.Exists(filePath))
                        {
                            Directory.CreateDirectory(filePath);
                        }
                        string fileName = Path.GetFileName(upFiles.FileName);// 原始文件名称
                        string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                        Random random = new Random();
                        string randomStr = random.Next(0000, 9999).ToString();
                        string saveName = DateTime.Now.ToString("yyyyMMddHHmmss") + randomStr + fileExtension; // 保存文件名称
                        filePaths = upPathsT + saveName; 
                        upFiles.SaveAs(filePath + saveName);
                    }
                }
                else
                {
                    return Success("true");
                }
                return Success("true", filePaths);

            }
            catch (Exception ex)
            {
                return Success("false",ex.Message);
            }
        }
    }
}
