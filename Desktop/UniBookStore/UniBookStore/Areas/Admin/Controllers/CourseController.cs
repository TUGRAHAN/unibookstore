using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniBookStore.Areas.Admin.Models.Attributes;
using UniBookStore.Data.Orm.Entity;

namespace UniBookStore.Areas.Admin.Controllers
{
    public class CourseController : BaseController
    {
        [AuthenticationControl]
        public ActionResult Index()
        {
            List<Course> courseList = Services.Course.GetAll();
            return View(courseList);
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

            //ViewBag.MainTypeID = new SelectList(Services.MainType.GetAll(), "ID", "MainTypeName", id);
        }


        [AuthenticationControl]
        public ViewResult AddCourse()
        {
            DrpDoldur(0);
            return View();
        }

        [HttpPost]
        public ViewResult AddCourse(Course _course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Course c = Services.Course.GetLambda(x => x.CourseName == _course.CourseName && x.MainTypeID == _course.MainTypeID).FirstOrDefault();

                    if (c != null)
                    {
                        ViewBag.NameError = true;
                    }
                    else
                    {
                        Services.Course.Insert(_course);
                        ViewBag.Error = false;
                    }
                }
                catch (Exception)
                {
                    ViewBag.NameError = true;
                }

                DrpDoldur(0);
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
        public ViewResult UpdateCourse(int id)
        {
            DrpDoldur(0);
            Course course = Services.Course.GetByID(id);
            return View(course);
        }

        [HttpPost]
        public ViewResult UpdateCourse(Course _course)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Course c = Services.Course.GetLambda(x => x.CourseName == _course.CourseName && x.MainTypeID == _course.MainTypeID).FirstOrDefault();
                    if (c != null)
                    {

                        ViewBag.NameError = true;
                    }
                    else
                    {
                        Services.Course.Update(_course);
                        ViewBag.Error = false;
                    }
                }
                catch (Exception)
                {
                    ViewBag.NameError = true;
                }

                DrpDoldur(0);
                ModelState.Clear();
                return View();
            }
            else
            {
                ViewBag.NameError = true;
                return View();
            }
        }


        public JsonResult DeleteCourse(int id)
        {
            Services.Course.Delete(id);
            return Json("succ", JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeCourseState(int id)
        {
            var result = Services.Course.ChangeState(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}