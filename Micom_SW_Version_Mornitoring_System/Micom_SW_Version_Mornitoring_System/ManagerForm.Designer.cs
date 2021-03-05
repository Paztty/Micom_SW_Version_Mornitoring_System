namespace Micom_SW_Version_Mornitoring_System
{
    partial class ManagerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSWVersionMornitor = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btExport = new System.Windows.Forms.Button();
            this.btModelClear = new System.Windows.Forms.Button();
            this.btModelEdit = new System.Windows.Forms.Button();
            this.btModelAddNew = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btFineModel = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.tbFindModel = new System.Windows.Forms.TextBox();
            this.pn = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tbServerNotify = new System.Windows.Forms.TextBox();
            this.tbActivityStatistics = new System.Windows.Forms.TextBox();
            this.pnDataEdit = new System.Windows.Forms.Panel();
            this.btCloseEdit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbbPBAcode = new System.Windows.Forms.ComboBox();
            this.cbbPCBcode = new System.Windows.Forms.ComboBox();
            this.cbbWritingArea = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbEditerUser = new System.Windows.Forms.Label();
            this.gbROM2 = new System.Windows.Forms.GroupBox();
            this.dtpInvMicomApply = new System.Windows.Forms.DateTimePicker();
            this.cbbInvMicomName = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbVersionRom2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbChecksumRom2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbAssyMicomCodeRom2 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btCancleAction = new System.Windows.Forms.Button();
            this.btModelUpdate = new System.Windows.Forms.Button();
            this.cb2Rom = new System.Windows.Forms.CheckBox();
            this.cb1Rom = new System.Windows.Forms.CheckBox();
            this.gbROM1 = new System.Windows.Forms.GroupBox();
            this.dtpMainMicomApply = new System.Windows.Forms.DateTimePicker();
            this.cbbMainMicomName = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbVersionRom1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbChecksumRom1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAssyMicomCodeRom1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbAssyCode = new System.Windows.Forms.TextBox();
            this.tbModelName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btMaximize = new System.Windows.Forms.Button();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lbHeader = new System.Windows.Forms.Label();
            this.timerUpdateData = new System.Windows.Forms.Timer(this.components);
            this.pnChangeData = new System.Windows.Forms.Panel();
            this.lbLoading = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSWVersionMornitor)).BeginInit();
            this.panel4.SuspendLayout();
            this.pn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.pnDataEdit.SuspendLayout();
            this.gbROM2.SuspendLayout();
            this.gbROM1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.pnChangeData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvSWVersionMornitor, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pn, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.32281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.67719F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1456, 724);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvSWVersionMornitor
            // 
            this.dgvSWVersionMornitor.AllowUserToAddRows = false;
            this.dgvSWVersionMornitor.AllowUserToDeleteRows = false;
            this.dgvSWVersionMornitor.AllowUserToResizeColumns = false;
            this.dgvSWVersionMornitor.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSWVersionMornitor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSWVersionMornitor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSWVersionMornitor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSWVersionMornitor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(204)))), ((int)(((byte)(217)))));
            this.dgvSWVersionMornitor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSWVersionMornitor.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgvSWVersionMornitor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(136)))), ((int)(((byte)(221)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSWVersionMornitor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSWVersionMornitor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Coral;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSWVersionMornitor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSWVersionMornitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSWVersionMornitor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.dgvSWVersionMornitor.Location = new System.Drawing.Point(3, 30);
            this.dgvSWVersionMornitor.MultiSelect = false;
            this.dgvSWVersionMornitor.Name = "dgvSWVersionMornitor";
            this.dgvSWVersionMornitor.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSWVersionMornitor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSWVersionMornitor.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSWVersionMornitor.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(204)))), ((int)(((byte)(217)))));
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(1);
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(68)))), ((int)(((byte)(95)))));
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSWVersionMornitor.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSWVersionMornitor.RowTemplate.ReadOnly = true;
            this.dgvSWVersionMornitor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSWVersionMornitor.Size = new System.Drawing.Size(1450, 518);
            this.dgvSWVersionMornitor.TabIndex = 2;
            this.dgvSWVersionMornitor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSWVersionMornitor_CellClick);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.panel4.Controls.Add(this.btExport);
            this.panel4.Controls.Add(this.btModelClear);
            this.panel4.Controls.Add(this.btModelEdit);
            this.panel4.Controls.Add(this.btModelAddNew);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.btFineModel);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.tbFindModel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1446, 27);
            this.panel4.TabIndex = 5;
            // 
            // btExport
            // 
            this.btExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.btExport.FlatAppearance.BorderSize = 2;
            this.btExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExport.ForeColor = System.Drawing.Color.White;
            this.btExport.Image = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.Excel_icon2;
            this.btExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExport.Location = new System.Drawing.Point(889, 0);
            this.btExport.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btExport.Name = "btExport";
            this.btExport.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btExport.Size = new System.Drawing.Size(103, 27);
            this.btExport.TabIndex = 19;
            this.btExport.Text = "       Export";
            this.btExport.UseVisualStyleBackColor = false;
            this.btExport.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // btModelClear
            // 
            this.btModelClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btModelClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModelClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btModelClear.FlatAppearance.BorderSize = 2;
            this.btModelClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModelClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModelClear.ForeColor = System.Drawing.Color.White;
            this.btModelClear.Location = new System.Drawing.Point(786, 0);
            this.btModelClear.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelClear.Name = "btModelClear";
            this.btModelClear.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelClear.Size = new System.Drawing.Size(103, 27);
            this.btModelClear.TabIndex = 0;
            this.btModelClear.Text = "Clear";
            this.btModelClear.UseVisualStyleBackColor = false;
            this.btModelClear.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // btModelEdit
            // 
            this.btModelEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btModelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModelEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btModelEdit.FlatAppearance.BorderSize = 2;
            this.btModelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModelEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModelEdit.ForeColor = System.Drawing.Color.White;
            this.btModelEdit.Location = new System.Drawing.Point(683, 0);
            this.btModelEdit.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelEdit.Name = "btModelEdit";
            this.btModelEdit.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelEdit.Size = new System.Drawing.Size(103, 27);
            this.btModelEdit.TabIndex = 1;
            this.btModelEdit.Text = "Edit";
            this.btModelEdit.UseVisualStyleBackColor = false;
            this.btModelEdit.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // btModelAddNew
            // 
            this.btModelAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btModelAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModelAddNew.Dock = System.Windows.Forms.DockStyle.Left;
            this.btModelAddNew.FlatAppearance.BorderSize = 2;
            this.btModelAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModelAddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModelAddNew.ForeColor = System.Drawing.Color.White;
            this.btModelAddNew.Location = new System.Drawing.Point(572, 0);
            this.btModelAddNew.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelAddNew.Name = "btModelAddNew";
            this.btModelAddNew.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.btModelAddNew.Size = new System.Drawing.Size(111, 27);
            this.btModelAddNew.TabIndex = 5;
            this.btModelAddNew.Text = "Add new";
            this.btModelAddNew.UseVisualStyleBackColor = false;
            this.btModelAddNew.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(553, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 27);
            this.label8.TabIndex = 20;
            this.label8.Text = "    ";
            // 
            // btFineModel
            // 
            this.btFineModel.BackColor = System.Drawing.Color.White;
            this.btFineModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btFineModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btFineModel.FlatAppearance.BorderSize = 0;
            this.btFineModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btFineModel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFineModel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btFineModel.Location = new System.Drawing.Point(489, 0);
            this.btFineModel.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.btFineModel.Name = "btFineModel";
            this.btFineModel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btFineModel.Size = new System.Drawing.Size(64, 27);
            this.btFineModel.TabIndex = 17;
            this.btFineModel.Text = "Find";
            this.btFineModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFineModel.UseVisualStyleBackColor = false;
            this.btFineModel.Click += new System.EventHandler(this.btFind_Click);
            // 
            // label27
            // 
            this.label27.Dock = System.Windows.Forms.DockStyle.Left;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(470, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(19, 27);
            this.label27.TabIndex = 18;
            this.label27.Text = "    ";
            // 
            // tbFindModel
            // 
            this.tbFindModel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.tbFindModel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbFindModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFindModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbFindModel.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindModel.Location = new System.Drawing.Point(0, 0);
            this.tbFindModel.MaxLength = 30;
            this.tbFindModel.Multiline = true;
            this.tbFindModel.Name = "tbFindModel";
            this.tbFindModel.Size = new System.Drawing.Size(470, 27);
            this.tbFindModel.TabIndex = 16;
            this.tbFindModel.Click += new System.EventHandler(this.tbFindModel_Click);
            // 
            // pn
            // 
            this.pn.Controls.Add(this.groupBox1);
            this.pn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn.Location = new System.Drawing.Point(3, 554);
            this.pn.Name = "pn";
            this.pn.Size = new System.Drawing.Size(1450, 167);
            this.pn.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1450, 167);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activity";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.23546F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.76454F));
            this.tableLayoutPanel3.Controls.Add(this.tbServerNotify, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tbActivityStatistics, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1444, 140);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tbServerNotify
            // 
            this.tbServerNotify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.tbServerNotify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServerNotify.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbServerNotify.ForeColor = System.Drawing.Color.White;
            this.tbServerNotify.Location = new System.Drawing.Point(584, 3);
            this.tbServerNotify.MaxLength = 100000;
            this.tbServerNotify.Multiline = true;
            this.tbServerNotify.Name = "tbServerNotify";
            this.tbServerNotify.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbServerNotify.Size = new System.Drawing.Size(857, 134);
            this.tbServerNotify.TabIndex = 1;
            // 
            // tbActivityStatistics
            // 
            this.tbActivityStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(204)))), ((int)(((byte)(217)))));
            this.tbActivityStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbActivityStatistics.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbActivityStatistics.Location = new System.Drawing.Point(3, 3);
            this.tbActivityStatistics.Multiline = true;
            this.tbActivityStatistics.Name = "tbActivityStatistics";
            this.tbActivityStatistics.Size = new System.Drawing.Size(575, 134);
            this.tbActivityStatistics.TabIndex = 0;
            // 
            // pnDataEdit
            // 
            this.pnDataEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnDataEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.pnDataEdit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnDataEdit.Controls.Add(this.btCloseEdit);
            this.pnDataEdit.Controls.Add(this.label7);
            this.pnDataEdit.Controls.Add(this.cbbPBAcode);
            this.pnDataEdit.Controls.Add(this.cbbPCBcode);
            this.pnDataEdit.Controls.Add(this.cbbWritingArea);
            this.pnDataEdit.Controls.Add(this.label21);
            this.pnDataEdit.Controls.Add(this.label22);
            this.pnDataEdit.Controls.Add(this.label5);
            this.pnDataEdit.Controls.Add(this.lbEditerUser);
            this.pnDataEdit.Controls.Add(this.gbROM2);
            this.pnDataEdit.Controls.Add(this.btCancleAction);
            this.pnDataEdit.Controls.Add(this.btModelUpdate);
            this.pnDataEdit.Controls.Add(this.cb2Rom);
            this.pnDataEdit.Controls.Add(this.cb1Rom);
            this.pnDataEdit.Controls.Add(this.gbROM1);
            this.pnDataEdit.Controls.Add(this.tbAssyCode);
            this.pnDataEdit.Controls.Add(this.tbModelName);
            this.pnDataEdit.Controls.Add(this.label6);
            this.pnDataEdit.Controls.Add(this.label1);
            this.pnDataEdit.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDataEdit.ForeColor = System.Drawing.Color.White;
            this.pnDataEdit.Location = new System.Drawing.Point(82, 82);
            this.pnDataEdit.Name = "pnDataEdit";
            this.pnDataEdit.Size = new System.Drawing.Size(1260, 379);
            this.pnDataEdit.TabIndex = 3;
            this.pnDataEdit.Visible = false;
            // 
            // btCloseEdit
            // 
            this.btCloseEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCloseEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btCloseEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCloseEdit.FlatAppearance.BorderSize = 2;
            this.btCloseEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCloseEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCloseEdit.ForeColor = System.Drawing.Color.White;
            this.btCloseEdit.Location = new System.Drawing.Point(1175, 3);
            this.btCloseEdit.Name = "btCloseEdit";
            this.btCloseEdit.Size = new System.Drawing.Size(73, 30);
            this.btCloseEdit.TabIndex = 38;
            this.btCloseEdit.Text = "CLOSE";
            this.btCloseEdit.UseVisualStyleBackColor = false;
            this.btCloseEdit.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(936, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 31);
            this.label7.TabIndex = 37;
            this.label7.Text = "MODEL EDIT";
            // 
            // cbbPBAcode
            // 
            this.cbbPBAcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbPBAcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbPBAcode.FormattingEnabled = true;
            this.cbbPBAcode.Location = new System.Drawing.Point(142, 228);
            this.cbbPBAcode.Name = "cbbPBAcode";
            this.cbbPBAcode.Size = new System.Drawing.Size(244, 29);
            this.cbbPBAcode.TabIndex = 36;
            // 
            // cbbPCBcode
            // 
            this.cbbPCBcode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbPCBcode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbPCBcode.FormattingEnabled = true;
            this.cbbPCBcode.Location = new System.Drawing.Point(142, 263);
            this.cbbPCBcode.Name = "cbbPCBcode";
            this.cbbPCBcode.Size = new System.Drawing.Size(244, 29);
            this.cbbPCBcode.TabIndex = 35;
            // 
            // cbbWritingArea
            // 
            this.cbbWritingArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbWritingArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbWritingArea.FormattingEnabled = true;
            this.cbbWritingArea.Items.AddRange(new object[] {
            "Micom Room",
            "A_MS machine",
            "FPT"});
            this.cbbWritingArea.Location = new System.Drawing.Point(142, 153);
            this.cbbWritingArea.Name = "cbbWritingArea";
            this.cbbWritingArea.Size = new System.Drawing.Size(244, 29);
            this.cbbWritingArea.TabIndex = 34;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(29, 231);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 21);
            this.label21.TabIndex = 32;
            this.label21.Text = "PBA Code";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(29, 266);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 21);
            this.label22.TabIndex = 30;
            this.label22.Text = "PCB Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 25;
            this.label5.Text = "Writing Area";
            // 
            // lbEditerUser
            // 
            this.lbEditerUser.AutoSize = true;
            this.lbEditerUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEditerUser.Location = new System.Drawing.Point(30, 28);
            this.lbEditerUser.Name = "lbEditerUser";
            this.lbEditerUser.Size = new System.Drawing.Size(105, 28);
            this.lbEditerUser.TabIndex = 23;
            this.lbEditerUser.Text = "EDITOR: ";
            // 
            // gbROM2
            // 
            this.gbROM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.gbROM2.Controls.Add(this.dtpInvMicomApply);
            this.gbROM2.Controls.Add(this.cbbInvMicomName);
            this.gbROM2.Controls.Add(this.label26);
            this.gbROM2.Controls.Add(this.label12);
            this.gbROM2.Controls.Add(this.tbVersionRom2);
            this.gbROM2.Controls.Add(this.label15);
            this.gbROM2.Controls.Add(this.tbChecksumRom2);
            this.gbROM2.Controls.Add(this.label16);
            this.gbROM2.Controls.Add(this.tbAssyMicomCodeRom2);
            this.gbROM2.Controls.Add(this.label18);
            this.gbROM2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbROM2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbROM2.ForeColor = System.Drawing.Color.White;
            this.gbROM2.Location = new System.Drawing.Point(844, 117);
            this.gbROM2.Name = "gbROM2";
            this.gbROM2.Size = new System.Drawing.Size(355, 182);
            this.gbROM2.TabIndex = 22;
            this.gbROM2.TabStop = false;
            this.gbROM2.Text = "ROM 2 (sub, inverter....)";
            // 
            // dtpInvMicomApply
            // 
            this.dtpInvMicomApply.CustomFormat = "dd/MM/yyyy";
            this.dtpInvMicomApply.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvMicomApply.Location = new System.Drawing.Point(148, 142);
            this.dtpInvMicomApply.Name = "dtpInvMicomApply";
            this.dtpInvMicomApply.ShowCheckBox = true;
            this.dtpInvMicomApply.Size = new System.Drawing.Size(186, 23);
            this.dtpInvMicomApply.TabIndex = 38;
            // 
            // cbbInvMicomName
            // 
            this.cbbInvMicomName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbInvMicomName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbInvMicomName.FormattingEnabled = true;
            this.cbbInvMicomName.Location = new System.Drawing.Point(148, 56);
            this.cbbInvMicomName.Name = "cbbInvMicomName";
            this.cbbInvMicomName.Size = new System.Drawing.Size(186, 25);
            this.cbbInvMicomName.TabIndex = 37;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(21, 138);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(71, 17);
            this.label26.TabIndex = 32;
            this.label26.Text = "Apply date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Micom name";
            // 
            // tbVersionRom2
            // 
            this.tbVersionRom2.Location = new System.Drawing.Point(148, 113);
            this.tbVersionRom2.MaxLength = 8;
            this.tbVersionRom2.Name = "tbVersionRom2";
            this.tbVersionRom2.Size = new System.Drawing.Size(186, 23);
            this.tbVersionRom2.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "Version";
            // 
            // tbChecksumRom2
            // 
            this.tbChecksumRom2.Location = new System.Drawing.Point(148, 85);
            this.tbChecksumRom2.MaxLength = 8;
            this.tbChecksumRom2.Name = "tbChecksumRom2";
            this.tbChecksumRom2.Size = new System.Drawing.Size(186, 23);
            this.tbChecksumRom2.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 17);
            this.label16.TabIndex = 8;
            this.label16.Text = "Checksum";
            // 
            // tbAssyMicomCodeRom2
            // 
            this.tbAssyMicomCodeRom2.Location = new System.Drawing.Point(148, 29);
            this.tbAssyMicomCodeRom2.Name = "tbAssyMicomCodeRom2";
            this.tbAssyMicomCodeRom2.Size = new System.Drawing.Size(186, 23);
            this.tbAssyMicomCodeRom2.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "Assy Micom Code";
            // 
            // btCancleAction
            // 
            this.btCancleAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancleAction.BackColor = System.Drawing.Color.White;
            this.btCancleAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btCancleAction.FlatAppearance.BorderSize = 0;
            this.btCancleAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCancleAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCancleAction.ForeColor = System.Drawing.Color.Red;
            this.btCancleAction.Location = new System.Drawing.Point(1049, 336);
            this.btCancleAction.Name = "btCancleAction";
            this.btCancleAction.Size = new System.Drawing.Size(199, 30);
            this.btCancleAction.TabIndex = 4;
            this.btCancleAction.Text = "Cancle";
            this.btCancleAction.UseVisualStyleBackColor = false;
            this.btCancleAction.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // btModelUpdate
            // 
            this.btModelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btModelUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btModelUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btModelUpdate.FlatAppearance.BorderSize = 2;
            this.btModelUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btModelUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btModelUpdate.ForeColor = System.Drawing.Color.White;
            this.btModelUpdate.Location = new System.Drawing.Point(904, 336);
            this.btModelUpdate.Name = "btModelUpdate";
            this.btModelUpdate.Size = new System.Drawing.Size(148, 30);
            this.btModelUpdate.TabIndex = 2;
            this.btModelUpdate.Text = "Update";
            this.btModelUpdate.UseVisualStyleBackColor = false;
            this.btModelUpdate.Click += new System.EventHandler(this.buttonActionClick);
            // 
            // cb2Rom
            // 
            this.cb2Rom.AutoSize = true;
            this.cb2Rom.Checked = true;
            this.cb2Rom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb2Rom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb2Rom.Location = new System.Drawing.Point(276, 117);
            this.cb2Rom.Name = "cb2Rom";
            this.cb2Rom.Size = new System.Drawing.Size(120, 25);
            this.cb2Rom.TabIndex = 18;
            this.cb2Rom.Text = "2 ROM/PCB";
            this.cb2Rom.UseVisualStyleBackColor = true;
            this.cb2Rom.Click += new System.EventHandler(this.cb1Rom_Click);
            // 
            // cb1Rom
            // 
            this.cb1Rom.AutoSize = true;
            this.cb1Rom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb1Rom.Location = new System.Drawing.Point(148, 117);
            this.cb1Rom.Name = "cb1Rom";
            this.cb1Rom.Size = new System.Drawing.Size(120, 25);
            this.cb1Rom.TabIndex = 17;
            this.cb1Rom.Text = "1 ROM/PCB";
            this.cb1Rom.UseVisualStyleBackColor = true;
            this.cb1Rom.Click += new System.EventHandler(this.cb1Rom_Click);
            // 
            // gbROM1
            // 
            this.gbROM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.gbROM1.Controls.Add(this.dtpMainMicomApply);
            this.gbROM1.Controls.Add(this.cbbMainMicomName);
            this.gbROM1.Controls.Add(this.label23);
            this.gbROM1.Controls.Add(this.label17);
            this.gbROM1.Controls.Add(this.tbVersionRom1);
            this.gbROM1.Controls.Add(this.label3);
            this.gbROM1.Controls.Add(this.tbChecksumRom1);
            this.gbROM1.Controls.Add(this.label2);
            this.gbROM1.Controls.Add(this.tbAssyMicomCodeRom1);
            this.gbROM1.Controls.Add(this.label4);
            this.gbROM1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbROM1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbROM1.ForeColor = System.Drawing.Color.White;
            this.gbROM1.Location = new System.Drawing.Point(436, 117);
            this.gbROM1.Name = "gbROM1";
            this.gbROM1.Size = new System.Drawing.Size(355, 182);
            this.gbROM1.TabIndex = 16;
            this.gbROM1.TabStop = false;
            this.gbROM1.Text = "ROM 1 (main micom)";
            // 
            // dtpMainMicomApply
            // 
            this.dtpMainMicomApply.CustomFormat = "dd/MM/yyyy";
            this.dtpMainMicomApply.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMainMicomApply.Location = new System.Drawing.Point(149, 138);
            this.dtpMainMicomApply.Name = "dtpMainMicomApply";
            this.dtpMainMicomApply.ShowCheckBox = true;
            this.dtpMainMicomApply.Size = new System.Drawing.Size(186, 23);
            this.dtpMainMicomApply.TabIndex = 37;
            // 
            // cbbMainMicomName
            // 
            this.cbbMainMicomName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbMainMicomName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbMainMicomName.FormattingEnabled = true;
            this.cbbMainMicomName.Location = new System.Drawing.Point(149, 55);
            this.cbbMainMicomName.Name = "cbbMainMicomName";
            this.cbbMainMicomName.Size = new System.Drawing.Size(186, 25);
            this.cbbMainMicomName.TabIndex = 36;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(22, 138);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 17);
            this.label23.TabIndex = 28;
            this.label23.Text = "Apply date";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 57);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 17);
            this.label17.TabIndex = 20;
            this.label17.Text = "Micom name";
            // 
            // tbVersionRom1
            // 
            this.tbVersionRom1.Location = new System.Drawing.Point(149, 113);
            this.tbVersionRom1.MaxLength = 8;
            this.tbVersionRom1.Name = "tbVersionRom1";
            this.tbVersionRom1.Size = new System.Drawing.Size(186, 23);
            this.tbVersionRom1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Version";
            // 
            // tbChecksumRom1
            // 
            this.tbChecksumRom1.Location = new System.Drawing.Point(149, 85);
            this.tbChecksumRom1.MaxLength = 8;
            this.tbChecksumRom1.Name = "tbChecksumRom1";
            this.tbChecksumRom1.Size = new System.Drawing.Size(186, 23);
            this.tbChecksumRom1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Checksum";
            // 
            // tbAssyMicomCodeRom1
            // 
            this.tbAssyMicomCodeRom1.Location = new System.Drawing.Point(149, 29);
            this.tbAssyMicomCodeRom1.Name = "tbAssyMicomCodeRom1";
            this.tbAssyMicomCodeRom1.Size = new System.Drawing.Size(186, 23);
            this.tbAssyMicomCodeRom1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Assy Micom Code";
            // 
            // tbAssyCode
            // 
            this.tbAssyCode.Location = new System.Drawing.Point(142, 192);
            this.tbAssyCode.Name = "tbAssyCode";
            this.tbAssyCode.Size = new System.Drawing.Size(244, 28);
            this.tbAssyCode.TabIndex = 11;
            // 
            // tbModelName
            // 
            this.tbModelName.Location = new System.Drawing.Point(142, 70);
            this.tbModelName.Name = "tbModelName";
            this.tbModelName.Size = new System.Drawing.Size(649, 28);
            this.tbModelName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Assy Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Model";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(1311, -2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 25);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.btMaximize, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btMinimize, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btClose, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(145, 25);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btMaximize
            // 
            this.btMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btMaximize.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.button_o;
            this.btMaximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMaximize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btMaximize.FlatAppearance.BorderSize = 0;
            this.btMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMaximize.Location = new System.Drawing.Point(48, 3);
            this.btMaximize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btMaximize.Name = "btMaximize";
            this.btMaximize.Size = new System.Drawing.Size(48, 22);
            this.btMaximize.TabIndex = 2;
            this.btMaximize.Text = "  ";
            this.btMaximize.UseVisualStyleBackColor = false;
            this.btMaximize.Click += new System.EventHandler(this.FormControlButton_Click);
            // 
            // btMinimize
            // 
            this.btMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btMinimize.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.button_minimise;
            this.btMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btMinimize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Location = new System.Drawing.Point(0, 3);
            this.btMinimize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(48, 22);
            this.btMinimize.TabIndex = 1;
            this.btMinimize.Text = "  ";
            this.btMinimize.UseVisualStyleBackColor = false;
            this.btMinimize.Click += new System.EventHandler(this.FormControlButton_Click);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.btClose.BackgroundImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.button_x;
            this.btClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btClose.FlatAppearance.BorderSize = 0;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Location = new System.Drawing.Point(96, 3);
            this.btClose.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(49, 22);
            this.btClose.TabIndex = 0;
            this.btClose.Text = "  ";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.FormControlButton_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.panel1);
            this.panelHeader.Controls.Add(this.lbHeader);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1456, 34);
            this.panelHeader.TabIndex = 2;
            // 
            // lbHeader
            // 
            this.lbHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lbHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHeader.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.White;
            this.lbHeader.Location = new System.Drawing.Point(0, 0);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(1456, 34);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "Micoms SW Manager";
            this.lbHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnTop_MouseDown);
            // 
            // timerUpdateData
            // 
            this.timerUpdateData.Interval = 10;
            this.timerUpdateData.Tick += new System.EventHandler(this.timerUpdateData_Tick);
            // 
            // pnChangeData
            // 
            this.pnChangeData.Controls.Add(this.pnDataEdit);
            this.pnChangeData.Controls.Add(this.tableLayoutPanel1);
            this.pnChangeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChangeData.Location = new System.Drawing.Point(0, 34);
            this.pnChangeData.Name = "pnChangeData";
            this.pnChangeData.Size = new System.Drawing.Size(1456, 724);
            this.pnChangeData.TabIndex = 3;
            // 
            // lbLoading
            // 
            this.lbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lbLoading.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.ForeColor = System.Drawing.Color.White;
            this.lbLoading.Location = new System.Drawing.Point(481, 335);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(494, 89);
            this.lbLoading.TabIndex = 42;
            this.lbLoading.Text = "Loading.....";
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoading.Visible = false;
            this.lbLoading.Click += new System.EventHandler(this.lbLoading_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1456, 758);
            this.ControlBox = false;
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.pnChangeData);
            this.Controls.Add(this.panelHeader);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "ManagerForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSWVersionMornitor)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.pnDataEdit.ResumeLayout(false);
            this.pnDataEdit.PerformLayout();
            this.gbROM2.ResumeLayout(false);
            this.gbROM2.PerformLayout();
            this.gbROM1.ResumeLayout(false);
            this.gbROM1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelHeader.ResumeLayout(false);
            this.pnChangeData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btMaximize;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.DataGridView dgvSWVersionMornitor;
        private System.Windows.Forms.Timer timerUpdateData;
        private System.Windows.Forms.Panel pnDataEdit;
        private System.Windows.Forms.GroupBox gbROM1;
        private System.Windows.Forms.TextBox tbAssyMicomCodeRom1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbAssyCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbModelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVersionRom1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbChecksumRom1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCancleAction;
        private System.Windows.Forms.Button btModelUpdate;
        private System.Windows.Forms.Button btModelEdit;
        private System.Windows.Forms.Button btModelClear;
        private System.Windows.Forms.CheckBox cb2Rom;
        private System.Windows.Forms.CheckBox cb1Rom;
        private System.Windows.Forms.GroupBox gbROM2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbVersionRom2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbChecksumRom2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbAssyMicomCodeRom2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btModelAddNew;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btFineModel;
        private System.Windows.Forms.TextBox tbFindModel;
        private System.Windows.Forms.Panel pnChangeData;
        private System.Windows.Forms.Panel pn;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox tbActivityStatistics;
        private System.Windows.Forms.Label lbEditerUser;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbWritingArea;
        private System.Windows.Forms.ComboBox cbbPCBcode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbbPBAcode;
        private System.Windows.Forms.DateTimePicker dtpInvMicomApply;
        private System.Windows.Forms.ComboBox cbbInvMicomName;
        private System.Windows.Forms.DateTimePicker dtpMainMicomApply;
        private System.Windows.Forms.ComboBox cbbMainMicomName;
        private System.Windows.Forms.Button btCloseEdit;
        private System.Windows.Forms.Button btExport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbLoading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.TextBox tbServerNotify;
    }
}

