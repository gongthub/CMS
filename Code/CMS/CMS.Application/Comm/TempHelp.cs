using CMS.Application.SystemManage;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Code.Html;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    public class TempHelp
    {
        private static TempHelp _tempHelp = new TempHelp();
        #region 单例模式创建对象
        //单例模式创建对象
        //// Creates an syn object.
        //private static readonly object SynObject = new object();
        //TempHelp()
        //{
        //}

        //public static TempHelp tempHelp
        //{
        //    get
        //    {
        //        // Double-Checked Locking
        //        if (null == _tempHelp)
        //        {
        //            lock (SynObject)
        //            {
        //                if (null == _tempHelp)
        //                {
        //                    _tempHelp = new TempHelp();
        //                }
        //            }
        //        }
        //        return _tempHelp;
        //    }
        //}
        #endregion
        /// <summary>
        /// 输出文件格式
        /// </summary>
        const string HTMLFOR = ".html";
        /// <summary>
        /// 模板开始特殊符
        /// </summary>
        const string STARTCHAR = "{{#";
        /// <summary>
        /// 模板结束特殊符
        /// </summary>
        const string ENDCHAR = "#}}";
        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        const string STARTMCHAR = "{";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        const string ENDMCHAR = "}";

        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        const string STARTMC = "@[";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        const string ENDMC = "]@";

        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        const string STARTMCNA = "[";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        const string ENDMCNA = "]";

        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        const string ATTRS = "@attrs=";
        /// <summary>
        /// 生成静态页面中内容浏览数特殊标识
        /// </summary>
        public const string STATICHTMLCONTENTNUM = "@viewnum@";
        /// <summary>
        /// 静态页面缓存路径
        /// </summary>
        private static readonly string HTMLSAVEPATH = ConfigHelp.configHelp.HTMLSRC;
        /// <summary>
        /// 静态页面相对路径
        /// </summary>
        private static readonly string HTMLSAVEHTMLPATH = ConfigHelp.configHelp.HTMLSRCPATH;
        /// <summary>
        /// 网站资源文件根目录
        /// </summary>
        private static readonly string HTMLCONTENTSRC = ConfigHelp.configHelp.HTMLCONTENTSRC;
        /// <summary>
        /// 网站根路径
        /// </summary>
        private static readonly string WEBURLHTTP = Configs.GetValue("WebUrlHttp");

        #region 初始化静态页面保持路径
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Id"></param>
        private void InitHtmlSavePath(string Id, out string filePath, out string urlAddress)
        {
            filePath = "";
            urlAddress = "";
            if (!string.IsNullOrEmpty(Id))
            {
                ContentApp c_ContentApp = new ContentApp();
                ColumnsEntity moduleentity = c_ContentApp.GetModuleByContentID(Id);

                if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(moduleentity))
                {
                    WebSiteApp webSiteApp = new WebSiteApp();
                    WebSiteEntity webSiteentity = webSiteApp.GetFormNoDel(moduleentity.WebSiteId);
                    if (JudgmentHelp.judgmentHelp.IsNullEntity<WebSiteEntity>(webSiteentity))
                    {
                        filePath = HTMLSAVEPATH + webSiteentity.ShortName + @"\" + moduleentity.ActionName + @"\";
                        urlAddress = HTMLSAVEHTMLPATH + moduleentity.ActionName + @"\";
                    }
                }
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="Id"></param>
        private void InitMHtmlSavePath(string Id, out string filePath, out string urlAddress)
        {
            filePath = "";
            urlAddress = "";
            if (!string.IsNullOrEmpty(Id))
            {
                ContentApp c_ContentApp = new ContentApp();
                ColumnsEntity moduleentity = c_ContentApp.GetModuleByContentID(Id);

                if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(moduleentity))
                {
                    WebSiteApp webSiteApp = new WebSiteApp();
                    WebSiteEntity webSiteentity = webSiteApp.GetFormNoDel(moduleentity.WebSiteId);
                    if (JudgmentHelp.judgmentHelp.IsNullEntity<WebSiteEntity>(webSiteentity))
                    {
                        filePath = HTMLSAVEPATH + webSiteentity.ShortName + @"\" + moduleentity.ActionName + @"\m\";
                        urlAddress = HTMLSAVEHTMLPATH + moduleentity.ActionName + @"\";
                    }
                }
            }
        }

        #endregion

        #region 生成文件名称 -string GenUrlName()
        /// <summary>
        /// 生成文件名称
        /// </summary>
        /// <returns></returns>
        private string GenUrlName()
        {
            Random rand = new Random();
            int rd = rand.Next(00, 99);
            string names = DateTime.Now.ToString("yyyyMMddHHmm") + rd.ToString();
            return names;
        }
        #endregion

        #region 创建静态页面 -void GenHtml(string htmls)
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void GenHtml(string htmls)
        {
            string filename = GenUrlName() + HTMLFOR;
            FileHelper.CreateAndWrite(HTMLSAVEPATH, filename, htmls);
        }
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void GenHtml(string htmls, out string filePath)
        {
            string filename = GenUrlName() + HTMLFOR;
            FileHelper.CreateAndWrite(HTMLSAVEPATH, filename, htmls);
            int index = HTMLSAVEPATH.LastIndexOf('\\');
            if (index >= 0)
            {
                filePath = HTMLSAVEPATH + filename;
            }
            else
            {
                filePath = HTMLSAVEPATH + @"\" + filename;
            }
        }
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void GenHtmlByFilePath(string htmls, ref string filePath, ref string urlAddress)
        {
            string filename = GenUrlName() + HTMLFOR;
            FileHelper.CreateAndWrite(filePath, filename, htmls);
            int index = filePath.LastIndexOf('\\');
            if (index >= 0)
            {
                filePath = filePath + filename;
                urlAddress = urlAddress + filename;
            }
            else
            {
                filePath = filePath + @"\" + filename;
                urlAddress = urlAddress + @"\" + filename;
            }
        }
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void GenHtml(string paths, string htmls)
        {
            FileHelper.WriteText(paths, htmls);
        }
        #endregion

        #region 根据urlRaw获取html +string GetHtmlByUrl(string urlRaw)
        /// <summary>
        /// 根据requestModel获取html
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        public string GetHtmlByUrl(RequestModel requestModel, out bool isNoFind)
        {
            string htmls = string.Empty;
            isNoFind = false;
            try
            {
                //处理Url参数
                requestModel.UrlRaw = Common.HandleUrlRaw(requestModel.UrlRaw);
                WebSiteApp app = new WebSiteApp();
                WebSiteEntity entity = app.GetModelByUrlHost(requestModel.UrlHost);
                requestModel.webSiteEntity = entity;
                htmls = GetHtmlStrsByWebSite(requestModel, out isNoFind);
            }
            catch
            {
                throw;
            }
            return htmls;
        }
        public string GetHtmlStrsByWebSite(RequestModel requestModel, out bool isNoFind)
        {
            string htmls = string.Empty;
            try
            {
                isNoFind = true;
                int irequestType = (int)Enums.TempletType.Common;
                if (requestModel.webSiteEntity != null && !string.IsNullOrEmpty(requestModel.webSiteEntity.Id))
                {
                    if (!new WebSiteApp().IsService(requestModel.webSiteEntity.Id))
                    {
                        requestModel.UrlRaws = WebHelper.GetUrls(requestModel.UrlRaw);
                        ContentApp contentApp = new ContentApp();
                        if (!contentApp.GetHtmlStrs(requestModel, out htmls))
                        {
                            TempletApp templetApp = new TempletApp();
                            TempletEntity templetmodel = new TempletEntity();
                            ColumnsEntity columnentity = new ColumnsEntity();
                            ColumnsApp c_ModulesApp = new ColumnsApp();
                            string Ids = "";
                            if (requestModel.UrlRaws == null || requestModel.UrlRaws.Count == 0)
                            {
                                templetmodel = templetApp.GetMain(requestModel);
                                columnentity = c_ModulesApp.GetMain(requestModel.webSiteEntity.Id);
                                if (columnentity != null)
                                    Ids = columnentity.Id;
                            }
                            else
                            {
                                if (requestModel.UrlRaws.Count > 0)
                                {
                                    templetmodel = templetApp.GetModelByUrlRaws(requestModel, ref irequestType);
                                    columnentity = c_ModulesApp.GetFormByActionName(requestModel.UrlRaws.FirstOrDefault(), requestModel.webSiteEntity.Id);
                                }
                                if (columnentity != null)
                                    Ids = columnentity.Id;
                                if (requestModel.UrlRaws.Count >= 2)
                                {
                                    Ids = requestModel.UrlRaws.LastOrDefault();
                                }
                            }
                            if (templetmodel != null)
                            {
                                htmls = System.Web.HttpUtility.HtmlDecode(templetmodel.Content);
                                if (templetmodel != null && !string.IsNullOrEmpty(templetmodel.Id))
                                {
                                    Guid TId = Guid.Empty;
                                    int pageNumber = 0;
                                    if (!Guid.TryParse(Ids, out TId) && Int32.TryParse(Ids, out pageNumber))
                                    {
                                        if (templetmodel.TempletType == (int)Code.Enums.TempletType.Search && requestModel.UrlRaws.Count == 3)
                                        {
                                            Ids = requestModel.UrlRaws[1];
                                        }
                                        TempHelp temphelp = new TempHelp();
                                        htmls = temphelp.GetHtmlPages(requestModel.webSiteEntity.ShortName, htmls, Ids, irequestType, pageNumber, requestModel.UrlHost);
                                        isNoFind = false;
                                    }
                                    else
                                    {
                                        TempHelp temphelp = new TempHelp();
                                        htmls = temphelp.GetHtmlPages(requestModel.webSiteEntity.ShortName, htmls, Ids, irequestType, requestModel.UrlHost);
                                        isNoFind = false;
                                    }
                                    //更新浏览数
                                    new ContentApp().UpdateViewNum(Ids, true);
                                }
                            }
                        }
                        else
                        {
                            isNoFind = false;
                        }
                    }
                    else
                    {
                        htmls = Comm.SysPageHelp.sysPageHelp.GetServicePage();
                        isNoFind = false;
                    }
                }
                if (isNoFind)
                {
                    htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
                }
            }
            catch
            {
                throw;
            }
            return htmls;
        }

        #endregion

        #region 判断字符串是否经过htmlEncode -bool IsHtmlEnCode(string contents)
        /// <summary>
        /// 判断字符串是否经过htmlEncode
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        private bool IsHtmlEnCode(string contents)
        {
            bool b = false;
            string[] strs = "&#60;&#97;&#32;&#104;&#114;&#101;&#102;&#61;&#34;&#104;&#116;&#116;&#112;&#58;&#47;&#47;&#104;&#111;&#118;&#101;&#114;&#116;&#114;&#101;&#101;&#46;&#99;&#111;&#109;&#47;&#34;&#62;&#20309;&#38382;&#36215;&#65292;&#25105;&#29233;&#20320;&#65292;&#23601;&#20687;&#32769;&#40736;&#29233;&#22823;&#31859;&#12290;&#60;&#47;&#97;&#62;&#32;".Split(';');
            foreach (string str in strs)
            {
                b = contents.Contains(str);
            }
            return b;
        }

        #endregion

        #region 生成html

        #region 生成静态页面保存文件 +bool GenHtmlPage(string codes, string Id,string webSiteShortName)
        /// <summary>
        /// 生成静态页面保存文件
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GenHtmlPage(string codes, string Id, string webSiteShortName)
        {
            bool b = true;
            try
            {
                string templets = GetHtmlPages(webSiteShortName, codes, Id, (int)Enums.TempletType.Common);
                ContentApp c_ContentApp = new ContentApp();
                ContentEntity contentEntity = c_ContentApp.GetForm(Id);
                if (contentEntity != null && contentEntity.ColumnId != null)
                {
                    string strPhyPaths = FileHelper.MapPath(contentEntity.UrlPath);
                    //已生成静态文件时
                    if (contentEntity.UrlPath != null && FileHelper.IsExistFile(strPhyPaths))
                    {
                        FileHelper.DeleteFile(contentEntity.UrlPath);
                        GenHtml(contentEntity.UrlPath, templets);
                    }
                    else
                    {
                        string filePaths = "";
                        string urlAddress = "";
                        InitHtmlSavePath(Id, out filePaths, out urlAddress);
                        //创建静态页面
                        GenHtmlByFilePath(templets, ref filePaths, ref urlAddress);
                        //更新链接地址
                        UpdateContentById(filePaths, urlAddress, Id);
                    }
                }
            }
            catch
            {
                b = false;
            }
            return b;

        }
        /// <summary>
        /// 生成移动端静态页面保存文件
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GenMHtmlPage(string codes, string Id, string webSiteShortName)
        {
            bool b = true;
            try
            {
                string templets = GetHtmlPages(webSiteShortName, codes, Id, (int)Enums.TempletType.Common);
                ContentApp c_ContentApp = new ContentApp();
                ContentEntity contentEntity = c_ContentApp.GetForm(Id);
                if (contentEntity != null && contentEntity.ColumnId != null)
                {
                    string strPhyPaths = FileHelper.MapPath(contentEntity.MUrlPath);
                    //已生成静态文件时
                    if (contentEntity.UrlPath != null && FileHelper.IsExistFile(strPhyPaths))
                    {
                        FileHelper.DeleteFile(contentEntity.MUrlPath);
                        GenHtml(contentEntity.MUrlPath, templets);
                    }
                    else
                    {
                        string filePaths = "";
                        string urlAddress = "";
                        InitMHtmlSavePath(Id, out filePaths, out urlAddress);
                        //创建静态页面
                        GenHtmlByFilePath(templets, ref filePaths, ref urlAddress);
                        //更新链接地址
                        UpdateMContentById(filePaths, urlAddress, Id);
                    }
                }
            }
            catch
            {
                b = false;
            }
            return b;

        }
        /// <summary>
        /// 生成静态页面保存文件
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GenHtmlPageCol(string colId, string webSiteId, string templetId, string actionName)
        {
            bool b = true;
            try
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                WebSiteEntity webSiteEntity = webSiteApp.GetFormNoDel(webSiteId);
                if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
                {
                    TempletApp templetapp = new TempletApp();
                    TempletEntity templet = templetapp.GetFormNoDel(templetId);
                    if (templet != null)
                    {
                        string templetstrs = System.Web.HttpUtility.HtmlDecode(templet.Content);
                        string htmlstrs = new TempHelp().GetHtmlPages(webSiteEntity.ShortName, templetstrs, colId, (int)Enums.TempletType.Common);
                        string urlPath = Code.ConfigHelp.configHelp.HTMLSRC + webSiteEntity.ShortName + @"\";
                        string urlPathStr = Code.ConfigHelp.configHelp.HTMLSRC + webSiteEntity.ShortName + @"\" + actionName + ".html";
                        string strPhyPaths = FileHelper.MapPath(urlPathStr);
                        //已生成静态文件时
                        if (FileHelper.IsExistFile(strPhyPaths))
                        {
                            FileHelper.DeleteFile(urlPathStr);
                            GenHtml(urlPath, htmlstrs);
                        }
                        else
                        {
                            //创建静态页面
                            FileHelper.CreateAndWrite(urlPath, actionName + ".html", htmlstrs);
                        }
                    }
                }
            }
            catch
            {
                b = false;
            }
            return b;

        }
        /// <summary>
        /// 生成移动端静态页面保存文件
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GenMHtmlPageCol(string colId, string webSiteId, string templetId, string actionName)
        {
            bool b = true;
            try
            {
                WebSiteApp webSiteApp = new WebSiteApp();
                WebSiteEntity webSiteEntity = webSiteApp.GetFormNoDel(webSiteId);
                if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
                {
                    TempletApp templetapp = new TempletApp();
                    TempletEntity templet = templetapp.GetFormNoDel(templetId);
                    if (templet != null)
                    {
                        string templetstrs = System.Web.HttpUtility.HtmlDecode(templet.Content);
                        string htmlstrs = new TempHelp().GetHtmlPages(webSiteEntity.ShortName, templetstrs, colId, (int)Enums.TempletType.Common);
                        string urlPath = Code.ConfigHelp.configHelp.HTMLSRC + webSiteEntity.ShortName + @"\m\";
                        string urlPathStr = Code.ConfigHelp.configHelp.HTMLSRC + webSiteEntity.ShortName + @"\m\" + actionName + ".html";
                        string strPhyPaths = FileHelper.MapPath(urlPathStr);
                        //已生成静态文件时
                        if (FileHelper.IsExistFile(strPhyPaths))
                        {
                            FileHelper.DeleteFile(urlPathStr);
                            GenHtml(urlPath, htmlstrs);
                        }
                        else
                        {
                            //创建静态页面
                            FileHelper.CreateAndWrite(urlPath, actionName + ".html", htmlstrs);
                        }
                    }
                }
            }
            catch
            {
                b = false;
            }
            return b;

        }
        #endregion

        #region 获取模板元素集合 +string GetHtmlPages
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPages(string webSiteShortName, string codes, string Id, int irequestType, string urlHost = "")
        {
            string strs = string.Empty;
            try
            {
                codes = codes == null ? "" : codes;
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTCHAR);
                int j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strAttr = "";
                    //获取属性
                    Dictionary<string, string> attrs = GetAttrs(templetst, out strAttr);
                    string strt = templetst.Replace(STARTCHAR, "").Replace(ENDCHAR, "");
                    if (!string.IsNullOrEmpty(strAttr))
                        strt = strt.Replace(strAttr, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string templetstm = ProModels(ref strt, strts);
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id, attrs, webSiteShortName, irequestType, urlHost);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTCHAR);
                    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                }
                strs = templets;
                //格式化
                //strs = HtmlCodeFormat.Format(strs);
            }
            catch
            {
                throw;
            }
            return strs;

        }
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPages(string webSiteShortName, string codes, string Id, int irequestType, int pageNumber, string urlHost = "")
        {
            string strs = string.Empty;
            try
            {
                codes = codes == null ? "" : codes;
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTCHAR);
                int j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strAttr = "";
                    //获取属性
                    Dictionary<string, string> attrs = GetAttrs(templetst, out strAttr);
                    string strt = templetst.Replace(STARTCHAR, "").Replace(ENDCHAR, "");
                    if (!string.IsNullOrEmpty(strAttr))
                        strt = strt.Replace(strAttr, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string templetstm = ProModels(ref strt, strts);
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id, attrs, webSiteShortName, irequestType, pageNumber, urlHost);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTCHAR);
                    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                }
                strs = templets;
                //格式化
                //strs = HtmlCodeFormat.Format(strs);
            }
            catch
            {
                throw;
            }
            return strs;

        }
        /// <summary>
        /// 处理存在内容时
        /// </summary>
        /// <param name="strt"></param>
        /// <param name="strts"></param>
        /// <returns></returns>
        private static string ProModels(ref string strt, string[] strts)
        {
            string templetstm = "";
            if (strts[0].Trim().ToLower() == "models")
            {
                int mitemp = strt.IndexOf(STARTMCHAR);
                int mjtemp = strt.IndexOf(ENDMCHAR) + ENDMCHAR.Length;
                if (mitemp >= 0 && mjtemp >= 0)
                {
                    templetstm = strt.Substring(mitemp, mjtemp - mitemp);
                    strt = strt.Replace(templetstm, "");
                    templetstm = templetstm.Replace(STARTMCHAR, "").Replace(ENDMCHAR, "");
                }
            }
            return templetstm;
        }

        #endregion

        #region 获取模板元素集合 +string GetHtmlPage(string codes, ContentEntity model)
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPage(string codes, ContentEntity model)
        {
            string strs = string.Empty;
            try
            {
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTMC);
                int j = templets.IndexOf(ENDMC) + ENDMC.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTMC, "").Replace(ENDMC, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string htmlt = GetModelById(strts[1], model);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTMC);
                    j = templets.IndexOf(ENDMC) + ENDMC.Length;
                }
                strs = templets;
            }
            catch
            {
                strs = string.Empty;
            }
            return strs;

        }
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPage<T>(string codes, T model)
        {
            string strs = string.Empty;
            try
            {
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTMC);
                int j = templets.IndexOf(ENDMC) + ENDMC.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTMC, "").Replace(ENDMC, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string htmlt = GetModelById(strts[1], model);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTMC);
                    j = templets.IndexOf(ENDMC) + ENDMC.Length;
                }
                strs = templets;
            }
            catch
            {
                strs = string.Empty;
            }
            return strs;

        }

        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPage(string codes, ContentEntity model, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            try
            {
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTMC);
                int j = templets.IndexOf(ENDMC) + ENDMC.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTMC, "").Replace(ENDMC, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string htmlt = GetModelById(strts[1], model, attrs);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTMC);
                    j = templets.IndexOf(ENDMC) + ENDMC.Length;
                }
                strs = templets;
            }
            catch
            {
                strs = string.Empty;
            }
            return strs;

        }


        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPage<T>(string codes, T model, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            try
            {
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTMC);
                int j = templets.IndexOf(ENDMC) + ENDMC.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTMC, "").Replace(ENDMC, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string htmlt = GetModelById<T>(strts[1], model, attrs);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTMC);
                    j = templets.IndexOf(ENDMC) + ENDMC.Length;
                }
                strs = templets;
            }
            catch
            {
                strs = string.Empty;
            }
            return strs;

        }

        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPageForImages(string codes, UpFileEntity model, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            try
            {
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTMC);
                int j = templets.IndexOf(ENDMC) + ENDMC.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTMC, "").Replace(ENDMC, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string htmlt = GetModelById(strts[1], model, attrs);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTMC);
                    j = templets.IndexOf(ENDMC) + ENDMC.Length;
                }
                strs = templets;
            }
            catch
            {
                strs = string.Empty;
            }
            return strs;

        }
        #endregion

        #endregion

        #region 获取html静态页面 -string GetTModel
        /// <summary>
        /// 获取html静态页面
        /// </summary>
        /// <returns></returns>
        private string GetTModel(string codes, string mcodes, string Id, Dictionary<string, string> attrs, string webSiteShortName, int irequestType, string urlHost = "")
        {
            string htmls = codes;
            string[] strs = codes.Split('.');
            if (strs != null && strs.Length == 2)
            {
                //获取名称
                string modelName = strs[0];
                //获取指定内容
                string modelStr = strs[1];
                switch (modelName.Trim().ToLower())
                {
                    case "model":
                        htmls = GetModelById(modelStr, Id, webSiteShortName, attrs);
                        break;
                    case "models":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "contents":
                                htmls = GetContentsById(webSiteShortName, Id, mcodes, attrs, irequestType);
                                break;
                            case "images":
                                htmls = GetImagessById(Id, mcodes, attrs);
                                break;
                        }
                        break;
                    case "templet":
                        htmls = GetHtmlsByTempletName(webSiteShortName, modelStr, Id, irequestType, urlHost);
                        break;
                    case "syssite":
                        htmls = GetWebSiteByShortName(modelStr, webSiteShortName);
                        break;
                    case "content":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "viewnum":
                                htmls = new ContentApp().GetViewNum(Id).ToString();
                                break;
                        }
                        break;
                    case "sys":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "resourceurl":
                                string webSiteUrls = urlHost;
                                if (string.IsNullOrWhiteSpace(urlHost))
                                {
                                    WebSiteEntity webSiteEntity = new WebSiteApp().GetFormByShortName(webSiteShortName);
                                    if (webSiteEntity != null)
                                    {
                                        webSiteUrls = webSiteEntity.UrlAddress;
                                    }
                                }
                                string urlStr = webSiteUrls + HTMLCONTENTSRC + webSiteShortName + "/";
                                urlStr = urlStr.Replace(@"\", @"/");
                                urlStr = urlStr.Replace(@"//", @"/");
                                htmls = WEBURLHTTP + urlStr;
                                break;
                            case "weburl":
                                if (!string.IsNullOrWhiteSpace(urlHost))
                                {
                                    htmls = urlHost;
                                }
                                else
                                {
                                    WebSiteEntity webSiteEntityT = new WebSiteApp().GetFormByShortName(webSiteShortName);
                                    htmls = webSiteEntityT?.UrlAddress;
                                }
                                break;
                        }
                        break;
                }

            }
            return htmls;
        }
        /// <summary>
        /// 获取html静态页面
        /// </summary>
        /// <returns></returns>
        private string GetTModel(string codes, string mcodes, string Id, Dictionary<string, string> attrs, string webSiteShortName, int irequestType, int pageNumber, string urlHost = "")
        {
            string htmls = codes;
            string[] strs = codes.Split('.');
            if (strs != null && strs.Length == 2)
            {
                //获取名称
                string modelName = strs[0];
                //获取指定内容
                string modelStr = strs[1];
                switch (modelName.Trim().ToLower())
                {
                    case "model":
                        htmls = GetModelById(modelStr, Id, webSiteShortName, attrs);
                        break;
                    case "models":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "contents":
                                htmls = GetContentsById(webSiteShortName, Id, mcodes, attrs, irequestType, pageNumber);
                                break;
                            case "images":
                                htmls = GetImagessById(Id, mcodes, attrs);
                                break;
                        }
                        break;
                    case "templet":
                        htmls = GetHtmlsByTempletName(webSiteShortName, modelStr, Id, irequestType, urlHost);
                        break;
                    case "syssite":
                        htmls = GetWebSiteByShortName(modelStr, webSiteShortName);
                        break;
                    case "content":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "viewnum":
                                htmls = new ContentApp().GetViewNum(Id).ToString();
                                break;
                        }
                        break;
                    case "sys":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "resourceurl":
                                string webSiteUrls = urlHost;
                                if (string.IsNullOrWhiteSpace(urlHost))
                                {
                                    WebSiteEntity webSiteEntity = new WebSiteApp().GetFormByShortName(webSiteShortName);
                                    if (webSiteEntity != null)
                                    {
                                        webSiteUrls = webSiteEntity.UrlAddress;
                                    }
                                }
                                string urlStr = webSiteUrls + HTMLCONTENTSRC + webSiteShortName + "/";
                                urlStr = urlStr.Replace(@"\", @"/");
                                urlStr = urlStr.Replace(@"//", @"/");
                                htmls = WEBURLHTTP + urlStr;
                                break;
                            case "weburl":
                                if (!string.IsNullOrWhiteSpace(urlHost))
                                {
                                    htmls = urlHost;
                                }
                                else
                                {
                                    WebSiteEntity webSiteEntityT = new WebSiteApp().GetFormByShortName(webSiteShortName);
                                    htmls = webSiteEntityT?.UrlAddress;
                                }
                                break;
                        }
                        break;
                }

            }
            return htmls;
        }
        #endregion

        #region 获取内容信息 -string GetModelById(string name, string Ids)
        /// <summary>
        /// 根据model获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, ContentEntity model)
        {
            string strs = string.Empty;
            if (model != null)
            {
                strs = ProContent<ContentEntity>(name, model);
            }

            return strs;
        }


        /// <summary>
        /// 根据model获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById<T>(string name, T model)
        {
            string strs = string.Empty;
            if (model != null)
            {
                strs = ProContent<T>(name, model);
            }

            return strs;
        }

        /// <summary>
        /// 根据model获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, ContentEntity model, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;

            if (model != null)
            {
                strs = ProContent<ContentEntity>(name, model, attrs);
            }

            return strs;
        }

        /// <summary>
        /// 根据model获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById<T>(string name, T model, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;

            if (model != null)
            {
                strs = ProContent<T>(name, model, attrs);
            }

            return strs;
        }
        /// <summary>
        /// 根据id获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, string Ids)
        {
            string strs = string.Empty;
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            if (contentEntity != null)
            {
                strs = ProContent<ContentEntity>(name, contentEntity);
            }

            return strs;
        }

        /// <summary>
        /// 根据id获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, string Ids, string webSiteShortName, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            ContentEntity contentEntity = InitModelAttr(Ids, webSiteShortName, attrs);
            if (contentEntity != null)
            {
                strs = ProContent<ContentEntity>(name, contentEntity, attrs);
            }

            return strs;
        }

        #endregion

        #region 根据id获取，站点信息 -string GetWebSiteById(string name, string Ids)
        /// <summary>
        /// 根据id获取，站点信息
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetWebSiteById(string name, string Ids)
        {
            string strs = string.Empty;
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id) && !string.IsNullOrEmpty(contentEntity.WebSiteId))
            {
                WebSiteEntity entity = new WebSiteApp().GetFormNoDel(contentEntity.WebSiteId);
                if (entity != null && !string.IsNullOrEmpty(entity.Id))
                {
                    strs = ProContent<WebSiteEntity>(name, entity);
                }
            }

            return strs;
        }
        /// <summary>
        /// 根据ShortName获取，站点信息
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetWebSiteByShortName(string name, string webSiteShortName)
        {
            string strs = string.Empty;
            WebSiteEntity entity = new WebSiteApp().GetFormByShortName(webSiteShortName);
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                strs = ProContent<WebSiteEntity>(name, entity);
            }

            return strs;
        }
        /// <summary>
        /// 根据id获取，站点信息
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetWebSiteById(string name, string Ids, out string webSiteShortName)
        {
            webSiteShortName = string.Empty;
            string strs = string.Empty;
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id) && !string.IsNullOrEmpty(contentEntity.WebSiteId))
            {
                WebSiteEntity entity = new WebSiteApp().GetFormNoDel(contentEntity.WebSiteId);
                webSiteShortName = entity.ShortName;
                if (entity != null && !string.IsNullOrEmpty(entity.Id))
                {
                    strs = ProContent<WebSiteEntity>(name, entity);
                }
            }
            else
            {
                ColumnsApp columnsApp = new ColumnsApp();
                ColumnsEntity columnsEntity = columnsApp.GetFormNoDel(Ids);
                if (columnsEntity != null && !string.IsNullOrEmpty(columnsEntity.Id) && !string.IsNullOrEmpty(columnsEntity.WebSiteId))
                {
                    WebSiteEntity entity = new WebSiteApp().GetFormNoDel(columnsEntity.WebSiteId);
                    webSiteShortName = entity.ShortName;
                    if (entity != null && !string.IsNullOrEmpty(entity.Id))
                    {
                        strs = ProContent<WebSiteEntity>(name, entity);
                    }
                }
            }

            return strs;
        }
        #endregion

        #region 根据栏目id获取内容集合 -string GetContentsById(string Ids, string mcodes,Dictionary<string, string> attrs)

        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsById(string Ids, string mcodes, string webSiteShortName, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            string extHtmls = string.Empty;
            List<ContentEntity> contententitys = GetContentsByAttrs(Ids, mcodes, webSiteShortName, attrs, 1, ref extHtmls);

            if (contententitys != null && contententitys.Count > 0)
            {
                int index = 1;
                int indexn = 0;
                foreach (ContentEntity contententity in contententitys)
                {
                    contententity.ContentIndex = index;
                    contententity.ContentIndexN = indexn;
                    strs += GetHtmlPage(mcodes, contententity, attrs); 
                    index++;
                    indexn++;
                }
            }
            strs += extHtmls;
            return strs;
        }
        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsById(string webSiteShortName, string Ids, string mcodes, Dictionary<string, string> attrs, int irequestType)
        {
            string strs = string.Empty;

            switch (irequestType)
            {
                case (int)Enums.TempletType.Common:
                    strs = GetContentsById(Ids, mcodes, webSiteShortName, attrs);
                    break;
                case (int)Enums.TempletType.Search:
                    strs = GetSearchContents(webSiteShortName, Ids, mcodes, attrs);
                    break;
            }
            return strs;
        }
        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsById(string webSiteShortName, string Ids, string mcodes, Dictionary<string, string> attrs, int irequestType, int pageNumber)
        {
            string strs = string.Empty;

            switch (irequestType)
            {
                case (int)Enums.TempletType.Common:
                    strs = GetContentsByIdAndWebSite(Ids, mcodes, webSiteShortName, attrs, pageNumber);
                    break;
                case (int)Enums.TempletType.Search:
                    strs = GetSearchContents(webSiteShortName, Ids, mcodes, attrs, pageNumber);
                    break;
            }
            return strs;
        }

        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsByIdAndWebSite(string Ids, string mcodes, string webSiteShortName, Dictionary<string, string> attrs, int pageNumber)
        {
            string strs = string.Empty;
            string extHtmls = string.Empty;
            List<ContentEntity> contententitys = GetContentsByAttrs(Ids, mcodes, webSiteShortName, attrs, pageNumber, ref extHtmls);

            if (contententitys != null && contententitys.Count > 0)
            {
                int index = 1;
                int indexn = 0;
                foreach (ContentEntity contententity in contententitys)
                {
                    contententity.ContentIndex = index;
                    contententity.ContentIndexN = indexn;
                    strs += GetHtmlPage(mcodes, contententity, attrs);
                    index++;
                    indexn++;
                }
            }
            strs += extHtmls;
            return strs;
        }
        private string GetSearchContents(string webSiteShortName, string Ids, string mcodes, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            string extHtmls = string.Empty;
            List<ContentEntity> contententitys = GetSearchsByAttrs(webSiteShortName, Ids, mcodes, attrs, 1, ref extHtmls);

            if (contententitys != null && contententitys.Count > 0)
            {
                foreach (ContentEntity contententity in contententitys)
                {
                    strs += GetHtmlPage(mcodes, contententity, attrs);
                }
            }
            strs += extHtmls;

            return strs;
        }
        private string GetSearchContents(string webSiteShortName, string Ids, string mcodes, Dictionary<string, string> attrs, int pageNumber)
        {
            string strs = string.Empty;
            string extHtmls = string.Empty;
            List<ContentEntity> contententitys = GetSearchsByAttrs(webSiteShortName, Ids, mcodes, attrs, pageNumber, ref extHtmls);

            if (contententitys != null && contententitys.Count > 0)
            {
                foreach (ContentEntity contententity in contententitys)
                {
                    strs += GetHtmlPage(mcodes, contententity, attrs);
                }
            }

            return strs;
        }
        private List<ContentEntity> GetContentsByAttrs(string Ids, string mcodes, string webSiteShortName, Dictionary<string, string> attrs, int pageNumber, ref string extHtmls)
        {
            string strs = string.Empty;
            List<ContentEntity> contententitys = new List<ContentEntity>();
            IQueryable<ContentEntity> contententitysT = null;

            ContentApp c_ContentApp = new ContentApp();
            //数据源
            if (attrs.ContainsKey("sourcename"))
            {
                string sourceName = "";
                attrs.TryGetValue("sourcename", out sourceName);
                ColumnsEntity moduleentity = new ColumnsEntity();
                ColumnsApp c_ModulesApp = new ColumnsApp();

                WebSiteEntity webSiteEntity = new WebSiteApp().GetFormByShortName(webSiteShortName);
                if (webSiteEntity != null && !string.IsNullOrWhiteSpace(webSiteEntity.Id))
                {
                    moduleentity = c_ModulesApp.GetFormByActionName(sourceName, webSiteEntity.Id);
                    if (moduleentity != null && moduleentity.Id != Guid.Empty.ToString())
                    {
                        contententitysT = c_ContentApp.GetListIqNoEnable(moduleentity.Id);
                    }
                }
            }
            else
            {
                contententitysT = c_ContentApp.GetListIqNoEnable(Ids);
            }
            if (contententitysT != null)
            {
                //排序
                if (attrs.ContainsKey("sort"))
                {
                    string val = "";
                    attrs.TryGetValue("sort", out val);

                    string sortName = val;
                    contententitysT = contententitysT.OrderByDescending(m => m.TopMark).ThenBy(sortName);


                }
                //排序
                if (attrs.ContainsKey("sortdesc"))
                {
                    string val = "";
                    attrs.TryGetValue("sortdesc", out val);

                    string sortName = val;
                    contententitysT = contententitysT.OrderByDescending(m => m.TopMark).ThenByDescending(sortName);

                }

                //行数
                if (attrs.ContainsKey("tatol"))
                {
                    string val = "";
                    attrs.TryGetValue("tatol", out val);
                    int tatolnum = 0;
                    if (int.TryParse(val, out tatolnum))
                    {
                        contententitysT = contententitysT.Take(tatolnum);
                    }

                }

                //if (contententitys != null && contententitys.Count > 0)
                if (contententitysT != null)
                {
                    //分页
                    if (attrs.ContainsKey("pagestyle"))
                    {
                        string val = "";
                        attrs.TryGetValue("pagestyle", out val);
                        InitContentPages(val, mcodes, attrs, ref contententitysT, pageNumber, ref extHtmls);
                    }

                    contententitys = contententitysT.ToList();
                    //处理连接地址
                    contententitys.ForEach(delegate (ContentEntity model)
                    {

                        if (model != null && model.UrlAddress != null)
                        {
                            model.UrlPage = model.UrlAddress;
                            model.UrlPage = model.UrlPage.Replace(@"\", "/");
                        }

                    });
                }
            }
            return contententitys;
        }
        private List<ContentEntity> GetSearchsByAttrs(string webSiteShortName, string Ids, string mcodes, Dictionary<string, string> attrs, int pageNumber, ref string extHtmls)
        {
            string strs = string.Empty;
            List<ContentEntity> contententitysT = new List<ContentEntity>();
            IQueryable<ContentEntity> contententitys = LucenceHelp.SearchByShortNameIq(webSiteShortName, Ids);
            if (contententitys != null)
            {
                //排序
                if (attrs.ContainsKey("sort"))
                {
                    string val = "";
                    attrs.TryGetValue("sort", out val);
                    string sortName = val;
                    contententitys = contententitys.OrderBy(sortName);
                }
                //排序
                if (attrs.ContainsKey("sortdesc"))
                {
                    string val = "";
                    attrs.TryGetValue("sortdesc", out val);

                    string sortName = val;
                    contententitys = contententitys.OrderByDescending(sortName);
                }
                //行数
                if (attrs.ContainsKey("tatol"))
                {
                    string val = "";
                    attrs.TryGetValue("tatol", out val);
                    int tatolnum = 0;
                    if (int.TryParse(val, out tatolnum))
                    {
                        contententitys = contententitys.Take(tatolnum);
                    }
                }

                if (contententitys != null)
                {
                    //分页
                    if (attrs.ContainsKey("pagestyle"))
                    {
                        string val = "";
                        attrs.TryGetValue("pagestyle", out val);
                        InitContentPages(val, mcodes, attrs, ref contententitys, pageNumber, ref extHtmls);
                    }
                    contententitysT = contententitys.ToList();

                    //处理连接地址
                    contententitysT.ForEach(delegate (ContentEntity model)
                    {
                        if (model != null && model.UrlAddress != null)
                        {
                            model.UrlPage = model.UrlAddress;
                            model.UrlPage = model.UrlPage.Replace(@"\", "/");
                        }

                    });
                }
            }
            return contententitysT;
        }
        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetImagessById(string Ids, string mcodes, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            List<UpFileEntity> upFileEntitys = new List<UpFileEntity>();
            UpFileApp upFileApp = new UpFileApp();
            IQueryable<UpFileEntity> upFileEntitysT = upFileApp.GetListIq();
            upFileEntitysT = upFileEntitysT.Where(m => m.ParentId == Ids);

            if (upFileEntitysT != null && upFileEntitysT.Count() > 0)
            {
                //排序
                if (attrs.ContainsKey("sort"))
                {
                    string val = "";
                    attrs.TryGetValue("sort", out val);

                    string sortName = val;
                    upFileEntitysT = upFileEntitysT.OrderBy(sortName);


                }
                //排序
                if (attrs.ContainsKey("sortdesc"))
                {
                    string val = "";
                    attrs.TryGetValue("sortdesc", out val);

                    string sortName = val;
                    upFileEntitysT = upFileEntitysT.OrderByDescending(sortName);

                }
                //行数
                if (attrs.ContainsKey("tatol"))
                {
                    string val = "";
                    attrs.TryGetValue("tatol", out val);
                    int tatolnum = 0;
                    if (int.TryParse(val, out tatolnum))
                    {
                        upFileEntitysT = upFileEntitysT.Take(tatolnum);
                    }

                }
                upFileEntitys = upFileEntitysT.ToList();
                //处理连接地址
                upFileEntitys.ForEach(delegate (UpFileEntity model)
                {

                    if (model != null && model.FilePath != null)
                    {
                        model.FilePath = model.FilePath;
                        model.FilePath = model.FilePath.Replace(@"\", "/");
                    }

                });
                if (upFileEntitys != null && upFileEntitys.Count > 0)
                {
                    foreach (UpFileEntity upFileEntity in upFileEntitys)
                    {
                        strs += GetHtmlPage<UpFileEntity>(mcodes, upFileEntity, attrs);
                    }
                }
            }
            return strs;
        }

        private static void InitContentPages(string val, string mcodes, Dictionary<string, string> attrs, ref IQueryable<ContentEntity> contententitys, int pageNumber, ref string extHtmls)
        {
            PageModel pageModel = InitPageModel(attrs, contententitys, pageNumber);
            switch (val.ToLower())
            {
                case "newpage":
                    InitContentPageForNewPage(attrs, ref contententitys, pageModel, ref extHtmls);
                    break;
                case "pageajax":
                    InitContentPageForAjax(mcodes, attrs, ref contententitys, pageModel, ref extHtmls);
                    break;
            }
        }

        private static PageModel InitPageModel(Dictionary<string, string> attrs, IQueryable<ContentEntity> contententitys, int pageNumber)
        {
            PageModel pageModel = new PageModel();

            pageModel.TotalCount = contententitys.Count();

            if (attrs.ContainsKey("currcount"))
            {
                string currcounts = string.Empty;
                int currcount = 0;
                attrs.TryGetValue("currcount", out currcounts);
                if (Int32.TryParse(currcounts, out currcount))
                {
                    pageModel.CurrCount = currcount;
                }
            }
            if (attrs.ContainsKey("currpage"))
            {
                string currpages = string.Empty;
                int currpage = 0;
                attrs.TryGetValue("currpage", out currpages);
                if (Int32.TryParse(currpages, out currpage))
                {
                    pageModel.CurrPage = currpage;
                }
            }
            string eleStrIds = string.Empty;
            if (attrs.ContainsKey("pageele"))
            {
                attrs.TryGetValue("pageele", out eleStrIds);
                pageModel.EleId = eleStrIds;
            }

            double decnum = (contententitys.Count() / (double)pageModel.CurrCount);

            string res = Math.Ceiling(Convert.ToDecimal(decnum)).ToString();
            int totalPage = 0;
            Int32.TryParse(res, out totalPage);
            pageModel.TotalPage = totalPage;

            pageModel.CurrPage = pageNumber;
            return pageModel;
        }

        private static void InitContentPageForNewPage(Dictionary<string, string> attrs, ref IQueryable<ContentEntity> contententitys, PageModel pagemodel, ref string extHtmls)
        {
            if (pagemodel.CurrCount > 0)
            {
                int pageNumberT = pagemodel.CurrPage - 1;
                int skipCount = pageNumberT * pagemodel.CurrCount;
                contententitys = contententitys.Skip(skipCount).Take(pagemodel.CurrCount);
                extHtmls += "<input type='hidden' id='hd" + pagemodel.EleId + "' totalCount='" + pagemodel.TotalCount + "' currCount='" +
                    pagemodel.CurrCount + "' totalPage='" + pagemodel.TotalPage + "' currPage='" +
                    pagemodel.CurrPage + "' eleId='" + pagemodel.EleId + "'/>";
            }
        }
        private static void InitContentPageForAjax(string mcodes, Dictionary<string, string> attrs, ref IQueryable<ContentEntity> contententitys, PageModel pagemodel, ref string extHtmls)
        {
            int pageNumberT = 0;
            int skipCount = pageNumberT * pagemodel.CurrCount;
            contententitys = contententitys.Skip(skipCount).Take(pagemodel.CurrCount);

            extHtmls += "<div style='display:none;' id='hd" + pagemodel.EleId + "'  totalCount='" +
                pagemodel.TotalCount + "' totalPage='" +
                pagemodel.TotalPage + "' currPage='" + pagemodel.CurrPage + "' eleId='" + pagemodel.EleId + "' class='hdsyspage' ";
            if (attrs != null && attrs.Count > 0)
            {
                foreach (var item in attrs)
                {
                    if (!item.Key.Contains("_"))
                    {
                        extHtmls += item.Key + "='" + item.Value + "' ";
                    }
                }
            }
            extHtmls += ">";

            extHtmls += "<div style='display:none;'>";
            foreach (var item in attrs)
            {
                if (item.Key.Contains("_"))
                {
                    extHtmls += "<span class='sysajaxpageattr' fname='" + item.Key + "' fvalue='" + item.Value + "'></span>";
                }
            }
            extHtmls += "</div>";
            extHtmls += mcodes;

            extHtmls += "</div>";
        }

        #endregion

        #region 根据模板名称获取模板信息 -string GetHtmlsByTempletName(string name, string Id)
        /// <summary>
        /// 根据模板名称获取模板信息
        /// </summary>
        /// <returns></returns>
        private string GetHtmlsByTempletName(string webSiteShortName, string name, string Id,int irequestType, string urlHost = "")
        {
            string strs = string.Empty;
            TempletApp templetapp = new TempletApp();
            TempletEntity templet = templetapp.GetFormByName(webSiteShortName, name);
            if (templet != null)
            {
                string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);
                TempHelp temphelp = new TempHelp();
                strs = temphelp.GetHtmlPages(webSiteShortName, templets, Id, irequestType, urlHost);
            }
            return strs;
        }

        #endregion

        #region 处理内容 - ProContent<T>(string name, string strs, T entity)
        /// <summary>
        /// 处理内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strs"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private string ProContent<T>(string name, T entity)
        {
            string strs = string.Empty;
            if (entity != null && name != null)
            {
                PropertyInfo[] propertys = entity.GetType().GetProperties();
                if (propertys != null && propertys.Length > 0)
                {
                    foreach (PropertyInfo property in propertys)
                    {
                        if (property.Name.ToLower() == name.ToLower())
                        {
                            object obj = property.GetValue(entity, null);
                            if (obj != null)
                            {
                                strs = obj.ToString();
                                if (IsHtmlEnCode(strs))
                                {
                                    strs = System.Web.HttpUtility.HtmlDecode(strs);
                                }
                            }
                        }
                    }
                }
            }
            return strs;
        }

        /// <summary>
        /// 处理内容
        /// </summary>
        /// <param name="name"></param>
        /// <param name="strs"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        private string ProContent<T>(string name, T entity, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            if (entity != null && name != null)
            {
                PropertyInfo[] propertys = entity.GetType().GetProperties();
                if (propertys != null && propertys.Length > 0)
                {
                    foreach (PropertyInfo property in propertys)
                    {
                        if (property.Name.ToLower() == name.ToLower())
                        {
                            object obj = property.GetValue(entity, null);
                            if (obj != null)
                            {
                                strs = obj.ToString();
                                if (IsHtmlEnCode(strs))
                                {
                                    strs = System.Web.HttpUtility.HtmlDecode(strs);
                                }
                                strs = InitFormat(name, strs, attrs);
                            }
                        }
                    }
                }
            }
            return strs;
        }

        #endregion

        #region 根据id更新内容链接 -void UpdateContentById(string name, string urlAddress,string Ids)
        /// <summary>
        /// 根据id更新内容链接
        /// </summary>
        /// <param name="Ids"></param>
        private void UpdateContentById(string url, string urlAddress, string Ids)
        {
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            if (contentEntity != null)
            {
                urlAddress = Code.Common.ReplaceStr(urlAddress, @"\", @"/");
                contentEntity.UrlPath = url;
                contentEntity.UrlAddress = urlAddress;
                c_ContentApp.SubmitForm(contentEntity, Ids);
            }
        }
        /// <summary>
        /// 根据id更新内容链接
        /// </summary>
        /// <param name="Ids"></param>
        private void UpdateMContentById(string url, string urlAddress, string Ids)
        {
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            if (contentEntity != null)
            {
                urlAddress = Code.Common.ReplaceStr(urlAddress, @"\", @"/");
                contentEntity.MUrlPath = url;
                contentEntity.UrlAddress = urlAddress;
                c_ContentApp.SubmitForm(contentEntity, Ids);
            }
        }
        #endregion

        #region 获取属性集合 -Dictionary<string, string> GetAttrs(string attrs)
        /// <summary>
        /// 获取属性集合
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetAttrs(string templetst)
        {
            Dictionary<string, string> attrsD = new Dictionary<string, string>();

            int i = templetst.IndexOf(ATTRS);
            int j = templetst.IndexOf(ENDMCNA) + ENDMCNA.Length;
            if (i >= 0 && j >= 0 && j >= i)
            {
                string attrs = templetst.Substring(i, j - i);
                if (!string.IsNullOrEmpty(attrs))
                {
                    string sStrT = ATTRS + STARTMCNA;
                    int iT = attrs.IndexOf(sStrT) + sStrT.Length;
                    int jT = attrs.IndexOf(ENDMCNA);
                    if (iT >= 0 && jT >= 0 && jT >= iT)
                    {
                        string attrsT = attrs.Substring(iT, jT - iT);
                        if (!string.IsNullOrEmpty(attrsT))
                        {
                            string[] attrsTs = attrsT.Split(',');
                            if (attrsTs != null && attrsTs.Count() > 0)
                            {
                                foreach (string item in attrsTs)
                                {
                                    string[] itemT = item.Split('=');
                                    if (itemT != null && itemT.Length == 2)
                                    {
                                        attrsD.Add(itemT[0].ToLower(), itemT[1]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return attrsD;
        }

        /// <summary>
        /// 获取属性集合
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private Dictionary<string, string> GetAttrs(string templetst, out string attrStr)
        {
            Dictionary<string, string> attrsD = new Dictionary<string, string>();
            attrStr = "";
            int i = templetst.IndexOf(ATTRS);
            int j = templetst.IndexOf(ENDMCNA) + ENDMCNA.Length;
            if (i >= 0 && j >= 0 && j >= i)
            {
                string attrs = templetst.Substring(i, j - i);
                attrStr = attrs;
                if (!string.IsNullOrEmpty(attrs))
                {
                    string sStrT = ATTRS + STARTMCNA;
                    int iT = attrs.IndexOf(sStrT) + sStrT.Length;
                    int jT = attrs.IndexOf(ENDMCNA);
                    if (iT >= 0 && jT >= 0 && jT >= iT)
                    {
                        string attrsT = attrs.Substring(iT, jT - iT);
                        if (!string.IsNullOrEmpty(attrsT))
                        {
                            string[] attrsTs = attrsT.Split(',');
                            if (attrsTs != null && attrsTs.Count() > 0)
                            {
                                foreach (string item in attrsTs)
                                {
                                    string[] itemT = item.Split('=');
                                    if (itemT != null && itemT.Length == 2)
                                    {
                                        attrsD.Add(itemT[0].ToLower(), itemT[1]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return attrsD;
        }
        #endregion

        #region 判断请求路径是否为网站前台地址 +bool IsWebSite(string urlRaw)
        /// <summary>
        /// 判断请求路径是否为网站前台地址
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool IsWebSite(string urlRaw)
        {
            bool retBol = true;
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);

            ColumnsApp c_ModulesApp = new ColumnsApp();
            List<ColumnsEntity> models = c_ModulesApp.GetListNoDel();
            if (models != null && models.Count > 0)
            {
                List<string> actionNames = models.Select(m => m.ActionName).ToList();
                if (urlRaws.Count > 0)
                {
                    if (actionNames.Contains(urlRaws.FirstOrDefault()))
                    {
                        retBol = false;
                    }
                }
            }
            return retBol;
        }
        /// <summary>
        /// 判断请求路径是否为网站前台地址
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool IsWebSite(string urlhost, string urlRaw)
        {
            bool retBol = false;
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            WebSiteEntity webSiteEntity = new WebSiteApp().GetModelByUrlHost(urlhost);
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                ColumnsApp c_ModulesApp = new ColumnsApp();
                List<ColumnsEntity> models = c_ModulesApp.GetListNoDel(m => m.DeleteMark != true && m.WebSiteId == webSiteEntity.Id);
                if (models != null && models.Count > 0)
                {
                    List<string> actionNames = models.Select(m => m.ActionName.ToLower()).ToList();
                    if (urlRaws.Count > 0)
                    {
                        string strUrlRaws = urlRaws.FirstOrDefault();
                        if (strUrlRaws != null)
                            strUrlRaws = strUrlRaws.ToLower();
                        if (actionNames.Contains(strUrlRaws))
                        {
                            retBol = true;
                        }
                    }
                }
            }
            return retBol;
        }
        #endregion

        #region 字段格式化处理 -InitFormat(string context, Dictionary<string, string> attrs)
        /// <summary>
        /// 字段格式化处理
        /// </summary>
        /// <param name="name"></param>
        /// <param name="context"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private string InitFormat(string context, Dictionary<string, string> attrs)
        {
            string contexts = context;

            //处理时间格式
            string formatNames = "formattime_" + context;
            if (attrs.ContainsKey(formatNames))
            {
                DateTime Times = new DateTime();
                if (DateTime.TryParse(context, out Times))
                {
                    string formats = "yyyy-MM-dd HH:mm:ss";

                    if (attrs.TryGetValue(formatNames, out formats))
                    {
                        contexts = Times.ToString(formats);
                    }
                }
            }
            //处理字符串截取长度格式
            string formatSubStringNames = ("formatsubstring_" + context).ToLower();
            if (attrs.ContainsKey(formatSubStringNames))
            {
                string formats = "0";
                if (attrs.TryGetValue(formatSubStringNames, out formats))
                {
                    int num = 0;
                    if (Int32.TryParse(formats, out num))
                    {
                        if (contexts != null && contexts.Length > num)
                        {
                            contexts = contexts.Substring(0, num);
                        }
                    }
                }
            }
            return contexts;
        }
        #endregion

        #region 字段格式化处理 -string InitFormat(string name, string context, Dictionary<string, string> attrs)
        /// <summary>
        /// 字段格式化处理
        /// </summary>
        /// <param name="name"></param>
        /// <param name="context"></param>
        /// <param name="attrs"></param>
        /// <returns></returns>
        private string InitFormat(string name, string context, Dictionary<string, string> attrs)
        {
            string contexts = context;
            //处理时间格式
            string formatNames = ("formattime_" + name).ToLower();
            if (attrs.ContainsKey(formatNames))
            {
                DateTime Times = new DateTime();
                if (DateTime.TryParse(context, out Times))
                {
                    string formats = "yyyy-MM-dd HH:mm:ss";

                    if (attrs.TryGetValue(formatNames, out formats))
                    {
                        contexts = Times.ToString(formats);
                    }
                }
            }
            //处理字符串截取长度格式
            string formatSubStringNames = ("formatsubstring_" + name).ToLower();
            if (attrs.ContainsKey(formatSubStringNames))
            {
                string formats = "0";
                if (attrs.TryGetValue(formatSubStringNames, out formats))
                {
                    int num = 0;
                    if (Int32.TryParse(formats, out num))
                    {
                        if (contexts != null && contexts.Length > num)
                        {
                            string contents = HtmlCodeFormat.NoHTML(contexts);
                            contexts = contents.Substring(0, num);
                        }
                    }
                }
            }
            return contexts;
        }
        #endregion

        #region 初始化单个模板属性 -ContentEntity InitModelAttr(string Ids, Dictionary<string, string> attrs)
        /// <summary>
        /// 初始化单个模板属性
        /// </summary>
        /// <returns></returns>
        private ContentEntity InitModelAttr(string Ids, string webSiteShortName, Dictionary<string, string> attrs)
        {
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetFormNoDel(Ids);
            //数据源
            if (attrs.ContainsKey("sourcename"))
            {
                string sourceName = "";
                if (attrs.TryGetValue("sourcename", out sourceName))
                {
                    ContentEntity contentEntityT = new ContentEntity();
                    ContentApp contentApp = new ContentApp();
                    contentEntityT = contentApp.GetContentByActionCode(sourceName, webSiteShortName);
                    if (contentEntityT != null && contentEntityT.Id != Guid.Empty.ToString())
                    {
                        Ids = contentEntityT.Id.ToString();
                    }
                }
            }
            else
            {
                if (contentEntity != null && contentEntity.Id != null && contentEntity.ColumnId != null)
                {

                    //上一个或下一个
                    if (attrs.ContainsKey("lastornext"))
                    {
                        if (attrs.ContainsKey("sort") || attrs.ContainsKey("sortdesc"))
                        {
                            List<ContentEntity> contentEntitysT = new List<ContentEntity>();
                            IQueryable<ContentEntity> contentEntitys = null;
                            contentEntitys = c_ContentApp.GetListIqNoEnable(contentEntity.ColumnId);
                            if (attrs.ContainsKey("sort"))
                            {
                                string sortName = "";
                                if (attrs.TryGetValue("sort", out sortName))
                                {
                                    contentEntitysT = contentEntitys.OrderByDescending(m => m.TopMark).ThenBy(sortName).ToList();
                                }
                            }
                            else
                            {
                                string sortName = "";
                                if (attrs.TryGetValue("sortdesc", out sortName))
                                {
                                    contentEntitysT = contentEntitys.OrderByDescending(m => m.TopMark).ThenByDescending(sortName).ToList();
                                }
                            }

                            //List<ContentEntity> contentEntitysT = contentEntitys.ToList();
                            if (contentEntitysT != null && contentEntitysT.Count > 0)
                            {
                                string lastornextVal = "";
                                if (attrs.TryGetValue("lastornext", out lastornextVal))
                                {
                                    switch (lastornextVal.ToLower())
                                    {
                                        case "last":
                                            int TempNum = 0;
                                            for (int i = 0; i < contentEntitysT.Count(); i++)
                                            {
                                                if (i != 0 && contentEntitysT[i].Id == Ids)
                                                {
                                                    contentEntity = contentEntitysT[i - 1];
                                                    Ids = contentEntity.Id;
                                                    TempNum = 1;
                                                    break;
                                                }
                                            }
                                            if (TempNum == 0)
                                            {
                                                Ids = "";
                                            }
                                            break;
                                        case "next":
                                            if (contentEntitysT.Count() > 1)
                                            {
                                                int TempNumJ = 0;
                                                for (int i = 0; i < contentEntitysT.Count(); i++)
                                                {
                                                    if (i != contentEntitysT.Count() - 1 && contentEntitysT[i].Id == Ids)
                                                    {
                                                        contentEntity = contentEntitysT[i + 1];
                                                        Ids = contentEntity.Id;
                                                        TempNumJ = 1;
                                                        break;
                                                    }
                                                }
                                                if (TempNumJ == 0)
                                                {
                                                    Ids = "";
                                                }
                                            }
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            contentEntity = c_ContentApp.GetFormNoDel(Ids);
            return contentEntity;
        }
        #endregion

        #region 获取ajax 分页数据 +ExtPageModel GetContentModels(ExtPageModel pageModel)
        /// <summary>
        /// 获取ajax 分页数据
        /// </summary>
        /// <returns></returns>
        public ExtPageModel GetContentModels(ExtPageModel pageModel, string webSiteShortName)
        {
            ExtPageModel extPageModel = new ExtPageModel();
            string strs = string.Empty;
            List<ContentEntity> contententitys = new List<ContentEntity>();
            IQueryable<ContentEntity> contententitysT = null;

            ContentApp c_ContentApp = new ContentApp();
            //数据源
            if (!string.IsNullOrEmpty(pageModel.SourceName))
            {
                ColumnsEntity moduleentity = new ColumnsEntity();
                ColumnsApp c_ModulesApp = new ColumnsApp();
                WebSiteEntity webSiteEntity = new WebSiteApp().GetFormByShortName(webSiteShortName);
                if (webSiteEntity != null && !string.IsNullOrWhiteSpace(webSiteEntity.Id))
                {
                    moduleentity = c_ModulesApp.GetFormByActionName(pageModel.SourceName);
                    if (moduleentity != null && moduleentity.Id != Guid.Empty.ToString())
                    {
                        contententitysT = c_ContentApp.GetListIq(moduleentity.Id);
                    }
                }
            }
            else
            {
                contententitysT = c_ContentApp.GetListIq(pageModel.SourceIds);
            }
            if (contententitysT != null)
            {
                //排序
                if (!string.IsNullOrEmpty(pageModel.Sort))
                {
                    contententitysT = contententitysT.OrderBy(pageModel.Sort);
                }
                if (!string.IsNullOrEmpty(pageModel.SortDesc))
                {
                    contententitysT = contententitysT.OrderBy(pageModel.SortDesc);
                }

                //行数
                if (pageModel.Total > 0)
                {
                    contententitysT = contententitysT.Take(pageModel.Total);
                }


                contententitys = contententitysT.ToList();


                if (pageModel.CurrCount > 0 && pageModel.CurrPage > 0)
                {
                    double decnum = (contententitys.Count() / (double)pageModel.CurrCount);
                    string res = Math.Ceiling(Convert.ToDecimal(decnum)).ToString();
                    int totalPage = 0;
                    Int32.TryParse(res, out totalPage);
                    extPageModel.TotalPage = totalPage;
                    extPageModel.TotalCount = contententitys.Count();

                    int pageNumberT = pageModel.CurrPage - 1;
                    int skCount = pageNumberT * pageModel.CurrCount;

                    contententitys = contententitysT.Skip(skCount).Take(pageModel.CurrCount).ToList();

                    extPageModel.CurrCount = pageModel.CurrCount;
                    extPageModel.CurrPage = pageModel.CurrPage;
                }

                if (contententitys != null && contententitys.Count > 0)
                {
                    //处理连接地址
                    contententitys.ForEach(delegate (ContentEntity model)
                    {

                        if (model != null && model.UrlAddress != null)
                        {
                            model.UrlPage = model.UrlAddress;
                            model.UrlPage = model.UrlPage.Replace(@"\", "/");
                        }

                    });
                }
                if (!pageModel.IsHtml)
                {
                    extPageModel.ContentModels = contententitys;
                }
                else
                {
                    if (contententitys != null && contententitys.Count > 0)
                    {
                        foreach (ContentEntity contententity in contententitys)
                        {
                            strs += GetHtmlPage(pageModel.MCodes, contententity, pageModel.AttrDatas);
                        }
                    }
                    extPageModel.Htmlstr = strs;
                }
            }
            return extPageModel;
        }


        #endregion
    }
}
