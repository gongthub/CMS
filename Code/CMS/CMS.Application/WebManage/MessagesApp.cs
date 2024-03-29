﻿using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class MessagesApp
    {
        private IMessagesRepository service = DataAccess.CreateIMessagesRepository();
        private IUserRepository iUserRepository = DataAccess.CreateIUserRepository();


        public MessagesEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public MessagesEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }

        public List<MessagesEntity> GetList()
        {
            return service.IQueryable().OrderByDescending(t => t.CreatorTime).ToList();
        }
        public List<MessagesEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<MessagesEntity>();
            expression = expression.And(m => m.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.UserName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<MessagesEntity> GetListByWebSiteId(string WebSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).OrderByDescending(t => t.CreatorTime).ToList();

        }
        public List<MessagesEntity> GetListByWebSiteId(Pagination pagination, string keyword, string WebSiteId)
        {
            var expression = ExtLinq.True<MessagesEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.UserName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        public List<MessagesEntity> GetListByWebSiteIdNoEnable(string WebSiteId)
        {
            var expression = ExtLinq.True<MessagesEntity>();
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true && t.EnabledMark == true);
            return service.IQueryable(expression).ToList();
        }
        public int GetCountByWebSiteId(string WebSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).Count();

        }
        public void AddForm(MessagesEntity moduleEntity)
        {
            if (!new WebSiteApp().IsMessage(moduleEntity.WebSiteId))
            {
                throw new Exception("本网站留言功能未开启！");
            }
            VerityTime(moduleEntity);
            moduleEntity.EnabledMark = true;
            moduleEntity.Create();
            service.Insert(moduleEntity);
        }

        public void SubmitForm(MessagesEntity moduleEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleEntity.Modify(keyValue);
                service.Update(moduleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改留言信息=>" + moduleEntity.UserName, Enums.DbLogType.Update, "留言管理");
            }
            else
            {
                moduleEntity.EnabledMark = true;
                moduleEntity.Create();
                service.Insert(moduleEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加留言信息=>" + moduleEntity.UserName, Enums.DbLogType.Create, "留言管理");
            }
        }
        public void DeleteForm(string keyValue)
        {
            MessagesEntity moduleEntity = service.FindEntity(keyValue);
            if (moduleEntity != null)
            {
                //验证用户站点权限
                iUserRepository.VerifyUserWebsiteRole(moduleEntity.WebSiteId);
            }
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除留言信息=>" + keyValue, Enums.DbLogType.Delete, "留言管理");
        }

        /// <summary>
        /// 验证留言间隔时间
        /// </summary>
        /// <param name="moduleEntity"></param>
        public void VerityTime(MessagesEntity moduleEntity)
        {
            MessagesEntity model = service.IQueryable(m => m.SessionId == moduleEntity.SessionId).OrderByDescending(m => m.CreatorTime).FirstOrDefault();
            if (model != null && !string.IsNullOrEmpty(model.Id) && model.CreatorTime!=null)
            {
                int timtNum = ConfigHelp.configHelp.MESSAGETIME;
                DateTime NowTime = DateTime.Now;
                TimeSpan tNow = new System.TimeSpan(NowTime.Ticks);

                TimeSpan tCreateTime = new System.TimeSpan(Convert.ToDateTime(model.CreatorTime).Ticks);
                 
                TimeSpan tsSub = tNow.Subtract(tCreateTime).Duration();
                if (tsSub.TotalSeconds < timtNum)
                {
                    throw new Exception("请稍等一会再提交！");
                }
            }
        }
    }
}
