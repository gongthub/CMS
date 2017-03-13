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
    public class WebSiteApp
    {
        private IWebSiteRepository service = new WebSiteRepository();

        public List<WebSiteEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }

        public WebSiteEntity GetFormByName(string Name)
        {
            WebSiteEntity model = new WebSiteEntity();
            model = service.FindEntity(m => m.FullName == Name && m.DeleteMark != true);
            return model;
        }
        public WebSiteEntity GetFormByUrl(string url)
        {
            WebSiteEntity model = new WebSiteEntity();
            model = service.FindEntity(m => m.UrlAddress == url && m.DeleteMark != true);
            return model;
        }
        public List<WebSiteEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public WebSiteEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.Id == keyValue);
        }
        public void SubmitForm(WebSiteEntity moduleEntity, string keyValue)
        {
            if (!IsExistUrl(keyValue, moduleEntity.UrlAddress))
            {
                if (!string.IsNullOrEmpty(keyValue))
                {
                    moduleEntity.Modify(keyValue);
                    service.Update(moduleEntity);
                }
                else
                {
                    moduleEntity.Create();
                    service.Insert(moduleEntity);
                }
            }
            else
            {
                throw new Exception("域名已存在，请重新输入！");
            }
        }

        /// <summary>
        /// 判断域名是否存在
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExistUrl(string keyId, string url)
        {
            url = url.Trim();
            bool retBool = false;
            int flay = 0;   //标示位 判断是否需要查询
            if (!string.IsNullOrEmpty(keyId))
            {
                Guid id = Guid.Empty;
                WebSiteEntity moduleEntity = service.FindEntity(m => m.Id == keyId);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    if (moduleEntity.UrlAddress != url)
                    {
                        flay = 1;
                    }
                }
            }
            else
            {
                flay = 1;
            }
            //需要判断
            if (flay == 1)
            {
                Guid id = Guid.Empty;
                WebSiteEntity moduleEntity = service.FindEntity(m => m.UrlAddress == url && m.DeleteMark != true);
                if (moduleEntity != null && Guid.TryParse(moduleEntity.Id, out id))
                {
                    retBool = true;
                }
            }

            return retBool;
        }
    }
}
