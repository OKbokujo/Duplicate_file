using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duplicate_file
{
    // There are  lot of things that could be done to improve this program's search accuracy like comparing more variables accociated with each file
    // but given that the main purpose of this program was to learn one aspect of programing, I feel any further time spent on it would not be as useful
    // as learning other areas.
    public partial class Form1 : Check_Duplicate
    {
        private string[] CheckFolders;
        private List<string> Folders = new List<string>();

        private long SelectedFileSize;
        private string SelectFile;
        private List<string> ListView2SelectFile = new List<string>();
        private List<int> ListView2SelectedIndices = new List<int>();
        private List<int> SelectedItemIndicesInList = new List<int>();
        private List<string> IndexChangeDistinctExtensions = new List<string>();
        private List<string> IndexChangeDuplicateExtensions = new List<string>();


        private List<string> DuplicateFileSizePathsFiltered = new List<string>();
        private List<long> DuplicateFileSizeFiltered = new List<long>();
        private List<string> DuplicateFileExtensionsFiltered = new List<string>();

        private List<long> DistinctFileSizeFiltered = new List<long>();
        private List<string> DistinctFileSizePathsFiltered = new List<string>();
        private List<string> DistinctFileExtensionsFiltered = new List<string>();

        private List<string> ListView1IndexChangeFilePaths = new List<string>();
        private List<long> ListView1IndexChangeFileSizes = new List<long>();

        private List<int> RemovedItemsIndices = new List<int>();
        private List<int> RemovedDistinctItemIndices = new List<int>();

        private List<string> FileExtensions = new List<string>();
        private List<string> HighLightedExtensions = new List<string>();
        //Below are potential variables required for future program features to add.
        private Hashtable HashFilePathsToCheck = new Hashtable();
        private BackgroundWorker Worker = new BackgroundWorker();
        private ImageList ListViewFolderImage = new ImageList();


        private ListViewColumnSorter ListView1Sorter;
        private ListViewColumnSorter ListView2Sorter;
        private ListViewColumnSorter ListView5Sorter;
        private bool MessageAlreadyAddedText;
        public bool NoFilter = true;
        public bool Include = false;
        public bool Exclude = false;
        private bool ExtenstionListCreated = false;
        private bool NetworkWarningShown = false;
   



        public Form1()
        {
            InitializeComponent();
            ListView1Sorter = new ListViewColumnSorter();
            ListView2Sorter = new ListViewColumnSorter();
            ListView5Sorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = ListView1Sorter;
            this.listView5.ListViewItemSorter = ListView5Sorter;
            this.listView2.ListViewItemSorter = ListView2Sorter;

            //lvwColumnSorter.Name = "bob";
            // ListViewFolderImage.Images.Add(Image.FromFile(@"1200px-OneDrive_Folder_Icon.bmp"));
            //listView4.Items[0].Selected = true;

        }
        private void Form1_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {

                CheckFolders = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                MessageAlreadyAddedText = false;
                int num = 0;
                foreach (string x in CheckFolders)
                {

                    string m = String.Concat(x.Reverse());
                    string FolderName = String.Concat(m.Substring(0, m.IndexOf(@"\")).Reverse());

                    if (!FolderName.Contains("."))
                    {
                        if (!Folders.Contains(x))
                        {
                       
                            Folders.Add(x);
                            listView3.Items.Add(FolderName);
                            listView3.Items[num].ToolTipText = "Click right to remove.";
                            num++;
                           
                            if(x[0].ToString() == @"\" && !NetworkWarningShown)
                            {
                                MessageBox.Show("Search speeds are greatly decreased for network folders.");
                                NetworkWarningShown = true;
                            }

                        }
                        else
                        { if (MessageAlreadyAddedText == false)
                            {
                                MessageBox.Show("Already added.");
                                MessageAlreadyAddedText = true;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please enter a folder.");
                    }

                }

            }
        }
        private void Form1_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Bitmap) ||
               e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_Load_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked)
            {
                if (Folders.Count == 0)
                {
                    MessageBox.Show("Please add a folder.");
                }
                else
                {

                    if (listView3.Items.Count > 0)
                    {
                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView5.Items.Clear();
                        NoFilter = true;
                        Include = false;
                        Exclude = false;
                        ExtenstionListCreated = false;
                        CheckFolders = new string[0];
                        toolStripMenuItem1.DropDownItems.Clear();
                        ExtenstionListCreated = false;

                    }
                    if (!Worker.IsBusy)
                    {
                        List<string> filePathsToCheck = FolderCheck.FolderChck(Folders);  
                        if (checkBox1.Checked)
                        {
                            listView1.Visible = true;
                            listView5.Visible = false;
                            DuplicateNames = StringEditor.GetNamesAndExtension(filePathsToCheck);

                            Worker.DoWork += new DoWorkEventHandler(Check_DuplicatesNames);
                            Worker.RunWorkerAsync();
                            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ReadyIt);


                        }
                        else if (checkBox2.Checked)
                        {
                            listView1.Visible = false;
                            listView5.Visible = true;

                            Worker.DoWork += new DoWorkEventHandler(Check_DuplicateFileSizes);
                            Worker.RunWorkerAsync();
                            Worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(ReadyIt);


                        }

                        FilePathsToCheck = filePathsToCheck;
                    }
                    else
                    {
                        MessageBox.Show("Relax, we are searching already");
                    }
                }


               
            }
            else
            {
                MessageBox.Show("Please check a Search Method box.");
            }
        }
        private void ReadyIt(object sender, RunWorkerCompletedEventArgs e)
        {
            string Filenumber = "";
            if (checkBox1.Checked)
            {
                List<string> duplicateFilePaths = new List<string>();
                listView1 = ListViewItemPreparer.GetListsListView1(listView1, DuplicateDistinctNames, DuplicateFilePaths, out Filenumber);
                FileExtensions = GetFileTypes.FileTypes(DistinctFileSizePaths).Distinct().ToList();
            }
            else
            {
                listView5 = ListViewItemPreparer.GetListsListView5(listView5, DistinctFileSize, DuplicateFileSize, DistinctFileSizePaths, DistinctFileExtensions, DuplicateFileExtensions, out Filenumber);
                FileExtensions = GetFileTypes.FileTypes(DistinctFileSizePaths).Distinct().ToList();
            }
            ToolStripMenuItem[] bob = new ToolStripMenuItem[FileExtensions.Count];
            for (int i = 0; i < FileExtensions.Count; i++)
            {

                toolStripMenuItem1.DropDownItems.Add($"{FileExtensions[i]}");
                toolStripMenuItem1.DropDownItems[i].Name = i.ToString();
                toolStripMenuItem1.DropDownItems[i].Click += new EventHandler(toolStripMenuItem_Clicked);

            }

            Count.Text = Filenumber;
            listView4.Visible = true;
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            listView5.Items.Clear();
            listView4.Visible = false;
          
            NoFilter = true;
            Include = false;
            Exclude = false;
            ExtenstionListCreated = false;
            toolStripMenuItem1.DropDownItems.Clear();
            CheckFolders = new string[0];
            Folders = new List<string>();
            menuStrip1.Visible = false;
         
            Count.Text = "0";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            List<int> SameNameList = new List<int>();
            int SelectedItems = 1;
       
            foreach (int x in listView1.SelectedIndices)
            {
                SelectedItems = x;
            }

          
            SelectFile = listView1.Items[SelectedItems].SubItems[1].ToString();
            SelectFile = SelectFile.Substring(SelectFile.IndexOf("{") + 1, SelectFile.Length - SelectFile.IndexOf("{") - 2);
           
            if (Include || Exclude)
            {
                if (DuplicateDistinctNamesFiltered.Count > 0)
                {
                    
                    ListView1IndexChangeFilePaths = DuplicateFilePathsFiltered;
                }

            }
            if (NoFilter)
            {
              
                ListView1IndexChangeFilePaths = DuplicateFilePaths;
            
            }

            SameNameList = ListView1IndexChangeFilePaths.Select((x, i) => i).Where(i => StringEditor.GetNameAndExtension(ListView1IndexChangeFilePaths[i]) == SelectFile).ToList();
            SelectedItemIndicesInList = SameNameList;
            listView2 = ListViewItemPreparer.GetFileDetailsListView2(listView2, SelectedItemIndicesInList, ListView1IndexChangeFilePaths);



        }
        private void listView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            List<int> SameNameList = new List<int>();
            int SelectedItems = 0;
            string  index = "";
            string index1 = "";

            foreach (int x in listView5.SelectedIndices)
            {
                SelectedItems = x;
            }
            string select = listView5.Items[SelectedItems].SubItems[1].ToString();
            SelectedFileSize = Int32.Parse(select.Substring(select.IndexOf("{") + 1, select.Length - select.IndexOf("{") - 2));
            index1 = listView5.Items[SelectedItems].SubItems[2].ToString();
            index = index1.Substring(index1.IndexOf("{") + 1, index1.Length - index1.IndexOf("{") - 2);
            
            if (Include || Exclude)
            {

                if (DistinctFileSizeFiltered.Count> 0)
                {
                    ListView1IndexChangeFilePaths = DuplicateFileSizePathsFiltered;
                    ListView1IndexChangeFileSizes = DuplicateFileSizeFiltered;
                    IndexChangeDuplicateExtensions = DuplicateFileExtensionsFiltered;
                    IndexChangeDistinctExtensions = DistinctFileExtensionsFiltered;
                }

            }
            if (NoFilter)
            {
                ListView1IndexChangeFilePaths = DuplicateFileSizePaths;
                ListView1IndexChangeFileSizes = DuplicateFileSize;
                IndexChangeDuplicateExtensions = DuplicateFileExtensions;
                IndexChangeDistinctExtensions = DistinctFileExtensions;

            }
            SameNameList = ListView1IndexChangeFileSizes.Select((x, i) => i).Where(i => ListView1IndexChangeFileSizes[i] == SelectedFileSize && IndexChangeDuplicateExtensions[i] == index).ToList();
            SelectedItemIndicesInList = SameNameList;

            listView2 = ListViewItemPreparer.GetFileDetailsListView2(listView2, SelectedItemIndicesInList, ListView1IndexChangeFilePaths);
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
          
        }
        private void listViewColumn_Click(object sender, ColumnClickEventArgs e)
        {
            
            if (checkBox1.Checked)
            {
                ListView1Sorter.Name = listView1.Columns[e.Column].ToString();
                if (e.Column == ListView1Sorter.SortColumn)
                {

                    if (ListView1Sorter.Order == SortOrder.Ascending)
                    {
                        ListView1Sorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        ListView1Sorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {

                    ListView1Sorter.SortColumn = e.Column;
                    ListView1Sorter.Order = SortOrder.Ascending;

                }
                this.listView1.Sort();
            }
            else
            {
                
                ListView5Sorter.Name = listView5.Columns[e.Column].ToString();
                if (e.Column == ListView5Sorter.SortColumn)
                {

                    if (ListView5Sorter.Order == SortOrder.Ascending)
                    {
                        ListView5Sorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        ListView5Sorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {

                    ListView5Sorter.SortColumn = e.Column;
                    ListView5Sorter.Order = SortOrder.Ascending;

                }
                this.listView5.Sort();
            }
           
           
        }
        private void listView2Column_Click(object sender, ColumnClickEventArgs e)
        {
            
               ListView2Sorter.Name = listView2.Columns[e.Column].ToString();
            
            if (e.Column == ListView2Sorter.SortColumn)
            {

                if (ListView2Sorter.Order == SortOrder.Ascending)
                {
                    ListView2Sorter.Order = SortOrder.Descending;
                }
                else
                {
                    ListView2Sorter.Order = SortOrder.Ascending;
                }
            }
            else
            {

                ListView2Sorter.SortColumn = e.Column;
                ListView2Sorter.Order = SortOrder.Ascending;

            }
           
                this.listView2.Sort();
              
            
        }
        private void listView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                if (listView2.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListView2SelectFile = new List<string>();
                    for (int i = 0; i < listView2.SelectedItems.Count; i++)
                    {
                        ListView2SelectFile.Add(String.Concat(listView2.Items[listView2.SelectedIndices[i]].ToString().Substring(15, listView2.Items[listView2.SelectedIndices[i]].ToString().Length - 16)));
                        ListView2SelectedIndices.Add(listView2.SelectedIndices[i]);
                    }
                    contextMenuStrip1.Show(Cursor.Position);

                }
                
            }
        }
        private void listView3_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView3.FocusedItem.Bounds.Contains(e.Location))
                {



                    contextMenuStrip2.Show(Cursor.Position);
                }
            }
        }
        private void Open_MouseClick(object sender, EventArgs e)
        {
            foreach (string x in ListView2SelectFile)
            {
                Process.Start("explorer.exe", string.Format(x));

            }
        }
        private void OpenFolder_MouseClick(object sender, EventArgs e)
        {
            foreach (string x in ListView2SelectFile)
            {
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", x));
            }

        }
        private void Delete_MouseClick(object sender, EventArgs e)
        {
            string filecount = "";
            if (checkBox1.Checked)
            {
                filecount = listView1.SelectedItems[0].SubItems[2].ToString();
            }
            else
            {
                filecount = listView5.SelectedItems[0].SubItems[3].ToString();
            }
            RemovedItemsIndices = new List<int>();
            RemovedDistinctItemIndices = new List<int>();
          
            int FileCount = Int32.Parse(filecount.Substring(filecount.IndexOf("{") + 1, filecount.Length - filecount.IndexOf("{") - 2));
            int removecount = 0;
            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(ListView2SelectFile[removecount], Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
            
                FileCount--;
                removecount++;
            }
            if (FileCount == 2 || FileCount - ListView2SelectedIndices.Count < 2)
            {
                if (checkBox1.Checked)
                {
                   
                        foreach (int x in listView1.SelectedIndices)
                        {
                            listView1.Items.RemoveAt(x);
                           if (!ExtenstionListCreated)
                            {

                                 DuplicateDistinctNames.RemoveAt(x);
                            }
                           else
                            {
                                DuplicateDistinctNamesFiltered.RemoveAt(x);
                            }

                         }   
                }
                else
                {
                    foreach(int x in listView5.SelectedIndices)
                    {
                        listView5.Items.RemoveAt(x);
                        if (!ExtenstionListCreated)
                        {
                            DistinctFileSize.RemoveAt(x);
                            DistinctFileSizePaths.RemoveAt(x);
                            DistinctFileExtensions.RemoveAt(x);
                        }
                        else
                        {
                            DistinctFileSizeFiltered.RemoveAt(x);
                            DistinctFileSizePathsFiltered.RemoveAt(x);
                            DistinctFileExtensionsFiltered.RemoveAt(x); 
                        }
                    }
                }
            }
            

            foreach (ListViewItem eachItem in listView2.SelectedItems)
            {
                listView2.Items.Remove(eachItem);
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(ListView2SelectFile[removecount], Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                removecount++;
            }
            if (checkBox1.Checked && FileCount > 1 )
            {
                listView1.SelectedItems[0].SubItems[2].Text = listView2.Items.Count.ToString();
            }
            else if(FileCount > 1)
            {
                
                 listView5.SelectedItems[0].SubItems[3].Text = listView2.Items.Count.ToString();
            }
            

        }
        private void DeleteAllOldFiles_MouseClick(object sender, EventArgs e)
        {
            string filecount = "";
            if (checkBox1.Checked)
            {
                filecount = listView1.SelectedItems[0].SubItems[2].ToString();
            }
            else
            {
                filecount = listView5.SelectedItems[0].SubItems[3].ToString();
            }
            RemovedItemsIndices = new List<int>();
            RemovedDistinctItemIndices = new List<int>();
          

            int FileCount = Int32.Parse(filecount.Substring(filecount.IndexOf("{") + 1, filecount.Length - filecount.IndexOf("{") - 2));
            int removecount = 0;
            for (int i = 1; i < listView2.Items.Count; i++)
            {
                ListView2SelectFile.Clear();
                ListView2SelectFile.Add(String.Concat(listView2.Items[i].ToString().Substring(15, listView2.Items[i].ToString().Length - 16)));
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(ListView2SelectFile[0], Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin);
                FileCount--;
            }
            listView2.Items.Clear();
        
            if (FileCount == 2 || FileCount - ListView2SelectedIndices.Count < 2)
            {
                if (checkBox1.Checked)
                {

                    foreach (int x in listView1.SelectedIndices)
                    {
                        listView1.Items.RemoveAt(x);
                        if (!ExtenstionListCreated)
                        {

                            DuplicateDistinctNames.RemoveAt(x);
                        }
                        else
                        {
                            DuplicateDistinctNamesFiltered.RemoveAt(x);
                        }

                    }
                }
                else
                {
                    foreach (int x in listView5.SelectedIndices)
                    {
                        listView5.Items.RemoveAt(x);
                        if (!ExtenstionListCreated)
                        {
                            DistinctFileSize.RemoveAt(x);
                            DistinctFileSizePaths.RemoveAt(x);
                            DistinctFileExtensions.RemoveAt(x);
                        }
                        else
                        {
                            DistinctFileSizeFiltered.RemoveAt(x);
                            DistinctFileSizePathsFiltered.RemoveAt(x);
                            DistinctFileExtensionsFiltered.RemoveAt(x);
                        }
                    }
                }
            }
        }

        private void RemoveFolder_MouseClick(object sender, EventArgs e)
        {
            foreach(ListViewItem x in listView3.SelectedItems)
            {
                Folders.RemoveAt(listView3.Items.IndexOf(x));
                listView3.Items.Remove(x);
   
            }
        }
        private void Delete_MenuHover(object sender, EventArgs e)
        {


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        private void toolStripMenuItem_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
 
            int select =toolStripMenuItem1.DropDownItems.IndexOf(clickedItem);
          
                if (toolStripMenuItem1.DropDownItems[select].BackColor == System.Drawing.Color.DodgerBlue)
            {
                toolStripMenuItem1.DropDownItems[select].BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                toolStripMenuItem1.DropDownItems[select].BackColor = System.Drawing.Color.DodgerBlue;
            }
            List<string> highLightedExtenstions = ListViewItemPreparer.GetHighLightedExtenstions(toolStripMenuItem1);
            HighLightedExtensions = highLightedExtenstions;
           
            listView2.Items.Clear();
            String FileNumber = "";
            if (checkBox1.Checked)
            {
                listView1.Items.Clear();
                DuplicateFilePathsFiltered = ListViewItemPreparer.ExtensionFilter(DuplicateDistinctNames, DuplicateFilePaths, HighLightedExtensions, Include, out DuplicateDistinctNamesFiltered);

                listView1 = ListViewItemPreparer.GetListsListView1(listView1, DuplicateDistinctNamesFiltered, DuplicateFilePathsFiltered, out FileNumber);
            }
            else
            {
                listView5.Items.Clear();
                ListViewItemPreparer.ExtensionFilterFileSize(DistinctFileSize, DistinctFileSizePaths, DistinctFileExtensions, HighLightedExtensions, Include, 
                                                          DuplicateFileExtensions,DuplicateFileSizePaths,DuplicateFileSize,  
                                                         out DistinctFileSizeFiltered,  out DistinctFileSizePathsFiltered, out DistinctFileExtensionsFiltered,
                                                         out DuplicateFileSizeFiltered,out DuplicateFileExtensionsFiltered,out DuplicateFileSizePathsFiltered);

                listView5 = ListViewItemPreparer.GetListsListView5(listView5, DistinctFileSizeFiltered, DuplicateFileSize, DistinctFileSizePathsFiltered, DistinctFileExtensionsFiltered, DuplicateFileExtensions, out FileNumber);
            }
            Count.Text = FileNumber;
            ExtenstionListCreated = true;
           
        }

        private void ListView_ItemChecked(object sender, EventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DuplicateDistinctNames.Count > 0 || DistinctFileSize.Count > 0)
            {
               
             

                for (int i = 0; i < listView4.SelectedItems.Count; i++)
                {
                    if (listView4.SelectedItems[i] == listView4.Items[0])
                    {     
                            NoFilter = true;
                            Include = false;
                            Exclude = false;
                            string FileNumber = "";
                            if (checkBox1.Checked)
                            {
                                listView1.Items.Clear();
                                listView1 = ListViewItemPreparer.GetListsListView1(listView1, DuplicateDistinctNames, DuplicateFilePaths, out FileNumber);
                            }
                            else 
                            {
                               listView5.Items.Clear();
                                listView5 = ListViewItemPreparer.GetListsListView5(listView5, DistinctFileSize, DuplicateFileSize, DistinctFileSizePaths, DistinctFileExtensions, DuplicateFileExtensions, out FileNumber);
                            }
                            Count.Text = FileNumber;
                            HighLightedExtensions = new List<string>();
                            foreach (ToolStripMenuItem x in toolStripMenuItem1.DropDown.Items)
                            {
                                x.BackColor = Color.Empty;
                            }
                            ExtenstionListCreated = false;
                      
                        menuStrip1.Visible = false;
                    
                    }
                    else if (listView4.SelectedItems[i] == listView4.Items[1])
                    {
                        NoFilter = false;
                        Include = true;
                        Exclude = false;
                        menuStrip1.Visible = true;
                        if(ExtenstionListCreated)
                        {
                            DuplicateFilePathsFiltered = ListViewItemPreparer.ExtensionFilter(DuplicateDistinctNames, DuplicateFilePaths, HighLightedExtensions, true, out DuplicateDistinctNamesFiltered);
                        }
                    }
                    else
                    {
                        NoFilter = false;
                        Include = false;
                        Exclude = true;
                        menuStrip1.Visible = true;
                        if (ExtenstionListCreated)
                        {
                            DuplicateFilePathsFiltered = ListViewItemPreparer.ExtensionFilter(DuplicateDistinctNames, DuplicateFilePaths, HighLightedExtensions, false, out DuplicateDistinctNamesFiltered);
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            folderDlg.ShowNewFolderButton = true;
            

            if (result == DialogResult.OK)
            {
                int num = Folders.Count;
                Folders.Add(folderDlg.SelectedPath);
                listView3.Items.Add(folderDlg.SelectedPath);
                listView3.Items[num].ToolTipText = "Click right to remove.";

            }
        }
        private void listView3_MouseHover(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox2.Checked = false;
                listView1.Visible = true;
                listView5.Visible = false;
            }
            

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                listView1.Visible = false;
                listView5.Visible = true;
            }
        }

       
    }
}
