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
using System.IO;
using System.Text.Json;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class OperatorForm : Form
    {
        MySQL mySQL = new MySQL();
        int sellectedRow = -1;
        Model Model = new Model();
        DataTable dataTable { get; set; } = new DataTable();
        public OperatorForm()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvSWVersionMornitor, new object[] { true });
            CreatDataTable();
            string line = "";
            try
            {
                line = File.ReadAllText(@"C:\DEV\MSWS\config.txt");
            }
            catch (Exception) { }
            if (line.Length > 2)
            {
                cbbLine.Text = line;
                cbbLine.Enabled = false;
            }

        }
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
        private void FormControlButton_Click(object sender, EventArgs e)
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

        private void OperatorForm_Load(object sender, EventArgs e)
        {
            timerUpdateData.Interval = 10;
            timerUpdateData.Start();
            getLineLocation();
            
        }
        private void CreatDataTable()
        {
            dataTable.Columns.Add("Master Data");
            dataTable.Columns.Add("Model");
            dataTable.Columns.Add("Writing Area");
            dataTable.Columns.Add("Assy Code");
            dataTable.Columns.Add("PBA Code");
            dataTable.Columns.Add("PCB Code");
            dataTable.Columns.Add("MainAssy Micom Code");
            dataTable.Columns.Add("MainMicom Name");
            dataTable.Columns.Add("MainChecksum");
            dataTable.Columns.Add("MainVersion");
            dataTable.Columns.Add("MainApply day");
            dataTable.Columns.Add("InvAssy Micom Code");
            dataTable.Columns.Add("InvMicom Name");
            dataTable.Columns.Add("InvChecksum");
            dataTable.Columns.Add("InvVersion");
            dataTable.Columns.Add("InvApply day");
            dataTable.Columns.Add("Last user");

            dgvSWVersionMornitor.DataSource = dataTable;
            foreach (DataGridViewColumn column in dgvSWVersionMornitor.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvSWVersionMornitor.Columns[0].Visible = false;
        }
        private void UpdateFromServer()
        {
            try
            {
                dgvSWVersionMornitor.Invoke(new MethodInvoker(delegate
                {
                    mySQL.TestConnection();
                    mySQL.GetDataFromTable("Micom SW Version");
                    mySQL.LoadToDataTable(dataTable, "Micom SW Version");
                }));
            }
            catch (Exception) { timerUpdateData.Stop(); }
        }

        List<string> line = new List<string>();
        public void getLineLocation()
        {
            if (mySQL.TestConnection())
            {
                mySQL.getLineList(line);
                cbbLine.Items.AddRange(line.ToArray());
            }
            else
                lbLoading.Text = "Connection fail.";
        }
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            if (timerUpdateData.Interval == 10)
            {
                if (mySQL.TestConnection())
                {

                    UpdateFromServer();
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!cbbPBAcodeFilter.Items.Contains(dataTable.Rows[i].ItemArray[4].ToString()))
                        {
                            cbbPBAcodeFilter.Items.Add(dataTable.Rows[i].ItemArray[4].ToString());
                        }
                        if (!cbbAssyCodeFilter.Items.Contains(dataTable.Rows[i].ItemArray[3].ToString()))
                        {
                            cbbAssyCodeFilter.Items.Add(dataTable.Rows[i].ItemArray[3].ToString());
                        }
                    }
                    timerUpdateData.Interval = 30000;
                    lbLoading.Hide();
                }
                else
                {
                    lbLoading.Text = "Connection fail.";
                }
            }
            else
            {
                UpdateFromServer();
            }
        }
        private void dgvSWVersionMornitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != sellectedRow)
            {
                Model.GetData(dgvSWVersionMornitor, e.RowIndex);
                loadDataToControl();
                sellectedRow = e.RowIndex;
            }
        }

        private void FilterChange(object sender, EventArgs e)
        {
            Console.WriteLine(cbbAssyCodeFilter.Text + " " + cbbPBAcodeFilter.Text);
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvSWVersionMornitor.DataSource];
            currencyManager.SuspendBinding();
            if (cbbAssyCodeFilter.Text.Length < 2 && cbbPBAcodeFilter.Text.Length < 2)
            {
                for (int row = 0; row < dgvSWVersionMornitor.RowCount; row++)
                {
                    dgvSWVersionMornitor.Rows[row].Visible = true;
                    for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                    {
                        dgvSWVersionMornitor[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                    }
                }
            }
            else
            {
                for (int row = 0; row < dgvSWVersionMornitor.RowCount; row++)
                {
                    bool exitted = false;
                    if (dgvSWVersionMornitor[3, row].Value.ToString().Contains(cbbAssyCodeFilter.Text) && (dgvSWVersionMornitor[4, row].Value.ToString().Contains(cbbPBAcodeFilter.Text)))
                    {
                        dgvSWVersionMornitor[3, row].Style.BackColor = Color.YellowGreen;
                        dgvSWVersionMornitor[4, row].Style.BackColor = Color.YellowGreen;
                        exitted = true;
                    }
                    else
                    {
                        dgvSWVersionMornitor[3, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                        dgvSWVersionMornitor[4, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                    }

                    dgvSWVersionMornitor.Rows[row].Visible = exitted;
                }
            }
            currencyManager.ResumeBinding();
        }

        private void btCloseEdit_Click(object sender, EventArgs e)
        {
            for (int row = 0; row < dgvSWVersionMornitor.RowCount; row++)
            {
                cbbAssyCodeFilter.Text = "";
                cbbPBAcodeFilter.Text = "";
                dgvSWVersionMornitor.Rows[row].Visible = true;
                for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                {
                    dgvSWVersionMornitor[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                }
            }
        }

        private void btModelSellect_Click(object sender, EventArgs e)
        {
            if (cbbLine.Text != null)
            {
                panel5.Enabled = false;
                lbLoading.Text = "Loading.....";
                lbLoading.Show();
                string result = mySQL.UpdateUsedModel(Model, cbbLine.Text);
                lbLoading.Text = result;
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                string ModelStr = JsonSerializer.Serialize(Model, options);
                File.WriteAllText(@"C:\Auto Micom Writing\AMW\model.txt", ModelStr);
            }
        }

        private void loadDataToControl()
        {
            tbModelName.Text = Model.Name;
            tbAssyCode.Text = Model.AssyCode;
            cbbWritingArea.Text = Model.WritingArea;
            cbbPBAcode.Text = Model.PBACode;
            cbbPCBcode.Text = Model.PCBCode;

            tbAssyMicomCodeRom1.Text = Model.ROMs[0].AssyMicomCode;
            cbbMainMicomName.Text = Model.ROMs[0].MicomName;
            tbChecksumRom1.Text = Model.ROMs[0].Checksum;
            tbVersionRom1.Text = Model.ROMs[0].Version;

            if (Model.ROMs[0].DateApply.Contains('/'))
            {
                string[] dateStr = Model.ROMs[0].DateApply.Split('/');
                Console.WriteLine(dateStr[0] + " " + dateStr[1] + " " + dateStr[2]);
                Console.WriteLine(Convert.ToInt32(dateStr[0]) + " " + Convert.ToInt32(dateStr[1]) + " " + Convert.ToInt32(dateStr[2]));
                try
                {
                    DateTime date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));
                    dtpMainMicomApply.Value = date;
                    dtpMainMicomApply.Checked = true;
                }
                catch (Exception)
                {
                }
            }
            else
            {
                dtpMainMicomApply.Checked = false;
            }

            tbAssyMicomCodeRom2.Text = Model.ROMs[1].AssyMicomCode;
            cbbInvMicomName.Text = Model.ROMs[1].MicomName;
            tbChecksumRom2.Text = Model.ROMs[1].Checksum;
            tbVersionRom2.Text = Model.ROMs[1].Version;

            if (Model.ROMs[1].DateApply.Contains('/'))
            {
                string[] dateStr = Model.ROMs[1].DateApply.Split('/');
                try
                {
                    DateTime date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));
                    dtpInvMicomApply.Value = date;
                    dtpInvMicomApply.Checked = true;
                }
                catch (Exception)
                {
                }

            }
            else
            {
                dtpInvMicomApply.Checked = false;
            }
            gbROM2.Visible = tbChecksumRom2.TextLength >= 1;
            cb1Rom.Checked = !gbROM2.Visible;
            cb2Rom.Checked = !cb1Rom.Checked;
        }

        private void lbLoading_Click(object sender, EventArgs e)
        {
            panel5.Enabled = true;
            lbLoading.Hide();
        }

        private void cbbLine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\DEV\MSWS\config.txt", cbbLine.Text);
            cbbLine.Enabled = false;
        }
    }
}
