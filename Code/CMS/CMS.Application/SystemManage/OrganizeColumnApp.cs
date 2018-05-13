using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.RepositoryFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Application.SystemManage
{
    public class OrganizeColumnApp
    {
        private IOrganizeColumnRepository service = DataAccess.CreateIOrganizeColumnRepository();

        public OrganizeColumnEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public OrganizeColumnEntity GetFormNoDel(string keyValue)
        {
            return service.FindEntity(m => m.DeleteMark != true && m.EnabledMark == true && m.Id == keyValue);
        }
        public List<OrganizeColumnEntity> GetList()
        {
            return service.IQueryable(m => m.DeleteMark != true).OrderBy(t => t.SortCode).ToList();
        }
        public List<OrganizeColumnEntity> GetListByOrganizeId(Pagination pagination, string keyword)
        {
            string organizeId = SysLoginObjHelp.sysLoginObjHelp.GetOperator().OrganizeId;
            var expression = ExtLinq.True<OrganizeColumnEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
            }
            expression = expression.And(t => t.OrganizeId == organizeId);
            expression = expression.And(t => t.DeleteMark != true);

            return service.FindList(expression, pagination);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除组织栏目信息=>" + keyValue, Enums.DbLogType.Delete, "组织栏目管理");
        }
        public void SubmitForm(OrganizeColumnEntity moduleEntity, string keyValue)
        {
            if (!service.IsExistAndMarkName(keyValue, "FullName", moduleEntity.FullName, "OrganizeId", moduleEntity.OrganizeId, true))
            {
                string organizeId = SysLoginObjHelp.sysLoginObjHelp.GetOperator().OrganizeId;

                if (!string.IsNullOrEmpty(keyValue))
                {
                    OrganizeColumnEntity organizeColumnEntity = GetForm(keyValue);
                    if (organizeColumnEntity != null && !string.IsNullOrEmpty(organizeColumnEntity.Id))
                        if (organizeId != organizeColumnEntity.OrganizeId)
                        {
                            throw new Exception("当前组织不合法，请联系管理员！");
                        }

                    moduleEntity.OrganizeId = organizeId;
                    moduleEntity.Modify(keyValue);

                    service.Update(moduleEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "修改组织栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Update, "组织栏目管理");
                }
                else
                {
                    moduleEntity.OrganizeId = organizeId;
                    moduleEntity.Create();

                    service.Insert(moduleEntity);
                    //添加日志
                    LogHelp.logHelp.WriteDbLog(true, "添加组织栏目信息=>" + moduleEntity.FullName, Enums.DbLogType.Create, "组织栏目管理");
                }
            }
            else
            {
                throw new Exception("名称已存在，请重新输入！");
            }
        }
    }
}
