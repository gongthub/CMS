using CMS.Application.WebManage;
using CMS.Code;
using CMS.Code.Html;
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
        #region 单例模式创建对象
        //单例模式创建对象
        private static TempHelp _tempHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        TempHelp()
        {
        }

        public static TempHelp tempHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _tempHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _tempHelp)
                        {
                            _tempHelp = new TempHelp();
                        }
                    }
                }
                return _tempHelp;
            }
        }
        #endregion 
        /// <summary>
        /// 输出文件格式
        /// </summary>
        private static readonly string HTMLFOR = ".html";
        /// <summary>
        /// 模板开始特殊符
        /// </summary>
        private static readonly string STARTCHAR = "{{#";
        /// <summary>
        /// 模板结束特殊符
        /// </summary>
        private static readonly string ENDCHAR = "#}}";
        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        private static readonly string STARTMCHAR = "{";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        private static readonly string ENDMCHAR = "}";

        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        private static readonly string STARTMC = "@[";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        private static readonly string ENDMC = "]@";

        /// <summary>
        /// 模板列表内容开始特殊符
        /// </summary>
        private static readonly string STARTMCNA = "[";
        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        private static readonly string ENDMCNA = "]";

        /// <summary>
        /// 模板列表内容结束特殊符
        /// </summary>
        private static readonly string ATTRS = "@attrs=";
        /// <summary>
        /// 静态页面缓存路径
        /// </summary>
        private static readonly string HTMLSAVEPATH = ConfigurationManager.AppSettings["htmlSrc"].ToString();
        /// <summary>
        /// 静态页面相对路径
        /// </summary>
        private static readonly string HTMLSAVEHTMLPATH = ConfigurationManager.AppSettings["htmlSrcPath"].ToString();

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
                    WebSiteEntity webSiteentity = webSiteApp.GetForm(moduleentity.WebSiteId);
                    if (JudgmentHelp.judgmentHelp.IsNullEntity<WebSiteEntity>(webSiteentity))
                    {
                        filePath = HTMLSAVEPATH + webSiteentity.ShortName + @"\" + moduleentity.ActionName + @"\";
                        urlAddress = HTMLSAVEHTMLPATH + moduleentity.ActionName + @"\";
                    }
                }
            }
        }

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

        #region 生成静态页面保存文件 +bool GenHtmlPage(string codes, string Id)
        /// <summary>
        /// 生成静态页面保存文件
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GenHtmlPage(string codes, string Id)
        {
            //InitHtmlSavePath();
            bool b = true;
            try
            {
                string templets = GetHtmlPages(codes, Id);

                ContentApp c_ContentApp = new ContentApp();
                ContentEntity contentEntity = c_ContentApp.GetForm(Id);
                if (contentEntity != null && contentEntity.ColumnId != null)
                {

                    //已生成静态文件时
                    if (contentEntity.UrlPath != null && FileHelper.IsExistFile(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + contentEntity.UrlPath))
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
            catch (Exception ex)
            {
                b = false;
            }
            return b;

        }
        #endregion

        #region 获取模板元素集合 +string GetHtmlPages(string codes, string Id)
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPages(string codes, string Id)
        {
            string strs = string.Empty;
            try
            {
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
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id, attrs);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTCHAR);
                    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                }
                strs = templets;
                //格式化
                //strs = HtmlCodeFormat.Format(strs);
            }
            catch (Exception ex)
            {
                strs = string.Empty;
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                strs = string.Empty;
            }
            return strs;

        }

        #endregion

        #endregion

        #region 获取html静态页面 -string GetTModel(string codes, string mcodes, string Id, string attrs)
        /// <summary>
        /// 获取html静态页面
        /// </summary>
        /// <returns></returns>
        private string GetTModel(string codes, string mcodes, string Id, Dictionary<string, string> attrs)
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
                        htmls = GetModelById(modelStr, Id, attrs);
                        break;
                    case "models":
                        switch (modelStr.Trim().ToLower())
                        {
                            case "contents":
                                htmls = GetContentsById(Id, mcodes, attrs);
                                break;
                        }
                        break;
                    case "templet":
                        htmls = GetHtmlsByTempletName(modelStr, Id);
                        break;
                    case "syssite":
                        htmls = GetWebSiteById(modelStr, Id);
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
        /// 根据id获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, string Ids)
        {
            string strs = string.Empty;
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetForm(Ids);
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
        private string GetModelById(string name, string Ids, Dictionary<string, string> attrs)
        {
            string strs = string.Empty;
            ContentEntity contentEntity = InitModelAttr(Ids, attrs);
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
            ContentEntity contentEntity = c_ContentApp.GetForm(Ids);
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id) && !string.IsNullOrEmpty(contentEntity.WebSiteId))
            {
                WebSiteEntity entity = new WebSiteApp().GetForm(contentEntity.WebSiteId);
                if (entity != null && !string.IsNullOrEmpty(entity.Id))
                {
                    strs = ProContent<WebSiteEntity>(name, entity);
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
        private string GetContentsById(string Ids, string mcodes, Dictionary<string, string> attrs)
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
                moduleentity = c_ModulesApp.GetFormByActionName(sourceName);
                if (moduleentity != null && moduleentity.Id != Guid.Empty.ToString())
                {
                    contententitysT = c_ContentApp.GetListIq(moduleentity.Id);
                }
            }
            else
            {
                contententitysT = c_ContentApp.GetListIq(Ids);
            }
            if (contententitysT != null)
            {
                //排序
                if (attrs.ContainsKey("sort"))
                {
                    string val = "";
                    attrs.TryGetValue("sort", out val);

                    string sortName = val;
                    contententitysT = contententitysT.OrderBy(sortName);


                }
                //排序
                if (attrs.ContainsKey("sortdesc"))
                {
                    string val = "";
                    attrs.TryGetValue("sortdesc", out val);

                    string sortName = val;
                    contententitysT = contententitysT.OrderBy(sortName, true);

                }
                //行数
                if (attrs.ContainsKey("tatol"))
                {
                    string val = "";
                    attrs.TryGetValue("tatol", out val);
                    int tatolnum = 0;
                    if (int.TryParse(val, out tatolnum))
                    {
                        contententitys = contententitysT.Take(tatolnum).ToList();
                    }

                }
                //处理连接地址
                contententitys.ForEach(delegate(ContentEntity model)
                {

                    if (model != null && model.UrlAddress != null)
                    {
                        model.UrlPage = model.UrlAddress;
                        model.UrlPage = model.UrlPage.Replace(@"\", "/");
                    }

                });
                if (contententitys != null && contententitys.Count > 0)
                {
                    foreach (ContentEntity contententity in contententitys)
                    {
                        strs += GetHtmlPage(mcodes, contententity, attrs);
                    }
                }
            }
            return strs;
        }

        #endregion

        #region 根据模板名称获取模板信息 -string GetHtmlsByTempletName(string name, string Id)
        /// <summary>
        /// 根据模板名称获取模板信息
        /// </summary>
        /// <returns></returns>
        private string GetHtmlsByTempletName(string name, string Id)
        {
            string strs = string.Empty;
            TempletApp templetapp = new TempletApp();
            TempletEntity templet = templetapp.GetFormByName(name);
            if (templet != null)
            {
                string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);
                TempHelp temphelp = new TempHelp();
                strs = temphelp.GetHtmlPages(templets, Id);
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
                                strs = InitFormat(strs, attrs);
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
            ContentEntity contentEntity = c_ContentApp.GetForm(Ids);
            if (contentEntity != null)
            {
                urlAddress = Code.Common.ReplaceStr(urlAddress, @"\", @"/");
                contentEntity.UrlPath = url;
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

        #region 根据urlRaw获取html +string GetHtmlByUrl(string urlRaw)
        /// <summary>
        /// 根据urlRaw获取html
        /// </summary>
        /// <param name="urlRaw"></param>
        /// <returns></returns>
        public string GetHtmlByUrl(string urlRaw)
        {
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            TempletApp templetApp = new TempletApp();
            TempletEntity model = new TempletEntity();
            ColumnsEntity moduleentity = new ColumnsEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            string Ids = "";
            if (urlRaws == null || urlRaws.Count == 0)
            {
                model = templetApp.GetMain();
                moduleentity = c_ModulesApp.GetMain();
                if (moduleentity != null)
                    Ids = moduleentity.Id;
            }
            else
            {
                if (urlRaws.Count > 0)
                {
                    model = templetApp.GetModelByActionName(urlRaws.FirstOrDefault());
                    moduleentity = c_ModulesApp.GetFormByActionName(urlRaws.FirstOrDefault());
                }
                if (moduleentity != null)
                    Ids = moduleentity.Id;
                if (urlRaws.Count == 2)
                {
                    Ids = urlRaws.LastOrDefault();
                }
            }
            string htmls = System.Web.HttpUtility.HtmlDecode(model.Content);
            if (moduleentity != null)
            {
                TempHelp temphelp = new TempHelp();
                htmls = temphelp.GetHtmlPages(htmls, Ids);
            }

            return htmls;
        }

        /// <summary>
        /// 根据urlRaw获取html
        /// </summary>
        /// <param name="urlRaw"></param>
        /// <returns></returns>
        public string GetHtmlByUrl(string urlHost, string urlRaw)
        {
            //处理Url参数
            urlRaw = Common.HandleUrlRaw(urlRaw);
            WebSiteApp app = new WebSiteApp();
            WebSiteEntity entity = app.GetModelByUrlHost(urlHost);
            return GetHtmlStrsByWebSite(entity, urlRaw);
        }

        public string GetHtmlStrsByWebSite(WebSiteEntity entity, string urlRaw)
        {
            string htmls = string.Empty;
            int iFlay = 0;
            bool isNoFind = false;
            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                List<string> urlRaws = WebHelper.GetUrls(urlRaw);
                ContentApp contentApp = new ContentApp();
                if (!contentApp.GetHtmlStrs(entity.Id, urlRaw, out htmls))
                {
                    TempletApp templetApp = new TempletApp();
                    TempletEntity templetmodel = new TempletEntity();
                    ColumnsEntity columnentity = new ColumnsEntity();
                    ColumnsApp c_ModulesApp = new ColumnsApp();
                    string Ids = "";
                    if (urlRaws == null || urlRaws.Count == 0)
                    {
                        templetmodel = templetApp.GetMain(entity.Id);
                        columnentity = c_ModulesApp.GetMain(entity.Id);
                        if (columnentity != null)
                            Ids = columnentity.Id;
                    }
                    else
                    {
                        if (urlRaws.Count > 0)
                        {
                            templetmodel = templetApp.GetCModelByActionName(urlRaws.FirstOrDefault(), entity.Id);
                            columnentity = c_ModulesApp.GetFormByActionName(urlRaws.FirstOrDefault(), entity.Id);
                        }
                        if (columnentity != null)
                            Ids = columnentity.Id;
                        if (urlRaws.Count == 2)
                        {
                            Ids = urlRaws.LastOrDefault();
                            iFlay = 1;
                        }
                    }
                    if (templetmodel == null)
                    {
                        isNoFind = true;
                    }
                    else
                    {
                        htmls = System.Web.HttpUtility.HtmlDecode(templetmodel.Content);
                        if (templetmodel != null && !string.IsNullOrEmpty(templetmodel.Content))
                        {
                            if (columnentity != null)
                            {
                                if (iFlay == 1)
                                {
                                    ContentEntity contentEntity = new ContentApp().GetForm(Ids);
                                    if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id))
                                    {
                                        TempHelp temphelp = new TempHelp();
                                        htmls = temphelp.GetHtmlPages(htmls, Ids);
                                    }
                                    else
                                    {
                                        isNoFind = true;
                                    }
                                }
                                else
                                {
                                    TempHelp temphelp = new TempHelp();
                                    htmls = temphelp.GetHtmlPages(htmls, Ids);
                                }
                            }
                        }
                        else
                        {
                            isNoFind = true;
                        }
                    }
                }
            }
            else
            {
                isNoFind = true;
            }
            if (isNoFind)
            {
                htmls = Comm.SysPageHelp.sysPageHelp.GetNoFindPage();
            }
            return htmls;
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
            List<ColumnsEntity> models = c_ModulesApp.GetList();
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
            WebSiteEntity webSiteEntity = new WebSiteApp().GetFormByUrl(urlhost);
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                ColumnsApp c_ModulesApp = new ColumnsApp();
                List<ColumnsEntity> models = c_ModulesApp.GetList(m => m.DeleteMark != true && m.WebSiteId == webSiteEntity.Id);
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
            string formatNames = "formattime";
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
            return contexts;
        }
        #endregion

        #region 初始化单个模板属性 -ContentEntity InitModelAttr(string Ids, Dictionary<string, string> attrs)
        /// <summary>
        /// 初始化单个模板属性
        /// </summary>
        /// <returns></returns>
        private ContentEntity InitModelAttr(string Ids, Dictionary<string, string> attrs)
        {
            ContentApp c_ContentApp = new ContentApp();
            ContentEntity contentEntity = c_ContentApp.GetForm(Ids);
            //数据源
            if (attrs.ContainsKey("sourcename"))
            {
                string sourceName = "";
                if (attrs.TryGetValue("sourcename", out sourceName))
                {
                    ContentEntity contentEntityT = new ContentEntity();
                    ContentApp contentApp = new ContentApp();
                    contentEntityT = contentApp.GetContentByActionCode(sourceName);
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
                            IQueryable<ContentEntity> contentEntitys = null;
                            contentEntitys = c_ContentApp.GetListIq(contentEntity.ColumnId);
                            if (attrs.ContainsKey("sort"))
                            {
                                string sortName = "";
                                if (attrs.TryGetValue("sort", out sortName))
                                {
                                    contentEntitys.OrderBy(sortName);
                                }
                            }
                            else
                            {
                                string sortName = "";
                                if (attrs.TryGetValue("sortdesc", out sortName))
                                {
                                    contentEntitys.OrderBy(sortName, true);
                                }
                            }

                            List<ContentEntity> contentEntitysT = contentEntitys.ToList();
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

            contentEntity = c_ContentApp.GetForm(Ids);
            return contentEntity;
        }
    }
        #endregion

}
