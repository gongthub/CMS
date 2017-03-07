using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        { 
            return View();
        }
        [HttpGet]
        public ActionResult WebSite(string webSiteId)
        { 
            return View();
        }
        [HttpGet]
        public ActionResult WebSiteList()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ModulM(string id)
        {
            string srcs = @"/html/" + id + ".html";
            srcs = Server.MapPath(srcs);
            string strLine;
            using (System.IO.StreamReader sr = new System.IO.StreamReader(srcs))
            {
                strLine = sr.ReadToEnd();
            }


            return Content(strLine);
        }
    }
}
