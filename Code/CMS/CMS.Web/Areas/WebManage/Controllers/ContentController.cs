using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.WebManage.Controllers
{
    [WebSiteMgr]
    public class ContentController : ControllerBase
    {

        /// <summary>
        /// 上传图片保存路径
        /// </summary>
        private static string UPLOADIMGPATH = ConfigurationManager.AppSettings["UploadImg"].ToString();
        private ContentApp c_contentApp = new ContentApp();

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
        public ActionResult SubmitForm(ContentEntity moduleEntity, string keyValue)
        {
            try
            {
                moduleEntity.WebSiteId = GetSessionByName(WEBSITEID);
                c_contentApp.SubmitForm(moduleEntity, keyValue);
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

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult LinkForm()
        {
            return View();
        }

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadImg()
        {
            try
            {
                string dates = DateTime.Now.ToString("yyyyMMdd");
                string upPaths = UPLOADIMGPATH + dates + "/";
                string upPathsT = upPaths.Replace("~", "");
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
                return Success("false", ex.Message);
            }
        }
    }
}
