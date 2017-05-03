using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.WebManage
{
    public class ResourceApp
    {
        private static readonly string HTMLCONTENTSRC = Code.Configs.GetValue("htmlContentSrc");
        private static readonly string WEBURLHTTP = Code.Configs.GetValue("WebUrlHttp");

        /// <summary>
        /// 根据站点id获取站点资源文件
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <returns></returns>
        public List<ResourceEntity> GetList(string webSiteId)
        {
            List<ResourceEntity> models = new List<ResourceEntity>();
            WebSiteApp webSiteApp = new WebSiteApp();
            if (!string.IsNullOrEmpty(webSiteId))
            {
                WebSiteEntity webSiteEntity = webSiteApp.GetForm(webSiteId);
                if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.ShortName))
                {
                    models = GetFilesByWebSiteShortName(webSiteEntity.ShortName, webSiteEntity.UrlAddress);
                }
            }
            return models;
        }

        /// <summary>
        /// 根据网站简称获取所有资源文件
        /// </summary>
        /// <param name="webSiteShortName"></param>
        /// <returns></returns>
        private List<ResourceEntity> GetFilesByWebSiteShortName(string webSiteShortName, string webSiteUrl)
        {
            List<ResourceEntity> models = new List<ResourceEntity>();
            string filePaths = HTMLCONTENTSRC + @"\" + webSiteShortName + @"\";
            filePaths = Code.FileHelper.MapPath(filePaths);

            if (!Code.FileHelper.IsExistDirectory(filePaths))
            {
                Code.FileHelper.CreateDirectory(filePaths);
            }

            InitFiles(filePaths, ref models, 0, false, "");
            ReplaceUrl(ref models, webSiteUrl);

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
            string[] files = Code.FileHelper.GetFileNames(filePaths);
            if (files != null && files.Length > 0)
            {
                ResourceEntity modelD = new ResourceEntity();
                modelD.id = Code.FileHelper.GetDirectoryName(files[0]);
                modelD.DirName = Code.FileHelper.GetDirectoryName(files[0]);
                modelD.Type = 0;
                modelD.level = level;
                modelD.expanded = false;
                modelD.loaded = true;
                modelD.parent = parents;
                models.Add(modelD);
                level++;
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
                    model.parent = Code.FileHelper.GetDirectoryName(file);
                    models.Add(model);
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
                    parents = Code.FileHelper.GetDirectoryName(dir);
                    InitFiles(dir, ref models, level, true, parents);
                }
            }
        }

        /// <summary>
        /// 替换全局路径为相对路径
        /// </summary>
        /// <returns></returns>
        private void ReplaceUrl(ref List<ResourceEntity> models, string urlAddress)
        {
            if (models != null && models.Count > 0)
            {
                foreach (ResourceEntity model in models)
                {
                    if (!string.IsNullOrEmpty(model.UrlAddress))
                    {
                        string htmlcontents = HTMLCONTENTSRC.Replace(@"\\", "/");
                        string webUrl = WEBURLHTTP + urlAddress;
                        string webUrlContents = webUrl + HTMLCONTENTSRC;
                        string urlConfigMath = Code.FileHelper.MapPath(HTMLCONTENTSRC);
                        model.id = model.id.Replace(urlConfigMath, webUrlContents);
                        model.id = model.id.Replace(@"\", @"/");
                        model.DirName = model.DirName.Replace(urlConfigMath, webUrlContents);
                        model.DirName = model.DirName.Replace(@"\", @"/");
                        model.UrlAddress = model.UrlAddress.Replace(urlConfigMath, webUrlContents);
                        model.UrlAddress = model.UrlAddress.Replace(@"\", @"/");
                    }
                }
            }
        }
    }
}
