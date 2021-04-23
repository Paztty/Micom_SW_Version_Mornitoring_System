namespace Micom_SW_Version_Mornitoring_System
{
    partial class Loadding
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
            this.loaddingBox = new System.Windows.Forms.PictureBox();
            this.lbLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.loaddingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // loaddingBox
            // 
            this.loaddingBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.loaddingBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.loaddingBox.InitialImage = global::Micom_SW_Version_Mornitoring_System.Properties.Resources.loadding;
            this.loaddingBox.Location = new System.Drawing.Point(0, 0);
            this.loaddingBox.Name = "loaddingBox";
            this.loaddingBox.Size = new System.Drawing.Size(52, 53);
            this.loaddingBox.TabIndex = 0;
            this.loaddingBox.TabStop = false;
            // 
            // lbLoading
            // 
            this.lbLoading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.lbLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLoading.Font = new System.Drawing.Font("Microsoft YaHei UI", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoading.ForeColor = System.Drawing.Color.White;
            this.lbLoading.Location = new System.Drawing.Point(52, 0);
            this.lbLoading.Name = "lbLoading";
            this.lbLoading.Size = new System.Drawing.Size(272, 53);
            this.lbLoading.TabIndex = 43;
            this.lbLoading.Text = "Loading.....";
            this.lbLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbLoading.Visible = false;
            // 
            // Loadding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(42)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(324, 53);
            this.Controls.Add(this.lbLoading);
            this.Controls.Add(this.loaddingBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loadding";
            this.Text = "Loadding";
            ((System.ComponentModel.ISupportInitialize)(this.loaddingBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox loaddingBox;
        private System.Windows.Forms.Label lbLoading;
    }
}