namespace Micom_SW_Version_Mornitoring_System
{
    partial class ConnectString
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btManager = new System.Windows.Forms.Button();
            this.btMornitoring = new System.Windows.Forms.Button();
            this.lbIPserver = new System.Windows.Forms.Label();
            this.btApply = new System.Windows.Forms.Button();
            this.loaddingBox = new System.Windows.Forms.PictureBox();
            this.bgwTestConnect = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.loaddingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(399, 26);
            this.textBox1.TabIndex = 0;
            // 
            // btManager
            // 
            this.btManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.btManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btManager.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btManager.FlatAppearance.BorderSize = 2;
            this.btManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btManager.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btManager.ForeColor = System.Drawing.Color.White;
            this.btManager.Location = new System.Drawing.Point(623, 7);
            this.btManager.Name = "btManager";
            this.btManager.Size = new System.Drawing.Size(71, 26);
            this.btManager.TabIndex = 4;
            this.btManager.Text = "CLOSE";
            this.btManager.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btManager.UseVisualStyleBackColor = false;
            this.btManager.Click += new System.EventHandler(this.btManager_Click);
            // 
            // btMornitoring
            // 
            this.btMornitoring.BackColor = System.Drawing.Color.White;
            this.btMornitoring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btMornitoring.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(121)))), ((int)(((byte)(155)))));
            this.btMornitoring.FlatAppearance.BorderSize = 2;
            this.btMornitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMornitoring.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMornitoring.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.btMornitoring.Location = new System.Drawing.Point(417, 36);
            this.btMornitoring.Name = "btMornitoring";
            this.btMornitoring.Size = new System.Drawing.Size(83, 26);
            this.btMornitoring.TabIndex = 3;
            this.btMornitoring.Text = "TEST";
            this.btMornitoring.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btMornitoring.UseVisualStyleBackColor = false;
            this.btMornitoring.Click += new System.EventHandler(this.btMornitoring_Click);
            // 
            // lbIPserver
            // 
            this.lbIPserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.lbIPserver.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIPserver.ForeColor = System.Drawing.Color.White;
            this.lbIPserver.Location = new System.Drawing.Point(18, 6);
            this.lbIPserver.Name = "lbIPserver";
            this.lbIPserver.Size = new System.Drawing.Size(599, 24);
            this.lbIPserver.TabIndex = 9;
            this.lbIPserver.Text = "IP SERVER (Ex: 123.1.2.3)";
            this.lbIPserver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btApply
            // 
            this.btApply.BackColor = System.Drawing.Color.White;
            this.btApply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btApply.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(121)))), ((int)(((byte)(155)))));
            this.btApply.FlatAppearance.BorderSize = 2;
            this.btApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btApply.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.btApply.Location = new System.Drawing.Point(506, 36);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(188, 26);
            this.btApply.TabIndex = 10;
            this.btApply.Text = "APPLY";
            this.btApply.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btApply.UseVisualStyleBackColor = false;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // loaddingBox
            // 
            this.loaddingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.loaddingBox.Image = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.loadding;
            this.loaddingBox.InitialImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.loadding;
            this.loaddingBox.Location = new System.Drawing.Point(12, 4);
            this.loaddingBox.Name = "loaddingBox";
            this.loaddingBox.Size = new System.Drawing.Size(29, 29);
            this.loaddingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loaddingBox.TabIndex = 11;
            this.loaddingBox.TabStop = false;
            // 
            // bgwTestConnect
            // 
            this.bgwTestConnect.WorkerReportsProgress = true;
            this.bgwTestConnect.WorkerSupportsCancellation = true;
            this.bgwTestConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTestConnect_DoWork);
            this.bgwTestConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTestConnect_RunWorkerCompleted);
            // 
            // ConnectString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(55)))), ((int)(((byte)(106)))));
            this.ClientSize = new System.Drawing.Size(706, 69);
            this.ControlBox = false;
            this.Controls.Add(this.loaddingBox);
            this.Controls.Add(this.btApply);
            this.Controls.Add(this.lbIPserver);
            this.Controls.Add(this.btManager);
            this.Controls.Add(this.btMornitoring);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ConnectString";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.loaddingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btManager;
        private System.Windows.Forms.Button btMornitoring;
        private System.Windows.Forms.Label lbIPserver;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.PictureBox loaddingBox;
        private System.ComponentModel.BackgroundWorker bgwTestConnect;
    }
}