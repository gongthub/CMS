using CMS.Data;
using CMS.Domain.Entity.SystemManage;

namespace CMS.Domain.IRepository
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        void DeleteForm(string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue);
        void SubmitForm(UserEntity userEntity, UserLogOnEntity userLogOnEntity, string keyValue, string[] webSiteIds);

        /// <summary>
        /// 获取当前用户可最大添加网站数
        /// </summary>
        /// <returns></returns>
        int GetUserWebSiteMaxNum();

        /// <summary>
        /// 判断是否为系统管理员用户
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        bool IsSystemUserName(string name);
        /// <summary>
        /// 判断是用户是否有该站点权限
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        void VerifyUserWebsiteRole(string userId, string webSiteId);
        void VerifyUserWebsiteRole(string webSiteId);
    }
}
