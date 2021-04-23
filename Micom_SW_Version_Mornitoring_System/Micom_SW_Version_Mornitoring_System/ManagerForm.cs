using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class ManagerForm : Form
    {
        #region Variable
        MySQLDatabase database = new MySQLDatabase();
        DataTable dataTableSWVersion { get; set; } = new DataTable();
        DataTable dataTableEepromOption { get; set; } = new DataTable();

        _Data SW_data = new _Data();
        _Data Eeprom_data = new _Data();

        // data grid view object variable
        Model Model = new Model();
        EEPROM eePROM = new EEPROM();

        long lastLoadNotify = Convert.ToInt64(DateTime.Now.AddDays(-1).ToString("yyyyMMddHHmmss"));
        bool closed = false;

        Color activePanel = Color.FromArgb(255, 255, 255);
        Color deactiverPanel = Color.FromArgb(30, 42, 74);
        #endregion

        #region Form control
        public ManagerForm()
        {
            InitializeComponent();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvSWVersionMornitor, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null,
            dgvMicomOption, new object[] { true });
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
                    closed = true;
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
            btModelEdit.Enabled = false;
            btModelClear.Enabled = false;
            btExport.Enabled = Global.user.userPermission.Contains("Export");
            btOption.Enabled = Global.user.userPermission.Contains("Option");
            cbbModelType.SelectedIndex = 0;


            lbEditerUser.Text = "EDITOR: " + Global.user.userName + "   ID: " + Global.user.userID;
            lbEEEditor.Text = "EDITOR: " + Global.user.userName + "   ID: " + Global.user.userID;

            addLog("Login success: " + Global.user.userName + "   ID: " + Global.user.userID + "   Permission : " + Global.user.userPermission.Replace(",", ", "));

            lbLoading.Text = "Loading.....";
            loaddingBox.Show();
            pnLoading.Show();

            pnSystem.BringToFront();

            pnChangeData.BringToFront();
            pnEepromOptionChange.BringToFront();
            pnLoading.BringToFront();

            dgvMicomOption.Visible = false;
            dgvSWVersionMornitor.Visible = true;
            btMicomSW.BackColor = activePanel;

            btMicomSW.ForeColor = deactiverPanel;

            SW_data.Table = dataTableSWVersion;
            SW_data.DataView = dgvSWVersionMornitor;

            Eeprom_data.Table = dataTableEepromOption;
            Eeprom_data.DataView = dgvMicomOption;

            timerUpdateData.Interval = 10;
            timerUpdateData.Start();
        }
        public void addLog(string log)
        {
            tbActivityStatistics.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss: ") + log + Environment.NewLine + tbActivityStatistics.Text;
        }
        #endregion
        #region timer event
        // mySQL data update
        private void timerUpdateData_Tick(object sender, EventArgs e)
        {
            timerUpdateData.Stop();
            if (timerUpdateData.Interval == 10)
            {
                Thread Notify = new Thread(loadNotify) { IsBackground = true };
                Notify.Start();
                bgwUpdateData.RunWorkerAsync();
            }
            else if (database.Connect())
            {
                SW_data.LastUpdate = database.UpdateData("Micom SW Version", dataTableSWVersion, SW_data.LastUpdate);
                Eeprom_data.LastUpdate = database.UpdateData("EEPROM OPTION", dataTableEepromOption, Eeprom_data.LastUpdate);
                timerUpdateData.Interval = 60000;
                timerUpdateData.Start();
            }
        }
        #endregion
        string acction;
        private void buttonActionClick(object sender, EventArgs e)
        {
            string resultStr = "";
            string ctrl = ((Button)sender).Name;
            if (dgvSWVersionMornitor.Visible && !dgvMicomOption.Visible)
            {
                switch (ctrl)
                {
                    case "btCancleAction":
                        pnDataEdit.Hide();
                        btModelEdit.Enabled = false;
                        btModelClear.Enabled = false;
                        dgvSWVersionMornitor.Enabled = true;
                        break;
                    case "btModelAddNew":
                        pnDataEdit.BringToFront();
                        pnDataEdit.Show();
                        acction = "add";
                        dgvSWVersionMornitor.Enabled = false;
                        break;
                    case "btModelClear":
                        pnLoading.Text = "Loading.....";
                        string message = "Do you want to clear this model ?";
                        string title = "Clear model " + Model.AssyCode;
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            pnLoading.Show();
                            while (!pnLoading.Visible) ;
                            resultStr = database.DeleteData(Model.MasterData);
                            pnLoading.Text = resultStr;
                            addLog(Global.user.userName + " Clear model " + Model.Name + Environment.NewLine + " Assy code " + Model.AssyCode + Environment.NewLine + " PBA code " + Model.PBACode + Environment.NewLine + resultStr);
                            if (resultStr == "success.")
                            {
                                database.updateAction(Global.user.userName, " Clear model \"" + Model.Name + "\" Assy code \"" + Model.AssyCode + "\" PBA code \"" + Model.PBACode + "\"");
                            }
                        }
                        SW_data.RowSelected = -1;
                        SW_data.LastUpdate = database.UpdateData("Micom SW Version", dataTableSWVersion, SW_data.LastUpdate);
                        break;
                    case "btModelEdit":
                        SW_loadDataToControl();
                        pnDataEdit.BringToFront();
                        pnDataEdit.Show();
                        acction = "edit";
                        dgvSWVersionMornitor.Enabled = false;
                        break;
                    case "btModelUpdate":
                        pnLoading.Show();
                        while (!pnLoading.Visible) ;

                        if (database.Connect())
                        {
                            string masterData = SW_getDataFromControl(acction);
                            if (acction == "add")
                            {
                                resultStr = database.InsertDatabase(Model);
                                addLog(Global.user.userName + " Add model " + Model.Name + Environment.NewLine + " Assy code " + Model.AssyCode + Environment.NewLine + " PBA code " + Model.PBACode + Environment.NewLine + resultStr);
                                if (resultStr == "success.")
                                {
                                    database.updateAction(Global.user.userName, " Add model \"" + Model.Name + "\" Assy code \"" + Model.AssyCode + "\" PBA code \"" + Model.PBACode + "\"");
                                }
                            }

                            if (acction == "edit")
                            {
                                string message1 = "Do you want to change this model ?";
                                string title1 = "Update model " + Model.AssyCode;
                                MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                                DialogResult result1 = MessageBox.Show(message1, title1, buttons1);
                                if (result1 == DialogResult.Yes)
                                {
                                    pnLoading.Show();
                                    resultStr = database.EditDatabase(Model, masterData);
                                    addLog(Global.user.userName + " Update model " + Model.Name + Environment.NewLine + " Assy code " + Model.AssyCode + Environment.NewLine + " PBA code " + Model.PBACode + Environment.NewLine + resultStr);
                                    if (resultStr == "success.")
                                    {
                                        database.updateAction(Global.user.userName, " Update model \"" + Model.Name + "\" Assy code \"" + Model.AssyCode + "\" PBA code \"" + Model.PBACode + "\"");
                                    }
                                }
                            }
                            SW_data.LastUpdate = database.UpdateData("Micom SW Version", dataTableSWVersion, SW_data.LastUpdate);
                            pnDataEdit.Hide();
                            btModelEdit.Enabled = false;
                            btModelClear.Enabled = false;
                            dgvSWVersionMornitor.Enabled = true;
                            dgvSWVersionMornitor.ClearSelection();
                            if (SW_data.RowSelected >= 0)
                            {
                                dgvSWVersionMornitor.Rows[SW_data.RowSelected].Selected = true;
                                SW_data.RowSelected = -1;
                            }
                        }
                        break;
                    case "btExport":
                        var lines = new List<string>();

                        string[] columnNames = dataTableSWVersion.Columns
                            .Cast<DataColumn>()
                            .Select(column => column.ColumnName)
                            .ToArray();

                        var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
                        lines.Add(header);

                        var valueLines = dataTableSWVersion.AsEnumerable()
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
            else if (!dgvSWVersionMornitor.Visible && dgvMicomOption.Visible)
            {
                switch (ctrl)
                {
                    case "btEECancleAction":
                        pnEepromOptionChange.Hide();
                        dgvMicomOption.Enabled = true;
                        btModelEdit.Enabled = false;
                        btModelClear.Enabled = false;
                        break;
                    case "btModelAddNew":
                        pnEepromOptionChange.Show();
                        acction = "add";
                        dgvMicomOption.Enabled = false;
                        break;
                    case "btModelClear":
                        pnLoading.Text = "Loading.....";
                        string message = "Do you want to clear this model ?";
                        string title = "Clear model " + eePROM.KitCode;
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result = MessageBox.Show(message, title, buttons);
                        if (result == DialogResult.Yes)
                        {
                            pnLoading.Show();
                            while (!pnLoading.Visible) ;
                            resultStr = database.Eeprom_Clrear(eePROM.KeyCode);
                            pnLoading.Text = resultStr;
                            if (resultStr == "success.")
                            {
                                addLog(Global.user.userName + " Clear model: \"" + eePROM.KitCode + "\" " + resultStr);
                                database.updateAction(Global.user.userName, "EEPROM Clear model \"" + eePROM.KitCode + "\" ");
                            }
                        }
                        Eeprom_data.RowSelected = -1;
                        Eeprom_data.LastUpdate = database.UpdateData("EEPROM OPTION", dataTableEepromOption, Eeprom_data.LastUpdate);
                        break;
                    case "btModelEdit":
                        EEPROM_loadDataToControl();
                        eePROM.GetData(dgvMicomOption, Eeprom_data.RowSelected);
                        pnEepromOptionChange.Show();
                        acction = "edit";
                        dgvMicomOption.Enabled = false;
                        break;
                    case "btEEModelUpdate":
                        pnLoading.Show();
                        while (!pnLoading.Visible) ;
                        if (database.Connect())
                        {
                            string masterData = EEPROM_getDataFromControls(acction);
                            if (acction == "add")
                            {
                                resultStr = database.Eeprom_Insert(eePROM);
                                if (resultStr == "success.")
                                {
                                    addLog(Global.user.userName + "EEPROM Add model \"" + eePROM.KitCode + "\" " + resultStr);
                                    database.updateAction(Global.user.userName, "EEPROM Add model \"" + eePROM.KitCode + "\" ");
                                }
                            }
                            if (acction == "edit")
                            {
                                string message1 = "Do you want to change this model ?";
                                string title1 = "Update model " + eePROM.KitCode;
                                MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                                DialogResult result1 = MessageBox.Show(message1, title1, buttons1);
                                if (result1 == DialogResult.Yes)
                                {
                                    pnLoading.Show();
                                    resultStr = database.Eeprom_Edit(eePROM, masterData);
                                    if (resultStr == "success.")
                                    {
                                        addLog(Global.user.userName + "EEPROM Update model \"" + eePROM.KitCode + "\" " + resultStr);
                                        database.updateAction(Global.user.userName, " Update model \"" + eePROM.KitCode + "\" ");
                                    }
                                }
                            }
                            Eeprom_data.LastUpdate = database.UpdateData("EEPROM OPTION", dataTableEepromOption, Eeprom_data.LastUpdate);
                            pnEepromOptionChange.Hide();
                            btModelEdit.Enabled = false;
                            btModelClear.Enabled = false;
                            dgvMicomOption.Enabled = true;
                            dgvMicomOption.ClearSelection();
                            dgvMicomOption.Rows[Eeprom_data.RowSelected].Selected = true;
                            pnLoading.Hide();
                            SW_data.RowSelected = -1;
                        }
                        break;
                    case "btExport":
                        var lines = new List<string>();

                        string[] columnNames = dataTableEepromOption.Columns
                            .Cast<DataColumn>()
                            .Select(column => column.ColumnName)
                            .ToArray();

                        var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
                        lines.Add(header);

                        var valueLines = dataTableSWVersion.AsEnumerable()
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
            pnLoading.Hide();
        }
        private void SW_loadDataToControl()
        {

            if (Model.MasterData.Contains("DA"))
            {
                cbbSetModelType.SelectedIndex = 1;
            }
            else if (Model.MasterData.Contains("DJ"))
            {
                cbbSetModelType.SelectedIndex = 2;
            }
            else if (Model.MasterData.Contains("DC"))
            {
                cbbSetModelType.SelectedIndex = 3;
            }
            else
            {
                cbbSetModelType.SelectedIndex = 0;
            }

            tbModelName.Text = Model.Name;
            tbAssyCode.Text = Model.AssyCode;
            cbbWritingArea.Text = Model.WritingArea;
            cbbPBAcode.Text = Model.PBACode;
            cbbPCBcode.Text = Model.PCBCode;

            tbAssyMicomCodeRom1.Text = Model.ROMs[0].AssyMicomCode;
            cbbMainMicomName.Text = Model.ROMs[0].MicomName;
            tbChecksumRom1.Text = Model.ROMs[0].Checksum;
            tbVersionRom1.Text = Model.ROMs[0].Version;

            if (Model.ROMs[0].DateApply.Length >= 8)
            {
                var spectCh= '\\';
                foreach (Char spectChar in Model.ROMs[0].DateApply)
                {
                    if (!Char.IsLetterOrDigit(spectChar))
                    {
                        spectCh = spectChar;
                        Console.Write(spectChar);
                        break;
                    }
 
                }
                string[] dateStr = Model.ROMs[0].DateApply.Split(spectCh);

                Console.WriteLine(dateStr[0] + " " + dateStr[1] + " " + dateStr[2]);
                Console.WriteLine(Convert.ToInt32(dateStr[0]) + " " + Convert.ToInt32(dateStr[1]) + " " + Convert.ToInt32(dateStr[2]));
                try
                {
                    DateTime date = new DateTime();
                    if (Convert.ToInt32(dateStr[1]) > 12)
                    {
                        date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[0]), Convert.ToInt32(dateStr[1]));
                    }
                    else
                    {
                        date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));
                    }
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
                var spectCh = '\\';
                foreach (Char spectChar in Model.ROMs[1].DateApply)
                {
                    if (!Char.IsLetterOrDigit(spectChar))
                    {
                        spectCh = spectChar;
                        Console.Write(spectChar);
                        break;
                    }
                }
                string[] dateStr = Model.ROMs[1].DateApply.Split(spectCh);
                try
                {
                    DateTime date = new DateTime();
                    if (Convert.ToInt32(dateStr[1]) > 12)
                    {
                        date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[0]), Convert.ToInt32(dateStr[1]));
                    }
                    else
                    {
                        date = new DateTime(Convert.ToInt32(dateStr[2]), Convert.ToInt32(dateStr[1]), Convert.ToInt32(dateStr[0]));
                    }

                    dtpInvMicomApply.Value = date;
                    dtpInvMicomApply.Checked = true;
                }
                catch (Exception)
                { }
            }
            else
            {
                dtpInvMicomApply.Checked = false;
            }

            if (tbChecksumRom2.TextLength > 1)
            {
                gbROM2.Visible = true;
                cb2Rom.Checked = true;
                cb1Rom.Checked = false;
            }
            else
            {
                gbROM2.Visible = false;
                cb1Rom.Checked = true;
                cb2Rom.Checked = false;
            }
        }
        private string SW_getDataFromControl(string acction)
        {
            if (acction == "add")
            {
                if (tbAssyCode.TextLength > 2)
                {
                    Model.MasterData = tbAssyCode.Text;
                }
                else if (cbbPBAcode.Text.Length > 2)
                {
                    Model.MasterData = tbAssyCode.Text;
                }
                if (Model.MasterData.Length < 2)
                {
                    switch (cbbSetModelType.SelectedIndex)
                    {
                        case 0:
                            break;
                        case 1:
                            Model.MasterData = "DA-";
                            break;
                        case 2:
                            Model.MasterData = "DJ-";
                            break;
                        case 3:
                            Model.MasterData = "DC-";
                            break;
                        default:
                            break;
                    }
                    Model.MasterData += DateTime.Now.ToString("yyyyMMdd");
                }

                int exited = 0;
            retry:
                exited++;
                for (int i = 0; i < dataTableSWVersion.Rows.Count; i++)
                {
                    if (dataTableSWVersion.Rows[i].ItemArray[0].ToString() == Model.MasterData)
                    {
                        Model.MasterData += "#" + exited.ToString();
                        goto retry;
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
                Model.ROMs[1].AssyMicomCode = tbAssyMicomCodeRom2.Text;
                Model.ROMs[1].MicomName = cbbInvMicomName.Text;
                Model.ROMs[1].Checksum = tbChecksumRom2.Text;
                Model.ROMs[1].Version = tbVersionRom2.Text;
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
        private void EEPROM_loadDataToControl()
        {
            cbbCompany.Text = eePROM.Company;
            cbbkitCode.Text = eePROM.KitCode;
            cbbM_PCBassyCode.Text = eePROM.MainPCBAssyCode;
            cbbM_PCBcode.Text = eePROM.MainPCBCode;
            cbbSUbPCBAssyCode.Text = eePROM.SubPCBAssyCode;
            cbbSubPCBcode.Text = eePROM.SubPCBCode;
            tbEepromOption.Text = eePROM.EEPROMOption;
            tbEepromPackage.Text = eePROM.EEPROMPacket;
            cbbEepromAssyCode.Text = eePROM.EEPROMAssyCode;
        }
        private string EEPROM_getDataFromControls(string action)
        {
            if (acction == "add")
            {
                eePROM.KeyCode = cbbkitCode.Text;
                if (eePROM.KeyCode.Length < 2)
                {
                    eePROM.KeyCode = "NULL";
                }

                int exited = 0;
            retry:
                exited++;
                for (int i = 0; i < dataTableEepromOption.Rows.Count; i++)
                {
                    if (dataTableEepromOption.Rows[i].ItemArray[0].ToString() == Model.MasterData)
                    {
                        eePROM.KeyCode += "#" + exited.ToString();
                        goto retry;
                    }
                }
            }
            eePROM.Company = cbbCompany.Text;
            eePROM.KitCode = cbbkitCode.Text;
            eePROM.MainPCBAssyCode = cbbM_PCBassyCode.Text;
            eePROM.MainPCBCode = cbbM_PCBcode.Text;
            eePROM.SubPCBAssyCode = cbbSUbPCBAssyCode.Text;
            eePROM.SubPCBCode = cbbSubPCBcode.Text;
            eePROM.EEPROMOption = tbEepromOption.Text;
            eePROM.EEPROMPacket = tbEepromPackage.Text;
            eePROM.EEPROMAssyCode = cbbEepromAssyCode.Text;
            return eePROM.KeyCode;
        }
        #region Event
        private void dgvSWVersionMornitor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != SW_data.RowSelected)
            {
                btModelEdit.Enabled = Global.user.userPermission.Contains(User.Permission.Clear.ToString());
                btModelClear.Enabled = Global.user.userPermission.Contains(User.Permission.Edit.ToString());
                Model.GetData(dgvSWVersionMornitor, e.RowIndex);
                SW_data.RowSelected = e.RowIndex;
            }
        }
        private void btFind_Click(object sender, EventArgs e)
        {
            if (dgvSWVersionMornitor.Visible)
            {
                btModelEdit.Enabled = false;
                btModelClear.Enabled = false;
                dgvSWVersionMornitor.ClearSelection();
                lbLoading.Text = "Searching....";
                pnLoading.Visible = true;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvSWVersionMornitor.DataSource];
                currencyManager.SuspendBinding();
                if (tbFindModel.TextLength < 2)
                {
                    SW_data.Filter_Clear();
                }
                else
                {
                    SW_data.FilterOR(tbFindModel.Text);
                    for (int row = 0; row < dgvSWVersionMornitor.RowCount; row++)
                    {
                        for (int column = 0; column < dgvSWVersionMornitor.ColumnCount; column++)
                        {
                            if (dgvSWVersionMornitor[column, row].Value.ToString().Contains(tbFindModel.Text) || dgvSWVersionMornitor[column, row].Value.ToString().Contains(tbFindModel.Text.ToUpper()))
                            {
                                dgvSWVersionMornitor[column, row].Style.BackColor = Color.YellowGreen;
                            }
                            else
                            {
                                dgvSWVersionMornitor[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                            }
                        }
                    }
                }
                currencyManager.ResumeBinding();
                pnLoading.Visible = false;
            }
            else if (dgvMicomOption.Visible)
            {
                btModelEdit.Enabled = false;
                btModelClear.Enabled = false;
                dgvMicomOption.ClearSelection();
                lbLoading.Text = "Searching....";
                pnLoading.Visible = true;
                CurrencyManager currencyManager = (CurrencyManager)BindingContext[dgvMicomOption.DataSource];
                currencyManager.SuspendBinding();
                if (tbFindModel.TextLength < 2)
                {
                    Eeprom_data.Filter_Clear();
                }
                else
                {
                    Eeprom_data.FilterOR(tbFindModel.Text);
                    for (int row = 0; row < dgvMicomOption.RowCount; row++)
                    {
                        for (int column = 0; column < dgvMicomOption.ColumnCount; column++)
                        {
                            if (dgvMicomOption[column, row].Value.ToString().Contains(tbFindModel.Text) || dgvMicomOption[column, row].Value.ToString().Contains(tbFindModel.Text.ToUpper()))
                            {
                                dgvMicomOption[column, row].Style.BackColor = Color.YellowGreen;
                            }
                            else
                            {
                                dgvMicomOption[column, row].Style.BackColor = Color.FromArgb(189, 204, 217);
                            }
                        }
                    }
                }
                currencyManager.ResumeBinding();
                pnLoading.Visible = false;
            }
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
        private void pnLoading_Click(object sender, EventArgs e)
        {
            pnLoading.Hide();
        }
        public void loadNotify()
        {
            while (!closed)
            {
                if (database.Connect())
                {
                    lastLoadNotify = database.loadAction(lastLoadNotify, tbServerNotify);
                }
                Thread.Sleep(1000);
            }
        }
        private void panelSelect(object sender, EventArgs e)
        {
            btModelAddNew.Enabled = Global.user.userPermission.Contains("Add");
            btMicomoption.BackColor = deactiverPanel;
            btMicomSW.BackColor = deactiverPanel;
            btMicomoption.ForeColor = activePanel;
            btMicomSW.ForeColor = activePanel;

            ((Button)sender).BackColor = activePanel;
            ((Button)sender).ForeColor = deactiverPanel;

            string Ctrl = ((Button)sender).Name;
            switch (Ctrl)
            {
                case "btMicomSW":
                    SW_data.LastUpdate = database.UpdateData("Micom SW Version", dataTableSWVersion, SW_data.LastUpdate);
                    dgvMicomOption.Visible = false;
                    dgvSWVersionMornitor.Visible = true;
                    dgvSWVersionMornitor.Enabled = true;
                    break;
                case "btMicomoption":
                    Eeprom_data.LastUpdate = database.UpdateData("EEPROM OPTION", dataTableEepromOption, Eeprom_data.LastUpdate);
                    dgvSWVersionMornitor.Visible = false;
                    dgvMicomOption.Visible = true;
                    dgvMicomOption.Enabled = true;
                    break;
            }
        }
        private void cbbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SW_data.Filter_Clear();
            switch (cbbModelType.Text)
            {
                case "All":
                    SW_data.Filter_Clear();
                    break;
                case "Refrigerator":
                    SW_data.Filter("Master Data", "DA");
                    break;
                case "Vacuum cleaner":
                    SW_data.Filter("Master Data", "DJ");
                    break;
                case "Washing machine":
                    SW_data.Filter("Master Data", "DC");
                    break;
            }
            this.ActiveControl = tbFindModel;
        }
        private void dgvMicomOption_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMicomOption.Columns.Count > 0)
            {
                dgvMicomOption.Columns[0].Visible = false;
            }
        }
        private void dgvSWVersionMornitor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvSWVersionMornitor.Columns.Count > 0)
            {
                dgvSWVersionMornitor.Columns[0].Visible = false;
                btModelAddNew.Enabled = Global.user.userPermission.Contains("Add");
                pnLoading.Hide();
            }
        }
        private void bgwUpdateData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SW_data.LastUpdate = database.UpdateData("Micom SW Version", dataTableSWVersion, " ");
            Eeprom_data.LastUpdate = database.UpdateData("EEPROM OPTION", dataTableEepromOption, " ");
            btModelAddNew.Invoke(new MethodInvoker(delegate
            {
                btModelAddNew.Enabled = Global.user.userPermission.Contains("Add");
                btExport.Enabled = Global.user.userPermission.Contains("Export");
            }));


            for (int i = 0; i < dataTableSWVersion.Rows.Count; i++)
            {
                if (!cbbPBAcode.Items.Contains(dataTableSWVersion.Rows[i].ItemArray[4].ToString()))
                {
                    cbbPBAcode.Items.Add(dataTableSWVersion.Rows[i].ItemArray[4].ToString());
                }
                if (!cbbPCBcode.Items.Contains(dataTableSWVersion.Rows[i].ItemArray[5].ToString()))
                {
                    cbbPCBcode.Items.Add(dataTableSWVersion.Rows[i].ItemArray[5].ToString());
                }
                if (!cbbMainMicomName.Items.Contains(dataTableSWVersion.Rows[i].ItemArray[7].ToString()))
                {
                    cbbMainMicomName.Items.Add(dataTableSWVersion.Rows[i].ItemArray[7].ToString());
                }
                if (!cbbInvMicomName.Items.Contains(dataTableSWVersion.Rows[i].ItemArray[12].ToString()))
                {
                    cbbInvMicomName.Items.Add(dataTableSWVersion.Rows[i].ItemArray[12].ToString());
                }
            }

            for (int i = 0; i < dataTableEepromOption.Rows.Count; i++)
            {
                if (!cbbCompany.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[1].ToString()))
                {
                    cbbCompany.Items.Add(dataTableEepromOption.Rows[i].ItemArray[1].ToString());
                }
                if (!cbbkitCode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[2].ToString()))
                {
                    cbbkitCode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[2].ToString());
                }
                if (!cbbM_PCBassyCode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[3].ToString()))
                {
                    cbbM_PCBassyCode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[3].ToString());
                }
                if (!cbbM_PCBcode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[4].ToString()))
                {
                    cbbM_PCBcode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[4].ToString());
                }
                if (!cbbSUbPCBAssyCode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[5].ToString()))
                {
                    cbbSUbPCBAssyCode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[5].ToString());
                }
                if (!cbbSubPCBcode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[6].ToString()))
                {
                    cbbSubPCBcode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[6].ToString());
                }
                if (!cbbEepromAssyCode.Items.Contains(dataTableEepromOption.Rows[i].ItemArray[7].ToString()))
                {
                    cbbEepromAssyCode.Items.Add(dataTableEepromOption.Rows[i].ItemArray[7].ToString());
                }
            }


        }
        private void bgwUpdateData_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SW_data.Init();
            Eeprom_data.Init();
            timerUpdateData.Interval = 60000;
            timerUpdateData.Start();
        }
        private void dgvSWVersionMornitor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != SW_data.RowSelected)
            {
                btModelEdit.Enabled = Global.user.userPermission.Contains(User.Permission.Clear.ToString());
                btModelClear.Enabled = Global.user.userPermission.Contains(User.Permission.Edit.ToString());
                Model.GetData(dgvSWVersionMornitor, e.RowIndex);
                SW_data.RowSelected = e.RowIndex;
            }
            SW_loadDataToControl();
            if (Global.user.userPermission.Contains("Edit"))
            {
                pnDataEdit.BringToFront();
                pnDataEdit.Visible = true;
                acction = "edit";
                dgvSWVersionMornitor.Enabled = false;
            }
        }

        private void dgvMicomOption_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != SW_data.RowSelected)
            {
                eePROM.GetData(dgvMicomOption, e.RowIndex);
                SW_data.RowSelected = e.RowIndex;
            }
            EEPROM_loadDataToControl();
            if (Global.user.userPermission.Contains("Edit"))
            {
                acction = "edit";
                pnEepromOptionChange.Visible = true;
                dgvSWVersionMornitor.Enabled = false;
            }
        }

        public List<string> GetAutoCompleSource(DataTable table, int ColumnsIndex, List<string> objectSource)
        {
            List<string> source = new List<string>(objectSource);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (!source.Contains(table.Rows[i].ItemArray[ColumnsIndex].ToString()))
                {
                    source.Add(table.Rows[i].ItemArray[ColumnsIndex].ToString());
                }
            }
            return source;
        }

        private void dgvMicomOption_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != Eeprom_data.RowSelected)
            {
                btModelEdit.Enabled = Global.user.userPermission.Contains(User.Permission.Clear.ToString());
                btModelClear.Enabled = Global.user.userPermission.Contains(User.Permission.Edit.ToString());
                Eeprom_data.RowSelected = e.RowIndex;
            }
        }

        private void tbFindModel_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btFineModel;
            if (tbFindModel.TextLength == 0)
            {
                SW_data.Filter_Clear();
                Eeprom_data.Filter_Clear();
            }
        }

        private void btOption_Click(object sender, EventArgs e)
        {
            pnSystem.Visible = pnSystem.Visible ? false : true;
            if (pnSystem.Visible)
            {
                btSystemSettingCancle.Text = "Cancle";
                pnSystem.BringToFront();
                if (database.Connect())
                {
                    nUDStoptimeDefine.Value = database.checkUpdateStopTime("check", 0);
                }
            }
        }

        private void btSystemSettingUpdate_Click(object sender, EventArgs e)
        {
            if (database.Connect())
            {
                nUDStoptimeDefine.Value = database.checkUpdateStopTime("update", (int)nUDStoptimeDefine.Value);
                btSystemSettingCancle.Text = "Close";
            }
        }

        private void btSystemSettingCancle_Click(object sender, EventArgs e)
        {
            pnSystem.Visible = false;
        }
    }
}
