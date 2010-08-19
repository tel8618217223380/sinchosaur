using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service.Models
{
    class FileModel
    {
        public static readonly FileModel Instance = new FileModel();

        static FileModel() { }

        //возвращает все файлы каталога
        public List<File> GetDirectoryFiles(int directoryId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var files = from f in db.Files
                        where f.DirectoryId == directoryId && f.UserId == userId && f.IsActual == true
                        select f;
            List<File> childFiles = new List<File>();
            foreach (File file in files)
                childFiles.Add(file);
            return childFiles;
        }
        

        //проверяет сущуствование файла имени
        public bool Exist(int directoryId, string fileName, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from f in db.Files
                         where f.Name == fileName && f.DirectoryId == directoryId && f.UserId == userId && f.IsActual == true
                         select f;
            if (result.Count<File>() > 0)
                return true;
            return false;
        }
        

        //проверяет сущуствование файла по FileId
        public bool ExistById(int fileId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from f in db.Files
                         where f.FileId == fileId && f.UserId == userId
                         select f;
            if (result.Count<File>() > 0)
                return true;
            return false;
        }


        //проверяет сущуствование файла по имени
        public bool ExistByName(string name, int directoryId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from d in db.Files
                         where d.DirectoryId == directoryId && d.Name == name && d.UserId == userId && d.IsActual == true
                         select d;
            if (result.Count<File>() > 0)
                return true;
            return false;
        }


        //возвращает все файлы каталога
        public File GetFile(int directoryId, string fileName, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from f in db.Files
                         where f.DirectoryId == directoryId && f.UserId == userId && f.Name == fileName && f.IsActual==true
                         select f;
            if (result.Count<File>() > 0)
                return (result).First<File>();
            throw new Exception("FileNotExist");
        }
        

        //возвращает все файлы каталога
        public File GetFileById(int fileId, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var result = from f in db.Files
                         where f.FileId == fileId && f.UserId == userId
                         select f;
            if (result.Count<File>() > 0)
                return (result).First<File>();
            throw new Exception("FileNotExist");
        }
        

        //создает файл
        public void CreateFile(int userId, string name, string physicalPath,  int directoryId, bool isPublic, long size)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            File newFile = new File();
            newFile.UserId = userId;
            newFile.Name = name;
            newFile.PhysicalPath = physicalPath;
            newFile.IsPublic = isPublic;
            newFile.IsActual = true;
            newFile.DirectoryId = directoryId;
            newFile.LastWrite = DateTime.Now;
            newFile.Size = size;
            db.Files.InsertOnSubmit(newFile);
            db.SubmitChanges();
        }
        

        //делает файл не активным
        public void MakeFileNotActive(int fileId, int userId)
        {
            try
            {
                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existFile = (from f in db.Files
                                 where f.FileId == fileId && f.UserId == userId && f.IsActual == true
                                 select f).Single();

                existFile.IsActual = false;
                db.SubmitChanges();
            }
            catch { };
        }
        

        //перемещает файл в другой каталог
        public void Move(int fileId, int outDirectoryId, int userId)
        {
            try
            {
                File fileInfo = GetFileById(fileId, userId);
                string fileName = fileInfo.Name;
                int i=1;
                while (Exist(outDirectoryId, fileName, userId))
                {
                    fileName = fileInfo.Name + string.Format("({0})", ++i);
                }

                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var existFile = (from f in db.Files
                                 where f.FileId == fileId && f.UserId == userId && f.IsActual == true
                                 select f).Single();

                existFile.Name = fileName;
                existFile.DirectoryId = outDirectoryId;
                db.SubmitChanges();
            }
            catch { };
        }
        

        //удаляет файл
        public void DeleteFile(int fileId, int userId)
        {
            try
            {
                DatabaseClassesDataContext db = new DatabaseClassesDataContext();
                var file = (from f in db.Files
                            where f.FileId == fileId && f.UserId == userId && f.IsActual == true
                            select f).Single();
                db.Files.DeleteOnSubmit(file);
                db.SubmitChanges();
            }
            catch { };

        }


        //проверяет возможность залить файл
        public bool IsCanUploadFile(int userId, long spaceLimit, long fileSize )
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            Nullable<long> usedSpace = (from f in db.Files
                                        where f.UserId == userId && f.IsActual == true && f.Size > 0
                                        select f).Sum(f => (long?)f.Size);

            if ( ( usedSpace.HasValue && spaceLimit - usedSpace > fileSize ) || ( !usedSpace.HasValue && spaceLimit > fileSize) )
                return true;
            return false;
        }


        //переименование файла
        public void Rename(int fileId, string newName, int userId)
        {
            DatabaseClassesDataContext db = new DatabaseClassesDataContext();
            var existFile = (from f in db.Files
                                where f.FileId == fileId && f.UserId == userId && f.IsActual == true
                                select f).Single();

            existFile.Name = newName;
            db.SubmitChanges();
        }

        
    }
}
