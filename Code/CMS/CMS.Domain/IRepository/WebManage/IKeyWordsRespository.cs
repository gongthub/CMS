using CMS.Data;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface IKeyWordsRespository : IRepositoryBase<KeyWordsEntity>
    {
        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        bool IsHasKeyWords(string webSiteId, string strs);

        /// <summary>
        /// 判断是否存在非法关键字
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="strs"></param>
        /// <returns></returns>
        bool IsHasKeyWords(string webSiteId, string strs, out string keyWords);
    }
}
