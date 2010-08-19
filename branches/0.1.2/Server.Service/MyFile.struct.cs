using System;


namespace Server.Service
{
    public enum FileStatus
    {
        Download,
        Upload,
        Delete,
        NotChange
    }

    public struct DynaTreeNode
    {
        public int key;
        public string title;
        public bool isFolder;
        public bool isLazy;

    }

    public struct MyFile
    {
        public string Name;
        public string Path;
        public long Size;
        public FileStatus status;
        public DateTime LastWriteTime;
        public bool IsDirectory;
        public int FileId;
        public int ParentDirectoryId;
        public int UserId;
        public bool IsPublic;

        
        public override string ToString()
        {
            return "Название:" + Name + ", Размер: " + Size.ToString() + ", Каталог : " + Path;
        }
    }
}
