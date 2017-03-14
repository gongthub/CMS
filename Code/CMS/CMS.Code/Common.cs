﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

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
            if (urlRaw != "/")
            {
                Regex reg = new Regex("[\\w]+[\\.](" + URLEXTENDED + ")");
                Match match = reg.Match(urlRaw);
                bretStatus = match.Success;
            }

            return bretStatus;
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
                urlRaw = urlRaw.Replace('？','?');
                string[] urlStrs = urlRaw.Split('?'); 
                urlraws = urlStrs[0];
            }

            return urlraws;
        }
        #endregion
    }
}
