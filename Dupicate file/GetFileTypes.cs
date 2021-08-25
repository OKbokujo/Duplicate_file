using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duplicate_file
{
    static class GetFileTypes
    {
        public static List<string> FileTypes (List<string> FileNames, bool menu = true)
        {
            List<string> FileType = new List<string>();
            foreach (string x in FileNames)
            {
                string reverse =  String.Concat(x.Reverse());
                int Point = reverse.IndexOf(".");
                if (Point >= 0)
                {
                    string type = String.Concat(reverse.Substring(0, Point+1).Reverse());

                    if (!FileType.Contains(type) && menu)
                    {
                        FileType.Add(type);
                        
                    }
                    else if (!menu)
                    {
                        FileType.Add(type);
                    }
                }
                else if(!menu)
                {
                    FileType.Add("notype");
                }
            }
            return FileType;

        }
        public static string FileType(string FileName)
        {
            
                string reverse = String.Concat(FileName.Reverse());
                int Point = reverse.IndexOf(".");
                if (Point >= 0)
                {
                    FileName = String.Concat(reverse.Substring(0, Point + 1).Reverse());     
                }
           
            return FileName;

        }
    }
}
