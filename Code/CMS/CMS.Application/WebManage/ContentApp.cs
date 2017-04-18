using CMS.Application.Comm;
using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
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
    public class ContentApp
    {
        private IContentRepository service = new ContentRepository();

        public List<ContentEntity> GetList(string itemId = "", string keyword = "")
        {
            List<ContentEntity> models = new List<ContentEntity>();
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ColumnId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
            models.ForEach(delegate(ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }

        public IQueryable<ContentEntity> GetListIq(string itemId = "", string keyword = "")
        {
            IQueryable<ContentEntity> models;
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ColumnId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.IQueryable(expression).OrderBy(t => t.SortCode);

            return models;
        }

        public List<ContentEntity> GetList()
        {
            List<ContentEntity> models = new List<ContentEntity>();
            models = service.IQueryable(t => t.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
            models.ForEach(delegate(ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }

        public List<ContentEntity> GetList(Pagination pagination, string keyword)
        {
            List<ContentEntity> models = new List<ContentEntity>();
            var expression = ExtLinq.True<ContentEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(m => m.DeleteMark != true);
            models = service.FindList(expression, pagination);
            models.ForEach(delegate(ContentEntity model)
            {

                if (model != null && model.UrlAddress != null)
                {
                    model.UrlPage = model.UrlAddress;
                    model.UrlPage = model.UrlPage.Replace(@"\", "/");
                }

            });
            return models;
        }
        public ContentEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.Delete(t => t.Id == keyValue);
        }
        public void DeleteFormById(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue)
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

                string mIds = moduleEntity.ColumnId;
                ColumnsApp c_ModulesApp = new ColumnsApp();
                ColumnsEntity cmModel = c_ModulesApp.GetForm(mIds);
                if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                {
                    string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                    moduleEntity.UrlAddress = urlAddress;
                    SubmitForm(moduleEntity, moduleEntity.Id);
                }
            }
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys)
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
                keyValue = moduleEntity.Id;

                string mIds = moduleEntity.ColumnId;
                ColumnsApp c_ModulesApp = new ColumnsApp();
                ColumnsEntity cmModel = c_ModulesApp.GetForm(mIds);
                if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                {
                    string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                    moduleEntity.UrlAddress = urlAddress;
                    SubmitForm(moduleEntity, moduleEntity.Id);
                }
            }
            if (upFileentitys != null && upFileentitys.Count > 0)
            {
                foreach (UpFileDTO upFileentity in upFileentitys)
                {
                    //更新上传文件表
                    UpFileApp upFileApp = new UpFileApp();

                    upFileentity.Sys_WebSiteId = moduleEntity.WebSiteId;
                    upFileentity.Sys_ParentId = keyValue;
                    upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.Contents);
                    upFileApp.AddUpFileEntity(upFileentity);
                }
            }
        }


        public ColumnsEntity GetModuleByContentID(string keyValue)
        {
            ColumnsEntity moduleEntity = new ColumnsEntity();
            ContentEntity contentEntity = GetForm(keyValue);
            ColumnsApp c_ModulesApp = new ColumnsApp();
            if (JudgmentHelp.judgmentHelp.IsNullEntity<ContentEntity>(contentEntity) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(contentEntity.ColumnId))
            {
                moduleEntity = c_ModulesApp.GetForm(contentEntity.ColumnId);
            }
            return moduleEntity;
        }

        /// <summary>
        /// 根据模块名称获取一个内容
        /// </summary>
        /// <param name="actionCode"></param>
        /// <returns></returns>
        public ContentEntity GetContentByActionCode(string actionCode)
        {
            ColumnsEntity moduleEntity = new ColumnsEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ContentEntity contentEntity = new ContentEntity();
            moduleEntity = c_ModulesApp.GetFormByActionName(actionCode);
            if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(moduleEntity) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(moduleEntity.Id))
            {
                contentEntity = service.IQueryable(m => m.ColumnId == moduleEntity.Id).FirstOrDefault();

            }
            return contentEntity;
        }

        public void GetStaticPage(string keyValue)
        {
            ColumnsEntity module = GetModuleByContentID(keyValue);
            //ContentEntity content = GetForm(keyValue);
            if (module != null)
            {
                TempletApp templetapp = new TempletApp();
                TempletEntity templet = templetapp.GetForm(module.CTempletId);
                if (templet != null)
                {
                    string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);

                    TempHelp.tempHelp.GenHtmlPage(templets, keyValue);
                }
            }
        }

        /// <summary>
        /// 获取静态HTML
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public string GetStaticHtmls(string keyValue)
        {
            string htmls = "";
            ColumnsEntity module = GetModuleByContentID(keyValue);
            //ContentEntity content = GetForm(keyValue);
            if (module != null)
            {
                TempletApp templetapp = new TempletApp();
                TempletEntity templet = templetapp.GetForm(module.CTempletId);
                if (templet != null)
                {
                    string templets = System.Web.HttpUtility.HtmlDecode(templet.Content);

                    TempHelp.tempHelp.GenHtmlPage(templets, keyValue);
                    htmls = TempHelp.tempHelp.GetHtmlPages(templets, keyValue);
                }
            }

            return htmls;
        }

        /// <summary>
        /// 根据站点ID和虚拟路径获取html
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool GetHtmlStrs(string webSiteId, string url, out string htmls)
        {
            bool isHave = false;
            htmls = string.Empty;
            ContentEntity contentEntity = service.IQueryable(m => m.WebSiteId == webSiteId && (m.UrlAddress == url || m.UrlAddress == url.Replace(@"/",@"\"))).FirstOrDefault();
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id))
            {
                string urlPath = contentEntity.UrlPath;

                if (Code.FileHelper.IsExistFile(urlPath, true))
                {
                    htmls = Code.FileHelper.ReadTxtFile(urlPath, true);
                    isHave = true;
                }
            }

            return isHave;
        }

    }
}
