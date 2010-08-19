using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

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
             "ShowPublicLink",
             "public_link/show/",
             new { controller = "FileSystem", action = "ShowPublicLink" }
           );
            
            routes.MapRoute(
              "GetTreeNode",
              "tree/getchild/",
              new { controller = "FileSystem", action = "GetTreeNode" } 
            );

            routes.MapRoute(
              "Upload",
              "file/upload",
              new { controller = "FileSystem", action = "Upload", outDirectoryId=1 } 
            );

            routes.MapRoute(
              "Delete",
              "file/delete",
              new { controller = "FileSystem", action = "Delete"} 
            );

            routes.MapRoute(
              "Rename",
              "file/rename",
              new { controller = "FileSystem", action = "Rename" } 
            );

            routes.MapRoute(
              "Move",
              "file/move",
              new { controller = "FileSystem", action = "Move" } 
            );

            routes.MapRoute(
             "Copy",
             "file/copy",
             new { controller = "FileSystem", action = "Copy" } 
            );

            routes.MapRoute(
              "CreateDirectory",
              "directory/create",
              new { controller = "FileSystem", action = "CreateDirectory" } 
            );

            routes.MapRoute(
               "DownloadEventFile",
               "events/download",
               new { controller = "FileSystem", action = "DownloadEventFile"} 
            );

            routes.MapRoute(
               "DownloadPublicFile",
               "file/u/{userId}/{fileId}/",
               new { controller = "FileSystem", action = "DownloadPublicFile" }
            );

            routes.MapRoute(
               "DownloadFile",
               "file/download/{id}",
               new { controller = "FileSystem", action = "DownloadFile" } 
            );

            routes.MapRoute(
               "DownloadPage",
               "download",
               new { controller = "Pages", action = "Download" } 
            );

            routes.MapRoute(
               "UserEvents",
               "events",
               new { controller = "Pages", action = "UserEvents" } 
            );
            
            routes.MapRoute(
                "Logout",
                "users/logout",
                new { controller = "Users", action = "Logout" } 
            );

            routes.MapRoute(
                "Login",
                "users/login",
                new { controller = "Users", action = "Login" } 
            );

            routes.MapRoute(
                "ShowFolder", // Route name
                "folder/{id}", // URL with parameters
                new { controller = "FileSystem", action = "ShowFolder", id=1 } 
            );

            routes.MapRoute(
                "Home", // Route name
                "", // URL with parameters
                new { controller = "Pages", action = "Main"} 
            );
           

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            /* we guess at this point session is not already retrieved by application so we recreate cookie with the session id... */
            try
            {
                string session_param_name = "ASPSESSID";
                string session_cookie_name = "ASP.NET_SessionId";

                if (HttpContext.Current.Request.Form[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[session_param_name] != null)
                {
                    UpdateCookie(session_cookie_name, HttpContext.Current.Request.QueryString[session_param_name]);
                }
            }
            catch
            {
            }

            try
            {
                string auth_param_name = "AUTHID";
                string auth_cookie_name = FormsAuthentication.FormsCookieName;

                if (HttpContext.Current.Request.Form[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
                }
                else if (HttpContext.Current.Request.QueryString[auth_param_name] != null)
                {
                    UpdateCookie(auth_cookie_name, HttpContext.Current.Request.QueryString[auth_param_name]);
                }

            }
            catch
            {
            }
        }

        private void UpdateCookie(string cookie_name, string cookie_value)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
            if (null == cookie)
            {
                cookie = new HttpCookie(cookie_name);
            }
            cookie.Value = cookie_value;
            HttpContext.Current.Request.Cookies.Set(cookie);
        }
    }
}