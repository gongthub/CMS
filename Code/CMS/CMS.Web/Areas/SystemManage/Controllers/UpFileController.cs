using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace CMS.Web.Areas.SystemManage.Controllers
{
    public class UpFileController : ControllerBase
    {

        [HttpPost]
        [HandlerAuthorize]
        public ActionResult UploadImg()
        {
            try
            {
                string filePaths = string.Empty;
                if (HttpContext.Request.Files.Count > 0)
                {
                    var upFiles = HttpContext.Request.Files[0];
                    if (upFiles != null)
                    {
                        CMS.Application.SystemManage.UpFileApp upfileApp = new Application.SystemManage.UpFileApp();
                        filePaths = upfileApp.UpLoadImg(upFiles);
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
