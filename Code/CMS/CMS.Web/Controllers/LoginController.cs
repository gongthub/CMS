using CMS.Domain.Entity.SystemSecurity;
using CMS.Application.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Domain.Entity.SystemManage;
using CMS.Application.SystemManage;
using CMS.Code;
using CMS.Application;

namespace CMS.Web.Controllers
{
    public class LoginController : Controller
    {
        private static readonly string SYSTEMADMINUSERNAME = Code.Configs.GetValue("SystemUserName");
        [HttpGet]
        public virtual ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogEntity
            {
                ModuleName = "系统登录",
                Type = Code.Enums.DbLogType.Exit.ToString(),
                Account = OperatorProvider.Provider.GetCurrent().UserCode,
                NickName = OperatorProvider.Provider.GetCurrent().UserName,
                Result = true,
                Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            //RedirectToAction("Index", "Login");
            return Redirect("Index");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.ModuleName = "系统登录";
            logEntity.Type = Code.Enums.DbLogType.Login.ToString();
            try
            {
                if (Session["cms_session_verifycode"].IsEmpty() || Md5.md5(code.ToLower(), 16) != Session["cms_session_verifycode"].ToString())
                {
                    throw new Exception("验证码错误，请重新输入");
                }

                UserEntity userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.Id;
                    operatorModel.UserCode = userEntity.Account;
                    operatorModel.UserName = userEntity.RealName;
                    operatorModel.CompanyId = userEntity.OrganizeId;
                    operatorModel.DepartmentId = userEntity.DepartmentId;
                    operatorModel.RoleId = userEntity.RoleId;
                    operatorModel.UserLevel = userEntity.UserLevel == null ? (int)Code.Enums.UserLevel.WebSiteUser : (int)userEntity.UserLevel;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    operatorModel.IsSystem = false;
                    if (!string.IsNullOrEmpty(SYSTEMADMINUSERNAME))
                    {
                        if (username == SYSTEMADMINUSERNAME)
                        {
                            operatorModel.IsSystem = true;
                        }
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.Account = userEntity.Account;
                    logEntity.NickName = userEntity.RealName;
                    logEntity.Result = true;
                    logEntity.Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.Account = username;
                logEntity.NickName = username;
                logEntity.Result = false;
                logEntity.Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
