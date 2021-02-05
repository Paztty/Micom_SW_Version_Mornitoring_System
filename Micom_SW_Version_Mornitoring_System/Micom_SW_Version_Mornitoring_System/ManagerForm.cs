using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class ManagerForm : Form
    {
        MySQL mySQL = new MySQL();
        public ManagerForm()
        {
            InitializeComponent();
            //dgvSWVersionMornitor.Columns.Add("columns1", "Model");
            //dgvSWVersionMornitor.Columns.Add("columns2", "Master Data");
            //dgvSWVersionMornitor.Columns.Add("columns3", "Assy Code");
            //dgvSWVersionMornitor.Columns.Add("columns4", "QR Code");
            //dgvSWVersionMornitor.Columns.Add("columns5", "PCB Code");
            //dgvSWVersionMornitor.Columns.Add("columns6", "Assy Micom Code");
            //dgvSWVersionMornitor.Columns.Add("columns7", "Micom Name");
            //dgvSWVersionMornitor.Columns.Add("columns8", " Checksum");
            //dgvSWVersionMornitor.Columns.Add("columns9", "Version");
            //dgvSWVersionMornitor.Columns.Add("columns10", "Apply day");
            //dgvSWVersionMornitor.Columns.Add("columns11", "Method");
            //dgvSWVersionMornitor.Columns.Add("columns12", "Writing Area");
            //dgvSWVersionMornitor.Columns.Add("columns13", "Previous Checksum");
            //dgvSWVersionMornitor.Columns.Add("columns14", "Previous Version");
            //dgvSWVersionMornitor.Columns.Add("columns15", "Previous apply day");
        }

        //private void MainForm_Load(object sender, EventArgs e)
        //{
        //    SQL.TestConnection();
        //    mySQL.GetDataFromTable("Micom SW Version");
        //    mySQL.LoadToDataGridView(dgvSWVersionMornitor, mySQL.DataTables[0].Name);
        //}

        //private void btGetDate_Click(object sender, EventArgs e)
        //{
        //    if(mySQL.GetDataFromTable(mySQL.DataTables[0].Name))
        //        mySQL.LoadToDataGridView(dgvSWVersionMornitor, mySQL.DataTables[0].Name);
        //}

        //private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    StartForm startForm = new StartForm();
        //    startForm.Show();
        //}

        //private void dgvSWVersionMornitor_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    Console.WriteLine(dgvSWVersionMornitor[e.ColumnIndex, e.RowIndex].Value.ToString());
        //}
    }
}
