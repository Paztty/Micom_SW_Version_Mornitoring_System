using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class Mornitoring : Form
    {
        MySQL mySQL = new MySQL();
        DataTable dataTable { get; set; } = new DataTable();
        public Mornitoring()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgwMicomSWMonitoring, new object[] { true });
        }
        #region Form control  
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void pnTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            StartForm startForm = new StartForm();
            //startForm.Show();
        }

        private void Mornitoring_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("LINE");
            dataTable.Columns.Add("PCB CODE");
            dataTable.Columns.Add("PBA CODE");
            dataTable.Columns.Add("MAIN MICOM ASSCODE");
            dataTable.Columns.Add("MAIN MICOM CHECKSUM");
            dataTable.Columns.Add("MAIN MICOM VERSION");
            dataTable.Columns.Add("INV MICOM ASSCODE");
            dataTable.Columns.Add("INV MICOM CHECKSUM");
            dataTable.Columns.Add("INV MICOM VERSION");
            dataTable.Columns.Add("UPDATE TIME");
            dataTable.Columns.Add("STATUS");

            dgwMicomSWMonitoring.DataSource = dataTable;
            dgwMicomSWMonitoring.Columns[10].Visible = false;
            dgwMicomSWMonitoring.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgwMicomSWMonitoring.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
            dgwMicomSWMonitoring.Enabled = false;
            //dataTable.Columns.Add("Column1");
            //dataTable.Columns.Add("Column2");
            //dataTable.Columns.Add("Column3");
            //dataTable.Columns.Add("Column4");
            //dataTable.Columns.Add("Column5");
            //dataTable.Columns.Add("Column6");
            //dataTable.Columns.Add("Column7");
            //dataTable.Columns.Add("Column8");
            //dataTable.Columns.Add("Column9");
            //dataTable.Columns.Add("Column10");
            //dataTable.Columns.Add("Column11");

            timerUpdate.Interval = 10;
            timerUpdate.Start();
            lbLoading.Text = "Loading.....";
            lbLoading.Show();
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            timerUpdate.Interval = 5000;
            update();

        }

        public void update()
        {

            if (mySQL.TestConnection())
            {
                mySQL.GetDataFromTable("MicomVersionMornitor");
                //mySQL.LoadToDataGridView(dgwMicomSWMonitoring, "MicomVersionMornitor");
                mySQL.LoadToDataTableBuffer(dataTable, "MicomVersionMornitor");
                for (int i = 0; i < dgwMicomSWMonitoring.Rows.Count; i++)
                {
                    if (i < 3)
                    {
                        dgwMicomSWMonitoring.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(47, 56, 37);
                    }
                    else if (i < 8)
                    {
                        dgwMicomSWMonitoring.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(85, 56, 28);
                    }
                    else
                    {
                        dgwMicomSWMonitoring.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(96, 103, 120);
                    }
                    try
                    {
                        if (dgwMicomSWMonitoring[10, i].Value != null)
                        {
                            if (dgwMicomSWMonitoring[10, i].Value.ToString() == "STOP")
                            {
                                dgwMicomSWMonitoring[0, i].Style.BackColor = Color.FromArgb(170, 0, 0);
                            }
                            else if (dgwMicomSWMonitoring[10, i].Value.ToString() == "RUNNING")
                            {
                                dgwMicomSWMonitoring[0, i].Style.BackColor = Color.FromArgb(0, 128, 0);
                            }
                            else
                            {
                                dgwMicomSWMonitoring[0, i].Style.BackColor = Color.FromArgb(85, 85, 85);
                            }
                        }
                    }
                    catch (Exception) { }
                }
                dgwMicomSWMonitoring.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgwMicomSWMonitoring.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgwMicomSWMonitoring[0, 0].Selected = false;
                dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
                dgwMicomSWMonitoring.Enabled = false;
                lbLoading.Hide();
            }
        }

        private void FormControlClick(object sender, EventArgs e)
        {
            var ctrl = ((Button)sender).Name;
            switch (ctrl)
            {
                case "btClose":
                    this.Close();
                    //StartForm startForm = new StartForm();
                    //startForm.Show();
                    break;
                case "btMaximize":
                    if (this.WindowState != FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                    }

                    break;
                case "btMinimize":
                    this.WindowState = FormWindowState.Minimized;
                    break;
            }
        }
    }
}
