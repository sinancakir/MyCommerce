using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCommerce.App_Start
{
    public class KullaniciFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.Session["user"]==null)
            {
                filterContext.Result = new RedirectResult("/Home/LogIn");
            }
        }
    }
}