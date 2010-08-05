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
                MyFile directoryInfo = serverFileSystem.GetDirectory(id, userEmail, userPassword);

                ViewData["currentPath"] = directoryInfo.Path;
                ViewData["currenId"] = id;
                ViewData["parentId"] = directoryInfo.ParentDirectoryId;
                ViewData["files"]= serverFileSystem.GetDirectoryFiles(id, false, userEmail, userPassword);
            }
            catch (Exception)
            {
                return RedirectToRoute("ShowFolder");
            }
             
            return View();
        }

        
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

            if (Request.HttpMethod == "POST")
            {
                try
                {
                    FileSystemClient serverFileSystem = new FileSystemClient();
                    MyFile directoryInfo = serverFileSystem.GetDirectory(directoryId, userEmail, userPassword);
                    serverFileSystem.CreateDirectory(directoryInfo.Path + "\\" + name, userEmail, userPassword);
                    return Json(new { error = "", success = true, id = directoryId });
                }
                catch (Exception ex)
                {
                    switch (ex.Message)
                    {
                        case "NameEmpty":
                            return Json(new { error = "Введите имя директории!", success = false });

                        case "NameIsBusy":
                            return Json(new { error = "Директория с таким именем уже существует!", success = false });

                        case "DirectoryNotFound":
                            return RedirectToRoute("ShowFolder");

                        default:
                            return Json(new { error = ex.Message, success = false });
                    }
                }
            }
            ViewData["directoryId"] = directoryId;
            return View();
            
        }


        [Authorize]
        public ActionResult UploadFile(string fileId = "/", string newPath = "/")
        {
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
        public ActionResult Copy(int fileId = 0, int outDirectoryId = 0, int isDirectory = 0)
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
                    serverFileSystem.Copy(fileId, outDirectoryId, isDirectory, userEmail, userPassword);
                    return Json(new { error = "", success = true, id = outDirectoryId });
                }
                catch (Exception ex)
                {
                    switch (ex.Message)
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
        public ActionResult Rename(int fileId , int isDirectory , string name="")
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");


            FileSystemClient serverFileSystem = new FileSystemClient();


            MyFile fileInfo;
            if (isDirectory == 1)
                fileInfo = serverFileSystem.GetDirectory(fileId, userEmail, userPassword);
            else
                fileInfo = serverFileSystem.GetFile(fileId, userEmail, userPassword);

            if (Request.HttpMethod == "POST")
            {
                try
                {
                    serverFileSystem.Rename(fileId, name, isDirectory, userEmail, userPassword);
                    return Json(new { error = "", success = true, id = fileInfo.ParentDirectoryId });
                }
                catch (Exception ex)
                {
                    switch (ex.Message)
                    {
                        case "FileNotSelected":
                            return Json(new { error = isDirectory == 1 ? "Выберите директорию для переименования!" : "Выберите файл для переименования", success = false });
                        case "EmptyNewName":
                            return Json(new { error = isDirectory == 1 ? "Введите новое имя директории!" : "Введите новое имя файла", success = false });
                        case "FileNotExist":
                            return Json(new { error = isDirectory == 1 ? "Такой директории не существует!" : "Такой файл не существует!", success = false });
                        case "NameIsBusy":
                            return Json(new { error = isDirectory == 1 ? "Директория с таким именем уже существует!" : "Файл с таким именем уже существует!!", success = false });
                            
                        default:
                            return Json(new { error = ex.Message, success = false });
                    }
                }
            }
            ViewData["fileId"] = fileId;
            ViewData["name"] = fileInfo.Name;
            ViewData["isDirectory"] = isDirectory;
            return View();
        }


        [Authorize]
        public ActionResult Delete(int fileId , int isDirectory)
        {
            string userEmail = (string)Session["email"];
            string userPassword = (string)Session["password"];

            if (userEmail == null || userPassword == null)
                return RedirectToRoute("Logout");

            FileSystemClient serverFileSystem = new FileSystemClient();
            MyFile fileInfo;
                
            if(isDirectory==1)
            {
                fileInfo = serverFileSystem.GetDirectory(fileId, userEmail, userPassword);
                serverFileSystem.DeleteDirectory(fileId, userEmail, userPassword);
            }
            else
            {
                fileInfo = serverFileSystem.GetFile(fileId, userEmail, userPassword);
                serverFileSystem.DeleteFile(fileId, userEmail, userPassword);
            }
            return RedirectToRoute("ShowFolder", new { id = fileInfo.ParentDirectoryId });
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
