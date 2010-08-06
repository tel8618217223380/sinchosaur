using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service.Models
{
    public class DirectoryModel
    {
        public static readonly DirectoryModel Instance = new DirectoryModel();

        static DirectoryModel() { }


        //возвращает директорию по DirectoryId
        public Directory GetDirectoryById(int directoryId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.DirectoryId == directoryId && d.UserId == userId
                         select d;
            if (result.Count<Directory>() > 0)
                return (result).First<Directory>();
            throw new Exception("DirectoryNotFound");
        }
        

        // возвращает путь каталога
        public string GetDirectoryPath(int directoryId,int userId)
        {
            Directory directoryInfo = GetDirectoryById(directoryId,userId);
            string path = "";
            if (directoryInfo.ParentId != 0)
            {
                path = GetDirectoryPath(directoryInfo.ParentId, userId) + "\\" + directoryInfo.Name;
            }
            return path;
        }
        

        //возвращает главную директорию
        public Directory GetRootDirectory(int userId)
        {
            if (!ExistRootDirectory(userId))
                CreateDirectory(userId, "\\", false);

            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.ParentId == 0 && d.UserId == userId && d.IsActual == true
                         select d;
            if (result.Count<Directory>() > 0)
                return (result).First<Directory>();
            throw new Exception("DirectoryNotFound");
        }
        

        //возвращает диреторию по ParentId
        public Directory GetDirectoryByName(string name, int parentId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.ParentId == parentId && d.Name == name && d.UserId == userId && d.IsActual == true
                         select d;
            if (result.Count<Directory>() > 0)
                return (result).First<Directory>();
            throw new Exception("DirectoryNotFound");
        }


        //возвращает директорию
        public Directory GetDirectory(string path, int userId)
        {
            if (path == "\\" || path == "")
                return GetRootDirectory(userId);
            Directory rootDirectory = GetRootDirectory(userId);
            int parentId = rootDirectory.DirectoryId;
            string[] directories = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            Directory directoryInfo = new Directory(); ;
            foreach (string directory in directories)
            {
                directoryInfo = GetDirectoryByName(directory, parentId, userId);
                parentId = directoryInfo.DirectoryId;
                
            }
            return directoryInfo;
        }


        //проверяет существование главной диретории
        public bool ExistRootDirectory(int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.ParentId == 0 && d.Name == "" && d.UserId == userId
                         select d;
            if (result.Count<Directory>() > 0)
                return true;
            return false;
        }


        //проверяет сущуствование директории
        public bool Exist(string path, int userId)
        {
            if (path == "\\")
                return ExistRootDirectory(userId);

            Directory rootDirectory = GetRootDirectory(userId);
            int parentId = rootDirectory.DirectoryId;
            string[] directories = path.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);

            Directory directoryInfo = new Directory(); ;
            try
            {
                foreach (string directory in directories)
                {
                    directoryInfo = GetDirectoryByName(directory, parentId, userId);
                    parentId = directoryInfo.DirectoryId;
                }
            }
            catch 
            { 
                return false; 
            }
            return true;
        }
        

        //проверяет сущуствование директории
        public bool ExistById(int directoryId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.DirectoryId == directoryId && d.UserId == userId
                         select d;
            if (result.Count<Directory>() > 0)
                return true;
            return false;
        }
        

        //проверяет сущуствование директории по имени
        public bool ExistByName(string name, int parentId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Directories
                         where d.ParentId == parentId && d.Name == name && d.UserId == userId && d.IsActual==true
                         select d;
            if (result.Count<Directory>() > 0)
                return true;
            return false;
        }
        

        //возвращает дочерние директории
        public List<Directory> GetChildDirectories(int parentId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var directories = from d in db.Directories
                              where d.ParentId == parentId && d.UserId == userId && d.IsActual == true
                              select d;
            List<Directory> childDirectories = new List<Directory>();
            foreach (Directory directory in directories)
                childDirectories.Add(directory);
            return childDirectories;
        }
        

        //создает директорию
        public int CreateDirectory(int userId, string patch, bool isPublic)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();

            Directory parentDirectory = GetParentDirectory(patch, userId);
            Directory newDirectory = new Directory();
            newDirectory.UserId = userId;
            newDirectory.Name = patch.Remove(0, patch.LastIndexOf('\\')+1);
            newDirectory.IsPublic = isPublic;
            newDirectory.IsActual = true;
            newDirectory.ParentId = parentDirectory.DirectoryId;
            newDirectory.Created = DateTime.Now;
            db.Directories.InsertOnSubmit(newDirectory);

            db.SubmitChanges();
            return newDirectory.DirectoryId; 
        }


        //создает директорию по имени и parentId
        public int CreateDirectoryByName(int userId, string name, int parentId, bool isPublic)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            
            Directory newDirectory = new Directory();
            newDirectory.UserId = userId;
            newDirectory.Name = name;
            newDirectory.IsPublic = isPublic;
            newDirectory.IsActual = true;
            newDirectory.ParentId = parentId;
            newDirectory.Created = DateTime.Now;
            db.Directories.InsertOnSubmit(newDirectory);

            db.SubmitChanges();
            return newDirectory.DirectoryId; 
        }
        

        //возвращает родительский каталог
        public Directory GetParentDirectory(string patch, int userId)
        {
            if (patch == "\\")
                return new Directory { DirectoryId = 0 };

            if (patch != "\\")
                patch = patch.Remove(patch.LastIndexOf('\\'));

            if (patch == "")
                patch = "\\";
            if (!Exist(patch, userId))
                CreateDirectory(userId, patch, false);
            return GetDirectory(patch, userId);
        }

        //возвращает родительский каталог
        public Directory GetParentDirectoryById(int directoryId, int userId)
        {
            Directory directoryInfo = GetDirectoryById(directoryId,  userId);
            return GetDirectoryById(directoryInfo.ParentId, userId);
        }
        

        //делает каталог не активным
        public void MakeFileNotActive(int directoryId, int userId)
        {
            try
            {
                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existFile = (from d in db.Directories
                                 where d.DirectoryId == directoryId && d.UserId == userId && d.ParentId!=0
                                 select d).Single();

                existFile.IsActual = false;
                db.SubmitChanges();
            }
            catch { };
        }


        //переименование каталога
        public void Rename(int directoryId, string newName, int userId)
        {
            try
            {
                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existFile = (from d in db.Directories
                                 where d.DirectoryId == directoryId && d.UserId == userId && d.ParentId != 0
                                 select d).Single();

                existFile.Name = newName;
                db.SubmitChanges();
            }
            catch { };
        }

        
        //перемещает каталог
        public void Move(int directoryId, int outDirectoryId, int userId)
        {
            try
            {
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(directoryId, userId);
                Directory parentDirectoryInfo = DirectoryModel.Instance.GetDirectoryById(outDirectoryId, userId);

                string directoryName = directoryInfo.Name;
            
                int i = 1;
                while (ExistByName(directoryName, outDirectoryId, userId))
                {
                    directoryName = directoryInfo.Name + string.Format("({0})", ++i);
                }

                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existFile = (from d in db.Directories
                                 where d.DirectoryId == directoryId && d.UserId == userId
                                 select d).Single();

                existFile.ParentId = outDirectoryId;
                existFile.Name = directoryName;
                db.SubmitChanges();
            }
            catch { };
        }

        // каталог
        public int Copy(int directoryId, int outDirectoryId, int userId)
        {
            
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(directoryId, userId);
                Directory parentDirectoryInfo = DirectoryModel.Instance.GetDirectoryById(outDirectoryId, userId);

                string directoryName = directoryInfo.Name;

                int i = 1;
                while (ExistByName(directoryName, outDirectoryId, userId))
                {
                    directoryName = directoryInfo.Name + string.Format("({0})", ++i);
                }

                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existDirectory = (from d in db.Directories
                                 where d.DirectoryId == directoryId && d.UserId == userId
                                 select d).Single();
                return CreateDirectoryByName(userId, directoryName, outDirectoryId,false);
            
        }

        //проверяет на перемещение каталога в свой дочерний каталог
        public bool ExistDirectoryInMovedPath(int directoryId, int outDirectoryId, int userId)
        {
            Directory directoryInfo = GetDirectoryById(outDirectoryId, userId);
            int parentDirectoryId = directoryInfo.ParentId;
            while (parentDirectoryId > 0)
            {
                if (directoryInfo.DirectoryId == directoryId)
                    return true;
                directoryInfo = GetDirectoryById(parentDirectoryId, userId);
                parentDirectoryId = directoryInfo.ParentId;
            } 
            return false;

        }
        

        //удаляет директорию
        public void DeleteDirectory(int direstoryId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var deleteQuerry = from d in db.Directories
                               where d.DirectoryId == direstoryId && d.UserId == userId
                               select d;

            if (deleteQuerry.Count<Directory>() > 0)
            {
                db.Directories.DeleteOnSubmit(deleteQuerry.First<Directory>());
                db.SubmitChanges();
            }
        }
        


    }
}
