using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SqlServerRepository
{
    public class TempletRepository : SqlServerRepositoryBase<TempletEntity>, ITempletRepository
    {
        private ILogRepository iLogRepository = new LogRepository();
        private IUserRepository iUserRepository = new UserRepository();
        public bool IsExistSearchModel(string WebSiteId)
        {
            bool bState = false;
            TempletEntity model = GetSearchModel(WebSiteId);
            if (model != null && !string.IsNullOrEmpty(model.Id))
            {
                bState = true;
            }
            return bState;
        }
        public bool IsExistMSearchModel(string WebSiteId)
        {
            bool bState = false;
            TempletEntity model = GetMSearchModel(WebSiteId);
            if (model != null && !string.IsNullOrEmpty(model.Id))
            {
                bState = true;
            }
            return bState;
        }
        /// <summary>
        /// 获取全站搜索模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetSearchModel(string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(webSiteId))
            {
                expression = expression.And(t => t.WebSiteId == webSiteId 
                && t.DeleteMark != true 
                && t.EnabledMark == true 
                && t.TempletType == (int)Enums.TempletType.Search);
            }
            templet = FindEntity(expression);
            return templet;
        }
        /// <summary>
        /// 获取移动端全站搜索模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetMSearchModel(string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(webSiteId))
            {
                expression = expression.And(t => t.WebSiteId == webSiteId 
                && t.DeleteMark != true 
                && t.EnabledMark == true 
                && t.TempletType == (int)Enums.TempletType.MSearch);
            }
            templet = FindEntity(expression);
            return templet;
        }

        public void SubmitForm(TempletEntity moduleEntity, string keyValue)
        {
            if (moduleEntity.FullName.ToLower() != ConfigHelp.configHelp.WEBSITESEARCHPATH.ToLower())
            {
                if (!IsExist(keyValue, "FullName", moduleEntity.FullName, moduleEntity.WebSiteId, true))
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        TempletEntity moduleEntityT = FindEntity(keyValue);
                        if (moduleEntityT != null)
                        {
                            //验证用户站点权限
                            iUserRepository.VerifyUserWebsiteRole(moduleEntityT.WebSiteId);
                            moduleEntity.WebSiteId = moduleEntityT.WebSiteId;
                        }
                        moduleEntity.Modify(keyValue);
                        Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "模板管理");
                    }
                    else
                    {
                        moduleEntity.Create();
                        Insert(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "添加模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "模板管理");
                    }
                }
                else
                {
                    throw new Exception("名称已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("名称不能为系统保留名称，请重新输入！");
            }
        }
    }
}
