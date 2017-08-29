using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Code
{
    /// <summary>
    /// 系统登录相关
    /// </summary>
    public class SysLoginObjHelp
    {
        private readonly string CMS_VERIFYCODE = "CMS_VERIFYCODE";
        private readonly string LOGINUSERKEY = "CMS_LOGIN_USER_KEY";
        private readonly string LOGINPROVIDER = Configs.GetValue("LoginProvider");

        public readonly string WEBSITEID = "WEBSITEID";
        public readonly string WEBSITENAME = "WEBSITENAME";
        public readonly string WEBSITESHORTNAME = "WEBSITESHORTNAME";
        public readonly string WEBSITEURLADDRESS = "WEBSITEURLADDRESS";
        public readonly string WEBSITEENTITY = "WEBSITEENTITY";

        private CMS.Code.Enums.LoginProvider LOGINPROVIDER_ENUM;
        
        #region 单例模式创建对象
        //单例模式创建对象
        private static SysLoginObjHelp _sysLoginObjHelp = null;
        // Creates an syn object.
        private static readonly object SynObject = new object();
        SysLoginObjHelp()
        {
            int iloginProvider = 0;
            if (int.TryParse(LOGINPROVIDER, out iloginProvider))
            {
                LOGINPROVIDER_ENUM = (CMS.Code.Enums.LoginProvider)iloginProvider;
            }
        }

        public static SysLoginObjHelp sysLoginObjHelp
        {
            get
            {
                // Double-Checked Locking
                if (null == _sysLoginObjHelp)
                {
                    lock (SynObject)
                    {
                        if (null == _sysLoginObjHelp)
                        {
                            _sysLoginObjHelp = new SysLoginObjHelp();
                        }
                    }
                }
                return _sysLoginObjHelp;
            }
        }
        #endregion

        #region 添加

        public void AddOperator(OperatorModel operatorModel)
        {
            AddObj<OperatorModel>(operatorModel, LOGINUSERKEY, Code.ConfigHelp.configHelp.USERLOGINTIMEOUT);
        }
        public void AddVerifyCode(string strCode)
        {
            AddObj<string>(strCode, CMS_VERIFYCODE);
        }

        public void AddWebSiteId(string strWebSiteId)
        {
            AddObj<string>(strWebSiteId, WEBSITEID);
        }

        public void AddWebSiteName(string strWebSiteName)
        {
            AddObj<string>(strWebSiteName, WEBSITENAME);
        }
        public void AddWebSiteShortName(string strWebSiteShortName)
        {
            AddObj<string>(strWebSiteShortName, WEBSITESHORTNAME);
        }
        public void AddWebSiteAddress(string strWebSiteAddress)
        {
            AddObj<string>(strWebSiteAddress, WEBSITEURLADDRESS);
        }
        public void AddWebSite<T>(T t)
        {
            AddObj<T>(t, WEBSITEENTITY);
        }

        public void AddObj(string str, string key)
        {
            AddObj<string>(str, key);
        }
        public void AddObj<T>(T t, string key)
        {
            switch (LOGINPROVIDER_ENUM)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.WriteCookie(key, DESEncrypt.Encrypt(t.ToJson()));
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.WriteSession(key, DESEncrypt.Encrypt(t.ToJson()));
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    WebHelper.WriteRedis(key, DESEncrypt.Encrypt(t.ToJson()));
                    break;
            }
        }

        public void AddObj<T>(T t, string key,int minutes)
        {
            switch (LOGINPROVIDER_ENUM)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.WriteCookie(key, DESEncrypt.Encrypt(t.ToJson()), minutes);
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.WriteSession(key, DESEncrypt.Encrypt(t.ToJson()));
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    WebHelper.WriteRedis(key, DESEncrypt.Encrypt(t.ToJson()),minutes);
                    break;
            }
        }

        #endregion

        #region 获取

        public OperatorModel GetOperator()
        {
            OperatorModel operatorModel = new OperatorModel();
            operatorModel = GetObj<OperatorModel>(LOGINUSERKEY);
            if (operatorModel != null)
            {
                AddObj<OperatorModel>(operatorModel, LOGINUSERKEY, Code.ConfigHelp.configHelp.USERLOGINTIMEOUT);
            }
            else
            {
                operatorModel = new OperatorModel();
            }
            return operatorModel;
        }
        public string GetVerifyCode()
        {
            return GetObj<string>(CMS_VERIFYCODE);
        }

        public string GetWebSiteId()
        {
            return GetObj<string>(WEBSITEID);
        }

        public string GetWebSiteName()
        {
            return GetObj<string>(WEBSITENAME);
        }
        public string GetWebSiteShortName()
        {
            return GetObj<string>(WEBSITESHORTNAME);
        }
        public string GetWebSiteAddress()
        {
            return GetObj<string>(WEBSITEURLADDRESS);
        }
        public T GetWebSit<T>()
        {
            return GetObj<T>(WEBSITEENTITY);
        }

        public T GetObj<T>(string key)
        {
            T t = default(T);
            switch (LOGINPROVIDER_ENUM)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    t = DESEncrypt.Decrypt(WebHelper.GetCookie(key).ToString()).ToObject<T>();
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    if (WebHelper.GetSession(key) != null)
                        t = DESEncrypt.Decrypt(WebHelper.GetSession(key).ToString()).ToObject<T>();
                    else
                        t = default(T);
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    if (WebHelper.GetRedis(key) != null)
                        t = DESEncrypt.Decrypt(WebHelper.GetRedis(key).ToString()).ToObject<T>();
                    else
                        t = default(T);
                    break;
            }
            return t;
        } 
        #endregion

        #region 删除

        public void RemoveOperator()
        {
            RemoveObj(LOGINUSERKEY);
        }
        public void RemoveWebSiteId()
        {
            RemoveObj(WEBSITEID);
        }

        public void RemoveWebSiteName()
        {
            RemoveObj(WEBSITENAME);
        }
        public void RemoveWebSiteShortName()
        {
            RemoveObj(WEBSITESHORTNAME);
        }
        public void RemoveWebSiteAddress()
        {
            RemoveObj(WEBSITEURLADDRESS);
        }
        public void RemoveWebSit()
        {
            RemoveObj(WEBSITEENTITY);
        }
        public void RemoveVerifyCode()
        {
            RemoveObj(CMS_VERIFYCODE);
        }

        public void RemoveObj(string key)
        {
            switch (LOGINPROVIDER_ENUM)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.RemoveCookie(key.Trim());
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.RemoveSession(key.Trim());
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    WebHelper.RemoveRedis(key.Trim());
                    break;
            }
        }

        #endregion

    }
}
