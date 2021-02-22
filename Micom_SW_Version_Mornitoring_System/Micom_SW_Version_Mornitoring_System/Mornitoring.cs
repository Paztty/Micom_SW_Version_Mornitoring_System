using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class Mornitoring : Form
    {
        MySQL mySQL = new MySQL();
        public Mornitoring()
        {
            InitializeComponent();
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
            startForm.Show();
        }

        private void Mornitoring_Load(object sender, EventArgs e)
        {
            dgwMicomSWMonitoring.Columns.Add("Column1", "LINE");
            dgwMicomSWMonitoring.Columns.Add("Column2", "PCB CODE");
            dgwMicomSWMonitoring.Columns.Add("Column3", "PBA CODE");
            dgwMicomSWMonitoring.Columns.Add("Column4", "MAIN MICOM ASSCODE");
            dgwMicomSWMonitoring.Columns.Add("Column5", "MAIN MICOM CHECKSUM");
            dgwMicomSWMonitoring.Columns.Add("Column6", "MAIN MICOM VERSION");
            dgwMicomSWMonitoring.Columns.Add("Column7", "INV MICOM ASSCODE");
            dgwMicomSWMonitoring.Columns.Add("Column8", "INV MICOM CHECKSUM");
            dgwMicomSWMonitoring.Columns.Add("Column9", "INV MICOM VERSION");
            dgwMicomSWMonitoring.Columns.Add("Column10", "UPDATE TIME");

            mySQL.GetDataFromTable("MicomVersionMornitor");
            mySQL.LoadToDataGridView(dgwMicomSWMonitoring, "MicomVersionMornitor");

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
            }
            dgwMicomSWMonitoring[0, 0].Selected = false;
            dgwMicomSWMonitoring.ScrollBars = ScrollBars.None;
            dgwMicomSWMonitoring.Enabled = false;
        }
    }
}
