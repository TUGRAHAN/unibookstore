using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniBookStore.Areas.Admin.Models.Attributes;
using UniBookStore.Data.Orm.Context;
using UniBookStore.Data.Orm.Entity;

namespace UniBookStore.Areas.Admin.Controllers
{
    public class MainTypeController : BaseController
    {
        [AuthenticationControl]
        public ActionResult Index()
        {
            List<MainType> mainTypeList = Services.MainType.GetAll();
            return View(mainTypeList);
        }

        [AuthenticationControl]
        public ViewResult AddMainType()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddMainType(MainType _mtype)
        {
            if (ModelState.IsValid)
            {
                if (!Services.MainType.MainTypeNameControl(_mtype.MainTypeName))
                {
                    _mtype.IsActive = true;
                    Services.MainType.Insert(_mtype);
                    ViewBag.Error = false;
                }
                else
                {
                    ViewBag.NameError = true;
                }

                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.Error = true;
                return View();
            }

        }

        [AuthenticationControl]
        public ViewResult UpdateMainType(int id)
        {
            MainType mtype = Services.MainType.GetByID(id);
            return View(mtype);
        }

        [HttpPost]
        public ViewResult UpdateMainType(MainType _mtype)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    MainType m = Services.MainType.GetLambda(x => x.MainTypeName == _mtype.MainTypeName).FirstOrDefault();
                    if (m != null)
                    {

                        ViewBag.NameError = true;
                    }
                    else
                    {
                        Services.MainType.Update(_mtype);
                        ViewBag.Error = false;
                    }
                }
                catch (Exception)
                {
                    ViewBag.NameError = true;
                }

                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.NameError = true;
                return View();
            }
        }

        public JsonResult DeleteMainType(int id)
        {
            Services.MainType.Delete(id);
            return Json("succ", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeMainTypeState(int id)
        {
            var result = Services.MainType.ChangeState(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}