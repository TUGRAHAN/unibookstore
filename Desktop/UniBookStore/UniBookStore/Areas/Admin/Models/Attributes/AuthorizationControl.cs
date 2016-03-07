using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniBookStore.Areas.Admin.Models.Enums;
using UniBookStore.Data.Orm.Context;
using UniBookStore.Data.Orm.Entity;

namespace UniBookStore.Areas.Admin.Models.Attributes
{
    public class AuthorizationControl: ActionFilterAttribute
    {
        int role = 0;
        public AuthorizationControl(RoleEnum _role)
        {
            role = Convert.ToInt32(_role);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BookStoreEntities db = new BookStoreEntities();
            string username = HttpContext.Current.User.Identity.Name;
            AdminUser user = db.AdminUsers.FirstOrDefault(x => x.UserName == username);
            string[] roles = user.Roles.Split(';');

            bool isAccess = false;
            for (int i = 0; i < roles.Length; i++)
            {
                if (roles[i] == role.ToString())
                {
                    isAccess = true;
                    return;
                }
            }

            if (isAccess == false)
            {
                filterContext.Result = new RedirectResult("/Admin/Error/AutherizationError");
            }
        }
    }
}