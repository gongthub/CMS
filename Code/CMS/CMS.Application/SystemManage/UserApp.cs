using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;

namespace CMS.Application.SystemManage
{
    public class UserApp
    {
        private static readonly string SYSTEMADMINUSERNAME = Code.Configs.GetValue("SystemUserName");
        private static readonly string SYSTEMADMINUSERPASSWORD = Code.Configs.GetValue("SystemUserPassword");
        private IUserRepository service = new UserRepository();
        private UserLogOnApp userLogOnApp = new UserLogOnApp();

        public List<UserEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<UserEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.Account.Contains(keyword));
                expression = expression.Or(t => t.RealName.Contains(keyword));
                expression = expression.Or(t => t.MobilePhone.Contains(keyword));
            }
            expression = expression.And(t => t.Account != SYSTEMADMINUSERNAME);
            expression = expression.And(t => t.DeleteMark != true);

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
            {
                expression = expression.And(t => t.UserLevel == LoginInfo.UserLevel && t.Id == LoginInfo.UserId);
            }
            else
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                {
                    expression = expression.And(t => t.Id == LoginInfo.UserId || t.CreatorUserId == LoginInfo.UserId);
                }
            }
            return service.FindList(expression, pagination);
        }
        public UserEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(m => m.Id == keyValue);
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue, string[] webSiteIds)
        {
            userEntity.Account = userEntity.Account.Trim();
            if (!service.IsExist(keyValue, "Account", userEntity.Account) && !IsSystemUserName(userEntity.Account))
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    userEntity.Modify(keyValue);
                }
                else
                {
                    userEntity.Create();
                }
                service.SubmitForm(userEntity, userLogOnEntity, keyValue);
                UserWebSiteApp userWebSiteApp = new UserWebSiteApp();
                userWebSiteApp.SaveUserWebSite(userEntity.Id, webSiteIds);
            }
            else
            {
                throw new Exception("用户名已存在，请重新输入！");
            }
        }
        public void UpdateForm(UserEntity userEntity)
        {
            service.Update(userEntity);
        }
        public UserEntity CheckLogin(string username, string password)
        {
            UserEntity userEntity = service.FindEntity(t => t.Account == username);
            if (username == SYSTEMADMINUSERNAME && password == SYSTEMADMINUSERPASSWORD)
            {
                //userEntity = service.FindEntity(t => t.DeleteMark != true);
                return userEntity;
            }
            if (userEntity != null)
            {
                if (userEntity.EnabledMark == true)
                {
                    UserLogOnEntity userLogOnEntity = userLogOnApp.GetForm(userEntity.Id);
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(password.ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                    if (dbPassword == userLogOnEntity.UserPassword)
                    {
                        DateTime lastVisitTime = DateTime.Now;
                        int LogOnCount = (userLogOnEntity.LogOnCount).ToInt() + 1;
                        if (userLogOnEntity.LastVisitTime != null)
                        {
                            userLogOnEntity.PreviousVisitTime = userLogOnEntity.LastVisitTime.ToDate();
                        }
                        userLogOnEntity.LastVisitTime = lastVisitTime;
                        userLogOnEntity.LogOnCount = LogOnCount;
                        userLogOnApp.UpdateForm(userLogOnEntity);
                        return userEntity;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("账户被系统锁定,请联系管理员");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }

        /// <summary>
        /// 获取当前用户可最大添加网站数
        /// </summary>
        /// <returns></returns>
        public int GetUserWebSiteMaxNum()
        {
            int iWebSiteNum = 0;

            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.SystemUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_SYSTEMUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_WEBSITEUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_REGISTERUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_ORDINARYUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_GOLDUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                {
                    int.TryParse(Comm.ConfigHelp.configHelp.WEBSITENUM_DIAMONDUSER, out iWebSiteNum);
                }
            }
            return iWebSiteNum;
        }


        /// <summary>
        /// 判断是否为系统管理员用户
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsSystemUserName(string name)
        {
            bool retBool = false;
            if (name != null && SYSTEMADMINUSERNAME != null)
            {
                if (name.ToLower() == SYSTEMADMINUSERNAME.ToLower())
                {
                    retBool = true;
                }
            }
            return retBool;
        }

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        public bool IsExistDefaultWebSite(ref string webSiteId)
        {
            bool bState = false;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    WebSiteApp webSiteApp = new WebSiteApp();
                    List<WebSiteEntity> webSiteEntitys = webSiteApp.GetListForUserId();
                    if (webSiteEntitys != null && webSiteEntitys.Count > 0)
                    {
                        if (webSiteEntitys.Count == 1)
                        {
                            bState = true;
                            webSiteId = webSiteEntitys[0].Id;
                        }
                        else
                        {
                            WebSiteEntity webSiteEntity = webSiteEntitys.Find(m => m.MainMark == true);
                            if (webSiteEntity != null)
                            {
                                bState = true;
                                webSiteId = webSiteEntity.Id;
                            }
                        }
                    }
                }
            }
            return bState;
        }
    }
}
