using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Micom_SW_Version_Mornitoring_System
{
    public partial class StartForm : Form
    {
        MySQL mySQL = new MySQL();
        public StartForm()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            File.AppendAllText(@"D:\log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt", DateTime.Now.ToString("yyyy_MM_dd hh_mm :") + " Program open.");
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
            if (mySQL.AccountCheck(tbUser.Text, tbPassword.Text) != "Guest")
            {
                ManagerForm managerForm = new ManagerForm();
                managerForm.Show();
                this.Hide();
            }
            else
            {
                //lbVieNotification.Text = "Tài khoản hoặc mật khẩu không chính xác. Trong trường hợp quên mật khẩu vui lòng liên hệ quản trị viên: 0346809230.";
                lbEngNotification.Text = "Account or password is incorrect. In case of forgetting the password, please contact the administrator: 0346809230.";
            }
        }

        private void btMonitoring_Click(object sender, EventArgs e)
        {
            Mornitoring mornitoring = new Mornitoring();
            mornitoring.Show();
            this.Hide();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btManager;
        }
    }
}
