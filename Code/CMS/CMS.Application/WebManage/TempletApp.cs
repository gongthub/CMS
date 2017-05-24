﻿using CMS.Application.Comm;
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
    public class TempletApp
    {
        private ITempletRepository service = new TempletRepository();

        public TempletEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public TempletEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true);
        }
        public TempletEntity GetFormByName(string Name)
        {
            TempletEntity model = new TempletEntity();
            model = service.FindEntity(m => m.FullName == Name && m.DeleteMark != true);
            return model;
        }

        /// <summary>
        /// 获取默认模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetMain()
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetMain();
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId && m.EnabledMark ==true && m.DeleteMark !=true);
            }
            return templet;
        }
        /// <summary>
        /// 获取默认模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetMain(string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetMain(webSiteId);
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId && m.WebSiteId == webSiteId && m.EnabledMark == true && m.DeleteMark != true);
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByActionName(string actionName)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName);
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId && m.EnabledMark == true && m.DeleteMark != true);
            }
            return templet;
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
                expression = expression.And(t => t.WebSiteId == webSiteId && t.DeleteMark != true && t.EnabledMark==true && t.TempletType == (int)Enums.TempletType.Search);
            }
            templet = service.FindEntity(expression);
            return templet;
        }
        /// <summary>
        /// 根据路径获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByUrlRaws(List<string> urlRaws, string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            if (urlRaws != null)
            {
                if (Common.IsSearchForUrl(urlRaws))
                {
                    if (new WebSiteConfigApp().IsSearch(webSiteId))
                    {
                        templet = GetSearchModel(webSiteId);
                    }
                }
                else
                {
                    if (urlRaws.Count == 1)
                    {
                        templet = GetModelByActionName(urlRaws.FirstOrDefault(), webSiteId);
                    }
                    else
                    {
                        templet = GetCModelByActionName(urlRaws.FirstOrDefault(), webSiteId);
                    }
                }
            }
            return templet;
        }
        /// <summary>
        /// 根据路径获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByUrlRaws(List<string> urlRaws, string webSiteId, ref int irequestType)
        {
            TempletEntity templet = new TempletEntity();
            if (urlRaws != null)
            {
                if (Common.IsSearchForUrl(urlRaws))
                {
                    if (new WebSiteConfigApp().IsSearch(webSiteId))
                    {
                        templet = GetSearchModel(webSiteId);
                        irequestType = (int)Enums.TempletType.Search;
                    }
                }
                else
                {
                    if (urlRaws.Count == 1)
                    {
                        templet = GetModelByActionName(urlRaws.FirstOrDefault(), webSiteId);
                    }
                    else
                    {
                        templet = GetCModelByActionName(urlRaws.FirstOrDefault(), webSiteId);
                    }
                }
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetModelByActionName(string actionName, string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName, webSiteId);
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.TempletId && m.WebSiteId == webSiteId && m.EnabledMark == true && m.DeleteMark != true);
            }
            return templet;
        }

        /// <summary>
        /// 根据名称获取内容模板
        /// </summary>
        /// <returns></returns>
        public TempletEntity GetCModelByActionName(string actionName, string webSiteId)
        {
            TempletEntity templet = new TempletEntity();
            ColumnsApp c_ModulesApp = new ColumnsApp();
            ColumnsEntity module = c_ModulesApp.GetModelByActionName(actionName, webSiteId);
            if (module != null)
            {
                templet = service.FindEntity(m => m.Id == module.CTempletId && m.WebSiteId == webSiteId && m.EnabledMark == true && m.DeleteMark != true);
            }
            return templet;
        }
        public List<TempletEntity> GetList()
        {
            return service.IQueryable().OrderBy(t => t.SortCode).ToList();
        }
        public List<TempletEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<TempletEntity>();
            expression = expression.And(m => m.DeleteMark != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return service.FindList(expression, pagination);
        }
        public List<TempletEntity> GetListByWebSiteId(string WebSiteId)
        {
            if (new WebSiteConfigApp().IsSearch(WebSiteId))
            {
                return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
            }
            else
            {
                return service.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true && m.TempletType == (int)Code.Enums.TempletType.Common).OrderBy(t => t.SortCode).ToList();
            }
        }
        public List<TempletEntity> GetListByWebSiteId(Pagination pagination, string keyword, string WebSiteId)
        {
            var expression = ExtLinq.True<TempletEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            if (!string.IsNullOrEmpty(WebSiteId))
            {
                expression = expression.And(t => t.WebSiteId == WebSiteId);
            }
            if (!new WebSiteConfigApp().IsSearch(WebSiteId))
            {
                expression = expression.And(t => t.TempletType == (int)Code.Enums.TempletType.Common);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        /// <summary>
        /// 添加全站搜索模板
        /// </summary>
        public void AddSearchModel(string WebSiteId)
        {
            if (!IsExistSearchModel(WebSiteId))
            {
                TempletEntity moduleEntity = new TempletEntity();
                moduleEntity.WebSiteId = WebSiteId;
                moduleEntity.SortCode = 0;
                moduleEntity.FullName = ConfigHelp.configHelp.WEBSITESEARCHPATH;
                moduleEntity.Description = "全站搜索模板";
                moduleEntity.TempletType = (int)Code.Enums.TempletType.Search;
                moduleEntity.EnabledMark = true;
                moduleEntity.Create();
                service.Insert(moduleEntity);
            }
        }
        public void SubmitForm(TempletEntity moduleEntity, string keyValue)
        {
            if (moduleEntity.FullName.ToLower() != ConfigHelp.configHelp.WEBSITESEARCHPATH.ToLower())
            {
                if (!service.IsExist(keyValue, "FullName", moduleEntity.FullName, moduleEntity.WebSiteId, true))
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
                    throw new Exception("名称已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("名称不能为系统保留名称，请重新输入！");
            }
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
        }

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
    }
}
