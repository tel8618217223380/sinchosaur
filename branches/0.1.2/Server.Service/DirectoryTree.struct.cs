using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Service
{
    public struct DirectoryTree
    {
        public List<DirectoryTree> ChildTree;
        public string Name;
        public int DirectoryId;
        public int ParentId;

    }
}
