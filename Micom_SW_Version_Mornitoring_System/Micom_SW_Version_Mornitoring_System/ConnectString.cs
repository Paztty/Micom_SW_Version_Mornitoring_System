using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        string connectionStr = @"Data Source=172.22.14.220;Initial Catalog=Tech;User ID=sa;Password=123456";

        public ConnectString()
        {
            InitializeComponent();
            btApply.Enabled = false;
        }

        private void btMornitoring_Click(object sender, EventArgs e)
        {
            lbIPserver.Text = "IP SERVER ( " + textBox1.Text + " ) CONNECTING ";
            Thread thread = new Thread(TestConnecttion);
            thread.Start();
        }

        public void TestConnecttion()
        {
            string connectStr = @"Data Source=" + textBox1.Text + ";Initial Catalog=Tech;User ID=sa;Password=123456";
            lbIPserver.Invoke(new MethodInvoker(delegate { 
                if (database.Connect(connectStr))
                {
                    lbIPserver.Text += " - OK";
                    btApply.Enabled = true;
                }
                else
                {
                    lbIPserver.Text += " - FAIL";
                    btApply.Enabled = false;
                }
            }));
        }

        private void btManager_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\MSWS\")) Directory.CreateDirectory(@"C:\MSWS\");
            File.WriteAllText(@"C:\MSWS\databaseConfig.txt", @"Data Source=" + textBox1.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
