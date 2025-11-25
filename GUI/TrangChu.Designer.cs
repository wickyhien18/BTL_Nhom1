namespace BTL___Nhóm_1
{
    partial class fmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaNhan = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogoutPopup = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnToggle = new System.Windows.Forms.Button();
            this.pcbUserAvatar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.trangChu1 = new BTL___Nhóm_1.BUS.TrangChu();
            this.lopHoc1 = new BTL___Nhóm_1.BUS.LopHoc();
            this.deCuongCuaToi1 = new BTL___Nhóm_1.BUS.DeCuongCuaToi();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserAvatar)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.btnCaNhan);
            this.panel1.Controls.Add(this.btnLopHoc);
            this.panel1.Controls.Add(this.btnTrangChu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 776);
            this.panel1.TabIndex = 0;
            // 
            // btnCaNhan
            // 
            this.btnCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            this.btnCaNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaNhan.FlatAppearance.BorderSize = 0;
            this.btnCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnCaNhan.Location = new System.Drawing.Point(5, 306);
            this.btnCaNhan.Name = "btnCaNhan";
            this.btnCaNhan.Size = new System.Drawing.Size(286, 67);
            this.btnCaNhan.TabIndex = 3;
            this.btnCaNhan.Text = "Lưu trữ cá nhân";
            this.btnCaNhan.UseVisualStyleBackColor = false;
            this.btnCaNhan.Click += new System.EventHandler(this.btnCaNhan_Click);
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            this.btnLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLopHoc.FlatAppearance.BorderSize = 0;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnLopHoc.ForeColor = System.Drawing.Color.White;
            this.btnLopHoc.Location = new System.Drawing.Point(4, 233);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Size = new System.Drawing.Size(286, 67);
            this.btnLopHoc.TabIndex = 2;
            this.btnLopHoc.Text = "Lớp học ";
            this.btnLopHoc.UseVisualStyleBackColor = false;
            this.btnLopHoc.Click += new System.EventHandler(this.btnLopHoc_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(140)))));
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.btnTrangChu.ForeColor = System.Drawing.Color.White;
            this.btnTrangChu.Location = new System.Drawing.Point(5, 160);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(286, 67);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = false;
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnLogoutPopup);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(294, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1080, 114);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // btnLogoutPopup
            // 
            this.btnLogoutPopup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogoutPopup.BackColor = System.Drawing.Color.White;
            this.btnLogoutPopup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogoutPopup.FlatAppearance.BorderSize = 0;
            this.btnLogoutPopup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoutPopup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnLogoutPopup.Location = new System.Drawing.Point(950, 64);
            this.btnLogoutPopup.Name = "btnLogoutPopup";
            this.btnLogoutPopup.Size = new System.Drawing.Size(120, 48);
            this.btnLogoutPopup.TabIndex = 5;
            this.btnLogoutPopup.Text = "Đăng xuất";
            this.btnLogoutPopup.UseVisualStyleBackColor = false;
            this.btnLogoutPopup.Visible = false;
            this.btnLogoutPopup.Click += new System.EventHandler(this.btnLogoutPopup_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUsername.Location = new System.Drawing.Point(831, 17);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(151, 20);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username - Vai trò";
            // 
            // btnToggle
            // 
            this.btnToggle.BackColor = System.Drawing.Color.Transparent;
            this.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnToggle.Location = new System.Drawing.Point(6, 6);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(36, 36);
            this.btnToggle.TabIndex = 4;
            this.btnToggle.Text = "☰";
            this.btnToggle.UseVisualStyleBackColor = false;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // pcbUserAvatar
            // 
            this.pcbUserAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pcbUserAvatar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pcbUserAvatar.Image = global::BTL___Nhóm_1.Properties.Resources.UTC;
            this.pcbUserAvatar.Location = new System.Drawing.Point(1328, 8);
            this.pcbUserAvatar.Name = "pcbUserAvatar";
            this.pcbUserAvatar.Size = new System.Drawing.Size(36, 36);
            this.pcbUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbUserAvatar.TabIndex = 3;
            this.pcbUserAvatar.TabStop = false;
            this.pcbUserAvatar.Click += new System.EventHandler(this.pcbUserAvatar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.trangChu1);
            this.panel3.Controls.Add(this.lopHoc1);
            this.panel3.Controls.Add(this.deCuongCuaToi1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(294, 114);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1080, 662);
            this.panel3.TabIndex = 5;
            // 
            // trangChu1
            // 
            this.trangChu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trangChu1.Location = new System.Drawing.Point(0, 0);
            this.trangChu1.Name = "trangChu1";
            this.trangChu1.Size = new System.Drawing.Size(1080, 662);
            this.trangChu1.TabIndex = 2;
            //this.trangChu1.Load += new System.EventHandler(this.trangChu1_Load);
            // 
            // lopHoc1
            // 
            this.lopHoc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lopHoc1.Location = new System.Drawing.Point(0, 0);
            this.lopHoc1.Name = "lopHoc1";
            this.lopHoc1.Size = new System.Drawing.Size(1080, 662);
            this.lopHoc1.TabIndex = 1;
            // 
            // deCuongCuaToi1
            // 
            this.deCuongCuaToi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deCuongCuaToi1.Location = new System.Drawing.Point(0, 0);
            this.deCuongCuaToi1.Name = "deCuongCuaToi1";
            this.deCuongCuaToi1.Size = new System.Drawing.Size(1080, 662);
            this.deCuongCuaToi1.TabIndex = 0;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 776);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pcbUserAvatar);
            this.Controls.Add(this.btnToggle);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmMain";
            this.Text = "Trang chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbUserAvatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnCaNhan;
        private System.Windows.Forms.Button btnLopHoc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.PictureBox pcbUserAvatar;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogoutPopup;
        private System.Windows.Forms.Panel panel3;
        private BUS.LopHoc lopHoc1;
        private BUS.DeCuongCuaToi deCuongCuaToi1;
        private BUS.TrangChu trangChu1;
    }
}