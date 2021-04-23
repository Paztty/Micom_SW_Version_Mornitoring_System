namespace Micom_SW_Version_Mornitoring_System
{
    partial class Mornitoring
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mornitoring));
            this.lbHeader = new System.Windows.Forms.Label();
            this.dgwMicomSWMonitoring = new System.Windows.Forms.DataGridView();
            this.AREA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btMaximize = new System.Windows.Forms.Button();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.timerUpdate = new System.Windows.Forms.Timer(this.components);
            this.lbLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMicomSWMonitoring)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.White;
            this.lbHeader.Location = new System.Drawing.Point(0, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(1290, 49);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "Micom SW Mornitoring";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // dgwMicomSWMonitoring
            // 
            this.dgwMicomSWMonitoring.AllowUserToAddRows = false;
            this.dgwMicomSWMonitoring.AllowUserToDeleteRows = false;
            this.dgwMicomSWMonitoring.AllowUserToResizeColumns = false;
            this.dgwMicomSWMonitoring.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgwMicomSWMonitoring.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwMicomSWMonitoring.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwMicomSWMonitoring.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgwMicomSWMonitoring.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwMicomSWMonitoring.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwMicomSWMonitoring.ColumnHeadersHeight = 34;
            this.dgwMicomSWMonitoring.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgwMicomSWMonitoring.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AREA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwMicomSWMonitoring.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgwMicomSWMonitoring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwMicomSWMonitoring.EnableHeadersVisualStyles = false;
            this.dgwMicomSWMonitoring.GridColor = System.Drawing.Color.Black;
            this.dgwMicomSWMonitoring.Location = new System.Drawing.Point(0, 49);
            this.dgwMicomSWMonitoring.MultiSelect = false;
            this.dgwMicomSWMonitoring.Name = "dgwMicomSWMonitoring";
            this.dgwMicomSWMonitoring.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwMicomSWMonitoring.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwMicomSWMonitoring.RowHeadersVisible = false;
            this.dgwMicomSWMonitoring.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Blue;
            this.dgwMicomSWMonitoring.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgwMicomSWMonitoring.RowTemplate.Height = 35;
            this.dgwMicomSWMonitoring.RowTemplate.ReadOnly = true;
            this.dgwMicomSWMonitoring.Size = new System.Drawing.Size(1290, 606);
            this.dgwMicomSWMonitoring.TabIndex = 3;
            this.dgwMicomSWMonitoring.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgwMicomSWMonitoring_CellFormatting);
            this.dgwMicomSWMonitoring.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgwMicomSWMonitoring_CellPainting);
            this.dgwMicomSWMonitoring.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgwMicomSWMonitoring_DataBindingComplete);
            // 
            // AREA
            // 
            this.AREA.HeaderText = "AREA";
            this.AREA.Name = "AREA";
            this.AREA.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.lbHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1290, 49);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btMaximize, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btMinimize, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btClose, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1145, 9);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(145, 25);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btMaximize
            // 
            this.btMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btMaximize.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.icons8_maximize_window_50;
            this.btMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMaximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btMaximize.FlatAppearance.BorderSize = 0;
            this.btMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximize.Location = new System.Drawing.Point(48, 0);
            this.btMaximize.Margin = new System.Windows.Forms.Padding(0);
            this.btMaximize.Name = "btMaximize";
            this.btMaximize.Size = new System.Drawing.Size(48, 25);
            this.btMaximize.TabIndex = 2;
            this.btMaximize.Text = "  ";
            this.btMaximize.UseVisualStyleBackColor = false;
            this.btMaximize.Click += new System.EventHandler(this.FormControlClick);
            // 
            // btMinimize
            // 
            this.btMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btMinimize.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.icons8_macos_minimize_50;
            this.btMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Location = new System.Drawing.Point(0, 0);
            this.btMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(48, 25);
            this.btMinimize.TabIndex = 1;
            this.btMinimize.Text = "  ";
            this.btMinimize.UseVisualStyleBackColor = false;
            this.btMinimize.Click += new System.EventHandler(this.FormControlClick);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btClose.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.icons8_macos_close_50;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(96, 0);
            this.btClose.Margin = new System.Windows.Forms.Padding(0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(49, 25);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "  ";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.FormControlClick);
            // 
            // timerUpdate
            // 
            this.timerUpdate.Interval = 30000;
            this.timerUpdate.Tick += new System.EventHandler(this.timerUpdate_Tick);
            // 
            // lbLoading
            // 
            this.lbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lbLoading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.ForeColor = System.Drawing.Color.White;
            this.lbLoading.Location = new System.Drawing.Point(398, 283);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(494, 89);
            this.lbLoading.TabIndex = 42;
            this.lbLoading.Text = "Loading.....";
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mornitoring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1290, 655);
            this.ControlBox = false;
            this.Controls.Add(this.dgwMicomSWMonitoring);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mornitoring";
            this.Load += new System.EventHandler(this.Mornitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMicomSWMonitoring)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.DataGridView dgwMicomSWMonitoring;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerUpdate;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btMaximize;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn AREA;
    }
}