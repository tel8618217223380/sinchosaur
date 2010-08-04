using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service
{
    public struct EventInfo
    {
        public string FileName;
        public int FileId;
        public long FileSize;
        public DateTime Created;
        public string Path;
        public string Description;
    }
}
