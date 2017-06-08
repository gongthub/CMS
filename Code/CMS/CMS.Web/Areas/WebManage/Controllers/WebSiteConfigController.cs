using CMS.Application.Comm;
using CMS.Code;
using CMS.Application.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.Domain.Entity.WebManage;
using System.Web;
using System.Reflection;


namespace CMS.Web.Areas.WebManage.Controllers
{
    [HandlerWebSiteMgr]
    public class WebSiteConfigController : ControllerBase
    {
        private WebSiteConfigApp webSiteConfigApp = new WebSiteConfigApp();

        [HttpGet]
        [HandlerAuthorize]
        public override ActionResult Index()
        {
            var data = webSiteConfigApp.GetFormByWebSiteId(Base_WebSiteId);
            return View(data);
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson()
        {
            var data = webSiteConfigApp.GetFormByWebSiteId(Base_WebSiteId);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult MessageConfig()
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult GetMessageConfig()
        {
            object strJson = new MessageConfigApp().GetFormJsonStr(Base_WebSiteId);
            return Content(strJson.ToJson());
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult GetAdvancedContentConfig()
        {
            object strJson = new AdvancedContentConfigApp().GetFormJsonStr(Base_WebSiteId);
            return Content(strJson.ToJson());
        }

        [HttpGet]
        [HandlerAuthorize]
        public ActionResult AdvancedContentConfig()
        {
            return View();
        } 

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult IsMessage()
        {
            try
            {
                bool bState = webSiteConfigApp.IsMessage(Base_WebSiteId);
                return Success(bState.ToString().ToLower());
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult IsAdvancedContent()
        {
            try
            {
                bool bState = webSiteConfigApp.IsAdvancedContent(Base_WebSiteId);
                return Success(bState.ToString().ToLower());
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSearchEnabled(bool searchEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateSearchEnableByWebSiteId(Base_WebSiteId, searchEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMessageEnabled(bool messageEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateMessageEnableByWebSiteId(Base_WebSiteId, messageEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAdvancedContentEnabled(bool advancedContentEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateAdvancedContentEnableByWebSiteId(Base_WebSiteId, advancedContentEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateServiceEnabled(bool serviceEnabled)
        {
            try
            {
                webSiteConfigApp.UpdateServiceEnableByWebSiteId(Base_WebSiteId, serviceEnabled);
                return Success("设置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSearchIndex()
        {
            try
            {
                LucenceHelp.CreateIndex(Base_WebSiteId, Base_WebSiteShortName);
                return Success("生成成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMessageConfig(MessagesEntity moduleEntity)
        {
            try
            {
                List<MessageConfigEntity> models = InitMessageConfigs(moduleEntity, Request);
                new MessageConfigApp().AddForms(models, true);
                return Success("配置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SaveAdvancedContentConfig(ContentEntity moduleEntity)
        {
            try
            {
                List<AdvancedContentConfigEntity> models = InitAdvancedContentConfigs(moduleEntity, Request);
                new AdvancedContentConfigApp().AddForms(models, true);
                return Success("配置成功。");
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        #region 处理留言配置
        /// <summary>
        /// 处理留言配置
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="requert"></param>
        /// <returns></returns>
        private List<MessageConfigEntity> InitMessageConfigs(MessagesEntity moduleEntity, HttpRequestBase requert)
        {
            List<MessageConfigEntity> models = new List<MessageConfigEntity>();

            PropertyInfo[] info = moduleEntity.GetType().GetProperties();
            if (info != null && info.Count() > 0)
            {
                foreach (PropertyInfo item in info)
                {
                    MessageConfigEntity model = InitMessageConfig(item, requert);
                    if (model != null && !string.IsNullOrEmpty(model.ColumnName))
                    {
                        object val = moduleEntity.GetType().GetProperty(item.Name).GetValue(moduleEntity, null);
                        if (val != null)
                            model.ColumnShowName = val.ToString();
                        models.Add(model);
                    }
                }
            }
            return models;
        }

        private MessageConfigEntity InitMessageConfig(PropertyInfo item, HttpRequestBase requert)
        {
            string ckIsEnableMark = "ckIsEnable_";
            string ckIsShowListMark = "ckIsShowList_";
            string ckIsShowViewMark = "ckIsShowView_";
            MessageConfigEntity model = new MessageConfigEntity();
            if (item != null)
            {
                ckIsEnableMark += item.Name;
                ckIsShowListMark += item.Name;
                ckIsShowViewMark += item.Name;
                if (requert[ckIsEnableMark] != null && requert[ckIsShowListMark] != null && requert[ckIsShowViewMark] != null)
                {
                    bool isEnable = false;
                    bool.TryParse(requert[ckIsEnableMark].ToString(), out isEnable);

                    bool isShowList = false;
                    bool.TryParse(requert[ckIsShowListMark].ToString(), out isShowList);

                    bool isShowView = false;
                    bool.TryParse(requert[ckIsShowViewMark].ToString(), out isShowView);
                    model.WebSiteId = Base_WebSiteId;
                    model.ColumnName = item.Name;

                    model.EnabledMark = isEnable;
                    model.ListShowMark = isShowList;
                    model.ViewShowMark = isShowView;
                }
            }

            return model;
        }

        #endregion

        #region 处理高级列表配置
        /// <summary>
        /// 处理高级列表配置
        /// </summary>
        /// <param name="moduleEntity"></param>
        /// <param name="requert"></param>
        /// <returns></returns>
        private List<AdvancedContentConfigEntity> InitAdvancedContentConfigs(ContentEntity moduleEntity, HttpRequestBase requert)
        {
            List<AdvancedContentConfigEntity> models = new List<AdvancedContentConfigEntity>();

            PropertyInfo[] info = moduleEntity.GetType().GetProperties();
            if (info != null && info.Count() > 0)
            {
                foreach (PropertyInfo item in info)
                {
                    AdvancedContentConfigEntity model = InitAdvancedContentConfig(item, requert);
                    if (model != null && !string.IsNullOrEmpty(model.ColumnName))
                    {
                        object val = moduleEntity.GetType().GetProperty(item.Name).GetValue(moduleEntity, null);
                        if (val != null)
                            model.ColumnShowName = val.ToString();
                        models.Add(model);
                    }
                }
            }
            return models;
        }

        private AdvancedContentConfigEntity InitAdvancedContentConfig(PropertyInfo item, HttpRequestBase requert)
        {
            string ckIsEnableMark = "ckIsEnable_";
            AdvancedContentConfigEntity model = new AdvancedContentConfigEntity();
            if (item != null)
            {
                ckIsEnableMark += item.Name;
                if (requert[ckIsEnableMark] != null)
                {
                    bool isEnable = false;
                    bool.TryParse(requert[ckIsEnableMark].ToString(), out isEnable);

                    model.WebSiteId = Base_WebSiteId;
                    model.ColumnName = item.Name;

                    model.EnabledMark = isEnable;
                }
            }

            return model;
        }

        #endregion
    }
}
