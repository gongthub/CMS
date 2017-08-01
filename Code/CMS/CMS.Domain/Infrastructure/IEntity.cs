using CMS.Code;
using CMS.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CMS.Domain
{
    public class IEntity<TEntity>
    {
        public void Create()
        {
            var entity = this as ICreationAudited;
            entity.Id = Common.GuId();
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                entity.CreatorUserId = LoginInfo.UserId;
            }
            entity.DeleteMark = false;
            entity.CreatorTime = DateTime.Now;
        }
        public void CreateNotId()
        {
            var entity = this as ICreationAudited;  
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                entity.CreatorUserId = LoginInfo.UserId;
            }
            entity.DeleteMark = false;
            entity.CreatorTime = DateTime.Now;
        }
        public void Modify(string keyValue)
        {
            var entity = this as IModificationAudited;
            entity.Id = keyValue;
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                entity.LastModifyUserId = LoginInfo.UserId;
            }
            entity.LastModifyTime = DateTime.Now;
        }
        public void Remove()
        {
            var entity = this as IDeleteAudited;
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            var LoginInfo = SysLoginObjHelp.sysLoginObjHelp.GetOperator();
            if (LoginInfo != null)
            {
                entity.DeleteUserId = LoginInfo.UserId;
            }
            entity.DeleteTime = DateTime.Now;
            entity.DeleteMark = true;
        }

    }
}
