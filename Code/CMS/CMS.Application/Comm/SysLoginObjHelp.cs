using CMS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.Comm
{
    /// <summary>
    /// 系统登录相关
    /// </summary>
    public class SysLoginObjHelp
    {
        private string LoginUserKey = "CMS_LOGIN_USER_KEY";
        private string LoginProvider = Configs.GetValue("LoginProvider");
        private CMS.Code.Enums.LoginProvider LOGINPROVIDER;

        public SysLoginObjHelp()
        {

            int iloginProvider = 0;
            if (int.TryParse(LoginProvider, out iloginProvider))
            {
                LOGINPROVIDER = (CMS.Code.Enums.LoginProvider)iloginProvider;
            }
        }

        #region 添加

        public void AddObj(string str, string key)
        {
            AddObj<string>(str, key);
        }

        public void AddOperator(OperatorModel operatorModel)
        {
            AddObj<OperatorModel>(operatorModel, LoginUserKey);
        }

        public void AddObj<T>(T t, string key)
        {
            switch (LOGINPROVIDER)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.WriteCookie(key, DESEncrypt.Encrypt(t.ToJson()), 30);
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.WriteSession(key, DESEncrypt.Encrypt(t.ToJson()));
                    break;
            }
        }

        #endregion

        #region 获取

        public T GetObj<T>(string key)
        {
            return GetCurrent<T>(key);
        }

        public OperatorModel GetOperator()
        {
            OperatorModel operatorModel = new OperatorModel();
            operatorModel = GetCurrent<OperatorModel>(LoginUserKey);
            return operatorModel;
        }
        public T GetCurrent<T>(string key)
        {
            T t = default(T);
            switch (LOGINPROVIDER)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    t = DESEncrypt.Decrypt(WebHelper.GetCookie(key).ToString()).ToObject<T>();
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    if (WebHelper.GetSession(LoginUserKey) != null)
                        t = DESEncrypt.Decrypt(WebHelper.GetSession(key).ToString()).ToObject<T>();
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
            RemoveObj(LoginUserKey);
        }

        public void RemoveObj(string key)
        {
            switch (LOGINPROVIDER)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.RemoveCookie(key.Trim());
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.RemoveSession(key.Trim());
                    break;
            }
        }

        #endregion

    }
}
