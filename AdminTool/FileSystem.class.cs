using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AdminTool.FileSystemServiceReference;
using System.ServiceModel;

namespace AdminTool
{
    class FileSystem
    {
        public static FileSystem Instance = new FileSystem();
        private FileSystemClient serverFileSystem;

        static FileSystem()
        {
            Instance.InitProxyChannel();
        }

        //инициализация канала
        public void InitProxyChannel()
        {
            string ServerRemoteAddress = string.Concat("http://", Properties.Settings.Default.ServerRemoteAddress, "/FileSystem/");
            serverFileSystem = new FileSystemClient("BasicHttpBinding_IFileSystem", new EndpointAddress(ServerRemoteAddress));
        }


        //возвращает дерево каталогов пользователя
        public DirectoryTree GetUserDirectories(int userId)
        {
            return serverFileSystem.GetUserDirectoryTree(userId, Account.Instance.GetOperatorLogin(), Account.Instance.GetOperatorPass());
        }

        //возвращает файлы пользователя в каталоге
        public MyFile[] GetUserDirectyFiles(int userId,int directoryId)
        {
            return serverFileSystem.GetDirectoryFilesOperator(directoryId, userId, Account.Instance.GetOperatorLogin(), Account.Instance.GetOperatorPass());
        }


    }
}
