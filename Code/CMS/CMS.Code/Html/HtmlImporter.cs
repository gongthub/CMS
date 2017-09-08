using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMS.Code.Html
{
    public class HtmlCodeFormat
    {
        public static string Format(string inputString)
        {
            StringBuilder outputString = new StringBuilder();
            string[] arrayString = ToFormatArray(inputString);
            arrayString = FormatImp(arrayString);

            foreach (string ss in arrayString)
            {
                outputString.Append(ss + "\r\n");
            }

            return outputString.ToString();

        }
        public static string NoHTML(string html)
        {

            html = html.Replace("(<style)+[^<>]*>[^\0]*(</style>)+", "");
            html = html.Replace(@"\<img[^\>] \>", "");
            html = html.Replace(@"<p>", "");
            html = html.Replace(@"</p>", "");


            System.Text.RegularExpressions.Regex regex0 =
            new System.Text.RegularExpressions.Regex("(<style)+[^<>]*>[^\0]*(</style>)+", System.Text.RegularExpressions.RegexOptions.Multiline);
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S] </script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S] </iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S] </frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@"\<img[^\>] \>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex7 = new System.Text.RegularExpressions.Regex(@"</p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex8 = new System.Text.RegularExpressions.Regex(@"<p>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex9 = new System.Text.RegularExpressions.Regex(@"<[^>]*>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
            html = regex0.Replace(html, ""); //过滤href=javascript: (<A>) 属性 


            //html = regex10.Replace(html, "");
            html = regex3.Replace(html, "");// _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, ""); //过滤frameset
            html = regex7.Replace(html, ""); //过滤frameset
            html = regex8.Replace(html, ""); //过滤frameset
            html = regex9.Replace(html, "");
            //html = html.Replace(" ", "");
            html = html.Replace("</strong>", "");
            html = html.Replace("<strong>", "");
            html = html.Replace(" ", "");
            return html;
        }

        private static string[] ToFormatArray(string inputString)
        {
            StringBuilder workString = new StringBuilder(inputString);
            StringBuilder outputString = new StringBuilder();
            //去掉换行
            workString.Replace("\r\n", "");
            //添加必须的换行
            workString.Replace("<", "\n<");
            workString.Replace(">", ">\n");

            char[] cc = new char[1] { '\n' };
            string[] arrayString = workString.ToString().Split(cc);
            //去掉空行
            foreach (string s in arrayString)
            {
                // 去掉前前后空白字符
                string text = s.Trim();
                if (text != "")
                {
                    outputString.Append(text + "\n");
                }
            }

            // 不包含空行的字符串数组
            arrayString = outputString.ToString().Split(cc);

            return arrayString;
        }

        private static string[] FormatImp(string[] arrayString)
        {
            int indent = 4;
            int count = 0;
            LastTagType lastTag = LastTagType.None;

            // 找第一个HTML开始标签，<html>
            for (int i = 0; i < arrayString.Length; i++)
            {
                if (Regex.IsMatch(arrayString[i], "<[^\\/].+>")) //匹配HTML开始标签 <html> <head> <title> <font>
                {
                    if (LastTagType.BeginTag == lastTag)
                    {
                        count++;
                    }
                    arrayString[i] = CreateBlank(indent * count) + arrayString[i];
                    lastTag = LastTagType.BeginTag;
                }
                else if (Regex.IsMatch(arrayString[i], "<\\/.+>")) //匹配HTML开始标签 </html> </body> </font>
                {
                    if ((lastTag == LastTagType.Text) || (lastTag == LastTagType.EndTag))
                    {
                        count--;
                    }
                    arrayString[i] = CreateBlank(indent * count) + arrayString[i];
                    lastTag = LastTagType.EndTag;
                }
                else
                {
                    if (lastTag == LastTagType.BeginTag)
                    {
                        count++;
                    }
                    arrayString[i] = CreateBlank(indent * count) + arrayString[i];
                    lastTag = LastTagType.Text;
                }
            }

            return arrayString;
        }

        private static string CreateBlank(int length)
        {
            if (length <= 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        private enum LastTagType
        {
            BeginTag,
            Text,
            EndTag,
            None
        }
    }
}
