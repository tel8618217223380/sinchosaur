using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace Server.Service
{
    [ServiceContract]
   public interface IFileSystem
    {
        //возвращает все файлы/диретории пользователя
        [OperationContract]
        List<MyFile> GetAllFiles(string userEmail, string userPass);


        //возвращает поток StreamWithProgress упакованный в Stream
        [OperationContract]
        Stream GetFileStream(int fileId, string userEmail, string userPass);


        //возвращает каталог
        [OperationContract]
        MyFile GetDirectory(int directoryId, string userEmail, string userPass);

        //возвращает каталог
        [OperationContract]
        MyFile GetFile(int fileId, string userEmail, string userPass);


        //возвращает id родительского каталога
        [OperationContract]
        int GetParentDirectoryId(int directoryId, string userEmail, string userPass);


        //возвращает все файлы/диретории пользователя в указанной диретории
        [OperationContract]
        List<MyFile> GetDirectoryFiles(int directoryId, bool recursive, string userEmail, string userPass);


        //добавление файла
        [OperationContract]
        void UploadFile(FileUploadMessage clienMessage);


        //удаление файла
        [OperationContract]
        void DeleteFile(int fileId, string userEmail, string userPass);


        //добавление директории
        [OperationContract]
        void CreateDirectory(string path, string userEmail, string userPass);


        //удаление директории
        [OperationContract]
        void DeleteDirectory(int directoryId, string userEmail, string userPass);


        //возвращает вложенные диретории для dynatree на сайте
        [OperationContract]
        List<DynaTreeNode> GetDirectorySubDirectories(int directoryId, string userEmail, string userPass);


        //перемещение файла/диретории
        [OperationContract]
        void Move(int fileId, int directoryId, int isDirectory, string userEmail, string userPass);

        //копирование файла/диретории
        [OperationContract]
        void Copy(int sourceFileId, int outputDirectoryId, int isDirectory, string userEmail, string userPass);

        //копирование файла/диретории
        [OperationContract]
        void Rename(int fileId, string newName, int isDirectory, string userEmail, string userPass);

        //возвращает путь для файла/диретории
        [OperationContract]
        string GetFilePath(int fileId, int isDirectory, string userEmail, string userPass);
    }
}
