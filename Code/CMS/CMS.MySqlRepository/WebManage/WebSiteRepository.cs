using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class WebSiteRepository : SqlServerRepositoryBase<WebSiteEntity>, IWebSiteRepository
    {
        private IUserRepository iUserRepository = new UserRepository();
        private IUserWebSiteRepository iUserWebSiteRepository = new UserWebSiteRepository();
        private IWebSiteForUrlRepository iWebSiteForUrlRepository = new WebSiteForUrlRepository();
        private IWebSiteConfigRepository iWebSiteConfigRepository = new WebSiteConfigRepository();
        private ISysTempletsRepository iSysTempletsRepository = new SysTempletsRepository();
        private ITempletRepository iTempletRepository = new TempletRepository();
        private IUpFileRepository iUpFileRepository = new UpFileRepository();
        private ILogRepository iLogRepository = new LogRepository();


        private static readonly string HTMLSYSCONTENTSRC = Code.ConfigHelp.configHelp.HTMLSYSCONTENTSRC;
        private static readonly string HTMLCONTENTSRC = Code.Configs.GetValue("htmlContentSrc");
        private static readonly string SYSFILEFORDEL = Code.ConfigHelp.configHelp.SYSFILEFORDEL;
        private static readonly string HTMLSRE = Code.Configs.GetValue("htmlSrc");
        private static readonly string UPLOADIMG = Code.ConfigHelp.configHelp.UPLOADIMG;
        private static readonly string UPLOADFILE = Code.ConfigHelp.configHelp.UPLOADFILE;

        /// <summary>
        /// 获取当前用户所有站点Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteIds()
        {
            List<string> lstrids = new List<string>();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.IsSystem)
                {
                    lstrids = IQueryable(t => t.DeleteMark != true).Select(m => m.Id).ToList();
                }
                else
                {
                    lstrids = iUserWebSiteRepository.IQueryable(t => t.UserId == LoginInfo.UserId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
                }
            }
            return lstrids;
        }

        /// <summary>
        /// 根据用户获取所属站点
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetWebSiteIds(string userId)
        {
            return iUserWebSiteRepository.IQueryable(t => t.UserId == userId && t.DeleteMark != true).Select(m => m.WebSiteId).ToList();
        }

        /// <summary>
        /// 获取创建用户站点数
        /// </summary>
        /// <returns></returns>
        public int GetCountByCreatorId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            expression = expression.And(t => t.DeleteMark != true);

            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                expression = expression.And(t => t.CreatorUserId == LoginInfo.UserId);
            }
            return IQueryable(expression).Count();
        }

        /// <summary>
        /// 根据站点获取模板
        /// </summary>
        /// <param name="WebSiteId"></param>
        /// <returns></returns>
        public List<TempletEntity> GetListByWebSiteId(string WebSiteId)
        {
            if (iWebSiteConfigRepository.IsSearch(WebSiteId))
            {
                return iTempletRepository.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
            }
            else
            {
                return iTempletRepository.IQueryable(m => m.WebSiteId == WebSiteId && m.DeleteMark != true && m.TempletType == (int)Code.Enums.TempletType.Common).OrderBy(t => t.SortCode).ToList();
            }
        }

        public List<WebSiteEntity> GetListForUserId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            List<string> webSiteIds = GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            return IQueryable(expression).ToList();
        }

        public List<WebSiteEntity> GetListByCreatorId()
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            expression = expression.And(t => t.DeleteMark != true);

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                expression = expression.And(t => t.CreatorUserId == LoginInfo.UserId);
            }
            return IQueryable(expression).ToList();
        }

        public List<WebSiteEntity> GetListForUserId(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebSiteEntity>();
            List<string> webSiteIds = GetWebSiteIds();
            expression = expression.And(t => webSiteIds.Contains(t.Id));
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            return FindList(expression, pagination);
        }

        public void DeleteForm(string keyValue)
        {
            WebSiteEntity webSiteEntity = FindEntity(keyValue);
            if (webSiteEntity != null && !string.IsNullOrEmpty(webSiteEntity.Id))
            {
                using (var db = new SqlServerRepositoryBase().BeginTrans())
                {
                    db.DeleteById<WebSiteEntity>(t => t.Id == keyValue);
                    db.DeleteById<WebSiteForUrlEntity>(t => t.WebSiteId == keyValue);
                    //移除文件
                    MoveFileForDel(webSiteEntity.ShortName, webSiteEntity.Id);

                    //添加日志
                    iLogRepository.WriteDbLog(true, "删除站点信息=>" + keyValue, Enums.DbLogType.Delete, "站点管理");

                    db.Commit();
                }
            }
        }

        private void MoveFileForDel(string shortName, string keyId)
        {
            MoveResourceForDelDir(shortName, keyId);
            MoveHtmlForDelDir(shortName, keyId);
            MoveUploadImgsForDelDir(shortName, keyId);
            MoveUploadFilesForDelDir(shortName, keyId);
        }

        private void MoveResourceForDelDir(string shortName, string keyId)
        {
            string filePathsold = HTMLCONTENTSRC + @"\" + shortName + @"\";
            filePathsold = Code.FileHelper.MapPath(filePathsold);
            string filePathsnew = SYSFILEFORDEL + @"\" + keyId + @"\" + "\\Resources\\";

            string basedir = SYSFILEFORDEL + @"\" + keyId + @"\";
            filePathsnew = Code.FileHelper.MapPath(filePathsnew);
            FileHelper.MoveDir(filePathsold, filePathsnew, basedir);
        }
        private void MoveHtmlForDelDir(string shortName, string keyId)
        {
            string filePathsold = HTMLSRE + @"\" + shortName + @"\";
            filePathsold = Code.FileHelper.MapPath(filePathsold);
            string filePathsnew = SYSFILEFORDEL + @"\" + keyId + @"\" + "\\Htmls\\";
            string basedir = SYSFILEFORDEL + @"\" + keyId + @"\";
            filePathsnew = Code.FileHelper.MapPath(filePathsnew);
            FileHelper.MoveDir(filePathsold, filePathsnew, basedir);
        }
        private void MoveUploadImgsForDelDir(string shortName, string keyId)
        {
            string filePathsold = UPLOADIMG + @"\" + shortName + @"\";
            filePathsold = Code.FileHelper.MapPath(filePathsold);
            string filePathsnew = SYSFILEFORDEL + @"\" + keyId + @"\" + "\\UploadImgs\\";
            string basedir = SYSFILEFORDEL + @"\" + keyId + @"\";
            filePathsnew = Code.FileHelper.MapPath(filePathsnew);
            FileHelper.MoveDir(filePathsold, filePathsnew, basedir);
        }
        private void MoveUploadFilesForDelDir(string shortName, string keyId)
        {
            string filePathsold = UPLOADFILE + @"\" + shortName + @"\";
            filePathsold = Code.FileHelper.MapPath(filePathsold);
            string filePathsnew = SYSFILEFORDEL + @"\" + keyId + @"\" + "\\UploadFiles\\";
            string basedir = SYSFILEFORDEL + @"\" + keyId + @"\";
            filePathsnew = Code.FileHelper.MapPath(filePathsnew);
            FileHelper.MoveDir(filePathsold, filePathsnew, basedir);
        }

        public void SubmitForm(WebSiteEntity moduleEntity, string keyValue)
        {
            moduleEntity.UrlAddress = moduleEntity.UrlAddress.Trim();
            if (!iWebSiteForUrlRepository.IsExistUrl(moduleEntity, moduleEntity.UrlAddress))
            {
                InitSpareUrl(ref moduleEntity);
                using (var db = new SqlServerRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改站点信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "站点管理");
                    }
                    else
                    {
                        int iWebSiteNum = 0;
                        if (IsOverNum(out iWebSiteNum))
                        {
                            moduleEntity.Create();
                            db.Insert(moduleEntity);

                            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                            if (LoginInfo != null)
                            {
                                if (!string.IsNullOrEmpty(moduleEntity.Id))
                                {
                                    UserWebSiteEntity entity = new UserWebSiteEntity();
                                    entity.Create();
                                    entity.UserId = LoginInfo.UserId;
                                    entity.WebSiteId = moduleEntity.Id;
                                    entity.EnabledMark = true;
                                    db.Insert(entity);
                                }
                            }
                            //添加配置表
                            AddWebSiteConfig(moduleEntity, db);
                            //添加站点模板 
                            List<TempletEntity> TempletModels = new List<TempletEntity>();
                            CreateTemplet(moduleEntity, db, out TempletModels);
                            //添加站点搜索模板
                            AddSearchModel(moduleEntity, db);
                            //添加站点栏目
                            AddColumns(moduleEntity, db, TempletModels);

                            //添加日志
                            iLogRepository.WriteDbLog(true, "添加站点信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "站点管理");
                        }
                        else
                        {
                            throw new Exception("当前用户最多可添加" + iWebSiteNum + "个站点，如需添加更多站点，请联系管理员！");
                        }
                    }
                    db.Commit();
                }
            }
            else
            {
                throw new Exception("域名已存在，请重新输入！");
            }
        }
        public void SubmitForm(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue, UpFileDTO upFileentity)
        {
            if (string.IsNullOrEmpty(moduleEntity.SysTempletId))
            {
                moduleEntity.SysTempletId = null;
            }
            moduleEntity.UrlAddress = moduleEntity.UrlAddress.Trim();
            moduleEntity.Id = keyValue;
            if (!iWebSiteForUrlRepository.IsExistUrl(moduleEntity, moduleEntity.UrlAddress))
            {
                if (!IsExist(keyValue, "ShortName", moduleEntity.ShortName, true))
                {
                    InitSpareUrl(ref moduleEntity);
                    using (var db = new SqlServerRepositoryBase().BeginTrans())
                    {
                        if (!string.IsNullOrEmpty(keyValue))
                        {
                            moduleEntity.Modify(keyValue);
                            db.Update(moduleEntity);
                            //添加日志
                            iLogRepository.WriteDbLog(true, "修改站点信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "站点管理");
                        }
                        else
                        {
                            int iWebSiteNum = 0;
                            if (IsOverNum(out iWebSiteNum))
                            {
                                moduleEntity.Create();
                                db.Insert(moduleEntity);
                                keyValue = moduleEntity.Id;

                                var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                                if (LoginInfo != null)
                                {
                                    if (!string.IsNullOrEmpty(moduleEntity.Id))
                                    {
                                        UserWebSiteEntity entity = new UserWebSiteEntity();
                                        entity.Create();
                                        entity.UserId = LoginInfo.UserId;
                                        entity.WebSiteId = moduleEntity.Id;
                                        entity.EnabledMark = true;
                                        db.Insert(entity);
                                    }
                                }
                                //添加配置表
                                AddWebSiteConfig(moduleEntity, db);
                                List<TempletEntity> TempletModels = new List<TempletEntity>();
                                //添加站点模板 
                                CreateTemplet(moduleEntity, db, out TempletModels);
                                //添加站点搜索模板
                                AddSearchModel(moduleEntity, db);
                                //添加站点栏目
                                AddColumns(moduleEntity, db, TempletModels);
                                //添加日志
                                iLogRepository.WriteDbLog(true, "添加站点信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "站点管理");
                            }
                            else
                            {
                                throw new Exception("当前用户最多可添加" + iWebSiteNum + "个站点，如需添加更多站点，请联系管理员！");
                            }
                        }
                        //更新上传文件表 
                        AddUppFile(moduleEntity, keyValue, upFileentity, db);
                        //保存备用域名
                        SaveWebSiteForUrl(moduleEntity, webSiteForUrlEntitys, keyValue, db);

                        db.Commit();
                    }
                }
                else
                {
                    throw new Exception("简称已存在，请重新输入！");
                }
            }
            else
            {
                throw new Exception("域名已存在，请重新输入！");
            }
        }

        /// <summary>
        /// 添加站点栏目
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="db"></param>
        private void AddColumns(WebSiteEntity moduleEntity, IRepositoryBase db, List<TempletEntity> TempletModels)
        {
            List<ColumnsEntity> cmodels = new List<ColumnsEntity>();
            if (!string.IsNullOrEmpty(moduleEntity.Id))
            {
                List<SysColumnsEntity> models = iSysTempletsRepository.GetListBySysTempletId(moduleEntity.SysTempletId);

                List<TempletEntity> tempModels = GetListByWebSiteId(moduleEntity.Id);
                if (TempletModels != null && TempletModels.Count > 0)
                {
                    tempModels.AddRange(TempletModels);
                }
                List<SysTempletItemsEntity> systempsModels = iSysTempletsRepository.GetItemList(moduleEntity.SysTempletId);

                if (models != null && models.Count > 0)
                {
                    foreach (SysColumnsEntity model in models)
                    {
                        string strNewIds = Guid.NewGuid().ToString();
                        models.ForEach(delegate(SysColumnsEntity m)
                        {
                            if (m.ParentId == model.Id)
                            {
                                m.ParentId = strNewIds;
                            }
                            if (systempsModels != null && systempsModels.Count > 0
                                && tempModels != null && tempModels.Count > 0)
                            {
                                SysTempletItemsEntity systempsModelT = systempsModels.Find(t => t.Id == m.TempletId);
                                SysTempletItemsEntity systempsModelCT = systempsModels.Find(t => t.Id == m.CTempletId);
                                if (systempsModelT != null && !string.IsNullOrEmpty(systempsModelT.Id))
                                {
                                    TempletEntity tempModelT = tempModels.Find(t => t.FullName == systempsModelT.FullName);
                                    if (tempModelT != null && !string.IsNullOrEmpty(tempModelT.Id))
                                    {
                                        m.TempletId = tempModelT.Id;
                                    }
                                }
                                if (systempsModelCT != null && !string.IsNullOrEmpty(systempsModelCT.Id))
                                {
                                    TempletEntity tempModelCT = tempModels.Find(t => t.FullName == systempsModelCT.FullName);
                                    if (tempModelCT != null && !string.IsNullOrEmpty(tempModelCT.Id))
                                    {
                                        m.CTempletId = tempModelCT.Id;
                                    }
                                }
                            }

                        });
                        model.Id = strNewIds;
                    }
                    cmodels = InitColumnsEntity(moduleEntity.Id, cmodels, models);
                    if (cmodels != null && cmodels.Count > 0)
                    {
                        foreach (var cmodelT in cmodels)
                        {
                            cmodelT.Create();
                            db.Insert(cmodelT);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 添加站点搜索模板
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="db"></param>
        private void AddSearchModel(WebSiteEntity moduleEntity, IRepositoryBase db)
        {
            if (!iTempletRepository.IsExistSearchModel(moduleEntity.Id))
            {
                TempletEntity templetEntity = new TempletEntity();
                templetEntity.WebSiteId = moduleEntity.Id;
                templetEntity.SortCode = 0;
                templetEntity.FullName = ConfigHelp.configHelp.WEBSITESEARCHPATH;
                templetEntity.Description = "全站搜索模板";
                templetEntity.TempletType = (int)Code.Enums.TempletType.Search;
                templetEntity.EnabledMark = true;
                templetEntity.Create();
                db.Insert(templetEntity);
            }
        }
        /// <summary>
        /// 添加站点模板
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="db"></param>
        private void CreateTemplet(WebSiteEntity moduleEntity, IRepositoryBase db, out List<TempletEntity> TempletModels)
        {
            TempletModels = new List<TempletEntity>();
            if (!string.IsNullOrEmpty(moduleEntity.SysTempletId) && !string.IsNullOrEmpty(moduleEntity.Id))
            {
                SysTempletsEntity sysTempletModel = iSysTempletsRepository.FindEntity(moduleEntity.SysTempletId);
                List<SysTempletItemsEntity> models = iSysTempletsRepository.GetItemList(moduleEntity.SysTempletId);
                //WebSiteEntity websiteModel = FindEntity(moduleEntity.Id);
                if (sysTempletModel != null && !string.IsNullOrEmpty(sysTempletModel.Id))
                {
                    if (models != null && models.Count > 0)
                    {
                        List<TempletEntity> tmodels = new List<TempletEntity>();
                        tmodels = (from list in models
                                   select new TempletEntity
                                   {
                                       WebSiteId = moduleEntity.Id,
                                       SortCode = list.SortCode,
                                       FullName = list.FullName,
                                       Description = list.Description,
                                       Content = list.Content,
                                       TempletType = list.TempletType,
                                       EnabledMark = list.EnabledMark,
                                       DeleteMark = list.DeleteMark,
                                       CreatorUserId = list.CreatorUserId,
                                       CreatorTime = list.CreatorTime,
                                       DeleteUserId = list.DeleteUserId,
                                       DeleteTime = list.DeleteTime,
                                       LastModifyTime = list.LastModifyTime,
                                       LastModifyUserId = list.LastModifyUserId

                                   }).ToList();

                        TempletModels = tmodels;

                        if (tmodels != null && tmodels.Count > 0)
                        {
                            foreach (var tmodel in tmodels)
                            {
                                tmodel.Create();
                                db.Insert(tmodel);
                                //添加日志
                                iLogRepository.WriteDbLog(true, "添加模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "模板管理");
                            }
                        }
                    }
                    CopySysResourceToWebSite(sysTempletModel.ShortName, moduleEntity.ShortName);
                }
            }
        }

        /// <summary>
        /// 添加配置表
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="db"></param>
        private void AddWebSiteConfig(WebSiteEntity moduleEntity, IRepositoryBase db)
        {
            if (!iWebSiteConfigRepository.IsExist(string.Empty, "WebSiteId", moduleEntity.Id, true))
            {
                WebSiteConfigEntity webSiteConfigEntity = new WebSiteConfigEntity();
                webSiteConfigEntity.WebSiteId = moduleEntity.Id;
                webSiteConfigEntity.SearchEnabledMark = false;
                webSiteConfigEntity.Create();
                db.Insert(webSiteConfigEntity);
            }
        }

        /// <summary>
        /// 更新上传文件表
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="keyValue"></param>
        /// <param name="upFileentity"></param>
        /// <param name="db"></param>
        private void AddUppFile(WebSiteEntity moduleEntity, string keyValue, UpFileDTO upFileentity, IRepositoryBase db)
        {

            UpFileEntity upFileModel = new UpFileEntity();
            upFileentity.Sys_WebSiteId = moduleEntity.Id;
            upFileentity.Sys_ParentId = keyValue;
            upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.WebSites);
            upFileModel = iUpFileRepository.InitUpFileEntity(upFileentity);
            upFileModel.Create();
            db.Insert(upFileModel);
        }

        /// <summary>
        /// 保存备用域名
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="webSiteForUrlEntitys"></param>
        /// <param name="keyValue"></param>
        /// <param name="db"></param>
        private void SaveWebSiteForUrl(WebSiteEntity moduleEntity, List<WebSiteForUrlEntity> webSiteForUrlEntitys, string keyValue, IRepositoryBase db)
        {
            //保存备用域名
            if (webSiteForUrlEntitys != null && webSiteForUrlEntitys.Count() > 0)
            {
                webSiteForUrlEntitys.ForEach(m => m.WebSiteId = keyValue);

                WebSiteForUrlEntity webSiteForUrlEntity = new WebSiteForUrlEntity();
                webSiteForUrlEntity.SortCode = 0;
                webSiteForUrlEntity.MainMark = true;
                webSiteForUrlEntity.WebSiteId = keyValue;
                webSiteForUrlEntity.UrlAddress = moduleEntity.UrlAddress;
                webSiteForUrlEntitys.Add(webSiteForUrlEntity);
                if (webSiteForUrlEntitys != null && webSiteForUrlEntitys.Count > 0)
                {
                    foreach (var webSiteForUrlEntityT in webSiteForUrlEntitys)
                    {
                        webSiteForUrlEntityT.UrlAddress = webSiteForUrlEntityT.UrlAddress.Trim();

                        WebSiteForUrlEntity TwebSiteForUrlEntity = iWebSiteForUrlRepository.IQueryable(m => m.DeleteMark != true && m.WebSiteId == webSiteForUrlEntityT.WebSiteId && m.SortCode == webSiteForUrlEntityT.SortCode).FirstOrDefault();
                        string TwebIds = string.Empty;
                        if (TwebSiteForUrlEntity != null)
                        {
                            TwebIds = TwebSiteForUrlEntity.Id;
                        }
                        if (!iWebSiteForUrlRepository.IsExist(TwebIds, "UrlAddress", webSiteForUrlEntityT.UrlAddress, true))
                        {
                            if (TwebSiteForUrlEntity != null && !string.IsNullOrEmpty(TwebSiteForUrlEntity.Id))
                            {
                                TwebSiteForUrlEntity.Modify(TwebSiteForUrlEntity.Id);
                                TwebSiteForUrlEntity.UrlAddress = webSiteForUrlEntityT.UrlAddress;
                                db.Update(TwebSiteForUrlEntity);
                            }
                            else
                            {
                                webSiteForUrlEntityT.Create();
                                db.Insert(webSiteForUrlEntityT);
                            }
                        }
                        else
                        {

                            throw new Exception("域名：" + webSiteForUrlEntityT.UrlAddress + "已绑定站点，请重新输入！");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 拷贝系统模板资源文件到网站资源文件目录
        /// </summary>
        /// <param name="TempletId"></param>
        /// <param name="WebSiteId"></param>
        private void CopySysResourceToWebSite(string templentShortName, string WebSiteShortName)
        {
            string varFromDirectory = InitDirByTemplentShortName(templentShortName);
            string varToDirectory = InitDirByWebSiteShortName(WebSiteShortName);
            CMS.Code.FileHelper.CopyFolder(varFromDirectory, varToDirectory);
        }

        /// <summary>
        /// 判断当前用户是否包含默认站点 
        /// </summary>
        /// <returns></returns>
        public bool IsExistDefaultWebSite(ref string webSiteId)
        {
            bool bState = false;
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    List<WebSiteEntity> webSiteEntitys = GetListForUserId();
                    if (webSiteEntitys != null && webSiteEntitys.Count > 0)
                    {
                        if (webSiteEntitys.Count == 1)
                        {
                            bState = true;
                            webSiteId = webSiteEntitys[0].Id;
                        }
                        else
                        {
                            WebSiteEntity webSiteEntity = webSiteEntitys.Find(m => m.MainMark == true);
                            if (webSiteEntity != null)
                            {
                                bState = true;
                                webSiteId = webSiteEntity.Id;
                            }
                        }
                    }
                }
            }
            return bState;
        }

        /// <summary>
        /// 初始化备用域名字段为Null
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public void InitSpareUrl(ref WebSiteEntity moduleEntity)
        {
            moduleEntity.SpareUrlAddress01 = null;
            moduleEntity.SpareUrlAddress02 = null;
            moduleEntity.SpareUrlAddress03 = null;
            moduleEntity.SpareUrlAddress04 = null;
            moduleEntity.SpareUrlAddress05 = null;
            moduleEntity.SpareUrlAddress06 = null;
            moduleEntity.SpareUrlAddress07 = null;
            moduleEntity.SpareUrlAddress08 = null;
            moduleEntity.SpareUrlAddress09 = null;
            moduleEntity.SpareUrlAddress10 = null;
        }
        /// <summary>
        /// 判断当前用户添加网站数量
        /// </summary>
        /// <param name="keyId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsOverNum(out int iWebSiteNum)
        {
            bool retBool = false;

            iWebSiteNum = iUserRepository.GetUserWebSiteMaxNum();
            int userWebSiteNum = GetCountByCreatorId();
            if (userWebSiteNum < iWebSiteNum)
            {
                retBool = true;
            }

            return retBool;
        }
        /// <summary>
        /// 根据系统模板简称初始化模板资源文件路径并返回绝对路径
        /// </summary>
        /// <param name="webSiteShortName"></param>
        /// <returns></returns>
        public string InitDirByTemplentShortName(string templentShortName)
        {
            string filePaths = HTMLSYSCONTENTSRC + @"\" + templentShortName + @"\";
            filePaths = Code.FileHelper.MapPath(filePaths);
            if (!Code.FileHelper.IsExistDirectory(filePaths))
            {
                Code.FileHelper.CreateDirectory(filePaths);
            }
            return filePaths;
        }

        /// <summary>
        /// 根据网站简称初始化网站资源文件路径并返回绝对路径
        /// </summary>
        /// <param name="webSiteShortName"></param>
        /// <returns></returns>
        public string InitDirByWebSiteShortName(string webSiteShortName)
        {
            string filePaths = HTMLCONTENTSRC + @"\" + webSiteShortName + @"\";
            filePaths = Code.FileHelper.MapPath(filePaths);
            if (!Code.FileHelper.IsExistDirectory(filePaths))
            {
                Code.FileHelper.CreateDirectory(filePaths);
            }
            return filePaths;
        }
        /// <summary>
        /// 处理网站栏目实体
        /// </summary>
        /// <param name="webSiteId"></param>
        /// <param name="cmodels"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        private static List<ColumnsEntity> InitColumnsEntity(string webSiteId, List<ColumnsEntity> cmodels, List<SysColumnsEntity> models)
        {
            cmodels = (from list in models
                       select new ColumnsEntity
                       {
                           Id = list.Id,
                           WebSiteId = webSiteId,
                           ParentId = list.ParentId,
                           TempletId = list.TempletId,
                           CTempletId = list.CTempletId,
                           SortCode = list.SortCode,
                           FullName = list.FullName,
                           Type = list.Type,
                           ActionName = list.ActionName,
                           Description = list.Description,
                           UrlPath = list.UrlPath,
                           UrlAddress = list.UrlAddress,
                           Icon = list.Icon,
                           EnabledMark = list.EnabledMark,
                           DeleteMark = list.DeleteMark,
                           MainMark = list.MainMark,
                           CreatorUserId = list.CreatorUserId,
                           CreatorTime = list.CreatorTime,
                           DeleteUserId = list.DeleteUserId,
                           DeleteTime = list.DeleteTime,
                           LastModifyUserId = list.LastModifyUserId,
                           LastModifyTime = list.LastModifyTime
                       }).ToList();
            return cmodels;
        }

    }
}
