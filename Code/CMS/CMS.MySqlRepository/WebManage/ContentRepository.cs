using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.MySqlRepository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.MySqlRepository
{
    public class ContentRepository : MySqlRepositoryBase<ContentEntity>, IContentRepository
    {
        private IKeyWordsRespository iKeyWordsRespository = new KeyWordsRespository();
        private IColumnsRepository iColumnsRepository = new ColumnsRepository();
        private IUpFileRepository iUpFileRepository = new UpFileRepository();
        private ILogRepository iLogRepository = new LogRepository();
        private IUserRepository iUserRepository = new UserRepository();
        public void SubmitForm(ContentEntity moduleEntity, string keyValue)
        {
            string strKeyWords = string.Empty;
            if (!iKeyWordsRespository.IsHasKeyWords(moduleEntity.WebSiteId, moduleEntity.Content, out strKeyWords))
            {
                using (var db = new MySqlRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        ContentEntity moduleEntityT = FindEntity(keyValue);
                        if (moduleEntityT != null)
                        {
                            //验证用户站点权限
                            iUserRepository.VerifyUserWebsiteRole(moduleEntityT.WebSiteId);
                            moduleEntity.WebSiteId = moduleEntityT.WebSiteId;
                        }
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    else
                    {
                        string mIds = moduleEntity.ColumnId;
                        ColumnsEntity cmModel = iColumnsRepository.GetFormNoDel(mIds);
                        if (cmModel.Type == (int)Code.Enums.ModuleType.Content || cmModel.Type == (int)Code.Enums.ModuleType.List || cmModel.Type == (int)Code.Enums.ModuleType.AdvancedList)
                        {
                            if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                            {
                                string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                                moduleEntity.UrlAddress = urlAddress;
                                //SubmitForm(moduleEntity, moduleEntity.Id);
                            }
                        }
                        moduleEntity.Create();
                        db.Insert(moduleEntity);


                        //添加日志
                        iLogRepository.WriteDbLog(true, "添加内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "内容管理");
                    }
                    db.Commit();
                }
            }
            else
            {
                throw new Exception("存在非法关键词，请检查！关键字：" + strKeyWords);
            }
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys)
        {
            string strKeyWords = string.Empty;
            if (!iKeyWordsRespository.IsHasKeyWords(moduleEntity.WebSiteId, moduleEntity.Content, out strKeyWords))
            {
                using (var db = new MySqlRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        ContentEntity moduleEntityT = FindEntity(keyValue);
                        if (moduleEntityT != null)
                        {
                            //验证用户站点权限
                            iUserRepository.VerifyUserWebsiteRole(moduleEntityT.WebSiteId);
                            moduleEntity.WebSiteId = moduleEntityT.WebSiteId;
                        }
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    else
                    {
                        string mIds = moduleEntity.ColumnId;
                        ColumnsEntity cmModel = iColumnsRepository.GetFormNoDel(mIds);
                        if (cmModel.Type == (int)Code.Enums.ModuleType.Content || cmModel.Type == (int)Code.Enums.ModuleType.List || cmModel.Type == (int)Code.Enums.ModuleType.AdvancedList)
                        {
                            if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                            {
                                string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                                moduleEntity.UrlAddress = urlAddress;
                                //SubmitForm(moduleEntity, moduleEntity.Id);
                            }
                        }
                        moduleEntity.Create();
                        db.Insert(moduleEntity);

                        //添加日志
                        iLogRepository.WriteDbLog(true, "添加内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "内容管理");
                    }
                    if (upFileentitys != null && upFileentitys.Count > 0)
                    {
                        upFileentitys = upFileentitys.FindAll(m => m != null);
                        foreach (UpFileDTO upFileentity in upFileentitys)
                        {
                            if (upFileentity != null)
                            {
                                //更新上传文件表 
                                upFileentity.Sys_WebSiteId = moduleEntity.WebSiteId;
                                upFileentity.Sys_ParentId = keyValue;
                                upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.Contents);
                                UpFileEntity upFileEntity = iUpFileRepository.InitUpFileEntity(upFileentity);

                                upFileEntity.Create();
                                db.Insert(upFileEntity);
                            }
                        }
                    }
                    db.Commit();
                }
            }
            else
            {
                throw new Exception("存在非法关键词，请检查！关键字：" + strKeyWords);
            }
        }
        public void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys, List<string> lstRemoveImgIds)
        {
            string strKeyWords = string.Empty;
            if (!iKeyWordsRespository.IsHasKeyWords(moduleEntity.WebSiteId, moduleEntity.Content, out strKeyWords))
            {
                using (var db = new MySqlRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        ContentEntity moduleEntityT = FindEntity(keyValue);
                        if (moduleEntityT != null)
                        {
                            //验证用户站点权限
                            iUserRepository.VerifyUserWebsiteRole(moduleEntityT.WebSiteId);
                            moduleEntity.WebSiteId = moduleEntityT.WebSiteId;
                        }
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    else
                    {
                        moduleEntity.Create();
                        string mIds = moduleEntity.ColumnId;
                        ColumnsEntity cmModel = iColumnsRepository.GetFormNoDel(mIds);
                        if (cmModel.Type == (int)Code.Enums.ModuleType.Content || cmModel.Type == (int)Code.Enums.ModuleType.List || cmModel.Type == (int)Code.Enums.ModuleType.AdvancedList)
                        {
                            if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                            {
                                string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                                moduleEntity.UrlAddress = urlAddress;
                                //SubmitForm(moduleEntity, moduleEntity.Id);
                            }
                        }
                        db.Insert(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "添加内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "内容管理");
                    }
                    if (upFileentitys != null && upFileentitys.Count > 0)
                    {
                        upFileentitys = upFileentitys.FindAll(m => m != null);
                        foreach (UpFileDTO upFileentity in upFileentitys)
                        {
                            if (upFileentity != null)
                            {
                                //更新上传文件表 
                                upFileentity.Sys_WebSiteId = moduleEntity.WebSiteId;
                                upFileentity.Sys_ParentId = keyValue;
                                upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.Contents);
                                UpFileEntity upFileEntity = iUpFileRepository.InitUpFileEntity(upFileentity);
                                upFileEntity.Create();
                                db.Insert(upFileEntity);
                            }
                        }
                    }
                    if (lstRemoveImgIds != null && lstRemoveImgIds.Count > 0)
                    {
                        //删除已上传文件 
                        iUpFileRepository.DeleteByIds(lstRemoveImgIds);
                    }
                    db.Commit();
                }
            }
            else
            {
                throw new Exception("存在非法关键词，请检查！关键字：" + strKeyWords);
            }
        }
        public void Up(string keyValue)
        {
            ContentEntity contentEntity = FindEntity(keyValue);
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id))
            {
                using (var db = new MySqlRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        contentEntity.EnabledMark = true;
                        db.Update(contentEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "发布内容信息=>" + contentEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    db.Commit();
                }
            }
        }
        public void Down(string keyValue)
        {
            ContentEntity contentEntity = FindEntity(keyValue);
            if (contentEntity != null && !string.IsNullOrEmpty(contentEntity.Id))
            {
                using (var db = new MySqlRepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        contentEntity.EnabledMark = false;
                        db.Update(contentEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "移除内容信息=>" + contentEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    db.Commit();
                }
            }
        }

        public List<ContentEntity> GetAllEnableModels(string webSiteId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT
	                                A.Id,
	                                A.WebSiteId,
	                                A.ColumnId,
	                                A.SortCode,
	                                A.ShortName,
	                                A.FullName,
	                                A.Author,
	                                A.Description,
	                                A.EditTime,
	                                A.UrlPath,
	                                A.MUrlPath,
	                                A.UrlAddress,
	                                A.FilePath,
	                                A.FilePathSpare,
	                                A.Icon,
	                                A.LowIcon,
	                                A.Content,
	                                A.SEOTitle,
	                                A.SEOKeyWords,
	                                A.SEODesc,
	                                A.ViewNum,
	                                A.EnabledMark,
	                                A.TopMark,
	                                A.DeleteMark,
	                                A.CreatorUserId,
	                                A.CreatorTime,
	                                A.DeleteUserId,
	                                A.DeleteTime,
	                                A.LastModifyUserId,
	                                A.LastModifyTime,
	                                A.Description1,
	                                A.Description2,
	                                A.Description3,
	                                A.Description4,
	                                A.Description5,
	                                A.Description6,
	                                A.Description7,
	                                A.Description8,
	                                A.Description9,
	                                A.Description10
                                FROM
	                                c_contents A
                                LEFT JOIN c_columns B ON A.ColumnId = B.Id
                                AND B.EnabledMark = 1
                                AND (
	                                B.DeleteMark = 0
	                                OR B.DeleteMark IS NULL
                                )
                                WHERE
	                                A.WebSiteId =@websiteid AND A.EnabledMark = 1
                                AND (
	                                A.DeleteMark = 0
	                                OR A.DeleteMark IS NULL
                                )");
            DbParameter[] parameter =
            {
                 new MySqlParameter("@websiteid",webSiteId)
            };
            return this.FindList(strSql.ToString(), parameter);
        }
    }
}
