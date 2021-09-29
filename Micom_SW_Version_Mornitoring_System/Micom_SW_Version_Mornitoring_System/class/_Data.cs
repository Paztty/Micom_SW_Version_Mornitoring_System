using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    class _Data
    {
        public DataTable Table;
        private DataView view;
        public BindingSource Source = new BindingSource();
        public DataGridView DataView;

        public string LastUpdate = "";
        public int RowSelected = -1;
        public _Data(DataTable Table)
        {
            this.Table = Table;
            view = new DataView(Table);
            Source.DataSource = view;
            DataView.DataSource = Source;
        }
        public _Data() { }
        public void Init()
        {
            view = new DataView(Table);
            Source = new BindingSource();
            Source.DataSource = view;
            DataView.Invoke(new Action(()=>{
                for (int i = 0; i < DataView.ColumnCount; i++)
                {
                    if (DataView.Columns[i].Frozen)
                    {
                        DataView.Columns[i].Frozen = false;
                    }
                }
                DataView.DataSource = Source;
            }));
        }

        public void FilterOR(string filterString)
        {
            String FilterContent = "";
            foreach (DataColumn header in Table.Columns)
            {
                FilterContent += "["+ header.ColumnName +"] LIKE '%" + filterString + "%' OR ";
            }
            FilterContent = FilterContent.Remove(FilterContent.Length - 4,4);
            view.RowFilter = FilterContent;
        }

        public void FilterMulti(List<string> filterString, string Column)
        {
            String FilterContent = "";
            foreach (DataColumn header in Table.Columns)
            {
                if (header.ColumnName == Column)
                {
                    foreach (var item in filterString)
                    {
                        FilterContent += "[" + header.ColumnName + "] LIKE '" + item + "%' OR ";
                    }
                    break;
                }
            }
            FilterContent = FilterContent.Remove(FilterContent.Length - 4, 4);
            view.RowFilter = FilterContent;
        }
        public void Filter(string Column, string filterString)
        {
            foreach (DataColumn header in Table.Columns)
            {
                if (header.ColumnName == Column)
                {
                    view.RowFilter = "[" + header.ColumnName + "] LIKE '" + filterString + "%'";
                    break;
                }
            }  
        }

        public void Filter(string Column1, string Column2, string filterString)
        {
            foreach (DataColumn header in Table.Columns)
            {
                if (header.ColumnName == Column1 || header.ColumnName == Column2)
                {
                    view.RowFilter = "[" + header.ColumnName + "] LIKE '" + filterString + "%'";
                    break;
                }
            }
        }

        public void Filter_Clear()
        {
            view.RowFilter = null;
        }

    }
}
