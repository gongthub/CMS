﻿using CMS.Data;
using CMS.Domain.Entity.Common;
using CMS.Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.IRepository
{
    public interface IContentRepository : IRepositoryBase<ContentEntity>
    {
        void SubmitForm(ContentEntity moduleEntity, string keyValue);
        void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys);
        void SubmitForm(ContentEntity moduleEntity, string keyValue, List<UpFileDTO> upFileentitys, List<string> lstRemoveImgIds);
        void Up(string keyValue);
        void Down(string keyValue);
        /// <summary>
        /// 根据站点ID获取所有已发布和栏目可用的文章
        /// </summary>
        /// <returns></returns>
        List<ContentEntity> GetAllEnableModels(string webSiteId);
    }
}
