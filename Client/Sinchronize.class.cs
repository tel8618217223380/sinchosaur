using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.FileSystemServiceReference;
using System.IO;
using System.ComponentModel;
using System.ServiceModel;

using NLog;

namespace Client
{
    public delegate void ChangeSinchronizeStatus(Sinchronize sender, SinchronizeStatus SinchronizeStatus);
    public delegate void ProcessFileInfo(Sinchronize sender, ProgressFileInfo ProgressFileInfo);
    public delegate void CreateFileListForSincronization(Sinchronize sender, List<MyFile> filesForSinchronize);

    //состояние процесса синхронизации
    public enum SinchronizeStatus
    {
        ServerNotAvailable,
        GetServerFilesList,
        SinchronizeStarted,
        SinchronizeFinished,
        GetFilesListForSinchronize,
        NoFilesChanges,
        UserNotExist,
        ServerUrlNotCorrect,
        DiskSpacelimit
    }

    // состояние прогресса синхронизации файла
    public class ProgressFileInfo
    {
        public MyFile File;// название файла
        public int ProgressProcent; // процент выполнения
        public long ProgressBytes; // количество обработанных байт
        public FileStatus Action; // действие над файлов

        public override string ToString()
        {
            return Action.ToString() + " " + File.Name + ", catalog; " + File.Path; 
        }
    }
        
    // класс синхронизации
    public class Sinchronize
    {

        // изменено состояние процесса синхронизации
        public event ChangeSinchronizeStatus OnChangeSinchronizeStatus;

        // изменение файла
        public event ProcessFileInfo OnProcessFileInfo;

        // получен список измененых файлов
        public event CreateFileListForSincronization OnCreateFileListForSincronization;

        // состояние прогресса синхронизации файла
        public ProgressFileInfo SinchronizeFileProgressInfo = new ProgressFileInfo();

        //файлы для синхронизации
        public List<MyFile> filesForSinchronize = new List<MyFile>();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        //запуск синхронизации        
        public void Start()
        {
            try
            {
                ServerFileSystem.Instance.Init();

                GetFilesListForSinchronize();

                if (filesForSinchronize.Count == 0 && OnChangeSinchronizeStatus != null)
                    OnChangeSinchronizeStatus(this, SinchronizeStatus.NoFilesChanges);
                else
                {
                    Sinchronizing(filesForSinchronize); // синхронизация
                    ServerFileSystem.Instance.SaveLastSinchronazeFilesList(); // сохранение состояния сервера
                    UpdateLastSinchronizeTime();
                }
            }           

            catch (EndpointNotFoundException)
            {
                if (OnChangeSinchronizeStatus != null)
                    OnChangeSinchronizeStatus(this, SinchronizeStatus.ServerNotAvailable);
            }

            catch (UriFormatException)
            {
                if (OnChangeSinchronizeStatus != null)
                    OnChangeSinchronizeStatus(this, SinchronizeStatus.ServerUrlNotCorrect);
            }    
           
            catch (Exception ex)
            {
                switch (ex.Message)
                {
                    case "UserNotExist":
                        if (OnChangeSinchronizeStatus != null)
                            OnChangeSinchronizeStatus(this, SinchronizeStatus.UserNotExist);
                        break;
                    case "DiskSpacelimit":
                        if (OnChangeSinchronizeStatus != null)
                            OnChangeSinchronizeStatus(this, SinchronizeStatus.DiskSpacelimit);
                        break;

                    default:
                        logger.Fatal(ex.ToString());
                        Console.Write(ex.ToString());
                        break;
                }
            }         
        }
        

