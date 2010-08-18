using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Channels;
using NLog;
using Server.Service.Models;
using System.Linq;


namespace Server.Service
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class FileSystem : IFileSystem
    {
        string StorageFolder = Properties.Settings.Default.StorageFolder;
        private static Logger logger = LogManager.GetCurrentClassLogger();


        //возвращает файловый поток
        public Stream GetFileStream(int fileId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            if (FileModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                File fileInfo = FileModel.Instance.GetFileById(fileId, userInfo.UserId);
                string fileFullPath = StorageFolder + fileInfo.PhysicalPath;
                if (!System.IO.File.Exists(fileFullPath))
                {
                    DeleteFile(fileId, userEmail, userPass);
                    throw new Exception("FileNotExist");
                }
                logger.Info("Отправка файла: {0}, клиенту:{1}", fileInfo.Directory.Name + "\\" + fileInfo.Name, userEmail);
                return new FileStream(fileFullPath, FileMode.Open, FileAccess.Read);
            }
            throw new Exception("FileNotExist");
        }


        // возвращает все файлы пользователя
        public List<MyFile> GetAllFiles(string userEmail, string userPass)
        {
            logger.Debug("Получение списка файлов клиента: {0}", userEmail);
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            return GetDirectoryFiles(1, true, userEmail, userPass);
        }


        //возвращает клиенту список файлов и вложенных директорий
        public List<MyFile> GetDirectoryFiles(int directoryId, bool recursive, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            List<MyFile> directoryFiles = new List<MyFile>();
            // если главная директория
            if (directoryId == 1)
            {
                if (!DirectoryModel.Instance.ExistRootDirectory(userInfo.UserId))
                    DirectoryModel.Instance.CreateDirectory(userInfo.UserId, "\\", false);
                Directory rootDirectoryInfo = DirectoryModel.Instance.GetRootDirectory(userInfo.UserId);
                directoryId = rootDirectoryInfo.DirectoryId;
            }

            if (DirectoryModel.Instance.ExistById(directoryId, userInfo.UserId))
            {
                List<File> files = FileModel.Instance.GetDirectoryFiles(directoryId, userInfo.UserId);
                List<Directory> directories = DirectoryModel.Instance.GetChildDirectories(directoryId, userInfo.UserId);

                string directoryPath = DirectoryModel.Instance.GetDirectoryPath(directoryId, userInfo.UserId);

                //добавление списка файлов
                foreach (File file in files)
                {
                    directoryFiles.Add(new MyFile
                    {
                        Name = file.Name,
                        Path = directoryPath,
                        Size = file.Size,
                        status = FileStatus.Download,
                        LastWriteTime = file.LastWrite,
                        IsDirectory = false,
                        FileId = file.FileId,
                        ParentDirectoryId=file.DirectoryId
                    });
                }

                //добавление списка вложенных директорий
                foreach (Directory directory in directories)
                {

                    directoryFiles.Add(new MyFile{
                        Name = directory.Name,
                        Path = (directoryPath + "\\" + directory.Name).Replace("\\\\","\\"),
                        Size = 0,
                        status = FileStatus.Download,
                        LastWriteTime = directory.Created,
                        IsDirectory = true,
                        FileId = directory.DirectoryId,
                        ParentDirectoryId=directory.ParentId
                    });

                    if (recursive)
                    {
                        List<MyFile> subFiles = GetDirectoryFiles(directory.DirectoryId, recursive, userEmail, userPass);
                        foreach (MyFile file in subFiles)
                            directoryFiles.Add(file);
                    }
                }
            }
            return directoryFiles;
        }



        // проверяет доступное дисковое простанство для заливки файла
        public bool CanUploadFile(long fileSize, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);

            if (!FileModel.Instance.IsCanUploadFile(userInfo.UserId, userInfo.SpaceLimit, fileSize))
                return false;
            return true;
        }


        //сохраняет файл на сервере
        public void UploadFile(FileUploadMessage uploadMessage)
        {
            // получение инфы пользователя
            User userInfo = UserModel.Instance.GetUser(uploadMessage.userEmail, uploadMessage.userPass);

            if (!FileModel.Instance.IsCanUploadFile(userInfo.UserId, userInfo.SpaceLimit, uploadMessage.file.Size))
                throw new Exception("DiskSpacelimit");


            logger.Info("Получение файла: {0}, с клиента: {1}", uploadMessage.file.ToString(), uploadMessage.userEmail);

            string saveFilePath = GetFileSavePath();
            FileStream outputStream = new FileStream(saveFilePath, FileMode.Create, FileAccess.Write);

            try
            {
                uploadMessage.sourceStream.CopyTo(outputStream);
                uploadMessage.sourceStream.Close();
            }
            catch (IOException ex)// клиент закрыл поток
            {
                logger.Error("Клиент закрыл соединение. " + ex.Message);
            }

            outputStream.Close();
            FileInfo savedFileInfo = new FileInfo(saveFilePath);

            logger.Debug("Исходный файл:{0}, Полученный файл:{1}", uploadMessage.file.Size, savedFileInfo.Length);
            if (uploadMessage.file.Size != savedFileInfo.Length)
            {
                logger.Error("Размер файл полученного файла не соответствует исходному. Полученный файл будет удален!");
                System.IO.File.Delete(saveFilePath);
            }
            else
            { // сохраняем в БД

                if (!DirectoryModel.Instance.Exist(uploadMessage.file.Path, userInfo.UserId))
                    DirectoryModel.Instance.CreateDirectory(userInfo.UserId, uploadMessage.file.Path, false);

                Directory directory = DirectoryModel.Instance.GetDirectory(uploadMessage.file.Path, userInfo.UserId);

                // если файл существует делаем его неактивным
                bool existFile = FileModel.Instance.Exist(directory.DirectoryId, uploadMessage.file.Name, userInfo.UserId);
                if (existFile)
                {
                    File oldFile = FileModel.Instance.GetFile(directory.DirectoryId, uploadMessage.file.Name, userInfo.UserId);
                    FileModel.Instance.MakeFileNotActive(oldFile.FileId, userInfo.UserId);
                }

                FileModel.Instance.CreateFile(userInfo.UserId, uploadMessage.file.Name, saveFilePath.Replace(StorageFolder, ""), directory.DirectoryId, false, uploadMessage.file.Size);
                File fileInfo = FileModel.Instance.GetFile(directory.DirectoryId, uploadMessage.file.Name, userInfo.UserId);
                if (existFile)
                    EventModel.Instance.CreateEvent(userInfo.UserId, "Изменен", fileInfo.FileId);
                else
                    EventModel.Instance.CreateEvent(userInfo.UserId, "Добавлен", fileInfo.FileId);
            }
            logger.Info("Сделано");
        }


        //возвращает временный путь
        private string GetFileSavePath()
        {
            string randomFilePath = StorageFolder + "\\" + getRandomHash(32, true);
            if (!System.IO.Directory.Exists(randomFilePath))
                System.IO.Directory.CreateDirectory(randomFilePath);
            string randomFileName = getRandomHash(10, false) + ".file";
            return randomFilePath + randomFileName;
        }


        //возвращает случайный хеш
        public string getRandomHash(int length, bool withSlash)
        {
            string result = string.Empty;
            Random random = new Random();
            for (int i = 1; i <= length; i++)
            {
                char ch = Convert.ToChar(random.Next(97, 122));
                result += ch;
                if (withSlash && i % 4 == 0)
                    result += '\\';
            }
            return result;
        }


        // физическое удаление файла без поддержки версионности
        public void ____DeleteFile(string path, string fileName, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);

            if (DirectoryModel.Instance.Exist(path, userInfo.UserId))
            {
                Directory directoryInfo = DirectoryModel.Instance.GetDirectory(path, userInfo.UserId);
                if (FileModel.Instance.Exist(directoryInfo.DirectoryId, fileName, userInfo.UserId))
                {
                    File fileInfo = FileModel.Instance.GetFile(directoryInfo.DirectoryId, fileName, userInfo.UserId);
                    FileModel.Instance.DeleteFile(fileInfo.FileId, userInfo.UserId);
                    string rootFilePatch = fileInfo.PhysicalPath.Remove(fileInfo.PhysicalPath.IndexOf('\\', 5));
                    if (System.IO.Directory.Exists(StorageFolder + rootFilePatch))
                        System.IO.Directory.Delete(StorageFolder + rootFilePatch, true);
                }
                logger.Debug("Удаление файла:{0}, пользователь:{1} ", path + "\\" + fileName, userEmail);
            }
        }


        // физическое удаление файла с поддержкой версионности (файл фактически делается не актуальным)
        public void DeleteFile(int fileId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            if (FileModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                FileModel.Instance.MakeFileNotActive(fileId, userInfo.UserId);
                EventModel.Instance.CreateEvent(userInfo.UserId, "Удален", fileId);
                logger.Debug("Не физическое удаление файла:{0}, пользователь:{1} ", fileId, userEmail);
            }
        }


        //добавление диретории
        public void CreateDirectory(string patch, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            
            if (patch == "\\")
                throw new Exception("NameEmpty");

            if (!DirectoryModel.Instance.Exist(patch, userInfo.UserId))
            {
                logger.Debug("Создание каталога: {0}, пользователя: {1}", patch, userEmail);
                DirectoryModel.Instance.CreateDirectory(userInfo.UserId, patch, false);
            }
            else
                throw new Exception("NameIsBusy");
        }


        //возвращает родительскую диреторию
        public int GetParentDirectoryId(int directoryId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            logger.Debug("Получение каталога: {0}, пользователя: {1}", directoryId, userEmail);

            if (directoryId == 1) return 0;

            Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(directoryId, userInfo.UserId);
            return directoryInfo.ParentId;
        }


        //возвращает информацию о файле диреторию
        public MyFile GetDirectory(int directoryId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            logger.Debug("Получение каталога: {0}, пользователя: {1}", directoryId, userEmail);

            if (directoryId == 1)
            {

                Directory directoryInfo = DirectoryModel.Instance.GetRootDirectory(userInfo.UserId);
                return new MyFile{
                    Name = directoryInfo.Name,
                    Path = "",
                    Size = 0,
                    status = FileStatus.Download,
                    LastWriteTime = directoryInfo.Created,
                    IsDirectory = true,
                    FileId = directoryInfo.DirectoryId,
                    ParentDirectoryId = directoryInfo.ParentId
                };
            }

            if (DirectoryModel.Instance.ExistById(directoryId, userInfo.UserId))
            {
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(directoryId, userInfo.UserId);
                return new MyFile{
                    Name = directoryInfo.Name,
                    Path = DirectoryModel.Instance.GetDirectoryPath(directoryId, userInfo.UserId),
                    Size = 0,
                    status = FileStatus.Download,
                    LastWriteTime = directoryInfo.Created,
                    IsDirectory = true,
                    FileId = directoryInfo.DirectoryId,
                    ParentDirectoryId = directoryInfo.ParentId
                };
            }

            throw new Exception("DirectoryNotFound");
        }


        //возвращает информацию о файле
        public MyFile GetFile(int fileId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            logger.Debug("Получение информации о файле: {0}, пользователь: {1}", fileId, userEmail);

            if (FileModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                File fileInfo = FileModel.Instance.GetFileById(fileId, userInfo.UserId);
                return new MyFile
                {
                    Name = fileInfo.Name,
                    Path = DirectoryModel.Instance.GetDirectoryPath(fileInfo.DirectoryId, userInfo.UserId),
                    Size = fileInfo.Size,
                    status = FileStatus.Download,
                    LastWriteTime = fileInfo.LastWrite,
                    IsDirectory = true,
                    FileId = fileInfo.FileId,
                    ParentDirectoryId = fileInfo.DirectoryId
                };
            }
            throw new Exception("FileNotFound");
        }


        //перемещение файла/диретории
        public void Move(int fileId, int parentDirectoryId, int isDirectory, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);

            if (parentDirectoryId == 1)
            {
                Directory directoryInfo = DirectoryModel.Instance.GetRootDirectory(userInfo.UserId);
                parentDirectoryId = directoryInfo.DirectoryId;
            }

            if (parentDirectoryId == 0)
                throw new Exception("ParentIdIsNull");

            if (fileId == parentDirectoryId)
                throw new Exception("DirectoriesHaveSameIDs");
            
            if (DirectoryModel.Instance.ExistDirectoryInMovedPath(fileId, parentDirectoryId, userInfo.UserId))
                throw new Exception("DirectoryMovedInItSelf");

            if (DirectoryModel.Instance.ExistById(parentDirectoryId, userInfo.UserId) && fileId != parentDirectoryId && fileId != 0 && parentDirectoryId != 0)
            {
                if (isDirectory == 1 && DirectoryModel.Instance.ExistById(fileId, userInfo.UserId))
                {
                    logger.Debug("Перемещение каталога: {0} в каталог:{1} , пользователя: {2}", fileId, parentDirectoryId, userEmail);
                    DirectoryModel.Instance.Move(fileId, parentDirectoryId, userInfo.UserId);
                }
                if (isDirectory == 0 && FileModel.Instance.ExistById(fileId, userInfo.UserId))
                {
                    logger.Debug("Перемещение файла: {0} в каталог:{1} , пользователя: {2}", fileId, parentDirectoryId, userEmail);
                    FileModel.Instance.Move(fileId, parentDirectoryId, userInfo.UserId);
                }
            }
            else
                throw new Exception("ParentDirectoryNotExist");
        }


        //копирование файла/диретории
        public void Copy(int sourceFileId, int outputDirectoryId, int isDirectory, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);

            if (outputDirectoryId == 1)
            {
                Directory directoryInfo = DirectoryModel.Instance.GetRootDirectory(userInfo.UserId);
                outputDirectoryId = directoryInfo.DirectoryId;
            }

            if (outputDirectoryId == 0)
                throw new Exception("ParentIdIsNull");

            if (sourceFileId == outputDirectoryId)
                throw new Exception("DirectoriesHaveSameIDs");

            if (DirectoryModel.Instance.ExistById(outputDirectoryId, userInfo.UserId) && sourceFileId != outputDirectoryId && sourceFileId != 0 && outputDirectoryId != 0)
            {
                if (isDirectory == 1 && DirectoryModel.Instance.ExistById(sourceFileId, userInfo.UserId))
                {
                    logger.Debug("Перемещение каталога: {0} в каталог:{1} , пользователя: {2}", sourceFileId, outputDirectoryId, userEmail);
                    CopyDirectory(sourceFileId, outputDirectoryId, userInfo.UserId);
                }
                if (isDirectory == 0 && FileModel.Instance.ExistById(sourceFileId, userInfo.UserId))
                {
                    logger.Debug("Перемещение файла: {0} в каталог:{1} , пользователя: {2}", sourceFileId, outputDirectoryId, userEmail);
                    CopyFile(sourceFileId, outputDirectoryId, userInfo.UserId);
                }
            }
            else
                throw new Exception("ParentDirectoryNotExist");
        }


        //переименование файла/диретории
        public void Rename(int fileId, string newName, int isDirectory, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);

            if (fileId == 0)
                throw new Exception("FileNotSelected");

            if (newName.Length == 0)
                throw new Exception("EmptyNewName");

            if (isDirectory == 1 && DirectoryModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(fileId, userInfo.UserId);
                if (DirectoryModel.Instance.ExistByName(newName, directoryInfo.ParentId, userInfo.UserId))
                    throw new Exception("NameIsBusy");

                logger.Debug("Переименование каталога: {0} на :{1} , пользователя: {2}", fileId, newName, userEmail);
                DirectoryModel.Instance.Rename(fileId, newName, userInfo.UserId);
            }
            if (isDirectory == 0 && FileModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                File fileInfo = FileModel.Instance.GetFileById(fileId, userInfo.UserId);
                if (FileModel.Instance.ExistByName(newName, fileInfo.DirectoryId, userInfo.UserId))
                    throw new Exception("NameIsBusy");

                logger.Debug("Переименование файла: {0} на:{1} , пользователя: {2}", fileId, newName, userEmail);
                FileModel.Instance.Rename(fileId, newName, userInfo.UserId);
            }
        }


        // копирует диреторию
        public void CopyDirectory(int sourceDirectoryId, int outputDirectoryId, int userId)
        {
            List<File> directoryFiles = FileModel.Instance.GetDirectoryFiles(sourceDirectoryId, userId);
            List<Directory> subDirectories = DirectoryModel.Instance.GetChildDirectories(sourceDirectoryId, userId);

            outputDirectoryId = DirectoryModel.Instance.Copy(sourceDirectoryId, outputDirectoryId, userId);

            foreach (File directoryFile in directoryFiles)
                CopyFile(directoryFile.FileId, outputDirectoryId, userId);

            foreach (Directory subDirectory in subDirectories)
                CopyDirectory(subDirectory.DirectoryId, outputDirectoryId, userId);
        }


        // копирует файл
        public void CopyFile(int fileId, int outputDirectoryId, int userId)
        {
            File fileInfo = FileModel.Instance.GetFileById(fileId, userId);
            string fileSavePath= GetFileSavePath();
            System.IO.File.Copy(StorageFolder + fileInfo.PhysicalPath, fileSavePath);
            FileModel.Instance.CreateFile(userId, fileInfo.Name, fileSavePath.Replace(StorageFolder, ""), outputDirectoryId, false, fileInfo.Size);
        }


        //удаление каталога
        public void DeleteDirectory(int directoryId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            if (DirectoryModel.Instance.ExistById(directoryId, userInfo.UserId))
            {
                logger.Debug("Рекурсивное удаление каталога: {0}, пользователя: {1}", directoryId, userEmail);

                List<File> directoryFiles = FileModel.Instance.GetDirectoryFiles(directoryId, userInfo.UserId);
                List<Directory> childDirectories = DirectoryModel.Instance.GetChildDirectories(directoryId, userInfo.UserId);

                //удаление всех файлов директории
                foreach (File file in directoryFiles)
                    DeleteFile(file.FileId, userEmail, userPass);

                //удаление всех вложенных директорий
                foreach (Directory directory in childDirectories)
                    DeleteDirectory(directory.DirectoryId, userEmail, userPass);

                //делаем не актуальным каталог в БД
                DirectoryModel.Instance.MakeFileNotActive(directoryId, userInfo.UserId);
            }
        }


        //возвращает вложенные диретории подготовленные для Dynatree(сайт) 
        public List<DynaTreeNode> GetDirectorySubDirectories(int directoryId, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            List<DynaTreeNode> returnSubDirectories = new List<DynaTreeNode>();

            if (directoryId == 0)
            {
                Directory directoryInfo = DirectoryModel.Instance.GetRootDirectory(userInfo.UserId);
                directoryId = directoryInfo.DirectoryId;
            }

            List<Directory> subDirectories = DirectoryModel.Instance.GetChildDirectories(directoryId, userInfo.UserId);
            foreach (Directory subDirectory in subDirectories)
            {
                returnSubDirectories.Add(new DynaTreeNode
                {
                    key = subDirectory.DirectoryId,
                    isFolder = true,
                    title = subDirectory.Name,
                    isLazy = true,
                });
            }
            return returnSubDirectories;
        }


        //возвращает путь для файла/диретории
        public string GetFilePath(int fileId, int isDirectory, string userEmail, string userPass)
        {
            User userInfo = UserModel.Instance.GetUser(userEmail, userPass);
            if (fileId == 1)
                return "";
            if (isDirectory == 1 && DirectoryModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                logger.Debug("Получение пути для каталога: {0} , пользователя: {1}", fileId, userEmail);
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(fileId, userInfo.UserId);
                return DirectoryModel.Instance.GetDirectoryPath(directoryInfo.DirectoryId, userInfo.UserId);
            }
            if (isDirectory == 0 && FileModel.Instance.ExistById(fileId, userInfo.UserId))
            {
                logger.Debug("Получение пути для каталога: {0} , пользователя: {1}", fileId, userEmail);
                File fileInfo = FileModel.Instance.GetFileById(fileId, userInfo.UserId);
                Directory directoryInfo = DirectoryModel.Instance.GetDirectoryById(fileInfo.DirectoryId, userInfo.UserId);
                return DirectoryModel.Instance.GetDirectoryPath(directoryInfo.DirectoryId, userInfo.UserId);
            }
            throw new Exception("FileNotExist");
        }

    }
}
