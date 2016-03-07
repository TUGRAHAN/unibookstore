using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniBookStore.Areas.Admin.Models.Attributes
{
    public class AuthenticationControl: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                filterContext.HttpContext.Response.Redirect("/Admin/UyeGirisi");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}