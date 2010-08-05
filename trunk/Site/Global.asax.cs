using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            routes.MapRoute(
              "GetTreeNode",
              "tree/getchild/",
              new { controller = "FileSystem", action = "GetTreeNode" } // Parameter defaults
            );

            routes.MapRoute(
              "Delete",
              "file/delete",
              new { controller = "FileSystem", action = "Delete"} // Parameter defaults
            );

            routes.MapRoute(
              "Rename",
              "file/rename",
              new { controller = "FileSystem", action = "Rename" } // Parameter defaults
            );

            routes.MapRoute(
              "Move",
              "file/move",
              new { controller = "FileSystem", action = "Move" } // Parameter defaults
            );

            routes.MapRoute(
             "Copy",
             "file/copy",
             new { controller = "FileSystem", action = "Copy" } // Parameter defaults
            );

            routes.MapRoute(
              "CreateDirectory",
              "directory/create",
              new { controller = "FileSystem", action = "CreateDirectory" } // Parameter defaults
            );

            routes.MapRoute(
               "DownloadEventFile",
               "events/download",
               new { controller = "FileSystem", action = "DownloadEventFile"} // Parameter defaults
            );

            routes.MapRoute(
               "DownloadFile",
               "file/download/{id}",
               new { controller = "FileSystem", action = "DownloadFile" } // Parameter defaults
            );

            routes.MapRoute(
               "DownloadPage",
               "download",
               new { controller = "Pages", action = "Download" } // Parameter defaults
            );

            routes.MapRoute(
               "UserEvents",
               "events",
               new { controller = "Pages", action = "UserEvents" } // Parameter defaults
            );
            
            routes.MapRoute(
                "Logout",
                "users/logout",
                new { controller = "Users", action = "Logout" } // Parameter defaults
            );

            routes.MapRoute(
                "Login",
                "users/login",
                new { controller = "Users", action = "Login" } // Parameter defaults
            );

            routes.MapRoute(
                "ShowFolder", // Route name
                "folder/{id}", // URL with parameters
                new { controller = "FileSystem", action = "ShowFolder", id=1 } // Parameter defaults
            );

            routes.MapRoute(
                "Home", // Route name
                "", // URL with parameters
                new { controller = "Pages", action = "Main"} // Parameter defaults
            );
           

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}