        // возвращает список файлов для синхронизации
        private void GetFilesListForSinchronize()
        {
            // получает список файлов сервера
            if (OnChangeSinchronizeStatus != null)
                OnChangeSinchronizeStatus(this, SinchronizeStatus.GetServerFilesList);
            
            List<MyFile> serverFiles = ServerFileSystem.Instance.GetFilesList();

            // получает список файлов клиента
            List<MyFile> clientFiles = ClientFileSystem.Instance.GetFilesList();

            // получает список файлов сервера после последней синхронизации

            List<MyFile> lastSinchronizeServerFiles = ServerFileSystem.Instance.GetLastSinchronazeFilesList();

            //получает список файлов для обновления
            filesForSinchronize = GetFilesListStatus(serverFiles, clientFiles, lastSinchronizeServerFiles);
            if (OnCreateFileListForSincronization != null)
                OnCreateFileListForSincronization(this, filesForSinchronize);
            
        }


        // уставливает статус для списка файлов
        private List<MyFile> GetFilesListStatus(List<MyFile> serverFiles, List<MyFile> clientFiles, List<MyFile> lastSinchronizeServerFiles)
        {
            if (OnChangeSinchronizeStatus != null)
                OnChangeSinchronizeStatus(this, SinchronizeStatus.GetFilesListForSinchronize);

            List<MyFile> filesListForUpdate = new List<MyFile>();

            DateTime lastSinchronizeTime = GetLastSinchronizeTime();
            foreach (MyFile serverFile in serverFiles)
            {
                var clientFileList = FindFileInFileList(serverFile.Path, serverFile.Name, clientFiles);

                if (clientFileList.Count<MyFile>() > 0) // если такой клиенский  файл существует
                {
                    if(!serverFile.IsDirectory)
                    {
                        var serverOldFile = FindFileInFileList(serverFile.Path, serverFile.Name, lastSinchronizeServerFiles);
                        if (serverFile.LastWriteTime > lastSinchronizeTime)// если серверный файл был обновлен после синхронизации
                            filesListForUpdate.Add(CreateFileWithChangeStatus(serverFile, FileStatus.Download));
                        else
                            if (clientFileList.First<MyFile>().LastWriteTime > lastSinchronizeTime) // если клиентский файл был обновлен после синхронизации
                                filesListForUpdate.Add(CreateFileWithChangeStatus(clientFileList.First<MyFile>(), FileStatus.Upload));
                    }
                }
                else// если клиентский файл не существует
                {
                    var oldServerFile = FindFileInFileList(serverFile.Path, serverFile.Name, lastSinchronizeServerFiles);
                    if (oldServerFile.Count<MyFile>() > 0)//если файл на сервере уже был то удаляем
                        filesListForUpdate.Add(CreateFileWithChangeStatus(serverFile, FileStatus.Delete));
                    else // если отсутствовал у клиента то скачиваем
                        filesListForUpdate.Add(CreateFileWithChangeStatus(serverFile, FileStatus.Download));

                }
            }

            // перебор клиенских файлов
            foreach (MyFile clientFile in clientFiles)
            {
                var serverFile = FindFileInFileList(clientFile.Path, clientFile.Name, serverFiles); // поиск такого же серверного файла
                var oldServerFile = FindFileInFileList(clientFile.Path, clientFile.Name, lastSinchronizeServerFiles); // поиск такого же старого серверного файла
                if (serverFile.Count<MyFile>() == 0 && oldServerFile.Count<MyFile>() == 0) // если такой файл на сервере нет существует и не существовал
                    filesListForUpdate.Add(clientFile);
                if (serverFile.Count<MyFile>() == 0 && oldServerFile.Count<MyFile>() > 0) // если такой файл на сервере нет существует и но существовал
                    filesListForUpdate.Add(CreateFileWithChangeStatus(clientFile, FileStatus.Delete));

            }

            return filesListForUpdate;
        }
        

