using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniBookStore.Areas.Admin.Models.Attributes;
using UniBookStore.Areas.Admin.Models.Dto;
using UniBookStore.Data.Orm.Entity;

namespace UniBookStore.Areas.Admin.Controllers
{
    public class AdminRegisterController : BaseController
    {
        [AuthenticationControl]
        public ActionResult AddAdminUser()
        {
            return View();
        }


        [HttpPost]
        public JsonResult AddAdminUser(AdminRegisterDto _model)
        {
            if (Services.AdminRegister.IsRegisterUserName(_model.UserName))
            {
                return Fail("Bu kullanici adi zaten tanimli.");
            }

            else if (Services.AdminRegister.IsRegisterEmail(_model.Email))
            {
                return Fail("Bu mail adresi adi zaten tanimli.");
            }

            else
            {
                _model.isActive = true;
                var _name = _model.Name.Split(' ');  // bosluga gore split edecegiz bu sayede name ve surname i birlestirecegiz. _name inputunu split ettik
                var _password = FormsAuthentication.HashPasswordForStoringInConfigFile(_model.Password, "MD5"); // password'u authenticate ediyoruz MD5 formatinda. En sik kullanilan method. girilen sifreyi karisik bir sifre olarak kaydediyor
                AdminUser user = new AdminUser()
                {
                    Name = _name.Length < 3 ? _name[0] : _name[0] + " " + _name[1],  // burada max 3 isimli kisileri dusunduk. turner if islemi yaptik.
                    Surname = _name.Length < 3 ? _name[1] : _name[2],
                    Email = _model.Email,
                    Password = _password,
                    AddDate = DateTime.Now,
                    UserName = _model.UserName,
                    IsActive = _model.isActive

                };

                Services.AdminRegister.Insert(user);
                return Success("Kayit isleminiz basarili");
            }
        }
    }
}