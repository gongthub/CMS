using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;

namespace CMS.Application.SystemManage
{
    public class UserApp
    {
        private static readonly string SYSTEMADMINUSERNAME = Code.Configs.GetValue("SystemUserName");
        private static readonly string SYSTEMADMINUSERPASSWORD = Code.Configs.GetValue("SystemUserPassword");
        private IUserRepository service = DataAccess.CreateIUserRepository();
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

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
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
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除用户信息=>" + keyValue, Enums.DbLogType.Delete, "用户管理");
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue, string[] webSiteIds)
        {
            service.SubmitForm(userEntity, userLogOnEntity, keyValue, webSiteIds);
        }
        public void UpdateForm(UserEntity userEntity)
        {
            service.Update(userEntity);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "修改用户信息=>" + userEntity.Account, Enums.DbLogType.Update, "用户管理");
        }
        public UserEntity CheckLogin(string username, string password)
        {
            UserEntity userEntity = service.FindEntity(t => t.Account == username && t.DeleteMark != true);
            if (username == SYSTEMADMINUSERNAME && password == SYSTEMADMINUSERPASSWORD)
            {
                userEntity = service.FindEntity(t => t.DeleteMark != true && t.EnabledMark == true);
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
            int iWebSiteNum = service.GetUserWebSiteMaxNum();
            return iWebSiteNum;
        }

    }
}
