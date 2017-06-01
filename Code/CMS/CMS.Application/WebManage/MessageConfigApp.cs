using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public List<MessageConfigEntity> GetForms(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true).ToList();
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
