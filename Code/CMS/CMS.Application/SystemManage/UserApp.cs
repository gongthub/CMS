using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;

namespace CMS.Application.SystemManage
{
    public class UserApp
    {
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
            expression = expression.And(t => t.Account != "admin");
            expression = expression.And(t => t.DeleteMark != true);
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
            if (!IsExistAccountName(keyValue, userEntity.Account))
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
        /// 判断用户名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistAccountName(string keyId, string name)
        {
            name = name.Trim();
            bool retBool = false;
            int flay = 0;   //标示位 判断是否需要查询
            if (!string.IsNullOrEmpty(keyId))
            {
                Guid id = Guid.Empty;
                UserEntity userEntity = service.FindEntity(m => m.Id == keyId);
                if (userEntity != null && Guid.TryParse(userEntity.Id, out id))
                {
                    if (userEntity.Account != name)
                    {
                        flay = 1;
                    }
                }
            }
            else
            {
                flay = 1;
            }
            //需要判断
            if (flay == 1)
            {
                Guid id = Guid.Empty;
                UserEntity userEntity = service.FindEntity(m => m.Account == name && m.DeleteMark != true);
                if (userEntity != null && Guid.TryParse(userEntity.Id, out id))
                {
                    retBool = true;
                }
            }

            return retBool;
        }
    }
}
