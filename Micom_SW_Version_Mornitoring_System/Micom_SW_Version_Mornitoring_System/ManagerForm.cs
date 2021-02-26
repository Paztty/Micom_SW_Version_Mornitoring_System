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
using System.Threading;
using System.Reflection;
using ClosedXML.Excel;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class ManagerForm : Form
    {
        #region Variable
        MySQL mySQL = new MySQL();
        DataTable dataTable { get; set; } = new DataTable();

        // data grid view object variable
        int sellectedRow = -1;
        Model Model = new Model();
        #endregion

        #region Form control
        public ManagerForm()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvSWVersionMornitor, new object[] { true });
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

        private void MainForm_Load(object sender, EventArgs e)
        {

            btModelAddNew.Enabled = false;
            btModelEdit.Enabled = false;
            btModelClear.Enabled = false;
            btExport.Enabled = Global.user.userPermission.Contains("Export");

            lbEditerUser.Text = "EDITOR: " + Global.user.userName + "   ID: " + Global.user.userID;
            addLog("Login success: " + Global.user.userName + "   ID: " + Global.user.userID + "   Permission : " + Global.user.userPermission.Replace(",",", "));
            //btModelExport.Enabled = Global.user.userPermission.Contains(User.Permission.Export.ToString());
            //btModelAddNew.Enabled = Global.user.userPermission.Contains(User.Permission.Watch.ToString());

            //gbROM2.Enabled = false;
            CreatDataTable();
            timerUpdateData.Start();
            dgvSWVersionMornitor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            lbLoading.Text = "Loading.....";
            lbLoading.Show();
        }

        public void addLog(string log)
        {
            tbActivityStatistics.Text += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss: ") + log + Environment.NewLine;
            File.AppendAllText(@"D:\log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss: ") + log + Environment.NewLine);
        }

        #endregion

        #region Data connection



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
                    if (mySQL.TestConnection())
                    {
                        mySQL.GetDataFromTable("Micom SW Version");
                        mySQL.LoadToDataTable(dataTable, "Micom SW Version");
                        timerUpdateData.Interval = 10000;
                        timerUpdateData.Start();
                        btModelAddNew.Enabled = Global.user.userPermission.Contains(User.Permission.Add.ToString());
                    }
                }));
            }
            catch (Exception)
            { timerUpdateData.Stop(); }
        }
        #endregion

        #region timer event

        // mySQL data update
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            if (timerUpdateData.Interval == 10)
            {
                if (mySQL.TestConnection())
                {
                    UpdateFromServer();

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (!cbbPBAcode.Items.Contains(dataTable.Rows[i].ItemArray[4].ToString()))
                        {
                            cbbPBAcode.Items.Add(dataTable.Rows[i].ItemArray[4].ToString());
                        }
                        if (!cbbPCBcode.Items.Contains(dataTable.Rows[i].ItemArray[5].ToString()))
                        {
                            cbbPCBcode.Items.Add(dataTable.Rows[i].ItemArray[5].ToString());
                        }
                        if (!cbbMainMicomName.Items.Contains(dataTable.Rows[i].ItemArray[7].ToString()))
                        {
                            cbbMainMicomName.Items.Add(dataTable.Rows[i].ItemArray[7].ToString());
                        }
                        if (!cbbInvMicomName.Items.Contains(dataTable.Rows[i].ItemArray[12].ToString()))
                        {
                            cbbInvMicomName.Items.Add(dataTable.Rows[i].ItemArray[12].ToString());
                        }
                    }
                    lbLoading.Hide();
                }
                else
                {
                    addLog("Connection Fail.");
                }
                timerUpdateData.Interval = 3600000;
            }
            else
            {
                if (mySQL.TestConnection())
                {
                    Thread threadUpdate = new Thread(UpdateFromServer);
                    threadUpdate.Start();
                }
            }

        }

        #endregion

        string acction;
        private void buttonActionClick(object sender, EventArgs e)
        {
            string resultStr = "";
            string ctrl = ((Button)sender).Name;
            switch (ctrl)
            {
                case "btCloseEdit":
                    pnDataEdit.Hide();
                    dgvSWVersionMornitor.Enabled = true;
                    Model.GetData(dgvSWVersionMornitor, sellectedRow);
                    break;
                case "btCancleAction":
                    pnDataEdit.Hide();
                    dgvSWVersionMornitor.Enabled = true;
                    Model.GetData(dgvSWVersionMornitor, sellectedRow);
                    addLog("Edit window close by cancle, data not save.");
                    break;
                case "btModelAddNew":
                    pnDataEdit.Show();
                    acction = "add";
                    dgvSWVersionMornitor.Enabled = false;
                    break;
                case "btModelClear":

                    string message = "Do you want to clear this model ?";
                    string title = "Clear model " + Model.AssyCode;
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        lbLoading.Text = "Loading.....";
                        lbLoading.Show();
                        resultStr = mySQL.DeleteData(Model.MasterData);
                        lbLoading.Text = resultStr;
                        addLog(Global.user.userID + " Clear model: \"" + Model.AssyCode + "\" " + resultStr );
                    }
                    sellectedRow = -1;
                    UpdateFromServer();
                    break;
                case "btModelEdit":
                    loadDataToControl();
                    pnDataEdit.Show();
                    acction = "edit";
                    dgvSWVersionMornitor.Enabled = false;
                    break;
                case "btModelUpdate":
                    lbLoading.Text = "Loading.....";
                    lbLoading.Show();
                    if (mySQL.TestConnection())
                    {
                        string masterData = getDataFromControl(acction);
                        if (acction == "add")
                        {
                            resultStr = mySQL.InsertDatabase(Model);
                            addLog(Global.user.userID + " Add model \"" + Model.AssyCode + "\" " + resultStr);
                        }
                        if (acction == "edit")
                        {
                            string message1 = "Do you want to change this model ?";
                            string title1 = "Update model " + Model.AssyCode;
                            MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                            DialogResult result1 = MessageBox.Show(message1, title1, buttons1);
                            if (result1 == DialogResult.Yes)
                            {
                                resultStr = mySQL.EditDatabase(Model, masterData);
                                addLog(Global.user.userID + " Update model \"" + Model.AssyCode + "\" " + resultStr);

                            }
                        }
                        sellectedRow = -1;
                        UpdateFromServer();
                        lbLoading.Text = resultStr;
                    }
                    else
                    {
                        lbLoading.Text = "No connection.";
                    }
                    break;
                case "btExport":
                    var lines = new List<string>();

                    string[] columnNames = dataTable.Columns
                        .Cast<DataColumn>()
                        .Select(column => column.ColumnName)
                        .ToArray();

                    var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
                    lines.Add(header);

                    var valueLines = dataTable.AsEnumerable()
                        .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

                    lines.AddRange(valueLines);
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.DefaultExt = ".csv";
                    saveFile.Title = "Export file";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllLines(saveFile.FileName, lines);
                        addLog(Global.user.userID + " export file: \"" + saveFile.FileName + "\"");
                    }
                    
                    break;
                default:
                    break;
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
        private string getDataFromControl(string acction)
        {
            if (acction == "add")
            {
                Model.MasterData = tbAssyCode.Text;
                if (Model.MasterData.Length < 2)
                {
                    Model.MasterData = "NULL";
                }
                else
                {
                    int exited = 0;
                retry:
                    exited++;
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        if (dataTable.Rows[i].ItemArray[0].ToString() == Model.MasterData)
                        {
                            Model.MasterData += "#" + exited.ToString();
                            goto retry;
                        }
                    }
                }
            }

            Model.Name = tbModelName.Text;
            Model.AssyCode = tbAssyCode.Text;
            Model.WritingArea = cbbWritingArea.Text;
            Model.PBACode = cbbPBAcode.Text;
            Model.PCBCode = cbbPCBcode.Text;
            

            Model.ROMs[0].AssyMicomCode = tbAssyMicomCodeRom1.Text;
            Model.ROMs[0].MicomName = cbbMainMicomName.Text;
            Model.ROMs[0].Checksum = tbChecksumRom1.Text;
            Model.ROMs[0].Version = tbVersionRom1.Text;
            if (dtpMainMicomApply.Checked)
            {
                Model.ROMs[0].DateApply = dtpMainMicomApply.Value.ToString("dd/MM/yyyy");
            }
            else
            {
                Model.ROMs[0].DateApply = "";
            }

            if (cb2Rom.Checked)
            {
                Model.ROMs[1].AssyMicomCode = tbAssyMicomCodeRom1.Text;
                Model.ROMs[1].MicomName = cbbInvMicomName.Text;
                Model.ROMs[1].Checksum = tbChecksumRom1.Text;
                Model.ROMs[1].Version = tbVersionRom1.Text;
                if (dtpMainMicomApply.Checked)
                {
                    Model.ROMs[1].DateApply = dtpInvMicomApply.Value.ToString("dd/MM/yyyy");
                }
                else
                {
                    Model.ROMs[1].DateApply = "";
                }
            }
            else
            {
                Model.ROMs[1].AssyMicomCode = "";
                Model.ROMs[1].MicomName = "";
                Model.ROMs[1].Checksum = "";
                Model.ROMs[1].Version = "";
                Model.ROMs[1].DateApply = "";
            }
            return Model.MasterData;
        }

        #region Event
       private void dgvSWVersionMornitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != sellectedRow)
            {
                btModelEdit.Enabled = Global.user.userPermission.Contains(User.Permission.Clear.ToString());
                btModelClear.Enabled = Global.user.userPermission.Contains(User.Permission.Edit.ToString());
                Model.GetData(dgvSWVersionMornitor, e.RowIndex);
                sellectedRow = e.RowIndex;
            }
        }
        private void btFind_Click(object sender, EventArgs e)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvSWVersionMornitor.DataSource];
            currencyManager.SuspendBinding();
            if (tbFindModel.TextLength < 2)
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
                    for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                    {
                        if (dgvSWVersionMornitor[column, row].Value.ToString().Contains(tbFindModel.Text))
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

        #endregion

        private void cb1Rom_Click(object sender, EventArgs e)
        {
            ((CheckBox)sender).Checked = true;
            if ((CheckBox)sender == cb1Rom)
                cb2Rom.Checked = !cb1Rom.Checked;
            else
                cb1Rom.Checked = !cb2Rom.Checked;
            gbROM2.Visible = cb2Rom.Checked;
        }

        private void tbFindModel_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btFineModel;
        }

        private void lbLoading_Click(object sender, EventArgs e)
        {
            lbLoading.Hide();
        }
    }
}
