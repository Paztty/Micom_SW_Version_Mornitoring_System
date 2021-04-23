using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class ConnectString : Form
    {
        MySQLDatabase database = new MySQLDatabase();
        bool result = false;
        public ConnectString()
        {
            InitializeComponent();
            btApply.Enabled = false;
            loaddingBox.Hide();
        }

        private void btMornitoring_Click(object sender, EventArgs e)
        {
            var IP = textBox1.Text;
            lbIPserver.Text = "IP SERVER ( " + IP + " ) CONNECTING";
            loaddingBox.Show();
            btApply.Enabled = false;
            btMornitoring.Enabled = false;
            textBox1.Enabled = false;
            bgwTestConnect.RunWorkerAsync();
        }

        private void btManager_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
            {
                DataSource = textBox1.Text,
                InitialCatalog = "Tech",
                UserID = "micom",
                Password = "tech@12",
            };
            Console.WriteLine(builder.DataSource);
            File.WriteAllText("databaseConfig.txt", Protecter.Encode(builder.ConnectionString));
            this.DialogResult = DialogResult.OK;
        }

        private void bgwTestConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            var IP = textBox1.Text;
            result = database.Connect(IP);
        }

        private void bgwTestConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var IP = textBox1.Text;
            loaddingBox.Hide();
            btApply.Enabled = true;
            btMornitoring.Enabled = true;
            textBox1.Enabled = true;

            Console.WriteLine("test done");
            if (result)
            {
                lbIPserver.Text = "IP SERVER ( " + IP + " ) CONNECT OK";
            }
            else
            {
                lbIPserver.Text = "IP SERVER ( " + IP + " ) CONNECT FAIL";
            }
        }
    }
}
