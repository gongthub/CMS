using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class ColumnsApp
    {
        private IColumnsRepository service = DataAccess.CreateIColumnsRepository();
        private IUserRepository iUserRepository = DataAccess.CreateIUserRepository();

        public ColumnsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public ColumnsEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public ColumnsEntity GetFormByActionName(string actionName)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true).FirstOrDefault();
        }
        public ColumnsEntity GetFormByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable(m => m.ActionName.ToLower() == actionName.ToLower() && m.DeleteMark != true && m.EnabledMark == true && m.WebSiteId == webSiteId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetMain()
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetMain(string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.MainMark == true && m.EnabledMark == true && m.WebSiteId == webSiteId).FirstOrDefault();
        }

        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName).FirstOrDefault();
        }
        /// <summary>
        /// 获取主页模块数据
        /// </summary>
        /// <returns></returns> 
        public ColumnsEntity GetModelByActionName(string actionName, string webSiteId)
        {
            return service.IQueryable().Where(m => m.DeleteMark != true && m.EnabledMark == true && m.ActionName == actionName && m.WebSiteId == webSiteId).FirstOrDefault();
        }
        public List<ColumnsEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetList(Expression<Func<ColumnsEntity, bool>> predicate)
        {
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListNoDel()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListNoDel(Expression<Func<ColumnsEntity, bool>> predicate)
        {
            predicate.And(m => m.DeleteMark != true);
            return service.IQueryable(predicate).OrderBy(t => t.SortCode).ToList();
        }
        public List<ColumnsEntity> GetListByWebSiteId(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public void DeleteForm(string keyValue)
        {
            ColumnsEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }

            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除栏目信息=>" + keyValue, Enums.DbLogType.Delete, "栏目管理");
        }
        public void SubmitForm(ColumnsEntity moduleEntity, string keyValue)
        {
            service.SubmitForm(moduleEntity, keyValue);
        }

    }
}
