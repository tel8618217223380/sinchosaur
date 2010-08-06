using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site.Helpers
{
    public class MyHelpers
    {
        public static string ShowSize( long size)
        {
            float fileSize = (float)size / 1024.0f;
            string suffix = "KБайт";

            if (fileSize > 1000.0f)
            {
                fileSize /= 1024.0f;
                suffix = "MБайт";
            }
            return string.Format("{0:0.0} {1}", fileSize, suffix);
        }


        public static string ShowFileName(string name, int lengthLimit)
        {
            if (name.Length > lengthLimit)
                return name.Substring(0, lengthLimit) + "...";
            return name;
        }

    }
}