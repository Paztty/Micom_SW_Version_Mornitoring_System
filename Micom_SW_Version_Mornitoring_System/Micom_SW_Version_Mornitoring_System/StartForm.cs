using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class StartForm : Form
    {
        MySQL mySQL = new MySQL();
        public StartForm()
        {

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;


            InitializeComponent();
            try
            {
                if (!Directory.Exists(@"C:\DEV\MSWS")) Directory.CreateDirectory(@"C:\DEV\MSWS");
                if (File.Exists(@"C:\DEV\MSWS\config.txt"))
                {
                    lbLine.Text = File.ReadAllText(@"C:\DEV\MSWSconfig.txt");
                }

                if (!File.Exists(@"C:\DEV\MSWS\databaseConfig.cfg"))
                {
                    string connecStr = JsonSerializer.Serialize(mySQL);
                    File.WriteAllText(@"C:\DEV\MSWS\databaseConfig.cfg", connecStr);
                }
                else
                {
                    string str = File.ReadAllText(@"C:\DEV\MSWS\databaseConfig.cfg");
                    mySQL = JsonSerializer.Deserialize<MySQL>(str);
                }
            }
            catch (Exception)
            { }

            String firstMacAddress = NetworkInterface
                    .GetAllNetworkInterfaces()
                    .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    .Select(nic => nic.GetPhysicalAddress().ToString())
                    .FirstOrDefault();
            Console.WriteLine(firstMacAddress);

        }
        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var requestedNameAssembly = new System.Reflection.AssemblyName(args.Name);
            var requestedName = requestedNameAssembly.Name;
            if (requestedName.EndsWith(".resources")) return null;
            var binFolder = Application.StartupPath;
            var fullPath = System.IO.Path.Combine(binFolder, requestedName) + ".dll";
            if (System.IO.File.Exists(fullPath))
            {
                return System.Reflection.Assembly.LoadFrom(fullPath);
            }
            return null;
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
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        #endregion

        private void btManager_Click(object sender, EventArgs e)
        {
            if (mySQL.TestConnection())
            {
                if (changePassFlag)
                {
                    if (tbUser.TextLength < 7)
                    {
                        lbEngNotification.Text = "Tài khoản cần tối thiểu 7 kí tự." + Environment.NewLine + "Account needs a minimum of 7 characters.";
                    }
                    else
                    {
                        if (mySQL.AccountCheck(tbUser.Text, tbPassword.Text) != "Guest")
                        {
                            if (tbNewPass.Text == tbRetype.Text)
                            {
                                lbEngNotification.Text = "Change user password " + mySQL.AccountChangePass(tbUser.Text, tbNewPass.Text);
                            }
                        }
                    }
                }
                else
                {
                    if (mySQL.AccountCheck(tbUser.Text, tbPassword.Text) != "Guest")
                    {
                        ManagerForm managerForm = new ManagerForm();
                        this.Hide();
                        managerForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        //lbVieNotification.Text = "Tài khoản hoặc mật khẩu không chính xác. Trong trường hợp quên mật khẩu vui lòng liên hệ quản trị viên: 0346809230.";
                        lbEngNotification.Text = "Account or password is incorrect. In case of forgetting the password, please contact the administrator: 0346809230.";
                    }
                }
            }
            else
            {
                lbEngNotification.Text = "Connection fail.";
            }
        }

        private void btMonitoring_Click(object sender, EventArgs e)
        {
            Mornitoring mornitoring = new Mornitoring();
            this.Hide();
            mornitoring.ShowDialog();
            this.Show();

        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btManager;
        }

        bool changePassFlag = false;
        private void lbChangePass_Click(object sender, EventArgs e)
        {
            if (changePassFlag)
            {
                lbChangePass.Text = "Change Password";
                btManager.Text = "Manager";
                changePassFlag = false;
                lbNewPass.Visible = changePassFlag;
                tbNewPass.Visible = changePassFlag;
                lbRetype.Visible = changePassFlag;
                tbRetype.Visible = changePassFlag;
            }
            else
            {
                btManager.Text = "Change";
                lbChangePass.Text = "Login";
                changePassFlag = true;
                lbNewPass.Visible = changePassFlag;
                tbNewPass.Visible = changePassFlag;
                lbRetype.Visible = changePassFlag;
                tbRetype.Visible = changePassFlag;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperatorForm operatorForm = new OperatorForm();
            this.Hide();
            operatorForm.ShowDialog();
            this.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (mySQL.TestConnection())
            {
                string lineStatus = File.ReadAllText(@"C:\Auto Micom Writing\AMW\status.txt");
                string line = File.ReadAllText(@"C:\DEV\MSWS\config.txt");
                mySQL.UpdateRunStopStatus(lineStatus, line);
            }
            timer.Interval = 5000;
        }
        private void StartForm_Load(object sender, EventArgs e)
        {
            if (mySQL.TestConnection())
            {
                if (File.Exists(@"C:\Auto Micom Writing\AMW\status.txt") && File.Exists(@"C:\DEV\MSWS\config.txt"))
                {
                    string lineStatus = File.ReadAllText(@"C:\Auto Micom Writing\AMW\status.txt");
                    string line = File.ReadAllText(@"C:\DEV\MSWS\config.txt");
                    mySQL.UpdateRunStopStatus(lineStatus, line);
                    timer.Start();
                }
            }
        }
        private void StartForm_DoubleClick(object sender, EventArgs e)
        {
            
        }
        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
