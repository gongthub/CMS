﻿using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Domain.IRepository.SystemSecurity;
using CMS.Domain.IRepository.WebManage;
using CMS.Repository.SystemManage;
using CMS.Repository.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository.WebManage
{
    public class ContentRepository : RepositoryBase<ContentEntity>, IContentRepository
    {
        private IKeyWordsRespository iKeyWordsRespository = new KeyWordsRespository();
        private IColumnsRepository iColumnsRepository = new ColumnsRepository();
        private IUpFileRepository iUpFileRepository = new UpFileRepository();
        private ILogRepository iLogRepository = new LogRepository();
        public void SubmitForm(ContentEntity moduleEntity, string keyValue)
        {
            string strKeyWords = string.Empty;
            if (!iKeyWordsRespository.IsHasKeyWords(moduleEntity.WebSiteId, moduleEntity.Content, out strKeyWords))
            {
                using (var db = new RepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    else
                    {
                        string mIds = moduleEntity.ColumnId;
                        ColumnsEntity cmModel = iColumnsRepository.GetFormNoDel(mIds);
                        if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                        {
                            string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                            moduleEntity.UrlAddress = urlAddress;
                            //SubmitForm(moduleEntity, moduleEntity.Id);
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
                using (var db = new RepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        moduleEntity.Modify(keyValue);
                        db.Update(moduleEntity);
                        //添加日志
                        iLogRepository.WriteDbLog(true, "修改内容信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "内容管理");
                    }
                    else
                    {
                        string mIds = moduleEntity.ColumnId;
                        ColumnsEntity cmModel = iColumnsRepository.GetFormNoDel(mIds);
                        if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                        {
                            string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                            moduleEntity.UrlAddress = urlAddress;
                            //SubmitForm(moduleEntity, moduleEntity.Id);
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
                using (var db = new RepositoryBase().BeginTrans())
                {
                    if (!string.IsNullOrEmpty(keyValue))
                    {
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
                        if (JudgmentHelp.judgmentHelp.IsNullEntity<ColumnsEntity>(cmModel) && JudgmentHelp.judgmentHelp.IsNullOrEmptyOrGuidEmpty(cmModel.Id))
                        {
                            string urlAddress = @"\" + cmModel.ActionName + @"\" + moduleEntity.Id;
                            moduleEntity.UrlAddress = urlAddress;
                            //SubmitForm(moduleEntity, moduleEntity.Id);
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
    }
}
