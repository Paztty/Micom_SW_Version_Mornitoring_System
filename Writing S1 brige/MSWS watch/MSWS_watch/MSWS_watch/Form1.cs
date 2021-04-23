using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace MSWS_watch
{
    public partial class Form1 : Form
    {
        MySQLDatabase mydatabase = new MySQLDatabase();
        PopupNotifier popupChecksum = new PopupNotifier
        {
            TitleText = "MSWS Warning",
            ContentText = "Your model have update another checksum. Please checking."
        };
        PopupNotifier popupVersion = new PopupNotifier
        {
            TitleText = "MSWS Warning",
            ContentText = "Your model have update another version. Please checking."
        };
        public Form1()
        {
            InitializeComponent();
            notifyIcon.Visible = true;
        }

        private void btFindPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            tbWritingPath.Text = folderBrowserDialog.SelectedPath;
        }

        private void btApplySetting_Click(object sender, EventArgs e)
        {
            if (tbWritingPath.TextLength > 2 & tbStoptimer.TextLength > 0 & tbUpdateCycleTime.TextLength > 0 & cbbLineList.Text.Length > 1 )
            {
                File.WriteAllText("config.cfg", tbWritingPath.Text + Environment.NewLine + tbStoptimer.Text + Environment.NewLine + tbUpdateCycleTime.Text + Environment.NewLine + cbbLineList.Text + Environment.NewLine + checkBox1.Checked);
                tbHistory.AppendText(DateTime.Now.ToString() + ": Save config " + Environment.NewLine
                    + "Path to history: " + tbWritingPath.Text + Environment.NewLine +
                    "Stop time: " + tbStoptimer.Text + Environment.NewLine +
                    "Cycle time: " + tbUpdateCycleTime.Text + Environment.NewLine +
                     "Line: " + cbbLineList.Text + Environment.NewLine + 
                     "StartUp " + checkBox1.Checked + Environment.NewLine);
                if (!backgroundWorker.IsBusy)
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            if (File.Exists("config.cfg"))
            {
                string[] config = File.ReadAllLines("config.cfg");
                if (config.Length >= 5)
                {

                    tbWritingPath.Text = config[0];
                    tbStoptimer.Text = config[1];
                    tbUpdateCycleTime.Text = config[2];
                    cbbLineList.Text = config[3];
                    checkBox1.Checked = Convert.ToBoolean(config[4]);
                    tbHistory.AppendText(DateTime.Now.ToString() + ": Load config " + Environment.NewLine +
                                         "Path to history: " + tbWritingPath.Text + Environment.NewLine +
                                        "Stop time: " + tbStoptimer.Text + Environment.NewLine +
                                         "Cycle time: " + tbUpdateCycleTime.Text + Environment.NewLine +
                                        "Line: " + cbbLineList.Text + Environment.NewLine +
                                        "StartUp : " + checkBox1.Checked + Environment.NewLine);
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    tbHistory.AppendText(DateTime.Now.ToString() + ": Config file not correct, make your setting fist" + Environment.NewLine);
                }
            }
            else
            {
                tbHistory.AppendText(DateTime.Now.ToString() + ": No config file, make your setting fist" + Environment.NewLine);
            }

            if (mydatabase.Connect())
            {
                string line = cbbLineList.Text;
                List<string> lines = new List<string>();
                mydatabase.getLineList(lines);
                cbbLineList.DataSource = lines;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (line == lines[i])
                    {
                        cbbLineList.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                return true;
            }
            return false;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string status = "STOP";
            string lastStatus = "";
            string modelUser = "";
            Model useModel = new Model();
            while (true)
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(tbUpdateCycleTime.Text) * 1000);
                    var now = DateTime.Now.ToString("yyyyMMdd") + ".rlt";
                    //tbHistory.Invoke(new MethodInvoker(delegate { tbHistory.AppendText(DateTime.Now.ToString() + ": " + now + Environment.NewLine); }));
                    if (File.Exists(tbWritingPath.Text + "\\" + now))
                    {
                        var lineNumber = File.ReadAllLines(tbWritingPath.Text + "\\" + now);
                        //tbHistory.Invoke(new MethodInvoker(delegate { tbHistory.AppendText(DateTime.Now.ToString() + ": " + lineNumber.Length + Environment.NewLine); }));
                        var data = lineNumber[lineNumber.Length - 1].Split('^');
                        //2021-04-06 08:19:57^DC92-01950B_ED4E_NO17^D^06DC9201950BDYSCR460763^OK^@1@MAK@SHORT CHECK@@@@@Y^Micom Writing Error@2@ELN@FE42ED4E@WRITE@@Good@@Y^@3@DLY@@500@@exe@@Y^@4@END@@@@exe@@Y^
                        var datetimeLastcheck = Convert.ToDateTime(data[0]);
                        //Console.WriteLine(datetimeLastcheck);
                        if (DateTime.Now.Subtract(datetimeLastcheck).TotalSeconds > Convert.ToInt32(tbStoptimer.Text))
                        {
                            status = "STOP";
                        }
                        else
                        {
                            status = "RUNNING";
                        }

                        if (status != lastStatus || modelUser != data[1])
                        {
                            modelUser = data[1];
                            lastStatus = status;
                            //DC92-01950B_ED4E_NO17
                            string[] modelFromHistory = data[1].Split('_');

                            if (mydatabase.Connect())
                            {
                                int searchModel = mydatabase.GetModelLikeThis(modelFromHistory[0], modelFromHistory[1], useModel);
                                Console.WriteLine(searchModel);
                                switch (searchModel)
                                {
                                    case 11:
                                        string machineLine = "";
                                        tbHistory.Invoke(new MethodInvoker(delegate
                                        {
                                            machineLine = cbbLineList.Text;
                                            tbHistory.AppendText(DateTime.Now.ToString() + ":  Update status " + machineLine + Environment.NewLine);
                                        }));
                                        mydatabase.UpdateUsedModel(useModel, machineLine, status);
                                        break;
                                    case 10:
                                        tbHistory.Invoke(new MethodInvoker(delegate
                                        {
                                            popupChecksum.Popup();
                                        }));
                                        break;
                                    case 0:
                                        tbHistory.Invoke(new MethodInvoker(delegate
                                        {
                                            PopupNotifier popup = new PopupNotifier
                                            {
                                                TitleText = "MSWS Warning",
                                                ContentText = "Model not found. . Please checking."
                                            };
                                            popup.Popup();
                                        }));
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        tbHistory.Invoke(new MethodInvoker(delegate { tbHistory.AppendText(DateTime.Now.ToString() + ": Path not found."  + Environment.NewLine); }));
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon.Visible = false;
        }

        private void btHide_Click(object sender, EventArgs e)
        {
            this.Hide();
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
        private static readonly string StartupValue = "MSWS_Watch";

        private static void SetStartup()
        {
            //Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.SetValue(StartupValue, Application.ExecutablePath.ToString());
        }
        private static void ClearStartup()
        {
            //Set the application to run at startup
            RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey, true);
            key.DeleteValue(StartupValue);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SetStartup();
            }
            else
            {
                ClearStartup();
            }
        }
    }
}
