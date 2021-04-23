using Microsoft.Win32;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Micom_SW_Version_Mornitoring_System
{
    
    public partial class StartForm : Form
    {

        MySQLDatabase database = new MySQLDatabase();
        public StartForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            InitializeComponent();
            AssemblyInfo assemblyInfo = new AssemblyInfo(Assembly.GetEntryAssembly());
            lbVersion.Text = "Ver " + assemblyInfo.Version + "  " + assemblyInfo.Copyright + "  " + assemblyInfo.Company; 
            //SetStartup();
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

        //Startup registry key and value
        private static readonly string StartupKey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
        private static readonly string StartupValue = "MSWS";

        private static void SetStartup()
        {
            //Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());
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
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void btManager_Click(object sender, EventArgs e)
        {
            pnLoading.Show();
            timer1.Start();
        }

        public void loginManager()
        {
            if (database.Connect())
            {
                if (changePassFlag)
                {
                    if (tbUser.TextLength < 7)
                    {
                            lbEngNotification.Text = "Tài khoản cần tối thiểu 7 kí tự." + Environment.NewLine + "Account needs a minimum of 7 characters.";
                    }
                    else
                    {
                        if (database.AccountCheck(tbUser.Text, tbPassword.Text) != "Guest")
                        {
                            if (tbNewPass.Text == tbRetype.Text)
                            {
                               lbEngNotification.Text = "Change user password " + database.AccountChangePass(tbUser.Text, tbNewPass.Text);
                            }
                            pnLoading.Hide();
                        }
                    }
                }
                else
                {
                    if (database.AccountCheck(tbUser.Text, tbPassword.Text) != "Guest")
                    {
                        ManagerForm managerForm = new ManagerForm();
                        pnLoading.Hide();
                        this.Hide();
                        managerForm.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        pnLoading.Hide();
                        lbEngNotification.Text = "Account or password is incorrect. In case of forgetting the password, please contact support.";
                    }
                }
            }
            else
            {
                pnLoading.Hide();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectString connectString = new ConnectString();
            if (connectString.ShowDialog() == DialogResult.OK)
            {
                database = new MySQLDatabase();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            loginManager();
        }

        private void lbVersion_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Global.user = new User();
            ManagerForm managerForm = new ManagerForm();
            pnLoading.Hide();
            this.Hide();
            managerForm.ShowDialog();
            this.Show();
        }
    }
}
