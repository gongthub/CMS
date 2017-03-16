using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
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
    }
}
