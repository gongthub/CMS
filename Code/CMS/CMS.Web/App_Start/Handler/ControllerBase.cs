using CMS.Code;
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

        public static readonly string WEBSITEID = "WEBSITEID";

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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string Base_WebSiteId
        {
            get {
                return WebHelper.GetCookie("WEBSITEID");
            }
        }
    }
}
