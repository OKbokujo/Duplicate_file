using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Duplicate_file
{
    public static class ListViewItemPreparer
    {
        public  static ListView GetListsListView1(ListView ListView1, List<string> DuplicateDistinctNames, List<string> DuplicateFilePaths, out string Count)
        {
            int Count1 = 1;

            foreach (string x in DuplicateDistinctNames)
            {
                string[] Item1 = new string[3];
                ListViewItem List;
                Item1[0] = Count1.ToString();
                Item1[1] = x;
                Item1[2] = DuplicateFilePaths.Where(y => StringEditor.GetNameAndExtension(y) == x).Count().ToString();

                List = new ListViewItem(Item1);
                ListView1.Items.Add(List);
                Count1++;
            }

            Count = (DuplicateFilePaths.Count - DuplicateDistinctNames.Count).ToString();
            return ListView1;
        }
        public  static ListView GetFileDetailsListView2(ListView listView2, List<int> SameNameList, List<string> ListView1IndexChangeFilePaths)
        {
            List<DateTime> SameNameListModifiedDates = new List<DateTime>();
            List<DateTime> SameNameListCreatedDates = new List<DateTime>();
            List<string> SameNameListDirectories = new List<string>();
            List<long> FileSize = new List<long>();
            ListView Lists = listView2;
                foreach (int y in SameNameList)
                {
                    FileInfo FileSize1 = new FileInfo(ListView1IndexChangeFilePaths[y]);
                    SameNameListModifiedDates.Add(File.GetLastWriteTime(ListView1IndexChangeFilePaths[y]));
                    SameNameListDirectories.Add(ListView1IndexChangeFilePaths[y]);
                    SameNameListCreatedDates.Add(File.GetCreationTime(ListView1IndexChangeFilePaths[y]));
                    FileSize.Add((FileSize1.Length));
                }
                string[] Item1 = new string[4];

                for (int i = 0; i < SameNameListDirectories.Count; i++)
                {

                    ListViewItem List;
                    Item1[0] = SameNameListDirectories[i];
                    Item1[1] = SameNameListCreatedDates[i].ToString();
                    Item1[2] = SameNameListModifiedDates[i].ToString();
                    if (FileSize[i] < 1000000)
                    {
                        Item1[3] = $"{FileSize[i]} Bytes";
                    }
                    else
                    {
                        Item1[3] = $"{Math.Round((decimal)FileSize[i] / 1048576, 2)} MB";
                    }
                    List = new ListViewItem(Item1);
                    Lists.Items.Add(List);
                    }

            return Lists;
        }
        public static List<string> GetHighLightedExtenstions(ToolStripMenuItem MenuItem1)
        {
            List<string> highLightedExtenstions = new List<string>();
            foreach (ToolStripMenuItem x in MenuItem1.DropDownItems)
            {
                if (x.BackColor == Color.DodgerBlue)
                {
                    string Name = x.ToString();

                    if (!highLightedExtenstions.Contains(Name))
                    {
                        highLightedExtenstions.Add(Name);
                    }
                }
            }
            return highLightedExtenstions;
        }

        public static List<string> ExtensionFilter(List<string> DuplicateDistinctNames,List<string> DuplicateFilePaths, List<string> HighLightedExtensions,bool Include, out List<string>DuplicateDistinctNamesFiltered/*, out List<int> DuplicateDistinctFilteredIndex*/) 
        {
            List<string> duplicateDistinctNamesFiltered = new List<string>();
            List<int> duplicateDistinctNamesFilteredIndex = new List<int>();
            List<string> duplicateDistinctPathsFiltered = new List<string>();
            if (Include)
            {
                for (int i = 0; i < HighLightedExtensions.Count; i++)
                {
                    duplicateDistinctNamesFiltered.AddRange(DuplicateDistinctNames.Where(x => x.Contains(HighLightedExtensions[i])).ToList());
                    duplicateDistinctNamesFilteredIndex.AddRange(DuplicateDistinctNames.Select((x, y) => y).Where(y => DuplicateDistinctNames[y].Contains(HighLightedExtensions[i])).ToList());

                }
                for (int i = 0; i < duplicateDistinctNamesFiltered.Count; i++)
                {

                    duplicateDistinctPathsFiltered.AddRange(DuplicateFilePaths.Where(x => x.Contains(duplicateDistinctNamesFiltered[i])));
                }
            }
            else
            {
                
                for (int i = 0; i < DuplicateDistinctNames.Count ; i++)
                {
                    int count = 0;
                    for (int x = 0; x<HighLightedExtensions.Count; x ++)
                    {
                        
                        if(!DuplicateDistinctNames[i].Contains(HighLightedExtensions[x]))
                        {
                            count++;
                        }
                        if(count == HighLightedExtensions.Count)
                        {
                            duplicateDistinctNamesFiltered.Add(DuplicateDistinctNames[i]);
                            duplicateDistinctNamesFilteredIndex.Add(i);
                        }
                       
                    }

                }
                for (int i = 0; i < duplicateDistinctNamesFiltered.Count; i++)
                {
                    
                    duplicateDistinctPathsFiltered.AddRange(DuplicateFilePaths.Where(x => x.Contains(duplicateDistinctNamesFiltered[i])));
                }

            }
           
            DuplicateDistinctNamesFiltered = duplicateDistinctNamesFiltered;
            return duplicateDistinctPathsFiltered;
        }
        public static void ExtensionFilterFileSize(List<long> DistinctFileSize, List<string> DistinctFileSizePaths, List<string> DistinctFileExtensions, List<string> HighLightedExtensions,
                                                        bool Include, List<string> DuplicateFileExtensions, List<string> DuplicateFileSizePaths, List<long> DuplicateFileSize,
                                                          out List<long>DistinctFileSizeFiltered, out List<string> DistinctFileSizePathsFiltered, out List<string> DistinctFileExtensionsFiltered,
                                                         out List<long> DuplicateFileSizeFiltered, out List<string> DuplicateFileExtensionsFiltered, out List<string> DuplicateFileSizePathsFiltered)
        {
            List<long> distinctFileSizeFiltered = new List<long>();
            List<string> distinctFileSizePathsFiltered = new List<string>();
            List<string> distinctFileExtensionsFiltered = new List<string>();

            List<string> duplicateFileSizePathsFiltered = new List<string>();
            List<string> duplicateFileExtensionsFiltered = new List<string>();
            List<long> duplicateFileSizeFiltered = new List<long>();

            List<int> DistinctFilterIndex = new List<int>();
            List<int> DuplicateFilterIndex = new List<int>();
            if(Include)
            {
                for(int i = 0; i < HighLightedExtensions.Count; i ++)
                {
                    distinctFileExtensionsFiltered.AddRange(DistinctFileExtensions.Where(x => x.Contains(HighLightedExtensions[i])).ToList());
                    DistinctFilterIndex.AddRange(DistinctFileExtensions.Select((x, y) => y).Where(y => DistinctFileExtensions[y].Contains(HighLightedExtensions[i])).ToList());
                    duplicateFileExtensionsFiltered.AddRange(DuplicateFileExtensions.Where(x => x.Contains(HighLightedExtensions[i])).ToList());
                    DuplicateFilterIndex.AddRange(DuplicateFileExtensions.Select((x, y) => y).Where(y => DuplicateFileExtensions[y].Contains(HighLightedExtensions[i])).ToList());
                }
                foreach(int x in DistinctFilterIndex)
                {
                    distinctFileSizeFiltered.Add(DistinctFileSize[x]);
                    distinctFileSizePathsFiltered.Add(DistinctFileSizePaths[x]);
                }
                foreach (int x in DuplicateFilterIndex)
                {
                    duplicateFileSizeFiltered.Add(DuplicateFileSize[x]);
                    duplicateFileSizePathsFiltered.Add(DuplicateFileSizePaths[x]);
                }
            }
            else
            {
                for (int i = 0; i < DistinctFileExtensions.Count; i++)
                {
                    int count = 0;
                    for (int x = 0; x < HighLightedExtensions.Count; x++)
                    {

                        if (!DistinctFileExtensions[i].Contains(HighLightedExtensions[x]))
                        {
                            count++;
                        }
                        if (count == HighLightedExtensions.Count)
                        {
                            distinctFileExtensionsFiltered.Add(DistinctFileExtensions[i]);
                            DistinctFilterIndex.Add(i);  
                        }

                    }

                }
                foreach (int x in DistinctFilterIndex)
                {
                    distinctFileSizeFiltered.Add(DistinctFileSize[x]);
                    distinctFileSizePathsFiltered.Add(DistinctFileSizePaths[x]);
                }
                for (int i = 0; i < distinctFileSizeFiltered.Count; i++)
                {
                    for (int m = 0; m < DuplicateFileSize.Count; m++)
                    {
                        if (DuplicateFileSize[m] == distinctFileSizeFiltered[i] & DuplicateFileExtensions[m] == distinctFileExtensionsFiltered[i])
                        {
                            duplicateFileSizeFiltered.Add(DuplicateFileSize[m]);
                            DuplicateFilterIndex.Add(m);
                        }
                    }
                } 
                foreach(int x in DuplicateFilterIndex)
                {
                    duplicateFileSizePathsFiltered.Add(DuplicateFileSizePaths[x]);
                    duplicateFileExtensionsFiltered.Add(DuplicateFileExtensions[x]);
                }
                
            }
            DistinctFileSizePathsFiltered = distinctFileSizePathsFiltered;
            DistinctFileSizeFiltered = distinctFileSizeFiltered;
            DistinctFileExtensionsFiltered = distinctFileExtensionsFiltered;
            DuplicateFileSizeFiltered = duplicateFileSizeFiltered;
            DuplicateFileExtensionsFiltered = duplicateFileExtensionsFiltered;
            DuplicateFileSizePathsFiltered = duplicateFileSizePathsFiltered;

        }
        public static ListView GetListsListView5(ListView listView5, List<long> DistinctFileSize, List<long> DuplicateFileSize, List<string> DistinctFileSizePaths, List<string> DistinctFileExtensions, List<string>  DuplicateFileExtensions, out string FileNumber)
        {  
            int count = 1;
            int FileTotalCount = 0;
            for (int i = 0; i < DistinctFileSize.Count; i++)
            {
                if (DuplicateFileSize.Contains(DistinctFileSize[i]))
                {
                    int FileCount = DuplicateFileSize.Select((x, m) => m).Where(m => DuplicateFileSize[m] == DistinctFileSize[i] && DuplicateFileExtensions[m] == DistinctFileExtensions[i]).Count();
                    int filecount = DuplicateFileExtensions.Where(y => y == DistinctFileExtensions[i]).Count();
                    string[] Item1 = new string[4];
                    ListViewItem List;
                    Item1[0] = count.ToString();
                    Item1[1] = DistinctFileSize[i].ToString();
                    Item1[2] = GetFileTypes.FileType(DistinctFileSizePaths[i]);
                    Item1[3] = FileCount.ToString();
                    List = new ListViewItem(Item1);
                    listView5.Items.Add(List);
                    FileTotalCount += FileCount;
                    count++;
                }
            }
            
            FileNumber = (FileTotalCount - listView5.Items.Count).ToString();
            return listView5;
        }
    }
}   
    
