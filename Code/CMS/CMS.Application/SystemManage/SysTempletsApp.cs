﻿using CMS.Application.Comm;
using CMS.Application.WebManage;
using CMS.Code;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class SysTempletsApp
    {
        private static readonly string HTMLSYSCONTENTSRC = Code.ConfigHelp.configHelp.HTMLSYSCONTENTSRC;
        private ISysTempletsRepository service = DataAccess.CreateISysTempletsRepository();

        public List<SysTempletsEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).ToList();
        }
        public List<SysTempletsEntity> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<SysTempletsEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }

        public List<SysTempletItemsEntity> GetItemList(Pagination pagination, string parentIds, string keyword)
        {
            SysTempletItemsApp sysTempletItemsApp = new SysTempletItemsApp();
            return sysTempletItemsApp.GetList(pagination, parentIds, keyword);
        }
        public List<SysTempletItemsEntity> GetItemList(string parentIds)
        {
            SysTempletItemsApp sysTempletItemsApp = new SysTempletItemsApp();
            return sysTempletItemsApp.GetList(parentIds);
        }
        public SysTempletsEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteForm(keyValue);
        }
        public void SubmitForm(SysTempletsEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            service.SubmitForm(moduleEntity, keyValue, upFileentity);
        }
        public SysTempletItemsEntity GetItemForm(string keyValue)
        {
            SysTempletItemsApp sysTempletItemsApp = new SysTempletItemsApp();
            return sysTempletItemsApp.GetForm(keyValue);
        }
        public void SubmitItemForm(SysTempletItemsEntity moduleEntity, string keyValue)
        {
            SysTempletItemsApp sysTempletItemsApp = new SysTempletItemsApp();
            sysTempletItemsApp.SubmitForm(moduleEntity, keyValue);
        }
        public void DeleteItemForm(string keyValue)
        {
            SysTempletItemsApp sysTempletItemsApp = new SysTempletItemsApp();
            sysTempletItemsApp.DeleteForm(keyValue);
        }

        /// <summary>
        /// 根据模板id获取模板资源文件
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public List<ResourceEntity> GeResourcetList(string parentId)
        {
            List<ResourceEntity> models = new List<ResourceEntity>();
            if (!string.IsNullOrEmpty(parentId))
            {
                SysTempletsEntity sysTempletsEntity = GetForm(parentId);
                if (sysTempletsEntity != null && !string.IsNullOrEmpty(sysTempletsEntity.ShortName))
                {
                    models = GetFilesByTemplentShortName(sysTempletsEntity.ShortName);
                }
            }
            return models;
        }

        /// <summary>
        /// 根据站点id获取站点资源文件
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public ResourceEntity GetResourcetForm(string parentId, string keyValue)
        {
            ResourceEntity model = new ResourceEntity();
            List<ResourceEntity> models = GeResourcetList(parentId);

            if (models != null && models.Count > 0)
            {
                model = models.Find(m => m.id == keyValue);
            }
            return model;
        }

        /// <summary>
        /// 根据id创建文件夹
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public void CreateDirById(string parentId, string Id, string dirName)
        {
            ResourceEntity model = GetResourcetForm(parentId, Id);
            if (model != null)
            {
                string strPaths = model.UrlAddress;
                strPaths = HTMLSYSCONTENTSRC + strPaths;
                strPaths = Code.FileHelper.MapPath(strPaths);
                strPaths = strPaths + @"\" + dirName;
                model.UrlAddress = strPaths;

                CreateDirVerify(model);

                Code.FileHelper.CreateDirectory(model.UrlAddress);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加资源管理文件夹=>" + model.UrlAddress, Enums.DbLogType.Create, "资源管理");
            }
        }

        /// <summary>
        /// 根据id删除资源
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public void DeleteResourceForm(string parentId, string Id)
        {
            ResourceEntity model = GetResourcetForm(parentId, Id);
            if (model != null)
            {
                string strPaths = model.UrlAddress;
                strPaths = HTMLSYSCONTENTSRC + strPaths;
                strPaths = Code.FileHelper.MapPath(strPaths);
                model.UrlAddress = strPaths;
                if (model.Type == 0)
                {
                    Code.FileHelper.DeleteDirectory(model.UrlAddress, true);
                }
                else
                    if (model.Type == 1)
                    {
                        Code.FileHelper.DeleteFile(model.UrlAddress, true);
                    }
            }
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除资源管理文件夹=>" + model.UrlAddress, Enums.DbLogType.Delete, "资源管理");
        }


        /// <summary>
        /// 根据网站简称获取所有资源文件
        /// </summary>
        /// <param name="webSiteShortName"></param>
        /// <returns></returns>
        private List<ResourceEntity> GetFilesByTemplentShortName(string templentShortName)
        {
            List<ResourceEntity> models = new List<ResourceEntity>();
            string filePaths = HTMLSYSCONTENTSRC + @"\" + templentShortName + @"\";
            filePaths = Code.FileHelper.MapPath(filePaths);

            if (!Code.FileHelper.IsExistDirectory(filePaths))
            {
                Code.FileHelper.CreateDirectory(filePaths);
            }

            InitFiles(filePaths, ref models, 0, false, "");
            ReplaceUrl(ref models);

            return models;
        }


        /// <summary>
        /// 处理文件夹文件
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="models"></param>
        /// <param name="level"></param>
        /// <param name="isLeaf"></param>
        /// <param name="parents"></param>
        private void InitFiles(string filePaths, ref List<ResourceEntity> models, int level, bool isLeaf, string parents)
        {
            if (!string.IsNullOrEmpty(filePaths))
            {
                string filePathsD = filePaths + @"\\";
                string dirName = Code.FileHelper.GetDirName(filePathsD);
                ResourceEntity modelD = new ResourceEntity();
                modelD.id = filePaths;
                modelD.DirName = dirName;
                modelD.Type = 0;
                modelD.level = level;
                if (level == 0)
                {
                    modelD.expanded = true;
                }
                else
                {
                    modelD.expanded = false;
                }
                modelD.loaded = true;
                modelD.parent = parents;
                modelD.UrlAddress = filePaths;
                models.Add(modelD);
                level++;
                string[] files = Code.FileHelper.GetFileNames(filePaths);
                if (files != null && files.Length > 0)
                {
                    foreach (string file in files)
                    {
                        ResourceEntity model = new ResourceEntity();
                        model.id = file;
                        model.DirName = file;
                        model.Type = 1;
                        model.UrlAddress = file;
                        model.level = level;
                        model.isLeaf = true;
                        model.expanded = false;
                        model.loaded = true;
                        model.parent = filePaths;
                        models.Add(model);
                    }
                }
                InitDir(filePaths, ref models, level, parents);
            }
        }

        /// <summary>
        /// 处理文件夹
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="models"></param>
        /// <param name="level"></param>
        /// <param name="parents"></param>
        private void InitDir(string filePaths, ref List<ResourceEntity> models, int level, string parents)
        {
            string[] dirs = Code.FileHelper.GetDirectories(filePaths);
            if (dirs != null && dirs.Length > 0)
            {
                foreach (string dir in dirs)
                {
                    parents = filePaths;
                    InitFiles(dir, ref models, level, true, parents);
                }
            }
        }

        /// <summary>
        /// 替换全局路径为相对路径
        /// </summary>
        /// <returns></returns>
        private void ReplaceUrl(ref List<ResourceEntity> models)
        {
            if (models != null && models.Count > 0)
            {
                foreach (ResourceEntity model in models)
                {
                    if (!string.IsNullOrEmpty(model.UrlAddress))
                    {
                        string htmlcontents = HTMLSYSCONTENTSRC.Replace(@"\\", "/");
                        string webUrlContents = HTMLSYSCONTENTSRC;
                        string urlConfigMath = Code.FileHelper.MapPath(HTMLSYSCONTENTSRC);
                        model.id = model.id.Replace(urlConfigMath, webUrlContents);
                        model.id = model.id.Replace(@"\", @"/");
                        model.DirName = model.DirName.Replace(urlConfigMath, webUrlContents);
                        model.DirName = model.DirName.Replace(@"\", @"/");
                        model.UrlAddress = model.UrlAddress.Replace(urlConfigMath, "");
                        model.UrlAddress = model.UrlAddress.Replace(@"\", @"/");
                        model.parent = model.parent.Replace(urlConfigMath, webUrlContents);
                        model.parent = model.parent.Replace(@"\", @"/");
                    }
                }
            }
        }

        /// <summary>
        /// 创建文件验证
        /// </summary>
        /// <param name="model"></param>
        private void CreateDirVerify(ResourceEntity model)
        {
            if (string.IsNullOrEmpty(model.UrlAddress))
            {
                throw new Exception("路径不能为空！");
            }
            if (model.Type != 0)
            {
                throw new Exception("只能在文件夹下创建文件夹！");
            }
            if (Code.FileHelper.IsExistDirectory(model.UrlAddress))
            {
                throw new Exception("文件夹已存在！");
            }
        }
    }
}
