using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Domain.IRepository.SystemSecurity;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.SystemManage;
using CMS.Repository.SystemSecurity;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private IUserWebSiteRepository iUserWebSiteRepository = new UserWebSiteRepository();

        private ILogRepository iLogRepository = new LogRepository();

        private static readonly string SYSTEMADMINUSERNAME = Code.Configs.GetValue("SystemUserName");
        private static readonly string SYSTEMADMINUSERPASSWORD = Code.Configs.GetValue("SystemUserPassword");
        public void DeleteForm(string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                db.Delete<UserEntity>(t => t.Id == keyValue);
                db.Delete<UserLogOnEntity>(t => t.UserId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    db.Update(userEntity);
                }
                else
                {
                    userLogOnEntity.Id = userEntity.Id;
                    userLogOnEntity.UserId = userEntity.Id;
                    userLogOnEntity.UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                    userLogOnEntity.UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.UserPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                    db.Insert(userEntity);
                    db.Insert(userLogOnEntity);

                }
                db.Commit();
            }
        }


        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue, string[] webSiteIds)
        {
            userEntity.Account = userEntity.Account.Trim();
            if (!IsExist(keyValue, "Account", userEntity.Account) && !IsSystemUserName(userEntity.Account))
            {
                iUserWebSiteRepository.DeleteById(m => m.UserId == keyValue);
                using (var db = new RepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        userEntity.Modify(keyValue);
                        db.Update(userEntity);

                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改用户信息=>" + userEntity.Account, Enums.DbLogType.Update, "用户管理");
                    }
                    else
                    {
                        userEntity.Create();
                        userLogOnEntity.Id = userEntity.Id;
                        userLogOnEntity.UserId = userEntity.Id;
                        userLogOnEntity.UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
                        userLogOnEntity.UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.UserPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
                        db.Insert(userEntity);
                        db.Insert(userLogOnEntity);

                        //添加日志
                        iLogRepository.WriteDbLog(true, "添加用户信息=>" + userEntity.Account, Enums.DbLogType.Create, "用户管理");
                    }

                    //添加用户站点信息
                    AddUserWebSites(userEntity, webSiteIds, db);
                    db.Commit();
                }
            }
            else
            {
                throw new Exception("用户名已存在，请重新输入！");
            }
        }
        /// <summary>
        /// 添加用户站点信息
        /// </summary>
        /// <param name="userEntity"></param>
        /// <param name="webSiteIds"></param>
        /// <param name="db"></param>
        private static void AddUserWebSites(UserEntity userEntity, string[] webSiteIds, IRepositoryBase db)
        {
            if (webSiteIds != null && webSiteIds.Length > 0)
            {
                List<UserWebSiteEntity> entitys = new List<UserWebSiteEntity>();
                foreach (var webSiteId in webSiteIds)
                {
                    if (!string.IsNullOrEmpty(webSiteId))
                    {
                        UserWebSiteEntity entity = new UserWebSiteEntity();
                        entity.Create();
                        entity.UserId = userEntity.Id; ;
                        entity.WebSiteId = webSiteId;
                        entity.EnabledMark = true;
                        db.Insert(entity);
                    }
                }
            }
        }

        /// <summary>
        /// 获取当前用户可最大添加网站数
        /// </summary>
        /// <returns></returns>
        public int GetUserWebSiteMaxNum()
        {
            int iWebSiteNum = 0;

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.SystemUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_SYSTEMUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_WEBSITEUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_REGISTERUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_ORDINARYUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_GOLDUSER, out iWebSiteNum);
                }
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                {
                    int.TryParse(Code.ConfigHelp.configHelp.WEBSITENUM_DIAMONDUSER, out iWebSiteNum);
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


    }
}