        //синхронизирует файлы
        private void Sinchronizing(List<MyFile> filesForSinchronize)
        {
            if (OnChangeSinchronizeStatus != null)
                OnChangeSinchronizeStatus(this, SinchronizeStatus.SinchronizeStarted);

            foreach (MyFile file in filesForSinchronize)
            {
                SinchronizeFileProgressInfo.File = file;
                SinchronizeFileProgressInfo.ProgressBytes = 0;
                SinchronizeFileProgressInfo.ProgressProcent = 0;
                SinchronizeFileProgressInfo.Action=file.status;

                if (OnProcessFileInfo != null)
                    OnProcessFileInfo(this, SinchronizeFileProgressInfo);
                
                if (file.status == FileStatus.Delete)
                {
                    if (file.IsDirectory)
                    {
                        ClientFileSystem.Instance.DeleteDirectory(file.Path);
                        ServerFileSystem.Instance.DeleteDirectory(file.FileId);
                    }
                    else
                    {
                        ServerFileSystem.Instance.DeleteFile(file.FileId);
                        ClientFileSystem.Instance.DeleteFile(file.Path, file.Name);
                    }
                }

                if (file.status == FileStatus.Download)
                {
                    if (file.IsDirectory)
                        ClientFileSystem.Instance.CreateDirectory(file.Path);
                    else
                    {
                        StreamWithProgress fileSourceStream = new StreamWithProgress(ServerFileSystem.Instance.GetFileStream(file.FileId));
                        fileSourceStream.ProgressChanged += SetProgressInfoData;
                        ClientFileSystem.Instance.DownloadFile(fileSourceStream, file);
                    }
                }
                if (file.status == FileStatus.Upload)// если update
                {
                    if (file.IsDirectory)
                        ServerFileSystem.Instance.CreateDirectory(file.Path);
                    else
                    {
                        if (!ServerFileSystem.Instance.CanUploadFile(file.Size))
                        {
                            if (OnChangeSinchronizeStatus != null)
                                OnChangeSinchronizeStatus(this, SinchronizeStatus.DiskSpacelimit);
                            continue;
                        }

                        using (FileStream fileStream = ClientFileSystem.Instance.GetFileStream(file.Path, file.Name))
                        {
                            StreamWithProgress fileSourceStream = new StreamWithProgress(fileStream);
                            fileSourceStream.ProgressChanged += SetProgressInfoData;
                            file.SizeSpecified = true;
                            ServerFileSystem.Instance.UploadFile(file, fileSourceStream );
                        }
                    }

                }
            }
            if (OnChangeSinchronizeStatus != null)
                OnChangeSinchronizeStatus(this, SinchronizeStatus.SinchronizeFinished);
        }


        //проверяет существование файла в коллекции файлов
        private IEnumerable<MyFile> FindFileInFileList(string FileDirectory, string FileName, List<MyFile> files)
        {
            return from file in files
                   where file.Path == FileDirectory && file.Name == FileName
                   select file;
        }
        

        //возвращает дату последней синхронизации
        private DateTime GetLastSinchronizeTime()
        {
            return Properties.Settings.Default.LastCheckTime;
        }
        
        
        //обновляет дату последней синхронизации
        private void UpdateLastSinchronizeTime()
        {
            Properties.Settings.Default.LastCheckTime = DateTime.Now.AddSeconds(3);
            Properties.Settings.Default.Save();
        }
        

        //устанавливает прогресс синхронизации
        void SetProgressInfoData(object sender, StreamWithProgress.ProgressChangedEventArgs e)
        {
            SinchronizeFileProgressInfo.ProgressBytes = e.BytesRead; // количество обработанных байт
            SinchronizeFileProgressInfo.ProgressProcent = 0;
            if (e.BytesRead > 0)
            {
                float progressProcent = ((float)(e.BytesRead / 1024)) / ((float)(SinchronizeFileProgressInfo.File.Size / 1024));
                if (progressProcent<100)
                    SinchronizeFileProgressInfo.ProgressProcent = (int)(progressProcent * 100); // процент обработки
            }
        }
        

        //создание структуры MyFile с новым статусом
        private MyFile CreateFileWithChangeStatus(MyFile file, FileStatus status)
        {
            return new MyFile()
            {
                Name = file.Name,
                Path = file.Path,
                Size = file.Size,
                status = status,
                IsDirectory=file.IsDirectory,
                LastWriteTime = file.LastWriteTime,
                FileId = file.FileId
            };
        }


        //проверяет существование такого пользователя на сервере
        private bool ExistAccount()
        {
            return Account.Exist();
        }
        
    }
}
