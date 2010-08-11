using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site.Controllers
{
    public class UsersController : Controller
    {

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string email, string password, string returnUrl)
        {
            if (Membership.ValidateUser(email, password))
            {
                Session["email"] = email;
                Session["password"] = password;

                returnUrl =returnUrl ?? Url.RouteUrl("Home");
                FormsAuthentication.SetAuthCookie(email, false);
                
                return Redirect(returnUrl);
            }
            else
            {
                ViewData["LoginFailed"] = true;
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }



    }
}
