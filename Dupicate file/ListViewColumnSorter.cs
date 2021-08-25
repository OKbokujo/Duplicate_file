using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Duplicate_file
{ 
    public class ListViewColumnSorter : IComparer
{
        
        private int ColumnToSort;

        private SortOrder OrderOfSort;

        private CaseInsensitiveComparer ObjectCompare;

        public string Name = "";

        public ListViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
            
        }

      
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;
            
            if (Name =="ColumnHeader: Text: File Count" || Name == "ColumnHeader: Text: #" || Name == "ColumnHeader: Text: File Size")
            {
                compareResult = ObjectCompare.Compare(Int32.Parse(listviewX.SubItems[ColumnToSort].Text), Int32.Parse(listviewY.SubItems[ColumnToSort].Text));
            }
            else if(Name == "ColumnHeader: Text: Created Date"|| Name == "ColumnHeader: Text: Modified Date")
            {

                compareResult = ObjectCompare.Compare(DateTime.Parse(listviewX.SubItems[ColumnToSort].Text), DateTime.Parse(listviewY.SubItems[ColumnToSort].Text));
            }
            else
            {
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
            }
            if (OrderOfSort == SortOrder.Ascending)
            {
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                return (-compareResult);
            }
            else
            {
                return 0;
            }
        }

        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
