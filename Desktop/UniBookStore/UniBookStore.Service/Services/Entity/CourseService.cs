using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Data.Orm.Entity;
using UniBookStore.Service.Services.Base;

namespace UniBookStore.Service.Services.Entity
{
    public class CourseService : BaseService<Course>
    {
        public bool CourseNameControl(string name)
        {
            return db.Courses.Any(x => x.CourseName == name);
        }

        public string GetCourseName(int id)
        {
            return db.Courses.Find(id).CourseName;
        }
    }
}