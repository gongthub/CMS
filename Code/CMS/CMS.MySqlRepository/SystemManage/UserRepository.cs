﻿using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CMS.MySqlRepository
{
    public class UserRepository : MySqlRepositoryBase<UserEntity>, IUserRepository
    {
        private IUserWebSiteRepository iUserWebSiteRepository = new UserWebSiteRepository();

        private ILogRepository iLogRepository = new LogRepository();

        private readonly string SYSTEMADMINUSERNAME = Code.ConfigHelp.configHelp.SYSTEMADMINUSERNAME;
        private readonly string SYSTEMADMINUSERPASSWORD = Code.ConfigHelp.configHelp.SYSTEMADMINUSERPASSWORD;
        public void DeleteForm(string keyValue)
        {
            using (var db = new MySqlRepositoryBase().BeginTrans())
            {
                db.Delete<UserEntity>(t => t.Id == keyValue);
                db.Delete<UserLogOnEntity>(t => t.UserId == keyValue);
                db.Commit();
            }
        }
        public void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue)
        {
            using (var db = new MySqlRepositoryBase().BeginTrans())
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
                using (var db = new MySqlRepositoryBase().BeginTrans())
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

        /// <summary>
        /// 判断是用户是否有该站点权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public void VerifyUserWebsiteRole(string userId, string webSiteId)
        {
            bool bStatus = false;

            UserEntity useEntity = FindEntity(userId);
            if (useEntity != null && !string.IsNullOrEmpty(useEntity.Id))
            {
                if (IsSystemUserName(useEntity.Account))
                {
                    bStatus = true;
                }
                else
                {
                    List<string> userWebSiteIds = iUserWebSiteRepository.IQueryable(m => m.DeleteMark != true
                        && m.UserId == userId).Select(m => m.WebSiteId).ToList();
                    if (userWebSiteIds != null && userWebSiteIds.Count > 0)
                    {
                        bStatus = userWebSiteIds.Contains(webSiteId);
                    }
                }
            }
            if (!bStatus)
            {
                throw new Exception("当前用户无该站点操作权限！");
            }
        }
        /// <summary>
        /// 判断是用户是否有该站点权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public void VerifyUserWebsiteRole(string webSiteId)
        {
            var operatorModel = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (operatorModel != null && !operatorModel.IsSystem)
            {
                VerifyUserWebsiteRole(operatorModel.UserId, webSiteId);
            }
        }
    }
}
