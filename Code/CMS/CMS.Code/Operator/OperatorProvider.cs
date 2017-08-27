namespace CMS.Code
{
    public class OperatorProvider
    {
        public static OperatorProvider Provider
        {
            get { return new OperatorProvider(); }
        }
        private string LoginUserKey = "CMS_LOGIN_USER_KEY";
        private string LoginProvider = Configs.GetValue("LoginProvider");

        public OperatorModel GetCurrent()
        {
            OperatorModel operatorModel = new OperatorModel();
            int iloginProvider = 0;
            if (int.TryParse(LoginProvider, out iloginProvider))
            {
                operatorModel = GetCurrent((CMS.Code.Enums.LoginProvider)iloginProvider);
            }
            return operatorModel;
        }
        public void AddCurrent(OperatorModel operatorModel)
        {
            int iloginProvider = 0;
            if (int.TryParse(LoginProvider, out iloginProvider))
            {
                AddCurrent(operatorModel, (CMS.Code.Enums.LoginProvider)iloginProvider);
            }
        }
        public void RemoveCurrent()
        {
            int iloginProvider = 0;
            if (int.TryParse(LoginProvider, out iloginProvider))
            {
                RemoveCurrent((CMS.Code.Enums.LoginProvider)iloginProvider);
            }
        }

        private OperatorModel GetCurrent(CMS.Code.Enums.LoginProvider LoginProvider)
        {
            OperatorModel operatorModel = new OperatorModel();
            switch (LoginProvider)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    operatorModel = DESEncrypt.Decrypt(WebHelper.GetCookie(LoginUserKey).ToString()).ToObject<OperatorModel>();
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    if (WebHelper.GetSession(LoginUserKey) != null)
                        operatorModel = DESEncrypt.Decrypt(WebHelper.GetSession(LoginUserKey).ToString()).ToObject<OperatorModel>();
                    else
                        operatorModel = null;
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    if (WebHelper.GetRedis(LoginUserKey) != null)
                        operatorModel = DESEncrypt.Decrypt(WebHelper.GetRedis(LoginUserKey).ToString()).ToObject<OperatorModel>();
                    else
                        operatorModel = null;
                    break;
            }
            return operatorModel;
        }

        private void AddCurrent(OperatorModel operatorModel, CMS.Code.Enums.LoginProvider LoginProvider)
        {
            switch (LoginProvider)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.WriteCookie(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()), 30);
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.WriteSession(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    WebHelper.WriteRedis(LoginUserKey, DESEncrypt.Encrypt(operatorModel.ToJson()));
                    break;
            }
        }

        private void RemoveCurrent(CMS.Code.Enums.LoginProvider LoginProvider)
        {
            switch (LoginProvider)
            {
                case CMS.Code.Enums.LoginProvider.Cookie:
                    WebHelper.RemoveCookie(LoginUserKey.Trim());
                    break;
                case CMS.Code.Enums.LoginProvider.Session:
                    WebHelper.RemoveSession(LoginUserKey.Trim());
                    break;
                case CMS.Code.Enums.LoginProvider.Redis:
                    WebHelper.RemoveRedis(LoginUserKey.Trim());
                    break;
            }
        }
    }
}
