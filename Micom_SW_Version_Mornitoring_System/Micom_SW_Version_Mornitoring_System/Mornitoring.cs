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
        MySQLDatabase mySQL = new MySQLDatabase();
        DataTable dataTable { get; set; } = new DataTable();
        string lastUpdateTime = "";
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
            timerUpdate.Interval = 10;
            timerUpdate.Start();
            lbLoading.Text = "Loading.....";
            lbLoading.Show();

        }
        void loading()
        {
            if (mySQL.Connect())
            {
                mySQL.GetDataFromTable("MicomVersionMornitor", dataTable);
                lastUpdateTime = mySQL.UpdateData("MicomVersionMornitor", dataTable, lastUpdateTime);
                lbLoading.Invoke(new MethodInvoker(delegate {
                    lbLoading.Hide();
                    dgwMicomSWMonitoring.DataSource = dataTable;
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
                            if (dgwMicomSWMonitoring[columnName: "Status", i].Value != null)
                            {
                                if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "STOP")
                                {
                                    dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(170, 0, 0);
                                }
                                else if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "RUNNING")
                                {
                                    dgwMicomSWMonitoring[columnName:"Line", i].Style.BackColor = Color.FromArgb(0, 128, 0);
                                }
                                else
                                {
                                    dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(85, 85, 85);
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                    dgwMicomSWMonitoring[0, 0].Selected = false;
                    dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
                    dgwMicomSWMonitoring.Enabled = false;
                    timerUpdate.Interval = 10000;
                    timerUpdate.Start();
                    lbLoading.Hide();
                }));
            }
            else
            {
                lbLoading.Invoke(new MethodInvoker(delegate { lbLoading.Text = "Connect fail."; }));
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            if (timerUpdate.Interval == 10)
            {
                timerUpdate.Stop();
                Thread thread = new Thread(loading);
                thread.Start();
            }
            else
            {
                if (mySQL.Connect())
                {
                    string lastUpdateMoment = mySQL.UpdateData("MicomVersionMornitor", dataTable, lastUpdateTime);

                    if (lastUpdateMoment != lastUpdateTime)
                    {
                        lastUpdateTime = lastUpdateMoment;
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
                                if (dgwMicomSWMonitoring[columnName: "Status", i].Value != null)
                                {
                                    if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "STOP")
                                    {
                                        dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(170, 0, 0);
                                    }
                                    else if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "RUNNING")
                                    {
                                        dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(0, 128, 0);
                                    }
                                    else
                                    {
                                        dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(85, 85, 85);
                                    }
                                }

                            }
                            catch (Exception) { }
                        }
                        dgwMicomSWMonitoring[0, 0].Selected = false;
                        dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
                        dgwMicomSWMonitoring.Enabled = false;
                    }
                }
                else
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
                            if (dgwMicomSWMonitoring[columnName: "Status", i].Value != null)
                            {
                                if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "STOP")
                                {
                                    dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(170, 0, 0);
                                }
                                else if (dgwMicomSWMonitoring[columnName: "Status", i].Value.ToString() == "RUNNING")
                                {
                                    dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(0, 128, 0);
                                }
                                else
                                {
                                    dgwMicomSWMonitoring[columnName: "Line", i].Style.BackColor = Color.FromArgb(85, 85, 85);
                                }
                            }
                        }
                        catch (Exception) { }
                    }
                dgwMicomSWMonitoring[0, 0].Selected = false;
                dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
                dgwMicomSWMonitoring.Enabled = false;
                timerUpdate.Interval = 10000;
                timerUpdate.Start();
                lbLoading.Hide();
            }
        }
        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgwMicomSWMonitoring[column, row];
            DataGridViewCell cell2 = dgwMicomSWMonitoring[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        public void addArea()
        {
            try
            {
                dgwMicomSWMonitoring[columnName: "AREA", 0].Value = "DISPLAY";
                dgwMicomSWMonitoring[columnName: "AREA", 1].Value = "DISPLAY";
                dgwMicomSWMonitoring[columnName: "AREA", 2].Value = "DISPLAY";

                dgwMicomSWMonitoring[columnName: "AREA", 3].Value = "MI_D";
                dgwMicomSWMonitoring[columnName: "AREA", 4].Value = "MI_D";
                dgwMicomSWMonitoring[columnName: "AREA", 5].Value = "MI_D";
                dgwMicomSWMonitoring[columnName: "AREA", 6].Value = "MI_D";
                dgwMicomSWMonitoring[columnName: "AREA", 7].Value = "MI_D";

                dgwMicomSWMonitoring[columnName: "AREA", 8].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 9].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 10].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 11].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 12].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 13].Value = "MI_S";
                dgwMicomSWMonitoring[columnName: "AREA", 14].Value = "MI_S";

            }
            catch(Exception err)
            {
                //Console.WriteLine(err.Message);
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

        private void dgwMicomSWMonitoring_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            addArea();
        }

        private void dgwMicomSWMonitoring_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex > 0)
                return;
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgwMicomSWMonitoring.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgwMicomSWMonitoring_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (e.ColumnIndex > 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
    }
}
