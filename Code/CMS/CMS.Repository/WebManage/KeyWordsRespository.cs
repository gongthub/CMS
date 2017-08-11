using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.WebManage
{
    public class KeyWordsRespository : SqlServerRepositoryBase<KeyWordsEntity>, IKeyWordsRespository
    {
        public List<KeyWordsEntity> GetListByWebSiteIdNoEnable(string WebSiteId)
        {
            var expression = ExtLinq.True<KeyWordsEntity>();
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            expression = expression.And(t => t.DeleteMark != true && t.EnabledMark == true);
            return IQueryable(expression).ToList();
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
        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public bool IsHasKeyWords(string webSiteId, string strs)
        {
            bool bState = false;
            List<string> lsKeyWords = GetWordByWebSiteIdNoEnable(webSiteId);
            if (lsKeyWords != null && lsKeyWords.Count > 0)
            {
                List<string> lsWords = Code.PanGu.PanGuHelp.panGuHelp.GenWords(strs);
                if (lsWords != null && lsWords.Count > 0)
                {
                    foreach (string item in lsKeyWords)
                    {
                        if (lsWords.Contains(item))
                        {
                            bState = true;
                            break;
                        }
                    }
                }
            }

            return bState;
        }

        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        public bool IsHasKeyWords(string webSiteId, string strs, out string keyWords)
        {
            bool bState = false;
            keyWords = string.Empty;
            List<string> lsKeyWords = GetWordByWebSiteIdNoEnable(webSiteId);
            if (lsKeyWords != null && lsKeyWords.Count > 0)
            {
                List<string> lsWords = Code.PanGu.PanGuHelp.panGuHelp.GenWords(strs);
                if (lsWords != null && lsWords.Count > 0)
                {
                    foreach (string item in lsKeyWords)
                    {
                        if (lsWords.Contains(item))
                        {
                            bState = true;
                            keyWords = item;
                            break;
                        }
                    }
                }
            }

            return bState;
        }
    }
}
