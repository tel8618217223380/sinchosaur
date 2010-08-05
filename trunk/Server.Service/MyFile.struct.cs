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

        public MyFile(string Name, string Path, long Size, FileStatus status, DateTime LastWriteTime, bool IsDirectory, int FileId, int ParentDirectoryId)
        {
            this.Name = Name;
            this.Path = Path;
            this.Size = Size;
            this.status = status;
            this.LastWriteTime = LastWriteTime;
            this.IsDirectory = IsDirectory;
            this.FileId = FileId;
            this.ParentDirectoryId = ParentDirectoryId;
        }
        
        public override string ToString()
        {
            return "Название:" + Name + ", Размер: " + Size.ToString() + ", Каталог : " + Path;
        }
    }
}
