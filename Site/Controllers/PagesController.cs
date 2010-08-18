using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Site.UserEventsServiceReference;
using Site.Libs;

namespace Site.Controllers
{
    public class PagesController : Controller
    {
        //
        // GET: /Pages/

        public ActionResult Main()
        {
            return new LocalizedViewResult("Main");
        }

        public ActionResult Download()
        {
            return new LocalizedViewResult("Download");
        }

        [Authorize]
        public ActionResult UserEvents()
        {
            string userEmail=(string)Session["email"];
            string userPassword=(string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");
            UserEventsClient server = new UserEventsClient();

            ViewData["userEvents"] = server.GetEvents(userEmail, userPassword);
            return View();

        }
    }
}
