using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duplicate_file
{
    static class   StringEditor
    { 
        public static List<string> GetNamesAndExtension(List<string> RawFile)
        {
            List<string> NamesAndExtension = new List<string>();
            foreach(string x in RawFile)
            {
               string  M = String.Concat(x.Reverse());
               NamesAndExtension.Add(String.Concat(M.Substring(0, M.IndexOf(@"\")).Reverse()));
            }
            return NamesAndExtension;
        }
        public static string GetNameAndExtension(string path)
        {
            string M= string.Concat(path.Reverse());
            return String.Concat(M.Substring(0, M.IndexOf(@"\")).Reverse());
        }
    }
}
