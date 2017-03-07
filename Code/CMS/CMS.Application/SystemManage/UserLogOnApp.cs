using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;

namespace CMS.Application.SystemManage
{
    public class UserLogOnApp
    {
        private IUserLogOnRepository service = new UserLogOnRepository();

        public UserLogOnEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void UpdateForm(UserLogOnEntity userLogOnEntity)
        {
            service.Update(userLogOnEntity);
        }
        public void RevisePassword(string userPassword,string keyValue)
        {
            UserLogOnEntity userLogOnEntity = new UserLogOnEntity();
            userLogOnEntity.Id = keyValue;
            userLogOnEntity.UserSecretkey = Md5.md5(Common.CreateNo(), 16).ToLower();
            userLogOnEntity.UserPassword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), userLogOnEntity.UserSecretkey).ToLower(), 32).ToLower();
            service.Update(userLogOnEntity);
        }
    }
}
