using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        #region 获取模板元素集合
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
                string templets = System.Web.HttpUtility.HtmlDecode(codes);
                int i = templets.IndexOf(STARTCHAR);
                int j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                while (i > 0 && j > 0)
                {
                    string templetst = templets.Substring(i, j - i);
                    string strt = templetst.Replace(STARTCHAR, "").Replace(ENDCHAR, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string templetstm = "";
                        if (strts[0] == "models")
                        {
                            int mitemp = templetst.IndexOf(STARTMCHAR);
                            int mjtemp = templetst.IndexOf(ENDMCHAR) + ENDMCHAR.Length;
                            if (mitemp >= 0 && mjtemp >= 0)
                            {
                                templetstm = templetst.Substring(mitemp, mjtemp - mitemp);

                                strt = strt.Replace(templetstm,"");
                                templetstm = templetstm.Replace(STARTMCHAR, "").Replace(ENDMCHAR, "");
                            }
                        }
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id);
                        templets = templets.Replace(templetst, htmlt);

                    }
                    i = templets.IndexOf(STARTCHAR);
                    j = templets.IndexOf(ENDCHAR) + ENDCHAR.Length;
                }
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
                    string strt = templetst.Replace(STARTCHAR, "").Replace(ENDCHAR, "");
                    string[] strts = strt.Split('.');

                    if (strts.Length >= 2 && strts[1] != null)
                    {
                        string templetstm = "";
                        if (strts[0] == "models")
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
                        string htmlt = GetTModel(strt.Trim(), templetstm, Id);
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

        #region 获取html静态页面
        /// <summary>
        /// 获取html静态页面
        /// </summary>
        /// <returns></returns>
        private string GetTModel(string codes, string mcodes, string Id)
        {
            string htmls = codes;
            string[] strs = codes.Split('.');
            if (strs != null && strs.Length == 2)
            {
                //获取名称
                string modelName = strs[0];
                //获取指定内容
                string modelStr = strs[1];
                switch (modelName)
                {
                    case "model":
                        htmls = GetModelById(modelStr, Id);
                        break;
                    case "models":
                        switch (modelStr)
                        {
                            case "contents":
                                htmls = GetContentsById(Id, mcodes);
                                break;
                        }
                        break;
                }

            }
            return htmls;
        }
        #endregion

        #region 根据id获取内容
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

        #region 根据栏目id获取内容集合
        /// <summary>
        /// 根据栏目id获取内容集合
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private string GetContentsById(string Ids, string mcodes)
        {
            string strs = "";
            C_ContentApp contentapp = new C_ContentApp();
            List<C_ContentEntity> contententitys = new List<C_ContentEntity>();
            contententitys = contentapp.GetList(Ids);
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

        #region 根据id更新内容链接
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

    }
}
