using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Duplicate_file
{
    static class FolderCheck
    {   
        public static List<string> FolderChck(List<string> directoryCheck)
        {
            List<string> directories = new List<string>();
            List<string> Files = new List<string>();
            for (int i = 0; i < directoryCheck.Count; i++)
            {
                List<string> Files1 = new List<string>();
                if (!directories.Contains(directoryCheck[i]))
                {
                    directories.Add(directoryCheck[i]);
                    string[] check = Directory.GetDirectories(directoryCheck[i]);
                    foreach (string x in check)
                    {
                        if (!directories.Contains(x))
                        {
                            directories.Add(x);
                           
                        }
                    }

                    DirectoryInfo Check1 = new DirectoryInfo(directoryCheck[i]);
                    try
                    { 
                        Files1 = Directory.GetFiles(directoryCheck[i], "*.*", SearchOption.AllDirectories).ToList(); 
                    }
                    catch(Exception e) 
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                foreach(string x in Files1)
                {
                    if (!x.Contains(".db") && !x.Contains(".ini") )
                    {
                        Files.Add(x);
                    }
                }
            }
            return Files;
        }
     
    }

}
