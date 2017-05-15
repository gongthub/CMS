using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Web.Mvc;

namespace CMS.Web
{
    [HandlerLogin]
    public abstract class ControllerBase : Controller
    {
        public Log FileLog
        {
            get { return LogFactory.GetLogger(this.GetType().ToString()); }
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Form()
        {
            return View();
        }
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Details()
        {
            return View();
        }
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }

        //public static readonly string WEBSITEID = "WEBSITEID";

        /// <summary>
        /// 根据Session名称获取值
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetSessionByName(string name)
        {
            string val = string.Empty;
            if (Session[name] != null)
            {
                val = Session[name].ToString();
            }
            return val;
        }
        /// <summary>
        /// 站点Id
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Base_WebSiteId
        {
            get
            {
                string Ids = Guid.Empty.ToString();
                //if (Session["WEBSITEID"] != null)
                //{
                //    Ids = Session["WEBSITEID"].ToString();
                //}
                Ids = SysLoginObjHelp.sysLoginObjHelp.GetWebSiteId();
                return Ids;
            }
        }
        /// <summary>
        /// 站点简称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Base_WebSiteShortName
        {
            get
            {
                string strShortName = string.Empty;
                //if (Session["WEBSITESHORTNAME"] != null)
                //{
                //    strShortName = Session["WEBSITESHORTNAME"].ToString();
                //}
                strShortName = SysLoginObjHelp.sysLoginObjHelp.GetWebSiteShortName();
                return strShortName;
            }
        }
        /// <summary>
        /// 站点信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public WebSiteEntity Base_WebSiteEntity
        {
            get
            {
                WebSiteEntity entity = new WebSiteEntity();
                //if (Session["WEBSITEENTITY"] != null)
                //{
                //    entity = Session["WEBSITEENTITY"] as WebSiteEntity;
                //}
                entity = SysLoginObjHelp.sysLoginObjHelp.GetWebSit<WebSiteEntity>();
                return entity;
            }
        }
    }
}
