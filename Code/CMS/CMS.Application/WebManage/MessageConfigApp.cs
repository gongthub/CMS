using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class MessageConfigApp
    {
        private IMessageConfigRepository service = new MessageConfigRepository();

        public string GetFormJsonStr(string webSiteId)
        {
            StringBuilder JsonStr = new StringBuilder();
            List<MessageConfigEntity> models = GetForms(webSiteId);
            if (models != null && models.Count > 0)
            {
                JsonStr.Append("{");
                for (int j = 0; j < models.Count; j++)
                {
                    string ckIsEnableMark = "ckIsEnable_";
                    string ckIsShowListMark = "ckIsShowList_";
                    string ckIsShowViewMark = "ckIsShowView_";
                    ckIsEnableMark += models[j].ColumnName;
                    ckIsShowListMark += models[j].ColumnName;
                    ckIsShowViewMark += models[j].ColumnName;
                    JsonStr.Append("'" + models[j].ColumnName + "':'" + models[j].ColumnShowName +
                        "','" + ckIsEnableMark + "':'" + models[j].EnabledMark.ToString().ToLower() +
                        "','" + ckIsShowListMark + "':'" + models[j].ListShowMark.ToString().ToLower() +
                        "','" + ckIsShowViewMark + "':'" + models[j].ViewShowMark.ToString().ToLower() + "'");
                    if (j < models.Count - 1)
                    {
                        JsonStr.Append(",");
                    }
                }
                JsonStr.Append("}");
            }

            return JsonStr.ToString();
        }
        public string GetListTitleJsonStr(string webSiteId)
        {
            StringBuilder JsonStr = new StringBuilder();
            List<MessageConfigEntity> models = GetFormsListShow(webSiteId);
            if (models != null && models.Count > 0)
            {
                JsonStr.Append("[");

                JsonStr.Append("{ label: '主键', name: 'Id', hidden: true, key: true },");
                foreach (MessageConfigEntity model in models)
                {
                    JsonStr.Append("{ label: '" + model.ColumnShowName + "', name: '" + model.ColumnName + "', width: 200, align: 'left' },");
                }
                JsonStr.Append("{ label: '时间', name: 'CreatorTime', width: 200, align: 'left' }");
                JsonStr.Append("]");
            }

            return JsonStr.ToString();
        }


        public List<MessageConfigEntity> GetViewShow(string webSiteId, string keyValue)
        {
            List<MessageConfigEntity> models = GetFormsViewShow(webSiteId);
            MessagesEntity messageEntity = new MessagesApp().GetFormNoDel(keyValue);
            if (messageEntity != null && !string.IsNullOrEmpty(messageEntity.Id))
            {
                if (models != null && models.Count > 0)
                {
                    PropertyInfo[] infos = messageEntity.GetType().GetProperties();
                    if (infos != null && infos.Count() > 0)
                    {
                        foreach (MessageConfigEntity model in models)
                        {
                            PropertyInfo info = infos.FirstOrDefault(m => m.Name == model.ColumnName);
                            if (info != null)
                            {
                                object val = messageEntity.GetType().GetProperty(info.Name).GetValue(messageEntity, null);
                                if (val != null)
                                    model.MessageValue = val.ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("选择数据不存在！");
            }

            return models;
        }

        public List<MessageConfigEntity> GetForms(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).OrderBy(m => m.CreatorTime).ToList();
        }
        public List<MessageConfigEntity> GetFormsListShow(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true && m.EnabledMark == true && m.ListShowMark == true).OrderBy(m => m.CreatorTime).ToList();
        }
        public List<MessageConfigEntity> GetFormsViewShow(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true && m.EnabledMark == true && m.ViewShowMark == true).OrderBy(m => m.CreatorTime).ToList();
        }

        public void DeleteForm(string webSiteId)
        {
            service.Delete(t => t.WebSiteId == webSiteId);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除站点留言配置信息=>" + webSiteId, Enums.DbLogType.Delete, "站点留言配置管理");
        }
        public void AddForm(MessageConfigEntity moduleEntity)
        {
            moduleEntity.Create();
            service.Insert(moduleEntity);
        }
        public void AddForm(MessageConfigEntity moduleEntity, bool IsDel)
        {
            if (IsDel)
                DeleteForm(moduleEntity.WebSiteId);

            moduleEntity.Create();
            service.Insert(moduleEntity);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "添加站点留言配置信息=>" + moduleEntity.WebSiteId, Enums.DbLogType.Create, "站点留言配置管理");
        }
        public void AddForms(List<MessageConfigEntity> moduleEntitys)
        {
            if (moduleEntitys != null && moduleEntitys.Count > 0)
            {
                foreach (MessageConfigEntity moduleEntity in moduleEntitys)
                {
                    AddForm(moduleEntity);
                }
            }
        }
        public void AddForms(List<MessageConfigEntity> moduleEntitys, bool IsDel)
        {
            if (moduleEntitys != null && moduleEntitys.Count > 0)
            {
                if (IsDel)
                    DeleteForm(moduleEntitys.FirstOrDefault().WebSiteId);
                foreach (MessageConfigEntity moduleEntity in moduleEntitys)
                {
                    AddForm(moduleEntity);
                }
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加站点留言配置信息=>" + moduleEntitys.FirstOrDefault().WebSiteId, Enums.DbLogType.Create, "站点留言配置管理");
            }
        }
    }
}
