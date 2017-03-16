﻿using CMS.Code;
using CMS.Domain.Entity.SystemManage;
using CMS.Domain.IRepository.SystemManage;
using CMS.Repository.SystemManage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Application.SystemManage
{
    public class ModuleButtonApp
    {
        private IModuleButtonRepository service = new ModuleButtonRepository();

        public List<ModuleButtonEntity> GetList(string moduleId = "")
        {
            var expression = ExtLinq.True<ModuleButtonEntity>();
            if (!string.IsNullOrEmpty(moduleId))
            {
                expression = expression.And(t => t.ModuleId == moduleId);
            }
            expression = expression.And(t => t.DeleteMark != true);
            return service.IQueryable(expression).OrderBy(t => t.SortCode).ToList();
        }
        public ModuleButtonEntity GetForm(string keyValue)
        {
            return service.FindEntity(keyValue);
        }
        public void DeleteForm(string keyValue)
        {
            if (service.IQueryable().Count(t => t.ParentId.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                service.DeleteById(t => t.Id == keyValue);
            }
        }
        public void SubmitForm(ModuleButtonEntity moduleButtonEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                moduleButtonEntity.Modify(keyValue);
                service.Update(moduleButtonEntity);
            }
            else
            {
                moduleButtonEntity.Create();
                service.Insert(moduleButtonEntity);
            }
        }
        public void SubmitCloneButton(string moduleId, string Ids)
        {
            string[] ArrayId = Ids.Split(',');
            var data = this.GetList();
            List<ModuleButtonEntity> entitys = new List<ModuleButtonEntity>();
            foreach (string item in ArrayId)
            {
                ModuleButtonEntity moduleButtonEntity = data.Find(t => t.Id == item);
                moduleButtonEntity.Id = Common.GuId();
                moduleButtonEntity.ModuleId = moduleId;
                entitys.Add(moduleButtonEntity);
            }
            service.SubmitCloneButton(entitys);
        }
    }
}
