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
                    models = GetFilesByWebSiteShortName(webSiteEntity.ShortName);
                }
            }
            return models;
        }

        /// <summary>
        /// 根据网站简称获取所有资源文件
        /// </summary>
        /// <param name="webSiteShortName"></param>
        /// <returns></returns>
        private List<ResourceEntity> GetFilesByWebSiteShortName(string webSiteShortName)
        {
            List<ResourceEntity> models = new List<ResourceEntity>();
            string filePaths = HTMLCONTENTSRC + @"\" + webSiteShortName + @"\";
            filePaths = Code.FileHelper.MapPath(filePaths);

            if (!Code.FileHelper.IsExistDirectory(filePaths))
            {
                Code.FileHelper.CreateDirectory(filePaths);
            }

            InitFiles(filePaths, ref models, 0, false, "");


            return models;
        }
        private void InitFiles(string filePaths, ref List<ResourceEntity> models, int level, bool isLeaf, string parents)
        {
            string[] files = Code.FileHelper.GetFileNames(filePaths);
            if (files != null && files.Length > 0)
            {
                ResourceEntity modelD = new ResourceEntity();
                modelD.DirName = Code.FileHelper.GetDirectoryName(files[0]);
                modelD.Type = 0;
                modelD.level = level;
                modelD.expanded = false;
                modelD.parent = parents;
                models.Add(modelD);
                level++;
                foreach (string file in files)
                {
                    ResourceEntity model = new ResourceEntity();
                    model.DirName = file;
                    model.Type = 1;
                    model.UrlAddress = file;
                    model.level = level;
                    model.isLeaf = isLeaf;
                    model.expanded = false;
                    model.parent = parents;
                    models.Add(model);
                }
                InitDir(filePaths, ref models, level, parents);
            }
        }

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

    }
}
