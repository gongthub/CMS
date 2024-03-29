﻿using CMS.Application.Comm;
using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository;
using CMS.RepositoryFactory;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class ItemsDetailApp
    {
        private IItemsDetailRepository service = DataAccess.CreateIItemsDetailRepository();

        public List<ItemsDetailEntity> GetList(string itemId = "", string keyword = "")
        {
            var expression = ExtLinq.True<ItemsDetailEntity>();
            if (!string.IsNullOrEmpty(itemId))
            {
                expression = expression.And(t => t.ItemId == itemId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.ItemName.Contains(keyword));
                expression = expression.Or(t => t.ItemCode.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public List<ItemsDetailEntity> GetList(string itemId, string keyword, Pagination pagination)
        {
            var expression = ExtLinq.True<ItemsDetailEntity>();
            expression = expression.And(t => t.ItemId == itemId);
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.ItemName.Contains(keyword));
                expression = expression.Or(t => t.ItemCode.Contains(keyword));
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.FindList(expression, pagination);
        }
        public List<ItemsDetailEntity> GetItemList(string enCode)
        {
            List<ItemsDetailEntity> lItemEntity = new List<ItemsDetailEntity>();
            lItemEntity = service.GetItemList(enCode);
            lItemEntity = InitItemDetails(enCode, lItemEntity);
            return lItemEntity;
        }
        public List<ItemsDetailEntity> GetItemList(string enCode, string keyValue)
        {
            List<ItemsDetailEntity> lItemEntity = new List<ItemsDetailEntity>();
            lItemEntity = service.GetItemList(enCode);
            lItemEntity = InitItemDetails(enCode, lItemEntity, keyValue);
            return lItemEntity;
        }
        public ItemsDetailEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            service.DeleteById(t => t.Id == keyValue);
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "删除字典内容信息=>" + keyValue, Enums.DbLogType.Delete, "字典内容管理");
        }
        public void SubmitForm(ItemsDetailEntity itemsDetailEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsDetailEntity.Modify(keyValue);
                service.Update(itemsDetailEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "修改字典内容信息=>" + itemsDetailEntity.ItemName, Enums.DbLogType.Update, "字典内容管理");
            }
            else
            {
                itemsDetailEntity.Create();
                service.Insert(itemsDetailEntity);
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "添加字典内容信息=>" + itemsDetailEntity.ItemName, Enums.DbLogType.Create, "字典内容管理");
            }
        }

        private List<ItemsDetailEntity> InitItemDetails(string enCode, List<ItemsDetailEntity> lItemEntity)
        {
            switch (enCode)
            {
                case "UserLevel":
                    //var LoginInfo = OperatorProvider.Provider.GetCurrent();
                    var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                    if (LoginInfo != null)
                    {
                        if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.WebSiteUser)
                        {
                            lItemEntity = lItemEntity.FindAll(t => t.ItemCode == LoginInfo.UserLevel.ToString());
                        }
                        else
                        {
                            if (LoginInfo.UserLevel == (int)Code.Enums.UserLevel.RegisterUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.OrdinaryUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.GoldUser || LoginInfo.UserLevel == (int)Code.Enums.UserLevel.DiamondUser)
                            {
                                lItemEntity = lItemEntity.FindAll(t => t.ItemCode == ((int)Code.Enums.UserLevel.WebSiteUser).ToString());
                            }
                        }
                    }
                    break;
            }

            return lItemEntity;
        }

        private List<ItemsDetailEntity> InitItemDetails(string enCode, List<ItemsDetailEntity> lItemEntity, string keyValue)
        {
            switch (enCode)
            {
                case "UserLevel":
                    string strUserLevel = string.Empty;
                    if (!string.IsNullOrEmpty(keyValue))
                    {
                        var userEntity = new UserApp().GetForm(keyValue);
                        if (userEntity != null && userEntity.UserLevel != null)
                            strUserLevel = userEntity.UserLevel.ToString();
                    }
                    else
                    {
                        //var LoginInfo = OperatorProvider.Provider.GetCurrent();
                        var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
                        if (LoginInfo != null && LoginInfo.UserLevel >= 0)
                            strUserLevel = LoginInfo.UserLevel.ToString();
                    }
                    if (!string.IsNullOrEmpty(strUserLevel))
                    {
                        if (strUserLevel == ((int)Code.Enums.UserLevel.WebSiteUser).ToString())
                        {
                            lItemEntity = lItemEntity.FindAll(t => t.ItemCode == strUserLevel);
                        }
                        else
                        {
                            if (strUserLevel == ((int)Code.Enums.UserLevel.RegisterUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.OrdinaryUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.GoldUser).ToString() || strUserLevel == ((int)Code.Enums.UserLevel.DiamondUser).ToString())
                            {
                                if (!string.IsNullOrEmpty(keyValue))
                                {
                                    lItemEntity = lItemEntity.FindAll(t => t.ItemCode == strUserLevel || t.ItemCode == ((int)Code.Enums.UserLevel.WebSiteUser).ToString());
                                }
                                else
                                {
                                    lItemEntity = lItemEntity.FindAll(t => t.ItemCode == ((int)Code.Enums.UserLevel.WebSiteUser).ToString());
                                }
                            }
                        }
                    }
                    break;
            }

            return lItemEntity;
        }
    }
}
