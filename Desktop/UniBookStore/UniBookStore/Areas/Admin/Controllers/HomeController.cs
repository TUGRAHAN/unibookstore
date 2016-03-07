using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniBookStore.Areas.Admin.Models.Attributes;
using UniBookStore.Areas.Admin.Models.Enums;

namespace UniBookStore.Areas.Admin.Controllers
{
    [AuthenticationControl, AuthorizationControl(RoleEnum.Home)]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}