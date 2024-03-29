﻿using CMS.Code;
using CMS.Data;
using CMS.Domain.Entity.WebManage;
using CMS.Domain.IRepository;
using CMS.SqlServerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.SqlServerRepository
{
    public class ColumnsRepository : SqlServerRepositoryBase<ColumnsEntity>, IColumnsRepository
    {
        private ILogRepository iLogRepository = new LogRepository();
        private IUserRepository iUserRepository = new UserRepository();

        public ColumnsEntity GetFormNoDel(string keyValue)
        {
            return FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public void SubmitForm(ColumnsEntity moduleEntity, string keyValue)
        {
            if (!IsExist(keyValue, "ActionName", moduleEntity.ActionName, moduleEntity.WebSiteId, true))
            {
                if (!Common.IsSystemHaveName(moduleEntity.ActionName) && !Common.IsSearch(moduleEntity.ActionName))
                {
                    using (var db = new SqlServerRepositoryBase().BeginTrans())
                    {
                        if (!string.IsNullOrEmpty(keyValue))
                        {
                            ColumnsEntity moduleEntityT = FindEntity(keyValue);
                            if (moduleEntityT != null)
                            {
                                //验证用户站点权限
                                iUserRepository.VerifyUserWebsiteRole(moduleEntityT.WebSiteId);
                                moduleEntity.WebSiteId = moduleEntityT.WebSiteId;
                            }
                            moduleEntity.Modify(keyValue);
                            if (moduleEntity.MainMark == true)
                            {
                                List<ColumnsEntity> models = IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.WebSiteId == moduleEntity.WebSiteId).ToList();
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(ColumnsEntity model)
                                    {
                                        model.MainMark = false;
                                        db.Update(model);
                                    });
                                }
                            }

                            db.Update(moduleEntity);
                            //添加日志
                            iLogRepository.WriteDbLog(true, "修改栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "栏目管理");
                        }
                        else
                        {
                            moduleEntity.Create();

                            if (moduleEntity.MainMark == true)
                            {
                                List<ColumnsEntity> models = IQueryable().Where(m => m.DeleteMark != true && m.Id != moduleEntity.Id && m.WebSiteId == moduleEntity.WebSiteId).ToList();
                                if (models != null && models.Count > 0)
                                {
                                    models.ForEach(delegate(ColumnsEntity model)
                                    {
                                        model.MainMark = false;
                                        db.Update(model);
                                    });
                                }
                            }
                            db.Insert(moduleEntity);
                            //添加日志
                            iLogRepository.WriteDbLog(true, "添加栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "栏目管理");
                        }
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
                throw new Exception("简称不能为系统保留名称，请重新输入！");
            }
        }
    }
}
