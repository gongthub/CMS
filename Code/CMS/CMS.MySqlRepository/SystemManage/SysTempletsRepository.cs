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
    public class SysTempletsRepository : SqlServerRepositoryBase<SysTempletsEntity>, ISysTempletsRepository
    {
        private static readonly string HTMLSYSCONTENTSRC = Code.ConfigHelp.configHelp.HTMLSYSCONTENTSRC;
        private static readonly string SYSFILEFORDEL = Code.ConfigHelp.configHelp.SYSFILEFORDEL;

        private ISysTempletItemsRepository iSysTempletItemsRepository = new SysTempletItemsRepository();
        private ISysColumnsRepository iSysColumnsRepository = new SysColumnsRepository();
        private IUpFileRepository iUpFileRepository = new UpFileRepository();
        private ILogRepository iLogRepository = new LogRepository();

        public List<SysTempletItemsEntity> GetItemList(string parentIds)
        {
            return iSysTempletItemsRepository.IQueryable(t => t.DeleteMark != true && t.ParentId == parentIds).ToList();
        }

        public List<SysColumnsEntity> GetListBySysTempletId(string sysTempletId)
        {
            return iSysColumnsRepository.GetListBySysTempletId(sysTempletId);
        }
        public void DeleteForm(string keyValue)
        {
            SysTempletsEntity sysTempletsEntity = FindEntity(keyValue);
            if (sysTempletsEntity != null && !string.IsNullOrEmpty(sysTempletsEntity.Id))
            {
                using (var db = new SqlServerRepositoryBase().BeginTrans())
                {
                    db.DeleteById<SysTempletsEntity>(t => t.Id == keyValue);
                    db.DeleteById<SysTempletItemsEntity>(t => t.ParentId == keyValue);
                    db.DeleteById<SysColumnsEntity>(t => t.ParentId == keyValue);
                    MoveResourceForDelDir(sysTempletsEntity.ShortName, sysTempletsEntity.Id);
                    //添加日志
                    iLogRepository.WriteDbLog(true, "删除系统模板信息=>" + keyValue, Enums.DbLogType.Delete, "系统模板管理");

                    db.Commit();
                }
            }
        }

        private void MoveResourceForDelDir(string shortName, string keyId)
        {
            string filePathsold = HTMLSYSCONTENTSRC + @"\" + shortName + @"\";
            filePathsold = Code.FileHelper.MapPath(filePathsold);
            string filePathsnew = SYSFILEFORDEL + @"\" + keyId + @"\" + "\\Resources\\";
            string basedir = SYSFILEFORDEL + @"\" + keyId + @"\";
            filePathsnew = Code.FileHelper.MapPath(filePathsnew);
            FileHelper.MoveDir(filePathsold, filePathsnew, basedir);
        }

        public void SubmitForm(SysTempletsEntity moduleEntity, string keyValue, UpFileDTO upFileentity)
        {
            if (!IsExist(keyValue, "FullName", moduleEntity.FullName, true))
            {
                if (!IsExist(keyValue, "ShortName", moduleEntity.ShortName, true))
                {
                    using (var db = new SqlServerRepositoryBase().BeginTrans())
                    {
                        if (!string.IsNullOrEmpty(keyValue))
                        {
                            moduleEntity.Modify(keyValue);
                            db.Update(moduleEntity);
                            //添加日志
                            iLogRepository.WriteDbLog(true, "修改系统模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "系统模板管理");
                        }
                        else
                        {
                            moduleEntity.Create();
                            db.Insert(moduleEntity);
                            //添加日志
                            iLogRepository.WriteDbLog(true, "添加系统模板信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "系统模板管理");
                        }
                        //更新上传文件表
                        UpFileEntity upFileModel = new UpFileEntity();
                        upFileentity.Sys_WebSiteId = moduleEntity.Id;
                        upFileentity.Sys_ParentId = keyValue;
                        upFileentity.Sys_ModuleName = EnumHelp.enumHelp.GetDescription(Enums.UpFileModule.WebSites);
                        upFileModel = iUpFileRepository.InitUpFileEntity(upFileentity);

                        upFileModel.Create();
                        db.Insert(upFileModel);
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
                throw new Exception("名称已存在，请重新输入！");
            }
        }
    }
}
