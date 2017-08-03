using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.SystemManage;
using CMS.Repository.WebManage;
using System.Collections.Generic;

namespace CMS.Repository.SystemManage
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        private IWebSiteRepository iWebSiteRepository = new WebSiteRepository();
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
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        public bool IsExistDefaultWebSite(ref string webSiteId)
        {
            bool bState = false;
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    List<WebSiteEntity> webSiteEntitys = iWebSiteRepository.GetListForUserId();
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
