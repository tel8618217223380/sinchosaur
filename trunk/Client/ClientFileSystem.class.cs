using System;
using System.Collections.Generic;
using System.Text;

using Client.ServiceReference;

using System.IO;
using NLog;
using System.Threading;

namespace Client
{
    class ClientFileSystem
    {
        public static readonly ClientFileSystem Instance = new ClientFileSystem();

        static ClientFileSystem() { }

        string StorageFolder = Properties.Settings.Default.StorageFolder;

        private static Logger logger = LogManager.GetCurrentClassLogger();

        //--------------------------------------------------------------------------------
        private void CheckFolderExist(string folderName)
        {
            if (folderName == "")
                throw new Exception("StorageFolder is empty!");

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
        }
        //--------------------------------------------------------------------------------

        //возвращает список файлов на клиенте
        public List<MyFile> GetFilesList()
        {
            return GetDirectoryFiles("\\");
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public void CreateDirectory(string path)
        {
            if (path != "")
                Directory.CreateDirectory(StorageFolder + path);
        }
        //--------------------------------------------------------------------------------

        public  void DeleteDirectory(string path)
        {
            if (path != "" && Directory.Exists(StorageFolder + path))
            {
                _DeleteDirectory(StorageFolder + path);
            }
        }
         

        //удаление директории
        //исправление бага с эксепшеном http://stackoverflow.com/questions/329355/cannot-delete-directory-with-directory-deletepath-true
        public  void _DeleteDirectory(string path)
        {
            if (path != "" && Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);

                foreach (string file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (string dir in dirs)
                {
                    _DeleteDirectory(dir);
                }
                Directory.Delete(path, false);
            }
        }


        //возвращает список файлов на клиенте в заданной директории
        public List<MyFile> GetDirectoryFiles(string DirectoryName)
        {
            CheckFolderExist(StorageFolder);

            string forderPath = StorageFolder + DirectoryName;
            List<MyFile> files = new List<MyFile>();

           
            string[] directoryFiles = Directory.GetFiles(forderPath);
            
            foreach (string file in directoryFiles)
            {
                try
                {
                    FileStream fs = File.OpenRead(file);
                    fs.Close();
                }
                catch (IOException)
                {
                    continue;
                }
                
                FileInfo fileInfo = new FileInfo(file);
                string pathFile = fileInfo.DirectoryName.Replace(StorageFolder, "");
                if (pathFile == "") pathFile = "\\";
                files.Add(new MyFile(){
                    Name = fileInfo.Name,
                    Path = pathFile,
                    Size = fileInfo.Length,
                    status = FileStatus.Upload,
                    LastWriteTime = GetLastFileAccess(fileInfo)
                });
                  
            }

            string[] directories = Directory.GetDirectories(forderPath);
            foreach (string directory in directories)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                files.Add(new MyFile()
                {
                    Name = directory.Remove(0, directory.LastIndexOf('\\') + 1),
                    Path = directory.Replace(StorageFolder, ""),
                    Size = 0,
                    status = FileStatus.Upload,
                    LastWriteTime = directoryInfo.LastWriteTime,
                    IsDirectory=true
                });

                List<MyFile> subFiles = GetDirectoryFiles(directory.Replace(StorageFolder, ""));
                foreach (MyFile file in subFiles)
                    files.Add(file);
            }
            return files;
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        private DateTime GetLastFileAccess(FileInfo fileInfo)
        {
                return fileInfo.LastWriteTime;
        }
        //--------------------------------------------------------------------------------

        //сохраняет файл
        public void DownloadFile(StreamWithProgress fileSourceStream, MyFile file )
        {
            logger.Debug("Получение файла с сервера " + file.ToString());

            string fileFullPath = StorageFolder + "\\" + file.Path + "\\" + file.Name;

            FileStream outputStream = GetFileStream(file.Path, file.Name);

            try
            {
                fileSourceStream.CopyTo(outputStream);
                fileSourceStream.Close();
            }
            catch (IOException ex)// клиент закрыл поток
            {
                logger.Error("Сервер закрыл соединение. " + ex.Message);
            }

            outputStream.Close();
            FileInfo savedFileInfo = new FileInfo(fileFullPath);
            logger.Debug("Исходный файл:{0}, Полученный файл:{1}", file.Size, savedFileInfo.Length);
            if (file.Size != savedFileInfo.Length)
            {
                logger.Error("Размер файл полученного файла не соответствует исходному. Полученный файл будет удален!");
            }
            logger.Info("Сделано");
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public FileStream GetFileStream(string FileDirectoty, string FileName)
        {
            CheckFolderExist(StorageFolder + FileDirectoty);

            if (!Directory.Exists(StorageFolder + FileDirectoty))
                Directory.CreateDirectory(StorageFolder + FileDirectoty);

            string fileFullPath = StorageFolder + FileDirectoty + "\\" + FileName;
            return new FileStream(fileFullPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }
        //--------------------------------------------------------------------------------


        //--------------------------------------------------------------------------------
        public void DeleteFile(string FileDirectoty, string FileName)
        {
            if (File.Exists(StorageFolder + FileDirectoty + "\\" + FileName))
            {
                File.Delete(StorageFolder + FileDirectoty + "\\" + FileName);
                logger.Info("Удаление файла:{0}, каталог:{1}", FileName, FileDirectoty);
            }

        }
        //--------------------------------------------------------------------------------

        //--------------------------------------------------------------------------------
        public void DeleteLastSinronizateFilesList()
        {
            if (File.Exists("LastSinchronizeServerFilesList.dat"))
            {
                File.Delete("LastSinchronizeServerFilesList.dat");
                logger.Info("Удаление списка файлов после последней синхронизации");
            }
            StorageFolder = Properties.Settings.Default.StorageFolder;

        }
        //--------------------------------------------------------------------------------

    }
}
