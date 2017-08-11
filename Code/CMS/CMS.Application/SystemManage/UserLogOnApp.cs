using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;

namespace CMS.Application.SystemManage
{
    public class UserLogOnApp
    {
        private IUserLogOnRepository service = DataAccess.CreateIUserLogOnRepository();

        public UserLogOnEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void InsertForm(UserLogOnEntity userLogOnEntity, string userIds)
        {
            userLogOnEntity.Id = userIds;
            userLogOnEntity.UserId = userIds;
            userLogOnEntity.UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userLogOnEntity.UserPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            service.Insert(userLogOnEntity);
        }
        public void UpdateForm(UserLogOnEntity userLogOnEntity)
        {
            service.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword, string keyValue)
        {
            UserLogOnEntity userLogOnEntity = new UserLogOnEntity();
            userLogOnEntity.Id = keyValue;
            userLogOnEntity.UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnEntity);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "重置用户密码=>" + userLogOnEntity.UserId, Enums.DbLogType.Update, "用户管理");
        }
    }
}
