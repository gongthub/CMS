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
        #region 单例模式创建对象
        //单例模式创建对象
        private static RequestHelp _requestHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        RequestHelp()
        {
        }

        public static RequestHelp requestHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _requestHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _requestHelp)
                        {
                            _requestHelp = new RequestHelp();
                        }
                    }
                }
                return _requestHelp;
            }
        }
        #endregion

        #region 处理请求 +void InitRequest(System.Web.HttpContext context)
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void InitRequest(System.Web.HttpContext context)
        {
            //string keys = "11111111";
            ////string desE = DesEncrypt("www.abc.com", keys);
            ////string desD = DesDecrypt(desE, keys);

            
            //string rsaE = RSAEncrypt("www.abc.com", keys);
            //string rsaD = RSADecrypt(keys, rsaE);

            //string desE = CMS.Code.DESEncrypt.Encrypt("www.abc.com", keys);
            //string desD = CMS.Code.DESEncrypt.Decrypt(desE, keys);

            string urlPath = context.Request.Url.GetLeftPart(UriPartial.Authority);
            string urlHost = context.Request.Url.Host;
            string urlRaw = context.Request.RawUrl.ToString();
            if (!TempHelp.tempHelp.IsWebSite(urlRaw))
            {
                return;
            }
            string htmls = TempHelp.tempHelp.GetHtmlByUrl(urlHost,urlRaw);
            context.Response.Write(htmls);
            context.Response.End();
        } 
        #endregion


        //加密
        public static string EncryptDES(string value)
        {
            try
            {
                return System.Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(value));
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //解密
        public static string DecryptDES(string value)
        {
            try
            {
                return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(value));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region RSA加密解密

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="publickey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSAEncrypt(string publickey, string content)
        {
            publickey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(publickey);
            cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);

            return Convert.ToBase64String(cipherbytes);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="privatekey"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string RSADecrypt(string privatekey, string content)
        {
            privatekey = @"<RSAKeyValue><Modulus>5m9m14XH3oqLJ8bNGw9e4rGpXpcktv9MSkHSVFVMjHbfv+SJ5v0ubqQxa5YjLN4vc49z7SVju8s0X4gZ6AzZTn06jzWOgyPRV54Q4I0DCYadWW4Ze3e+BOtwgVU1Og3qHKn8vygoj40J6U85Z/PTJu3hN1m75Zr195ju7g9v4Hk=</Modulus><Exponent>AQAB</Exponent><P>/hf2dnK7rNfl3lbqghWcpFdu778hUpIEBixCDL5WiBtpkZdpSw90aERmHJYaW2RGvGRi6zSftLh00KHsPcNUMw==</P><Q>6Cn/jOLrPapDTEp1Fkq+uz++1Do0eeX7HYqi9rY29CqShzCeI7LEYOoSwYuAJ3xA/DuCdQENPSoJ9KFbO4Wsow==</Q><DP>ga1rHIJro8e/yhxjrKYo/nqc5ICQGhrpMNlPkD9n3CjZVPOISkWF7FzUHEzDANeJfkZhcZa21z24aG3rKo5Qnw==</DP><DQ>MNGsCB8rYlMsRZ2ek2pyQwO7h/sZT8y5ilO9wu08Dwnot/7UMiOEQfDWstY3w5XQQHnvC9WFyCfP4h4QBissyw==</DQ><InverseQ>EG02S7SADhH1EVT9DD0Z62Y0uY7gIYvxX/uq+IzKSCwB8M2G7Qv9xgZQaQlLpCaeKbux3Y59hHM+KpamGL19Kg==</InverseQ><D>vmaYHEbPAgOJvaEXQl+t8DQKFT1fudEysTy31LTyXjGu6XiltXXHUuZaa2IPyHgBz0Nd7znwsW/S44iql0Fen1kzKioEL3svANui63O3o5xdDeExVM6zOf1wUUh/oldovPweChyoAdMtUzgvCbJk1sYDJf++Nr0FeNW1RB1XG30=</D></RSAKeyValue>";
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            byte[] cipherbytes;
            rsa.FromXmlString(privatekey);
            byte[] s = Convert.FromBase64String(content);
            cipherbytes = rsa.Decrypt(s, false);

            return Encoding.UTF8.GetString(cipherbytes);
        }
        #endregion

        #region DES 加密解密

        /// <summary> 
        /// 加密字符串 
        /// 注意:密钥必须为８位 
        /// </summary> 
        /// <param name="strText">字符串</param> 
        /// <param name="encryptKey">密钥</param>
        /// <return>加密后字符串</return>
        public static string DesEncrypt(string strText, string encryptKey)
        {
            string outString = "";
            byte[] byKey = null;
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(encryptKey.Substring(0, encryptKey.Length));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Mode = CipherMode.ECB;
                des.Key = byKey;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                outString = ByteToString(ms.ToArray());

            }
            catch (System.Exception)
            {
                outString = "";
            }

            return outString;
        }

        /// <summary> 
        /// 解密字符串 
        /// </summary> 
        /// <param name="strText">加了密的字符串</param> 
        /// <param name="decryptKey">密钥</param> 
        public static string DesDecrypt(string strText, string decryptKey)
        {
            string outString = "";
            byte[] byKey = null;
            byte[] inputByteArray = StringToByte(strText);
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(decryptKey.Substring(0, decryptKey.Length));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = byKey;
                des.Mode = CipherMode.ECB;
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                outString = encoding.GetString(ms.ToArray());
            }
            catch (System.Exception)
            {
                outString = "";
            }

            return outString;
        }

        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2}", InByte);
            }
            return StringOut;
        }

        // 把十六进制字符串转换成字节型  
        public static byte[] StringToByte(string InString)
        {
            string[] ByteStrings;
            ByteStrings = GetStringE(InString);
            byte[] ByteOut;
            ByteOut = new byte[ByteStrings.Length - 1];
            for (int i = 0; i < ByteStrings.Length - 1; i++)
            {
                ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]), 16);
            }
            return ByteOut;
        }

        //将字符串转成8位数组
        public static string[] GetStringE(string InString)
        {
            string[] result = Regex.Split(InString, "(?<=\\G.{2})");

            return result;

        }
        #endregion DES 加密解密
    }
}
