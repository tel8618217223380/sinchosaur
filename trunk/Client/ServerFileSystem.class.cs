using System;
using System.Collections.Generic;
using System.Text;
using Client.ServiceReference;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;

namespace Client
{
    public class ServerFileSystem
    {
        public static readonly ServerFileSystem Instance = new ServerFileSystem();
        private FileSystemClient serverFileSystem ;
        static ServerFileSystem(){}


        
        public ServerFileSystem() 
        {
            string ServerRemoteAddress = "http://" + Properties.Settings.Default.ServerRemoteAddress + "/FileSystem/";
            serverFileSystem = new FileSystemClient("BasicHttpBinding_IFileSystem", new EndpointAddress(ServerRemoteAddress));
        }
        

        //возвращает список файлов на сервере
        public List<MyFile> GetFilesList()
        {
            MyFile[] serverFiles = serverFileSystem.GetAllFiles(Account.GetUserEmail(), Account.GetUserPass());

            List<MyFile> serverFileslist = new List<MyFile>();
            foreach (MyFile serverFile in serverFiles)
                serverFileslist.Add(serverFile);
            return serverFileslist;
        }
        

        //возвращает список файлов после последней синхронизации
        public List<MyFile> GetLastSinchronazeFilesList()
        {
            return LoadFromBinaryFile("LastSinchronizeServerFilesList.dat");
        }
        

        //возвращает список файлов после последней синхронизации
        public void SaveLastSinchronazeFilesList()
        {
            SaveAsBinaryFormat(GetFilesList(), "LastSinchronizeServerFilesList.dat");
        }
        

        //сериализация объекта 
        void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            // Сохранить объект в файл CarData.dat в двоичном виде.
            BinaryFormatter binFormat = new BinaryFormatter();
            using (Stream fStream = new FileStream(fileName,
            FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }
        }
        

        //десериализация объекта
        private List<MyFile> LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            List<MyFile> serverFiles = new List<MyFile>();
            if (!File.Exists(fileName))
            {
                return serverFiles;
            }
            using (Stream fStream = File.OpenRead(fileName))
            {
                serverFiles = (List<MyFile>)binFormat.Deserialize(fStream);
            }
            return serverFiles;
        }
        

        //возвращает поток заданного файла
        public Stream GetFileStream(int fileId)
        {
            return serverFileSystem.GetFileStream(fileId, Account.GetUserEmail(), Account.GetUserPass());
            
        }
        

        //удаляет диреторию на сервере
        public void DeleteDirectory(int directoryId)
        {
            serverFileSystem.DeleteDirectory(directoryId, Account.GetUserEmail(), Account.GetUserPass());
        }
        

        //создает диреторию на сервере
        public void CreateDirectory(string path)
        {
            serverFileSystem.CreateDirectory(path, Account.GetUserEmail(), Account.GetUserPass());
        }
        

        //отправялет файл на сервер
        public void UploadFile(MyFile file, StreamWithProgress stream)
        {
            serverFileSystem.UploadFile(file, Account.GetUserEmail(), Account.GetUserPass(), stream);
        }
        

        //удаляет файл
        public void DeleteFile(int directoryId)
        {
            serverFileSystem.DeleteFile(directoryId, Account.GetUserEmail(), Account.GetUserPass());
        }
        
    }
}
