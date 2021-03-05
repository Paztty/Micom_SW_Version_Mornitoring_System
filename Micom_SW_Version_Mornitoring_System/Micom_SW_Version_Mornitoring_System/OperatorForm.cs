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
        MySQLDatabase database = new MySQLDatabase();

        string lastUpdateTime = "";
        int sellectedRow = -1;
        Model Model = new Model();
        DataTable dataTable { get; set; } = new DataTable();
        public OperatorForm()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvSWVersionMornitor, new object[] { true });


            string line = "";
            try
            {
                if (File.Exists(@"C:\DEV\MSWS\config.txt"))
                {
                    line = File.ReadAllText(@"C:\DEV\MSWS\config.txt");
                }
                
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
        }

        private void UpdateFromServer()
        {
            if (database.Connect())
            {
                database.UpdateData("Micom SW Version", dataTable, lastUpdateTime);
                Console.WriteLine(lastUpdateTime);
            }
        }

        List<string> line = new List<string>();
        public void getLineLocation()
        {
            if (database.Connect())
            {
                database.getLineList(line);
                cbbLine.Items.AddRange(line.ToArray());
            }
            else
                lbLoading.Text = "Connection fail.";
        }
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            if (timerUpdateData.Interval == 10)
            {
                if (database.Connect())
                {
                    getLineLocation();
                    database.CreatTableFromServer("Micom SW Version", dataTable);
                    database.GetDataFromTable("Micom SW Version", dataTable);
                    dgvSWVersionMornitor.DataSource = dataTable;
                    foreach (DataGridViewColumn column in dgvSWVersionMornitor.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                        if (column.Name == "Master Data")
                        {
                            column.Visible = false;
                        }
                    }
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!cbbAssyCodeFilter.Items.Contains(dataTable.Rows[i].ItemArray[4].ToString()))
                        {
                            cbbAssyCodeFilter.Items.Add(dataTable.Rows[i].ItemArray[4].ToString());
                        }
                        if (!cbbAssyCodeFilter.Items.Contains(dataTable.Rows[i].ItemArray[3].ToString()))
                        {
                            cbbAssyCodeFilter.Items.Add(dataTable.Rows[i].ItemArray[3].ToString());
                        }
                    }
                    timerUpdateData.Interval = 3000;
                    lbLoading.Hide();
                }
                else
                {
                    lbLoading.Text = "Connection fail.";
                }
            }
            else
            {
              string lastTime = database.UpdateData("Micom SW Version", dataTable, lastUpdateTime);
              lastUpdateTime = lastTime;
              Console.WriteLine(lastUpdateTime);
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
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvSWVersionMornitor.DataSource];
            currencyManager.SuspendBinding();
            if (cbbAssyCodeFilter.Text.Length < 2)
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
                    if (dgvSWVersionMornitor[3, row].Value.ToString().Contains(cbbAssyCodeFilter.Text) || (dgvSWVersionMornitor[4, row].Value.ToString().Contains(cbbAssyCodeFilter.Text)))
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
                dgvSWVersionMornitor.Rows[row].Visible = true;
                for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                {
                    dgvSWVersionMornitor[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                }
            }
        }

        private void btModelSellect_Click(object sender, EventArgs e)
        {
            if (sellectedRow != -1)
            {
                if (cbbLine.Text != null)
                {
                    panel5.Enabled = false;
                    lbLoading.Text = "Loading.....";
                    lbLoading.Show();
                    string result = database.UpdateUsedModel(Model, cbbLine.Text);
                    lbLoading.Text = result;
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string ModelStr = JsonSerializer.Serialize(Model, options);
                    File.WriteAllText(@"C:\Auto Micom Writing\AMW\model.txt", ModelStr);
                }
            }
            else
            {
                lbLoading.Text = "Select one model.";
                lbLoading.Show();
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

        private void label3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:\DEV\MSWS\config.txt", cbbLine.Text);
            cbbLine.Enabled = false;
        }

        private void cbbAssyCodeFilter_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sellectedRow = -1;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvSWVersionMornitor.DataSource];
                currencyManager.SuspendBinding();
                if (cbbAssyCodeFilter.Text.Length < 2)
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
                    cbbAssyCodeFilter.Text = cbbAssyCodeFilter.Text.ToUpper();
                    for (int row = 0; row < dgvSWVersionMornitor.RowCount; row++)
                    {
                        bool exitted = false;
                        for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                        {
                            if (dgvSWVersionMornitor[column, row].Value.ToString().Contains(cbbAssyCodeFilter.Text))
                            {
                                dgvSWVersionMornitor[column, row].Style.BackColor = Color.YellowGreen;
                                exitted = true;
                            }
                            else
                            {
                                dgvSWVersionMornitor[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                            }
                        }
                        dgvSWVersionMornitor.Rows[row].Visible = exitted;
                    }
                }
                currencyManager.ResumeBinding();
            }
        }
    }
}
