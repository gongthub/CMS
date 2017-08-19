using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace CMS.Code
{
    /// <summary>
    /// 常用公共类
    /// </summary>
    public class Common
    {
        private static readonly string URLEXTENDED = Configs.GetValue("UrlExtended");
        private static readonly bool ISHANDLEURLPARA = Configs.GetValue("IsHandleUrlPara").IsEmpty() ? false : bool.Parse(Configs.GetValue("IsHandleUrlPara"));


        #region Stopwatch计时器
        /// <summary>
        /// 计时器开始
        /// </summary>
        /// <returns></returns>
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
        /// <summary>
        /// 计时器结束
        /// </summary>
        /// <param name="watch"></param>
        /// <returns></returns>
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
        #endregion

        #region 删除数组中的重复项
        /// <summary>
        /// 删除数组中的重复项
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static string[] RemoveDup(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)//遍历数组成员
            {
                if (!list.Contains(values[i]))
                {
                    list.Add(values[i]);
                };
            }
            return list.ToArray();
        }
        #endregion

        #region 自动生成编号
        /// <summary>
        /// 表示全局唯一标识符 (GUID)。
        /// </summary>
        /// <returns></returns>
        public static string GuId()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 自动生成编号  201008251145409865
        /// </summary>
        /// <returns></returns>
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); //生成编号 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;//形如
            return code;
        }
        #endregion

        #region 生成0-9随机数
        /// <summary>
        /// 生成0-9随机数
        /// </summary>
        /// <param name="codeNum">生成长度</param>
        /// <returns></returns>
        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
        #endregion

        #region 删除最后一个字符之后的字符
        /// <summary>
        /// 删除最后结尾的一个逗号
        /// </summary>
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
        /// <summary>
        /// 删除最后结尾的长度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }
        #endregion

        #region 替换指定字符
        /// <summary>
        /// 替换指定字符
        /// </summary>
        public static string ReplaceStr(string str, string oldStr, string newStr)
        {
            return str.Replace(oldStr, newStr);
        }
        #endregion

        #region 判断url扩展名是否存在
        /// <summary>
        /// 判断url扩展名是否存在
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsExistExtended(string urlRaw)
        {
            bool bretStatus = true;

            if (!IsExistUrlRaw(urlRaw))
            {
                Regex reg = new Regex("[\\w]+[\\.](" + URLEXTENDED + ")");
                Match match = reg.Match(urlRaw);
                bretStatus = match.Success;
            }

            return bretStatus;
        }
        public static bool IsExistUrlRaw(string urlRaw)
        {
            bool bretStatus = false;
            if (urlRaw == "/")
            {
                bretStatus = true;
            }
            else
            {
                string[] strUrlRaw = urlRaw.Split('/');
                if (strUrlRaw.Length == 2)
                {
                    string[] strExs = strUrlRaw[1].Split('.');
                    if (strExs.Length == 1)
                    {
                        bretStatus = true;
                    }
                }
            }
            return bretStatus;
        }
        public static bool IsExistUrlRawExt(string urlRaw)
        {
            bool bretStatus = false;
            string[] strUrlRaw = urlRaw.Split('/');
            string[] strExs = strUrlRaw.LastOrDefault().Split('.');
            if (strExs.Length == 2)
            {
                bretStatus = true;
            }
            return bretStatus;
        }
        #endregion

        #region 判断url后缀为Guid
        /// <summary>
        /// 判断url后缀为Guid
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsExistUrlGuid(string urlRaw)
        {
            bool bretStatus = false;

            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            if (urlRaws != null && urlRaws.Count > 0)
            {
                string urlLasts = urlRaws[urlRaws.Count - 1];
                Guid Id = Guid.Empty;
                if (Guid.TryParse(urlLasts, out Id))
                {
                    bretStatus = true;
                }
            }
            return bretStatus;
        }
        #endregion

        #region 判断请求路径是否为黑名单 +bool IsBlackName(string urlRaw)
        /// <summary>
        /// 判断请求路径是否为黑名单
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static bool IsBlackName(string urlRaw)
        {
            bool retBol = false;
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            string strModules = Configs.GetValue("UrlBlackName");
            if (!string.IsNullOrEmpty(strModules))
            {
                string[] strsModules = strModules.Split('|');
                if (urlRaws != null && urlRaws.Count > 0)
                {
                    retBol = (from c in strsModules where c.ToLower() == urlRaws[0].ToLower() select 1).ToList().Count > 0;
                }
            }
            return retBol;
        }
        #endregion

        #region 判断请求路径是否系统保留Url +bool IsSystemHaveUrlName(string urlRaw)
        /// <summary>
        /// 判断请求路径是否系统保留Url
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static bool IsSystemHaveUrlName(string urlRaw)
        {
            bool retBol = false;
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            string strModules = Configs.GetValue("SystemHaveUrlName");
            if (!string.IsNullOrEmpty(strModules))
            {
                string[] strsModules = strModules.Split('|');
                if (urlRaws != null && urlRaws.Count > 0)
                {
                    retBol = (from c in strsModules where c.ToLower() == urlRaws[0].ToLower() select 1).ToList().Count > 0;
                }
            }
            return retBol;
        }
        /// <summary>
        /// 判断请求路径是否系统保留Url
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        public static bool IsSystemHaveName(string name)
        {
            bool retBol = false;
            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim().ToLower();
                string strModules = Configs.GetValue("SystemHaveUrlName");
                if (!string.IsNullOrEmpty(strModules))
                {
                    strModules = strModules.ToLower();
                    string[] strsModules = strModules.Split('|');
                    retBol = strsModules.Contains(name);
                }
            }
            return retBol;
        }
        #endregion

        #region 判断是否为全站搜索

        /// <summary>
        /// 判断是否为全站搜索
        /// </summary>
        /// <returns></returns>
        public static bool IsSearch(string strName)
        {
            string WebSiteSearchPath = Configs.GetValue("WebSiteSearchPath");
            bool bState = false;
            if (!string.IsNullOrEmpty(strName))
            {
                if (strName.ToLower().Trim() == WebSiteSearchPath.ToLower())
                {
                    bState = true;
                }
            }
            return bState;
        }
        /// <summary>
        /// 判断是否为全站搜索
        /// </summary>
        /// <returns></returns>
        public static bool IsSearchForUrl(string urlRaw)
        {
            string WebSiteSearchPath = Configs.GetValue("WebSiteSearchPath");
            bool bState = false;
            List<string> urlRaws = WebHelper.GetUrls(urlRaw);
            if (!Common.IsExistUrlRawExt(urlRaw))
            {
                bState = IsSearchForUrl(urlRaws);
            }
            return bState;
        }

        /// <summary>
        /// 判断是否为全站搜索
        /// </summary>
        /// <returns></returns>
        public static bool IsSearchForUrl(List<string> urlRaws)
        {
            string WebSiteSearchPath = Configs.GetValue("WebSiteSearchPath");
            bool bState = false;
            if (urlRaws != null && urlRaws.Count >= 2)
            {
                if (urlRaws.FirstOrDefault().ToLower() == WebSiteSearchPath.ToLower())
                {
                    bState = true;
                }
            }
            return bState;
        }

        #endregion

        #region 处理Url参数
        /// <summary>
        /// 处理Url参数
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HandleUrlRaw(string urlRaw)
        {
            string urlraws = urlRaw;
            if (ISHANDLEURLPARA)
            {
                urlRaw = urlRaw.Replace('？', '?');
                string[] urlStrs = urlRaw.Split('?');
                urlraws = urlStrs[0];
            }

            return urlraws;
        }
        #endregion
    }
}
