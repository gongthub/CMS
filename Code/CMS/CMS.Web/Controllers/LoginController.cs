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
using CMS.Application.Comm;

namespace CMS.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly string SYSTEMADMINUSERNAME = Code.ConfigHelp.configHelp.SYSTEMADMINUSERNAME;
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
            //添加日志
            LogHelp.logHelp.WriteDbLog(true, "安全退出系统", Code.Enums.DbLogType.Exit, "系统登录");

            Session.Abandon();
            Session.Clear();
            SysLoginObjHelp.sysLoginObjHelp.RemoveOperator();
            return Redirect("Index");
        }
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            try
            {
                if (SysLoginObjHelp.sysLoginObjHelp.GetVerifyCode().IsEmpty() || Md5.md5(code.ToLower(), 16) != SysLoginObjHelp.sysLoginObjHelp.GetVerifyCode())
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
                            operatorModel.UserLevel = (int)Code.Enums.UserLevel.SystemUser;
                        }
                    }
                    SysLoginObjHelp.sysLoginObjHelp.AddOperator(operatorModel);
                }

                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "登录成功", Code.Enums.DbLogType.Login, "系统登录");
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                //添加日志
                LogHelp.logHelp.WriteDbLog(true, "登录失败" + ex.Message, Code.Enums.DbLogType.Login, "系统登录", username, username);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
