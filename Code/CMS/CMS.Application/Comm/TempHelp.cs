using CMS.Application.WebManage;
using CMS.Code;
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
        private static string HTMLSRC = ConfigurationManager.AppSettings["htmlSrc"].ToString();

        private C_ContentEntity CONTENTENTITY = new C_ContentEntity();

        private void InitHtmlSrc()
        {
            HTMLSRC = ConfigurationManager.AppSettings["htmlSrc"].ToString();
        }

        #region 获取文件名称 -string GetUrlName()
        /// <summary>
        /// 获取文件名称
        /// </summary>
        /// <returns></returns>
        private string GetUrlName()
        {
            string names = "";
            Random rand = new Random();
            int rd = rand.Next(00, 99);
            names = DateTime.Now.ToString("yyyyMMddHHmm") + rd.ToString();
            return names;
        }
        #endregion

        #region 创建静态页面 -void CreateHtml(string htmls)
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void CreateHtml(string htmls)
        {
            string filename = GetUrlName() + HTMLFOR;
            FileHelper.CreateAndWrite(HTMLSRC, filename, htmls);
        }
        /// <summary>
        /// 创建静态页面
        /// </summary>
        /// <param name="htmls"></param>
        private void CreateHtml(string htmls, out string filePath)
        {
            string filename = GetUrlName() + HTMLFOR;
            FileHelper.CreateAndWrite(HTMLSRC, filename, htmls);
            int index = HTMLSRC.LastIndexOf('\\');
            if (index >= 0)
            {
                filePath = HTMLSRC + filename;
            }
            else
            {
                filePath = HTMLSRC + @"\" + filename;
            }
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

        #region 获取html

        #region 获取模板元素集合 +bool GetHtmlPage(string codes, string Id)
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public bool GetHtmlPage(string codes, string Id)
        {
            InitHtmlSrc();
            bool b = true;
            try
            {
                if (Id != null)
                {
                    C_ContentApp contentapp = new C_ContentApp();
                    CONTENTENTITY = contentapp.GetForm(Id);
                    if (CONTENTENTITY != null && CONTENTENTITY.F_ModuleId != null)
                    {
                        C_ModulesApp moduleapp = new C_ModulesApp();
                        C_ModulesEntity moduleentity = moduleapp.GetForm(CONTENTENTITY.F_ModuleId);
                        if (moduleentity != null)
                        {
                            HTMLSRC += moduleentity.F_ActionName + @"\";
                        }
                    }

                }
                //string templets = System.Web.HttpUtility.HtmlDecode(codes);
                //int i = templets.IndexOf(STARTCHAR);
                //int j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                //while (i > 0 && j > 0)
                //{
                //    string templetst = templets.Substring(i, j - i);
                //    string strt = templetst.Replace(STARTCHAR, "").Replace(ENDCHAR, "");
                //    string[] strts = strt.Split('.');

                //    if (strts.Length >= 2 && strts[1] != null)
                //    {
                //        string templetstm = "";
                //        if (strts[0] == "models")
                //        {
                //            int mitemp = templetst.IndexOf(STARTMCHAR);
                //            int mjtemp = templetst.IndexOf(ENDMCHAR) + ENDMCHAR.Length;
                //            if (mitemp >= 0 && mjtemp >= 0)
                //            {
                //                templetstm = templetst.Substring(mitemp, mjtemp - mitemp);

                //                strt = strt.Replace(templetstm,"");
                //                templetstm = templetstm.Replace(STARTMCHAR, "").Replace(ENDMCHAR, "");
                //            }
                //        }
                //        string htmlt = GetTModel(strt.Trim(), templetstm, Id);
                //        templets = templets.Replace(templetst, htmlt);

                //    }
                //    i = templets.IndexOf(STARTCHAR);
                //    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                //}
                string templets = GetHtmlPages(codes, Id);
                string filePaths = "";
                //创建静态页面
                CreateHtml(templets, out filePaths);
                //更新链接地址
                UpdateContentById(filePaths, Id);
                //删除原有页面
                if (CONTENTENTITY != null && CONTENTENTITY.F_ModuleId != null && CONTENTENTITY.F_UrlAddress != null)
                {
                    FileHelper.DeleteFile(CONTENTENTITY.F_UrlAddress);
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
            string strs = "";
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
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id, attrs);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTCHAR);
                    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                }
                strs = templets;
            }
            catch (Exception ex)
            {
                strs = "";
            }
            return strs;

        }
        #endregion

        #region 获取模板元素集合 +string GetHtmlPage(string codes, C_ContentEntity model)
        /// <summary>
        /// 获取模板元素集合
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public string GetHtmlPage(string codes, C_ContentEntity model)
        {
            string strs = "";
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
                strs = "";
            }
            return strs;

        }

        #endregion

        #endregion

        #region 获取html静态页面 -GetTModel(string codes, string mcodes, string Id, string attrs)
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
                        htmls = GetModelById(modelStr, Id);
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
                }

            }
            return htmls;
        }
        #endregion

        #region 根据id获取内容 -string GetModelById(string name, string Ids)
        /// <summary>
        /// 根据id获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, string Ids)
        {
            string strs = "";
            if (CONTENTENTITY == null || CONTENTENTITY.F_Id != Ids)
            {
                C_ContentApp contentapp = new C_ContentApp();
                CONTENTENTITY = contentapp.GetForm(Ids);
                if (CONTENTENTITY != null && CONTENTENTITY.F_ModuleId != null)
                {
                    C_ModulesApp moduleapp = new C_ModulesApp();
                    C_ModulesEntity moduleentity = moduleapp.GetForm(CONTENTENTITY.F_ModuleId);
                    if (moduleentity != null)
                    {
                        HTMLSRC += moduleentity.F_ActionName + @"\";
                    }
                }
            }

            if (CONTENTENTITY != null)
            {
                PropertyInfo[] propertys = CONTENTENTITY.GetType().GetProperties();
                if (propertys != null && propertys.Length > 0)
                {
                    foreach (PropertyInfo property in propertys)
                    {
                        if (property.Name == name || property.Name.Replace("F_", "") == name)
                        {
                            object obj = property.GetValue(CONTENTENTITY, null);
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
        /// 根据model获取内容
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetModelById(string name, C_ContentEntity model)
        {
            string strs = "";

            if (model != null)
            {
                PropertyInfo[] propertys = model.GetType().GetProperties();
                if (propertys != null && propertys.Length > 0)
                {
                    foreach (PropertyInfo property in propertys)
                    {
                        if (property.Name == name || property.Name.Replace("F_", "") == name)
                        {
                            object obj = property.GetValue(model, null);
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

        #endregion

        #region 根据栏目id获取内容集合 -string GetContentsById(string Ids, string mcodes,Dictionary<string, string> attrs)
        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsById(string Ids, string mcodes, Dictionary<string, string> attrs)
        {
            string strs = "";
            C_ContentApp contentapp = new C_ContentApp();
            List<C_ContentEntity> contententitys = new List<C_ContentEntity>();
            IQueryable<C_ContentEntity> contententitysT = contentapp.GetListIq(Ids);

            //排序
            if (attrs.ContainsKey("sort"))
            {
                string val = "";
                attrs.TryGetValue("sort", out val);

                string sortName = "F_" + val; 
              contententitysT =  contententitysT.OrderBy(sortName);


            }
            //排序
            if (attrs.ContainsKey("sortdesc"))
            {
                string val = "";
                attrs.TryGetValue("sortdesc", out val);

                string sortName = "F_" + val; 
                contententitysT = contententitysT.OrderBy(sortName,true); 

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

            };
            if (contententitys != null && contententitys.Count > 0)
            {
                foreach (C_ContentEntity contententity in contententitys)
                {
                    strs += GetHtmlPage(mcodes, contententity);
                }
            }
            return strs;
        }

        #endregion

        #region 根据id更新内容链接 -void UpdateContentById(string url, string Ids)
        /// <summary>
        /// 根据id更新内容链接
        /// </summary>
        /// <param name="Ids"></param>
        private void UpdateContentById(string url, string Ids)
        {
            C_ContentApp contentapp = new C_ContentApp();
            C_ContentEntity contentEntity = contentapp.GetForm(Ids);
            if (contentEntity != null)
            {
                contentEntity.F_UrlAddress = url;
                contentapp.SubmitForm(contentEntity, Ids);
            }
        }
        #endregion

        #region 根据模板名称获取模板信息 -string GetHtmlsByTempletName(string name, string Id)
        /// <summary>
        /// 根据模板名称获取模板信息
        /// </summary>
        /// <returns></returns>
        private string GetHtmlsByTempletName(string name, string Id)
        {
            string strs = "";
            C_TempletApp templetapp = new C_TempletApp();
            C_TempletEntity templet = templetapp.GetFormByName(name);
            if (templet != null)
            {
                string templets = System.Web.HttpUtility.HtmlDecode(templet.F_Content);
                TempHelp temphelp = new TempHelp();
                strs = temphelp.GetHtmlPages(templets, Id);
            }
            return strs;
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
                                        attrsD.Add(itemT[0], itemT[1]);
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
                                        attrsD.Add(itemT[0], itemT[1]);
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
    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName)
        {
            return OrderBy(queryable, propertyName, false);
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> queryable, string propertyName, bool desc)
        {
            var param = Expression.Parameter(typeof(T));
            var body = Expression.Property(param, propertyName);
            dynamic keySelector = Expression.Lambda(body, param);
            return desc ? Queryable.OrderByDescending(queryable, keySelector) : Queryable.OrderBy(queryable, keySelector);
        }
    }
}
