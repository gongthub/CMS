using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class AdvancedContentConfigApp
    {
        private IAdvancedContentConfigRepository service = new AdvancedContentConfigRepository();

        public string GetFormJsonStr(string webSiteId)
        {
            StringBuilder JsonStr = new StringBuilder();
            List<AdvancedContentConfigEntity> models = GetForms(webSiteId);
            if (models != null && models.Count > 0)
            {
                JsonStr.Append("{");
                for (int j = 0; j < models.Count; j++)
                {
                    string ckIsEnableMark = "ckIsEnable_";
                    ckIsEnableMark += models[j].ColumnName;
                    JsonStr.Append("'" + models[j].ColumnName + "':'" + models[j].ColumnShowName +
                        "','" + ckIsEnableMark + "':'" + models[j].EnabledMark.ToString().ToLower() +
                        "'");
                    if (j < models.Count - 1)
                    {
                        JsonStr.Append(",");
                    }
                }
                JsonStr.Append("}");
            }

            return JsonStr.ToString();
        }
        public List<AdvancedContentConfigEntity> GetForms(string webSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == webSiteId && m.DeleteMark != true && m.EnabledMark == true).OrderBy(m => m.CreatorTime).ToList();
        }
        public int GetCount(string webSiteId)
        {
            List<AdvancedContentConfigEntity> models = GetForms(webSiteId);
            return models.Count;
        }

        public void DeleteForm(string webSiteId)
        {
            service.Delete(t => t.WebSiteId == webSiteId);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除站点高级列表配置信息=>" + webSiteId, Enums.DbLogType.Delete, "站点高级列表配置管理");
        }
        public void AddForm(AdvancedContentConfigEntity moduleEntity)
        {
            moduleEntity.Create();
            service.Insert(moduleEntity);
        }
        public void AddForm(AdvancedContentConfigEntity moduleEntity, bool IsDel)
        {
            if (IsDel)
                DeleteForm(moduleEntity.WebSiteId);

            moduleEntity.Create();
            service.Insert(moduleEntity);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "添加站点高级列表配置信息=>" + moduleEntity.WebSiteId, Enums.DbLogType.Create, "站点高级列表配置管理");
        }
        public void AddForms(List<AdvancedContentConfigEntity> moduleEntitys)
        {
            if (moduleEntitys != null && moduleEntitys.Count > 0)
            {
                foreach (AdvancedContentConfigEntity moduleEntity in moduleEntitys)
                {
                    AddForm(moduleEntity);
                }
            }
        }
        public void AddForms(List<AdvancedContentConfigEntity> moduleEntitys, bool IsDel)
        {
            if (moduleEntitys != null && moduleEntitys.Count > 0)
            {
                if (IsDel)
                    DeleteForm(moduleEntitys.FirstOrDefault().WebSiteId);
                foreach (AdvancedContentConfigEntity moduleEntity in moduleEntitys)
                {
                    AddForm(moduleEntity);
                }
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加站点高级列表配置信息=>" + moduleEntitys.FirstOrDefault().WebSiteId, Enums.DbLogType.Create, "站点高级列表配置管理");
            }
        }


    }
}
