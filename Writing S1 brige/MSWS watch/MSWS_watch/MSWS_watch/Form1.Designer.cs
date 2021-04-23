namespace MSWS_watch
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbWritingPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btFindPath = new System.Windows.Forms.Button();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.btHide = new System.Windows.Forms.Button();
            this.tbStoptimer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btApplySetting = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUpdateCycleTime = new System.Windows.Forms.TextBox();
            this.cbbLineList = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tbWritingPath
            // 
            this.tbWritingPath.Location = new System.Drawing.Point(86, 13);
            this.tbWritingPath.Name = "tbWritingPath";
            this.tbWritingPath.Size = new System.Drawing.Size(250, 20);
            this.tbWritingPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Writting Path";
            // 
            // btFindPath
            // 
            this.btFindPath.Location = new System.Drawing.Point(342, 12);
            this.btFindPath.Name = "btFindPath";
            this.btFindPath.Size = new System.Drawing.Size(75, 21);
            this.btFindPath.TabIndex = 2;
            this.btFindPath.Text = "Browser";
            this.btFindPath.UseVisualStyleBackColor = true;
            this.btFindPath.Click += new System.EventHandler(this.btFindPath_Click);
            // 
            // tbHistory
            // 
            this.tbHistory.Location = new System.Drawing.Point(15, 112);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.Size = new System.Drawing.Size(402, 358);
            this.tbHistory.TabIndex = 3;
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(342, 476);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(75, 21);
            this.btHide.TabIndex = 4;
            this.btHide.Text = "Hide";
            this.btHide.UseVisualStyleBackColor = true;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // tbStoptimer
            // 
            this.tbStoptimer.Location = new System.Drawing.Point(286, 39);
            this.tbStoptimer.MaxLength = 10;
            this.tbStoptimer.Name = "tbStoptimer";
            this.tbStoptimer.Size = new System.Drawing.Size(30, 20);
            this.tbStoptimer.TabIndex = 6;
            this.tbStoptimer.Text = "60";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stop timer (0~99s)";
            // 
            // btApplySetting
            // 
            this.btApplySetting.Location = new System.Drawing.Point(342, 73);
            this.btApplySetting.Name = "btApplySetting";
            this.btApplySetting.Size = new System.Drawing.Size(75, 21);
            this.btApplySetting.TabIndex = 8;
            this.btApplySetting.Text = "Apply";
            this.btApplySetting.UseVisualStyleBackColor = true;
            this.btApplySetting.Click += new System.EventHandler(this.btApplySetting_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "S";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Writing machine history folder";
            this.folderBrowserDialog.SelectedPath = "C:\\";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "S";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Update cycle time";
            // 
            // tbUpdateCycleTime
            // 
            this.tbUpdateCycleTime.Location = new System.Drawing.Point(111, 40);
            this.tbUpdateCycleTime.MaxLength = 10;
            this.tbUpdateCycleTime.Name = "tbUpdateCycleTime";
            this.tbUpdateCycleTime.Size = new System.Drawing.Size(30, 20);
            this.tbUpdateCycleTime.TabIndex = 10;
            this.tbUpdateCycleTime.Text = "60";
            // 
            // cbbLineList
            // 
            this.cbbLineList.FormattingEnabled = true;
            this.cbbLineList.Location = new System.Drawing.Point(45, 74);
            this.cbbLineList.Name = "cbbLineList";
            this.cbbLineList.Size = new System.Drawing.Size(137, 21);
            this.cbbLineList.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Line";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MSWS Watch";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(200, 76);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Start with window";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 509);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbbLineList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUpdateCycleTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btApplySetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStoptimer);
            this.Controls.Add(this.btHide);
            this.Controls.Add(this.tbHistory);
            this.Controls.Add(this.btFindPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbWritingPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MSWS_Watch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbWritingPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btFindPath;
        private System.Windows.Forms.TextBox tbHistory;
        private System.Windows.Forms.Button btHide;
        private System.Windows.Forms.TextBox tbStoptimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btApplySetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUpdateCycleTime;
        private System.Windows.Forms.ComboBox cbbLineList;
        private System.Windows.Forms.Label label6;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

