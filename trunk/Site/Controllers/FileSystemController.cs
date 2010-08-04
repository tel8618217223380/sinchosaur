using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ServiceModel;
using Site.FileSystemServiceReference;
using Site.AccountServiceReference;

namespace Site.Controllers
{
    public class FileSystemController : Controller
    {
      
        [Authorize]
        public ActionResult ShowFolder(int id = 1)
        {
            string userEmail=(string)Session["email"];
            string userPassword=(string)Session["password"];

            if (userEmail == null || userPassword == null)
              return  RedirectToRoute("Logout");

            try
            {
                FileSystemClient serverFileSystem = new FileSystemClient();
                MyFile parentDirectoryInfo = serverFileSystem.GetParentDirectory(id, userEmail, userPassword);

                ViewData["currentPath"] = serverFileSystem.GetFilePath(id, 1, userEmail, userPassword);
                ViewData["currenId"] = id;
                ViewData["parentId"] = parentDirectoryInfo.FileId;
                ViewData["files"]= serverFileSystem.GetDirectoryFiles(id, false, userEmail, userPassword);
            }
            catch (Exception)
            {
                return RedirectToRoute("ShowFolder");
            }
             
            return View();
        }

        [Authorize]
        
        [Authorize]
        public ActionResult DownloadFile(int id, string name)
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");

            FileSystemClient serverFileSystem = new FileSystemClient();
            try
            {
                return File(serverFileSystem.GetFileStream(id, userEmail, userPassword), "application/octet-stream", name);
            }
            catch (Exception)
            {
                return RedirectToRoute("UserEvents");
            }
        }


        [Authorize]
        public ActionResult CreateDirectory(int directoryId=0, string name="")
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");

            if (Request.HttpMethod == "POST" && directoryId != 0 && name != "")
            {
                FileSystemClient serverFileSystem = new FileSystemClient();
                MyFile directoryInfo = serverFileSystem.GetDirectory(directoryId, userEmail, userPassword);
                serverFileSystem.CreateDirectory(directoryInfo.Path + "\\" + name, userEmail, userPassword);
            }

            ViewData["directoryId"] = directoryId;
            return View();
            
        }


        [Authorize]
        public ActionResult Move(int fileId = 0, int outDirectoryId = 0, int isDirectory=0)
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");

            if (Request.HttpMethod == "POST")
            {
                try
                {
                    FileSystemClient serverFileSystem = new FileSystemClient();
                    serverFileSystem.Move(fileId, outDirectoryId, isDirectory, userEmail, userPassword);
                    return Json(new { error = "", success = true, id = outDirectoryId });
                }
                catch (Exception ex) 
                { 
                    switch(ex.Message)
                    {
                        case "ParentIdIsNull":
                            return Json(new { error = "Выберете каталог назначения!", success = false });
                            
                        case "DirectoriesHaveSameIDs":
                            return Json(new { error = "Скопировать директорию в саму себя нельзя!", success = false });

                        case "DirectoryMovedInItSelf":
                            return Json(new { error = "Скопировать директорию в свою вложенную папку нельзя!", success = false });
                        default:
                            return Json(new { error = ex.Message, success = false });
                    }
                }
            }
            ViewData["fileId"] = fileId;
            ViewData["isDirectory"] = isDirectory;
            ViewData["outDirectoryId"] = outDirectoryId;

            return View();
        }

        [Authorize]
        public ActionResult CopyToDirectory(string directoryId = "/", string newPath = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult RenameDirectory(string directoryId = "/", string newName = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult DeleteDirectory(string directoryId = "/", string newName = "/")
        {
            return View();
        }


        [Authorize]
        public ActionResult UploadFile(string fileId = "/", string newPath = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult MoveFile(string fileId = "/", string newPath = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult CopyToFile(string fileId = "/", string newPath = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult RenameFile(string fileId = "/", string newName = "/")
        {
            return View();
        }

        [Authorize]
        public ActionResult DeleteFile(string fileId = "/", string newName = "/")
        {
            return View();
        }


        [Authorize]
        public ActionResult GetTreeNode( string sleep, string mode,int key=0)
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");


            if (mode == "baseFolders")
                key = 0;
            FileSystemClient serverFileSystem = new FileSystemClient();
            DynaTreeNode[] subDirectories= serverFileSystem.GetDirectorySubDirectories(key, userEmail, userPassword);

           return Json(subDirectories, JsonRequestBehavior.AllowGet);
            
            
        }





    }
}
