﻿using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class RoleApp
    {
        private IRoleRepository service = DataAccess.CreateIRoleRepository();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        public List<RoleEntity> GetList(string keyword = "")
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 1);
            expression = expression.And(t => t.DeleteMark != true);

            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    string userlevels = LoginInfo.UserLevel.ToString();
                    expression = expression.And(t => t.Type == userlevels);
                }
                else
                {
                    if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                    {
                        string types =((int)Code.Enums.UserLevel.WebSiteUser).ToString();
                        expression = expression.And(t => t.Type == types);
                    }
                }
            }
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public List<RoleEntity> GetList(string keyword, Pagination pagination)
        {
            var expression = ExtLinq.True<RoleEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.FullName.Contains(keyword));
                expression = expression.Or(t => t.EnCode.Contains(keyword));
            }
            expression = expression.And(t => t.Category == 1);
            expression = expression.And(t => t.DeleteMark != true);

            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                {
                    string userlevels = LoginInfo.UserLevel.ToString();
                    expression = expression.And(t => t.Type == userlevels);
                }
                else
                {
                    if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                    {
                        string types = ((int)Code.Enums.UserLevel.WebSiteUser).ToString();
                        expression = expression.And(t => t.Type == types);
                    }
                }
            }
            return service.FindList(expression, pagination);
        }

        public List<RoleEntity> GetLists(string keyword)
        {
            var expression = ExtLinq.True<RoleEntity>();
            expression = expression.And(t => t.Category == 1);
            expression = expression.And(t => t.DeleteMark != true);

            string strUserLevel = string.Empty;
            if (!string.IsNullOrEmpty(keyword))
            {
                var userEntity = new UserApp().GetForm(keyword);
                if (userEntity != null && userEntity.UserLevel != null)
                    strUserLevel = userEntity.UserLevel.ToString();
            }
            else
            {
                //var LoginInfo = OperatorProvider.Provider.GetCurrent();
                var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                if (LoginInfo != null)
                    strUserLevel = LoginInfo.UserLevel.ToString();
            }
            if (!string.IsNullOrEmpty(strUserLevel))
            {
                if (strUserLevel == ((int)Code.Enums.UserLevel.WebSiteUser).ToString())
                {
                    expression = expression.And(t => t.Type == strUserLevel);
                }
                else
                {
                    if (strUserLevel == ((int)Code.Enums.UserLevel.RegisterUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.OrdinaryUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.GoldUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.DiamondUser).ToString())
                    {
                        if (!string.IsNullOrEmpty(keyword))
                        {
                            string types = ((int)Code.Enums.UserLevel.WebSiteUser).ToString();
                            expression = expression.And(t => t.Type == strUserLevel || t.Type == types);
                        }
                        else
                        {
                            string types = ((int)Code.Enums.UserLevel.WebSiteUser).ToString();
                            expression = expression.And(t => t.Type == types);
                        }
                    }
                }
            }
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public RoleEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(m => m.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除角色信息=>" + keyValue, Enums.DbLogType.Delete, "角色管理");
        }
        public void SubmitForm(RoleEntity roleEntity, string[] permissionIds, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                roleEntity.Modify(keyValue);
                roleEntity.Id = keyValue;
            }
            else
            {
                roleEntity.Create();
                roleEntity.Id = Common.GuId();
            }
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            List<RoleAuthorizeEntity> roleAuthorizeEntitys = new List<RoleAuthorizeEntity>();
            foreach (var itemId in permissionIds)
            {
                RoleAuthorizeEntity roleAuthorizeEntity = new RoleAuthorizeEntity();
                roleAuthorizeEntity.Id = Common.GuId();
                roleAuthorizeEntity.ObjectType = 1;
                roleAuthorizeEntity.ObjectId = roleEntity.Id;
                roleAuthorizeEntity.ItemId = itemId;
                if (moduledata.Find(t => t.Id == itemId) != null)
                {
                    roleAuthorizeEntity.ItemType = 1;
                }
                if (buttondata.Find(t => t.Id == itemId) != null)
                {
                    roleAuthorizeEntity.ItemType = 2;
                }
                roleAuthorizeEntitys.Add(roleAuthorizeEntity);
            }
            service.SubmitForm(roleEntity, roleAuthorizeEntitys, keyValue);

        }
    }
}
