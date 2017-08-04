using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class KeyWordsApp
    {
        private IKeyWordsRespository service = new KeyWordsRespository();

        public KeyWordsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public KeyWordsEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }

        public List<KeyWordsEntity> GetList()
        {
            return service.IQueryable().OrderByDescending(t => t.CreatorTime).ToList();
        }
        public List<KeyWordsEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<KeyWordsEntity>();
            expression = expression.And(m => m.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<KeyWordsEntity> GetListByWebSiteId(string WebSiteId)
        {
            return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).OrderByDescending(t => t.CreatorTime).ToList();

        }
        public List<KeyWordsEntity> GetListByWebSiteId(string WebSiteId, Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<KeyWordsEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        public List<KeyWordsEntity> GetListByWebSiteIdNoEnable(string WebSiteId)
        {
            var expression = ExtLinq.True<KeyWordsEntity>();
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true && t.EnabledMark == true);
            return service.IQueryable(expression).ToList();
        }
        public List<string> GetWordByWebSiteIdNoEnable(string WebSiteId)
        {
            List<string> lsWords = new List<string>();
            List<KeyWordsEntity> models = GetListByWebSiteIdNoEnable(WebSiteId);
            if (models != null && models.Count > 0)
            {
                models.ForEach(delegate(KeyWordsEntity model)
                {
                    lsWords.Add(model.FullName);
                });
            }
            return lsWords;
        }

        public void SubmitForm(KeyWordsEntity moduleEntity, string keyValue)
        {
            if (!service.IsExist(keyValue, "FullName", moduleEntity.FullName, moduleEntity.WebSiteId, true))
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    moduleEntity.Modify(keyValue);
                    service.Update(moduleEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "修改关键词信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "关键词管理");
                }
                else
                {
                    moduleEntity.Create();
                    service.Insert(moduleEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "添加关键词信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "关键词管理");
                }
            }
            else
            {
                throw new Exception("名称已存在，请重新输入！");
            }
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除关键词信息=>" + keyValue, Enums.DbLogType.Delete, "关键词管理");
        }

        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public bool IsHasKeyWords(string webSiteId, string strs)
        {
            return service.IsHasKeyWords(webSiteId, strs);
        }

        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public bool IsHasKeyWords(string webSiteId, string strs, out string keyWords)
        {
            return service.IsHasKeyWords(webSiteId, strs, out keyWords);
        }
    }
}
