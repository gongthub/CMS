using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class RequestHelp
    {
        private static string LOGINHOSTCONFIGALLMARK = "*";
        private static string LOGINURLMARK = "/Login/Index";
        private static RequestHelp _requestHelp = new RequestHelp();

        #region 处理请求 +void InitRequest(System.Web.HttpContext context)
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void InitRequest(System.Web.HttpContext context)
        {
            if (ConfigHelp.configHelp.ISPROREQUEST)
            {
                string htmls = string.Empty;
                try
                {
                    string urlHost = GetHost(context);
                    string urlRaw = context.Request.RawUrl.ToString();
                    urlRaw = context.Server.UrlDecode(urlRaw);
                    bool isShoudPre = false;
                    if (IsLoginHost(context))
                    {
                        if (Code.ConfigHelp.configHelp.LOGINHOST != LOGINHOSTCONFIGALLMARK)
                        {
                            if (string.IsNullOrEmpty(urlRaw) || urlRaw == "/")
                            {
                                context.Response.Clear();
                                context.Response.Redirect("/Login/Index", false);
                                context.ApplicationInstance.CompleteRequest();
                            }
                            else
                                if (!IsLoginUrl(context))
                            {
                                isShoudPre = true;
                            }
                        }
                        else
                            if (!IsLoginUrl(context))
                        {
                            isShoudPre = true;
                        }
                    }
                    else
                    {
                        isShoudPre = true;
                    }
                    if (isShoudPre == true)
                    {
                        if (IsProcess(urlHost, urlRaw))
                        {
                            string userAgents = context.Request.UserAgent;
                            bool isMobile = IsMobile(userAgents);
                            context.Response.Clear();
                            bool isNoFind = false;
                            RequestModel requestModel = new RequestModel();
                            requestModel.UrlHost = urlHost;
                            requestModel.UrlRaw = urlRaw;
                            requestModel.IsMobile = isMobile;
                            htmls = new TempHelp().GetHtmlByUrl(requestModel, out isNoFind);
                            if (isNoFind)
                            {
                                context.Response.StatusCode = 404;
                            }
                            else
                            {
                                context.Response.Write(htmls);
                            }
                            //插入访问日志
                            SysPageHelp.sysPageHelp.CreateAccessLog(context, true);
                            context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            if (IsLoginUrl(context))
                            {
                                context.Response.Clear();
                                context.Response.StatusCode = 404;
                                //插入访问日志
                                SysPageHelp.sysPageHelp.CreateAccessLog(context, true);
                                context.ApplicationInstance.CompleteRequest();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.Response.Clear();
                    context.Response.StatusCode = 500;
                    context.ApplicationInstance.CompleteRequest();

                    LogFactory.GetLogger(this.GetType()).Error("异常：" + ex.Message + "\r\n");
                    //throw;
                }
            }
        }
        #endregion

        #region 处理结束输出
        /// <summary>
        /// 处理结束输出
        /// </summary>
        /// <param name="context"></param>
        public void EndRequest(System.Web.HttpContext context)
        {
            SysPageHelp.sysPageHelp.AddEndRequestLog(context);
            setResponse(context);
        }

        /// <summary>
        /// 设置输出状态
        /// </summary>
        /// <param name="context"></param>
        private void setResponse(System.Web.HttpContext context)
        {
            string htmls = string.Empty;
            switch (context.Response.StatusCode)
            {
                case 403:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "403 Forbidden";
                        context.Response.StatusDescription = "Forbidden";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
                        DoResponse(context, htmls);
                        //context.RewritePath(ConfigHelp.configHelp.SYSPAGE_NOFIND);
                    }
                    break;
                case 404:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "404 Not Found";
                        context.Response.StatusDescription = "Not Found";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
                        DoResponse(context, htmls);
                        //context.RewritePath(ConfigHelp.configHelp.SYSPAGE_NOFIND);
                    }
                    break;
                case 500:
                    if (IsProcessEndStatus(context))
                    {
                        context.Response.Status = "500 Internal Server Error";
                        context.Response.StatusDescription = "Internal Server Error";
                        htmls = Comm.SysPageHelp.sysPageHelp.GetErrorPage();
                        DoResponse(context, htmls);
                        //context.RewritePath(ConfigHelp.configHelp.SYSPAGE_ERROR);
                    }
                    break;
            }
        }
        /// <summary>
        /// 请求返回是否需要处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool IsProcessEndStatus(System.Web.HttpContext context)
        {
            bool bState = false;
            if (string.IsNullOrEmpty(context.Response.Status) || context.Request != null && context.Request.AcceptTypes != null && context.Request.AcceptTypes.Contains("text/html"))
            {
                bState = true;
            }
            return bState;
        }

        private void DoResponse(System.Web.HttpContext context, string htmls)
        {
            //context.Response.Clear();
            context.Response.Write(htmls);
            context.ApplicationInstance.CompleteRequest();
        }

        #endregion

        #region 判断是否需要处理

        /// <summary>
        /// 是否需要处理
        /// </summary>
        /// <returns></returns>
        private bool IsProcess(string urlHost, string urlRaw)
        {
            bool bState = false;
            if (!Common.IsBlackName(urlRaw)
                && !Common.IsSystemHaveUrlName(urlRaw)
                && (IsWebSiteUrl(urlHost, urlRaw)
                || IsRootUrl(urlHost, urlRaw)))
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 判断是否为前台
        /// </summary>
        /// <returns></returns>
        private bool IsWebSiteUrl(string urlhost, string urlRaw)
        {
            bool bState = false;
            //判断是否前台url
            //if (TempHelp.tempHelp.IsWebSite(urlhost, urlRaw) && Common.IsExistExtended(urlRaw))
            if (new TempHelp().IsWebSite(urlhost, urlRaw))
            {
                bState = true;
            }
            else
            {
                if (Common.IsExistUrlRaw(urlRaw))
                {
                    bState = true;
                }
                else
                {
                    if (Common.IsExistUrlGuid(urlRaw))
                    {
                        bState = true;
                    }
                }
            }
            if (!bState)
                bState = Common.IsSearchForUrl(urlRaw);
            return bState;
        }

        /// <summary>
        /// 判断是否为根目录文件
        /// </summary>
        /// <returns></returns>
        private bool IsRootUrl(string urlhost, string urlRaw)
        {
            bool bState = false;
            WebSiteEntity webSiteEntity = new WebSiteApp().GetModelByUrlHost(urlhost);
            if (webSiteEntity != null && !string.IsNullOrWhiteSpace(webSiteEntity.Id))
            {
                List<string> urlRaws = WebHelper.GetUrls(urlRaw);
                if (new WebSiteApp().IsRoot(webSiteEntity.Id)
                    && urlRaws.Count == 1)
                {
                    string fileName = urlRaws[0];
                    string[] fileNames = fileName.Split('.');
                    if (fileNames.Length == 2)
                        bState = new ResourceApp().IsRootFile(webSiteEntity.Id, fileName);

                }
            }
            return bState;
        }
        #endregion

        #region 域名是否可访问后台
        /// <summary>
        /// 域名是否可访问后台
        /// </summary>
        /// <returns></returns>
        public bool IsLoginHost(System.Web.HttpContext context)
        {
            bool bState = false;
            string urlHost = GetHost(context);
            //string urlPath = context.Request.Path.ToString();

            //if (urlPath.Length >= LOGINURLMARK.Length)
            //{
            //    urlPath = urlPath.Substring(0, LOGINURLMARK.Length);
            //}

            //if (!string.IsNullOrEmpty(urlHost) && !string.IsNullOrEmpty(urlPath) && urlPath.ToLower() == LOGINURLMARK.ToLower())
            if (!string.IsNullOrEmpty(urlHost))
            {
                bState = IsContistHost(urlHost);
            }
            return bState;
        }
        /// <summary>
        /// 域名是否可访问后台
        /// </summary>
        /// <returns></returns>
        public bool IsLoginUrl(System.Web.HttpContext context)
        {
            bool bState = false;
            string urlPath = context.Request.Path.ToString();

            if (urlPath.Length >= LOGINURLMARK.Length)
            {
                urlPath = urlPath.Substring(0, LOGINURLMARK.Length);
            }

            if (!string.IsNullOrEmpty(urlPath) && urlPath.ToLower() == LOGINURLMARK.ToLower())
            {
                bState = true;
            }
            return bState;
        }

        public bool IsContistHost(string urlHost)
        {
            bool bState = false;
            string strLoginHostConfigs = Code.ConfigHelp.configHelp.LOGINHOST;
            if (!string.IsNullOrEmpty(strLoginHostConfigs))
            {
                strLoginHostConfigs = strLoginHostConfigs.ToLower();
                if (strLoginHostConfigs == LOGINHOSTCONFIGALLMARK)
                {
                    bState = true;
                }
                else
                {
                    string[] hostconfigs = strLoginHostConfigs.Split('|');
                    if (hostconfigs != null && hostconfigs.Count() > 0)
                    {
                        bState = hostconfigs.Contains(urlHost.ToLower());
                    }
                }
            }
            return bState;
        }
        #endregion

        #region 获取分页内容 +ExtPageModel GetPageModels(System.Web.HttpContext context)
        /// <summary>
        /// 获取分页内容
        /// </summary>
        /// <returns></returns>
        public ExtPageModel GetPageModels(System.Web.HttpContext context)
        {
            ExtPageModel extPageModel = new ExtPageModel();
            string urlHost = GetHost(context);
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity entity = app.GetModelByUrlHost(urlHost);
            if (entity != null && !string.IsNullOrWhiteSpace(entity.Id))
            {
                string strRqs = context.Request["pageDatas"];
                if (!string.IsNullOrEmpty(strRqs))
                {
                    ExtPageModel extPageModelReq = Json.ToObject<ExtPageModel>(strRqs);
                    string cIds = GetColumnIds(context);
                    extPageModelReq.SourceIds = cIds;

                    string attrDatas = context.Request["attrDatas"];
                    if (!string.IsNullOrEmpty(attrDatas))
                    {
                        extPageModelReq.AttrDatas = Json.ToObject<Dictionary<string, string>>(attrDatas);
                    }
                    extPageModel = new TempHelp().GetContentModels(extPageModelReq, entity.ShortName);
                }
            }
            return extPageModel;
        }

        #endregion

        #region 获取请求路径栏目Id -string GetColumnIds(System.Web.HttpContext context)
        /// <summary>
        /// 获取请求路径栏目Id
        /// </summary>
        /// <returns></returns>
        private string GetColumnIds(System.Web.HttpContext context)
        {
            string cIds = string.Empty;
            string urlHost = GetHost(context);
            string urlRaw = context.Request.RawUrl.ToString();
            urlRaw = context.Server.UrlDecode(urlRaw);

            //处理Url参数
            urlRaw = Common.HandleUrlRaw(urlRaw);
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            WebSiteApp app = new WebSiteApp();
            ColumnsApp c_ColumnsApp = new ColumnsApp();
            WebSiteEntity entity = app.GetModelByUrlHost(urlHost);
            if (urlRaws == null || urlRaws.Count == 0)
            {
                ColumnsEntity columnsEntity = c_ColumnsApp.GetMain(entity.Id);
                if (columnsEntity != null)
                    cIds = columnsEntity.Id;
            }
            else
            {
                if (urlRaws.Count > 0)
                {
                    ColumnsEntity columnsEntity = c_ColumnsApp.GetFormByActionName(urlRaws.FirstOrDefault(), entity.Id);
                    if (columnsEntity != null)
                        cIds = columnsEntity.Id;
                }
            }

            return cIds;
        }
        #endregion

        #region 获取请求urlHost +string GetHost(System.Web.HttpContext context)
        /// <summary>
        /// 获取请求urlHost
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetHost(System.Web.HttpContext context)
        {
            string urlHost = context.Request.Url.Host;
            if (!context.Request.Url.IsDefaultPort && Code.ConfigHelp.configHelp.ISOPENPORT)
            {
                urlHost = context.Request.Url.Authority;
            }
            return urlHost;
        }

        #endregion

        #region 获取请求urlHost +string GetHostRequest(System.Web.HttpRequestBase request)
        /// <summary>
        /// 获取请求urlHost
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetHostRequest(System.Web.HttpRequestBase request)
        {
            string urlHost = request.Url.Host;
            if (!request.Url.IsDefaultPort && Code.ConfigHelp.configHelp.ISOPENPORT)
            {
                urlHost = request.Url.Authority;
            }
            return urlHost;
        }
        #endregion

        /// <summary>
        /// 判断是否为移动端访问
        /// </summary>
        /// <param name="agents"></param>
        /// <returns></returns>
        public bool IsMobile(string agents)
        {
            bool bResult = false;
            Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            if ((b.IsMatch(agents) || v.IsMatch(agents.Substring(0, 4))))
            {
                bResult = true;
            }
            return bResult;
        }
    }
}
