using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniBookStore.Service.Services.Entity;

namespace UniBookStore.Service.Services.Base
{
    public class ServiceProvider : IDisposable
    {
        private MainTypeService _mainTypeService; // mainTypeService icin field tanimladim
        private AdminLoginService _loginService; // loginService icin field tanimladim
        private CourseService _courseService; // courseService icin field tanimladim
        private UniversityService _universityService; // universityService icin field tanimladim
        private AdminRegisterService _adminRegisterService; // adminRegisterService icin field tanimladim


        public MainTypeService MainType
        {
            get
            {
                return _mainTypeService ?? new MainTypeService(); // mainTypeService varsa kullan yoksa instance al
            }

        }

        public AdminLoginService Login
        {
            get
            {
                return _loginService ?? new AdminLoginService();
            }
        }

        public CourseService Course
        {
            get
            {
                return _courseService ?? new CourseService();
            }
        }

        public UniversityService University
        {
            get
            {
                return _universityService ?? new UniversityService();
            }
        }

        public AdminRegisterService AdminRegister
        {
            get
            {
                return _adminRegisterService ?? new AdminRegisterService();
            }
        }
   
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
