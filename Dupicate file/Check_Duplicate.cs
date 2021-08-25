using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
//Made this an inherited class so that I could use backgroundworker without a drastic change to the code.
namespace Duplicate_file
{
    public class Check_Duplicate : Form
    {
        // Below  variables used when search method "File Size" selected
        public List<string> FilePathsToCheck = new List<string>();
         protected List<long> DistinctFileSize = new List<long>();
        protected List<string> DistinctFileSizePaths = new List<string>();
        protected  List<long> DuplicateFileSize = new List<long>();
        protected  List<string> DuplicateFileSizePaths = new List<string>();
        protected List<long> FileSizes = new List<long>();
        protected List<string> FilePathsToCheckFileExtensions = new List<string>();
        protected List<string> DistinctFileExtensions = new List<string>();
        protected List<string> DuplicateFileExtensions = new List<string>();

        //Below  variables used when search method "Name" selected
        protected List<string> DuplicateDistinctNames = new List<string>();
        protected List<string> DuplicateFilePaths = new List<string>();
        protected List<string> DuplicateDistinctNamesFiltered = new List<string>();
       protected List<string> DuplicateFilePathsFiltered = new List<string>(); 
        protected List<string> DuplicateNames = new List<string>();


        public void Check_DuplicatesNames(object sender, DoWorkEventArgs e/*List<string> DuplicateNames, List<string> FilePath, out List<string> DuplicateNames, out List<string> DuplicateFilePaths, out List<string> DistinctNames*/)
        {
            List<string> DuplicateNameList = new List<string>();
            List<string> DuplicateNameListPath = new List<string>();
            List<string> DistinctN = new List<string>();
            List<string> DistinctNFilePath = new List<string>();
            for (int i = 0; i < DuplicateNames.Count; i++)
            {
                int count = 0;
                for (int x = i + 1; x < DuplicateNames.Count; x++)
                {
                    if (DuplicateNames[i] == DuplicateNames[x])
                    {
                        count++;
                    }
                }
                if (count >0)
                {
                    if (!DistinctN.Contains(DuplicateNames[i]))
                    {
                        DistinctN.Add(DuplicateNames[i]);
                        DistinctNFilePath.Add(FilePathsToCheck[i]);

                    }
                }

            }
            // the below search speed can be greatly improved if I do y = x +1. I need to come up with better code for it.
            for (int i = 0; i < DistinctN.Count; i++)
            {
                int count = 0;
                for (int y = 0; y < DuplicateNames.Count; y++)
                {
                    if (DistinctN[i] == DuplicateNames[y] && DuplicateNames[y].Length == DistinctN[i].Length)//&& DistinctNFilePath[i] != FilePath[y])
                    {
                        if (count == 0 && DistinctNFilePath[i] != FilePathsToCheck[y])
                        {
                            DuplicateNameList.Add(DistinctN[i]);
                            DuplicateNameListPath.Add(FilePathsToCheck[y]);
                            count++;
                        }
                        else if (DistinctNFilePath[i] != FilePathsToCheck[y])
                        {
                            DuplicateNameListPath.Add(FilePathsToCheck[y]);
                        }
                    }
                }
            }
            int count1 = 0;
            foreach (string x in DistinctN)
            {
                if (DuplicateNameList.Contains(x))
                {
                    DuplicateNameListPath.Add(DistinctNFilePath[count1]);
                }
                count1++;
            }
            // The below variables can be reworked to be more concise.
            DuplicateNames = DuplicateNameList;
            DuplicateFilePaths = DuplicateNameListPath;
            DuplicateDistinctNames = DistinctN;
            DistinctFileSizePaths = DistinctNFilePath;
        }

        public void Check_DuplicateFileSizes(object sender, DoWorkEventArgs e/*,out List<long> duplicateFileSize,out List<string> duplicateFileSizePaths, out List<string>distinctFileSizePaths, out List<long> distinctFileSize,out List<string> distinctFileExtensions, out List<string> duplicateFileExtensions*/)
        {
            DistinctFileSize.Clear();
             DistinctFileSizePaths.Clear();
            DuplicateFileSize.Clear();
            DuplicateFileSizePaths.Clear();
            FileSizes.Clear();
            FilePathsToCheckFileExtensions.Clear();
            DistinctFileExtensions.Clear();
            DuplicateFileExtensions.Clear();
            foreach (string x in FilePathsToCheck)
            {
                FileSizes.Add(new FileInfo(x).Length);

            }
       
            FilePathsToCheckFileExtensions = GetFileTypes.FileTypes(FilePathsToCheck,false);
           
            for (int i = 0; i < FileSizes.Count; i++)
            {
                int detect = 0;
                for (int x = 0; x < FileSizes.Count; x++)
                { 
                    if (FileSizes[i] == FileSizes[x]  && FilePathsToCheckFileExtensions[x] == FilePathsToCheckFileExtensions[i])
                    {
                       
                        detect++;
                        
                    }
                    if (detect > 1)
                    {
                        // enumerable range acts as a loop but uses linq
                        var result = Enumerable.Range(0, DistinctFileSize.Count)
                                        .Where(m => FileSizes[i] == DistinctFileSize[m])
                                        .ToList();
                        int same = 0;
                        for (int l = 0; l < result.Count; l++)
                        { 
                            if (DistinctFileExtensions[result[l]] != FilePathsToCheckFileExtensions[i])
                            {
                                same++;
                            }
                        }   
                        if (!DistinctFileSize.Contains(FileSizes[i]) ||(same == result.Count && same != 0) )
                        {     DistinctFileSize.Add(FileSizes[i]);
                                DistinctFileSizePaths.Add(FilePathsToCheck[i]);
                                DistinctFileExtensions.Add(FilePathsToCheckFileExtensions[i]);
                            }

                    }
                }
            }
          
                for (int i = 0; i < DistinctFileSize.Count; i++)

            { 
                int count = 0;
                for (int y = 0; y < FilePathsToCheck.Count; y++)
                {
                  
                    if (DistinctFileSize[i] == FileSizes[y] && DistinctFileExtensions[i] == FilePathsToCheckFileExtensions[y])
                    {   
                            DuplicateFileSize.Add(DistinctFileSize[i]);
                            DuplicateFileSizePaths.Add(FilePathsToCheck[y]);
                            DuplicateFileExtensions.Add(FilePathsToCheckFileExtensions[y]);
                            count++;
                       
                    }
                }
            }

        }


    }

}   

