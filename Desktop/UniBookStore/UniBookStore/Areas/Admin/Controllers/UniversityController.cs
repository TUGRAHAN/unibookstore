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
    public class UniversityController : BaseController
    {
        [AuthenticationControl]
        public ActionResult Index()
        {
            List<University> universityList = Services.University.GetAll();
            return View(universityList);
        }

        void DrpDoldur(int id)
        {
            List<SelectListItem> mainTypeList = Services.MainType.GetAll().Select(x => new SelectListItem()
            {
                Text = x.MainTypeName,
                Value = x.ID.ToString(),
                Selected = x.ID == id ? true : false
            }).ToList();
            ViewData["mainType"] = mainTypeList;

            ViewBag.MainTypeID = new SelectList(Services.MainType.GetAll(), "ID", "MainTypeName", id);
        }

        void DrpDoldurCourse(int id)
        {
            List<SelectListItem> courseList = Services.Course.GetAll().Select(x => new SelectListItem()
            {
                Text = x.CourseName,
                Value = x.ID.ToString(),
                Selected = x.ID == id ? true : false
            }).ToList();
            ViewData["course"] = courseList;

            ViewBag.CourseID = new SelectList(Services.Course.GetAll(), "ID", "CourseName", id);
        }

        [AuthenticationControl]
        public ViewResult AddUniversity()
        {
            DrpDoldur(0);
            DrpDoldurCourse(0);
            return View();
        }
        
        [HttpPost]
        public ViewResult AddUniversity(University _university)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    University u = Services.University.GetLambda(x => x.UniversityName == _university.UniversityName && x.MainTypeID == _university.MainTypeID && x.CourseID == _university.CourseID).FirstOrDefault();

                    if (u != null)
                    {
                        ViewBag.NameError = true;
                    }
                    else
                    {
                        Services.University.Insert(_university);
                        ViewBag.Error = false;
                    }
                }
                catch (Exception)
                {
                    ViewBag.NameError = true;
                }

                ModelState.Clear();
                DrpDoldur(0);
                DrpDoldurCourse(0);
                return View();
            }
            else
            {
                ViewBag.Error = true;
                return View();
            }
        }



        [AuthenticationControl]
        public ViewResult UpdateUniversity(int id)
        {
            DrpDoldur(0);
            DrpDoldurCourse(0);
            University university = Services.University.GetByID(id);
            return View(university);
        }

        [HttpPost]
        public ViewResult UpdateUniversity(University _university)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    University u = Services.University.GetLambda(x => x.UniversityName == _university.UniversityName && x.MainTypeID == _university.MainTypeID && x.CourseID == _university.CourseID).FirstOrDefault();
                    if (u != null)
                    {

                        ViewBag.NameError = true;
                    }
                    else
                    {
                        Services.University.Update(_university);
                        ViewBag.Error = false;
                    }
                }
                catch (Exception)
                {
                    ViewBag.NameError = true;
                }

                DrpDoldur(0);
                DrpDoldurCourse(0);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.NameError = true;
                return View();
            }
        }

        public JsonResult DeleteUniversity(int id)
        {
            Services.University.Delete(id);
            return Json("succ", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeUniversityState(int id)
        {
            var result = Services.University.ChangeState(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}