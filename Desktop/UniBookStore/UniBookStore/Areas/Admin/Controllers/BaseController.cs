using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniBookStore.Areas.Admin.Models.Dto;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected ServiceProvider Services;
        public BaseController()
        {
            Services = new ServiceProvider(); // ServiceProvider tanimladim
        }

        public JsonResult Success(string _message)
        {
            AdminRegisterJsonResponse jr = new AdminRegisterJsonResponse()
            {
                Class = "alert alert-success",
                isSuccess = true,
                Message = _message
            };

            return Json(jr);
        }

        public JsonResult Fail(string _message)
        {
            AdminRegisterJsonResponse jr = new AdminRegisterJsonResponse()
            {
                Class = "alert alert-danger",
                isSuccess = false,
                Message = _message
            };

            return Json(jr);
        }
    }
}