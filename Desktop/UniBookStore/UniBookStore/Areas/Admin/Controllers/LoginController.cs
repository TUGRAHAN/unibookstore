using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniBookStore.Areas.Admin.Models.Dto;

namespace UniBookStore.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminLoginDto _model)
        {
            var _password = FormsAuthentication.HashPasswordForStoringInConfigFile(_model.Password, "MD5");

            if (Services.Login.IsLogin(_model.UserName, _password))
            {
                FormsAuthentication.SetAuthCookie(_model.UserName, true);
                return Redirect("/Admin/Anasayfa");
            }
            else
            {
                ViewBag.Error = false;
            }

            return View();
        }

        public RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Admin/UyeGirisi");
        }
    }
}