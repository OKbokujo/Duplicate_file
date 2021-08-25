
using System.Windows.Forms;

namespace Duplicate_file
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("No Filter");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Include");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Exclude");
            this.Title = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader("(none)");
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.Check = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.Reset = new System.Windows.Forms.Button();
            this.FilesFound = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Remove_Folders = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.listView3 = new System.Windows.Forms.ListView();
            this.listView4 = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.listView5 = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader("(none)");
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(170, 42);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(181, 32);
            this.Title.TabIndex = 2;
            this.Title.Text = "Drag Folder or";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 205);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(298, 299);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewColumn_Click);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "#";
            this.columnHeader5.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "File Count";
            this.columnHeader2.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.OpenFolder,
            this.Delete,
            this.DeleteAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.Size = new System.Drawing.Size(189, 92);
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(188, 22);
            this.OpenFile.Text = "Open";
            this.OpenFile.Click += new System.EventHandler(this.Open_MouseClick);
            // 
            // OpenFolder
            // 
            this.OpenFolder.Name = "OpenFolder";
            this.OpenFolder.Size = new System.Drawing.Size(188, 22);
            this.OpenFolder.Text = "Open Folder";
            this.OpenFolder.Click += new System.EventHandler(this.OpenFolder_MouseClick);
            // 
            // Delete
            // 
            this.Delete.AutoToolTip = true;
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(188, 22);
            this.Delete.Text = "Delete Selected";
            this.Delete.ToolTipText = "Move to Recycle Bin";
            this.Delete.Click += new System.EventHandler(this.Delete_MouseClick);
            this.Delete.MouseHover += new System.EventHandler(this.Delete_MenuHover);
            // 
            // DeleteAll
            // 
            this.DeleteAll.Name = "DeleteAll";
            this.DeleteAll.Size = new System.Drawing.Size(188, 22);
            this.DeleteAll.Text = "Delete all old files";
            this.DeleteAll.ToolTipText = "All Old Files move to Recycle Bin";
            this.DeleteAll.Click += new System.EventHandler(this.DeleteAllOldFiles_MouseClick);
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Check.Location = new System.Drawing.Point(646, 510);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(75, 23);
            this.Check.TabIndex = 4;
            this.Check.Text = "Check Folders";
            this.Check.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // listView2
            // 
            this.listView2.AutoArrange = false;
            this.listView2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader4,
            this.columnHeader7});
            this.listView2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView2.FullRowSelect = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(376, 205);
            this.listView2.Name = "listView2";
            this.listView2.ShowGroups = false;
            this.listView2.Size = new System.Drawing.Size(852, 299);
            this.listView2.TabIndex = 4;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2Column_Click);
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView2_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Location";
            this.columnHeader3.Width = 400;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Created Date";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Modified Date";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "File Size";
            this.columnHeader7.Width = 150;
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Reset.Location = new System.Drawing.Point(730, 510);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 6;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // FilesFound
            // 
            this.FilesFound.AutoSize = true;
            this.FilesFound.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilesFound.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.FilesFound.Location = new System.Drawing.Point(294, 176);
            this.FilesFound.Name = "FilesFound";
            this.FilesFound.Size = new System.Drawing.Size(189, 25);
            this.FilesFound.TabIndex = 7;
            this.FilesFound.Text = "duplicate files found!";
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Count.ForeColor = System.Drawing.Color.Crimson;
            this.Count.Location = new System.Drawing.Point(214, 172);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(24, 30);
            this.Count.TabIndex = 8;
            this.Count.Text = "0";
            this.Count.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Remove_Folders});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(154, 26);
            // 
            // Remove_Folders
            // 
            this.Remove_Folders.Name = "Remove_Folders";
            this.Remove_Folders.Size = new System.Drawing.Size(153, 22);
            this.Remove_Folders.Text = "Remove Folder";
            this.Remove_Folders.Click += new System.EventHandler(this.RemoveFolder_MouseClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(149, 510);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(297, 31);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Visible = false;
            // 
            // listView3
            // 
            this.listView3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView3.ForeColor = System.Drawing.Color.DarkGreen;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(170, 77);
            this.listView3.Name = "listView3";
            this.listView3.ShowItemToolTips = true;
            this.listView3.Size = new System.Drawing.Size(852, 97);
            this.listView3.TabIndex = 10;
            this.toolTip1.SetToolTip(this.listView3, "Click right to remove the folder.");
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.SmallIcon;
            this.listView3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView3_MouseClick);
            this.listView3.MouseHover += new System.EventHandler(this.listView3_MouseHover);
            // 
            // listView4
            // 
            this.listView4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView4.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView4.HideSelection = false;
            listViewItem2.StateImageIndex = 0;
            listViewItem3.StateImageIndex = 0;
            this.listView4.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView4.Location = new System.Drawing.Point(12, 131);
            this.listView4.MultiSelect = false;
            this.listView4.Name = "listView4";
            this.listView4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView4.Size = new System.Drawing.Size(59, 68);
            this.listView4.TabIndex = 11;
            this.listView4.TileSize = new System.Drawing.Size(30, 30);
            this.listView4.UseCompatibleStateImageBehavior = false;
            this.listView4.View = System.Windows.Forms.View.SmallIcon;
            this.listView4.Visible = false;
            this.listView4.SelectedIndexChanged += new System.EventHandler(this.listView4_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(74, 150);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(69, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.toolStripMenuItem1.Text = "&FileType";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(366, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Find Folder";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(486, 510);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 31);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Method";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox2.Location = new System.Drawing.Point(87, 11);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 19);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "File Size";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(6, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Names";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // listView5
            // 
            this.listView5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.listView5.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.listView5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView5.FullRowSelect = true;
            this.listView5.HideSelection = false;
            this.listView5.Location = new System.Drawing.Point(12, 205);
            this.listView5.MultiSelect = false;
            this.listView5.Name = "listView5";
            this.listView5.Size = new System.Drawing.Size(334, 299);
            this.listView5.TabIndex = 15;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.Details;
            this.listView5.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewColumn_Click);
            this.listView5.SelectedIndexChanged += new System.EventHandler(this.listView5_SelectedIndexChanged);
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "#";
            this.columnHeader8.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "File Size";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "File Extension";
            this.columnHeader10.Width = 85;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "File Count";
            this.columnHeader11.Width = 75;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1240, 542);
            this.Controls.Add(this.listView5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listView4);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.FilesFound);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.Check);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Therapist";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label FilesFound;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem OpenFolder;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ListView listView4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Button button1;
        private ToolTip toolTip1;
        private ToolStripMenuItem Remove_Folders;
        private GroupBox groupBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private ListView listView5;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ToolStripMenuItem OpenFile;
        private ToolStripMenuItem DeleteAll;
    }
}

