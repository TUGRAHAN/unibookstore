using System.Web.Mvc;

namespace UniBookStore.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("adminhomepage", "Admin/Anasayfa", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "Home",
                action = "Index"
            });


            context.MapRoute("adminmaintypelist", "Admin/Tip/Liste", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "MainType",
                action = "Index"
            });

            context.MapRoute("adminaddmaintype", "Admin/Tip/Ekle", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "MainType",
                action = "AddMainType"
            });


            context.MapRoute("adminupdatemaintype", "Admin/Tip/Guncelle/{id}", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "MainType",
                action = "UpdateMainType"
            });

            context.MapRoute("adminaddcourse", "Admin/Ders/Ekle", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "Course",
                action = "AddCourse"
            });

            context.MapRoute("adminlogin", "Admin/UyeGirisi", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "Login",
                action = "Login"
            });


            context.MapRoute("adminlogout", "Admin/UyeGirisi", new  //dynamic route tanimlamasi yaptik. ilk tanimlanan isim unique olmali onemli
            {
                controller = "Login",
                action = "LogOut"
            });


            context.MapRoute("adminregister","Admin/UyelikOlustur", new
            {
                controller = "AdminRegister",
                action = "AddAdminUser"
            });

            context.MapRoute("courselist", "Admin/Ders/Liste", new
            {
                controller = "Course",
                action = "Index"
            });

            context.MapRoute("courseupdate", "Admin/Ders/Guncelle", new
            {
                controller = "Course",
                action = "UpdateCourse"
            });

            context.MapRoute("adduniversity", "Admin/Universite/Ekle", new
            {
                controller = "University",
                action = "AddUniversity"
            });

            context.MapRoute("universitylist", "Admin/Universite/Liste", new
            {
                controller = "University",
                action = "Index"
            });

            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}