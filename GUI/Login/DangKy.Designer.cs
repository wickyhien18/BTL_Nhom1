namespace BTL___Nhóm_1
{
    partial class fmDangKy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmDangKy));
            this.label3 = new System.Windows.Forms.Label();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.linkDangNhap = new System.Windows.Forms.LinkLabel();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuanLy = new System.Windows.Forms.Label();
            this.lblUngDung = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rdbtnSinhvien = new System.Windows.Forms.RadioButton();
            this.rdbtnGiangvien = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnXNClose = new System.Windows.Forms.Button();
            this.btnXNOpen = new System.Windows.Forms.Button();
            this.txtXacnhan = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(311, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 40);
            this.label3.TabIndex = 25;
            this.label3.Text = "ĐĂNG KÝ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.Location = new System.Drawing.Point(261, 670);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(235, 70);
            this.btnDangKy.TabIndex = 22;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // linkDangNhap
            // 
            this.linkDangNhap.AutoSize = true;
            this.linkDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDangNhap.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkDangNhap.Location = new System.Drawing.Point(525, 629);
            this.linkDangNhap.Name = "linkDangNhap";
            this.linkDangNhap.Size = new System.Drawing.Size(153, 32);
            this.linkDangNhap.TabIndex = 21;
            this.linkDangNhap.TabStop = true;
            this.linkDangNhap.Text = "Đăng nhập";
            this.linkDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangKy_LinkClicked);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(369, 395);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(309, 38);
            this.txtMatKhau.TabIndex = 19;
            this.txtMatKhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTen_KeyPress);
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(369, 338);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(309, 38);
            this.txtTen.TabIndex = 18;
            this.txtTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTen_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 32);
            this.label2.TabIndex = 17;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tên đăng ký";
            // 
            // lblQuanLy
            // 
            this.lblQuanLy.AutoSize = true;
            this.lblQuanLy.Font = new System.Drawing.Font("Cascadia Mono SemiLight", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanLy.Location = new System.Drawing.Point(142, 62);
            this.lblQuanLy.Name = "lblQuanLy";
            this.lblQuanLy.Size = new System.Drawing.Size(475, 44);
            this.lblQuanLy.TabIndex = 14;
            this.lblQuanLy.Text = "Quản lý đề cương môn học";
            this.lblQuanLy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUngDung
            // 
            this.lblUngDung.AutoSize = true;
            this.lblUngDung.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUngDung.Location = new System.Drawing.Point(292, 21);
            this.lblUngDung.Name = "lblUngDung";
            this.lblUngDung.Size = new System.Drawing.Size(178, 40);
            this.lblUngDung.TabIndex = 13;
            this.lblUngDung.Text = "ỨNG DỤNG";
            this.lblUngDung.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(623, 396);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 37);
            this.btnClose.TabIndex = 24;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Location = new System.Drawing.Point(623, 395);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(55, 37);
            this.btnOpen.TabIndex = 23;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(299, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 512);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 32);
            this.label4.TabIndex = 26;
            this.label4.Text = "Vai trò";
            // 
            // rdbtnSinhvien
            // 
            this.rdbtnSinhvien.AutoSize = true;
            this.rdbtnSinhvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnSinhvien.Location = new System.Drawing.Point(369, 512);
            this.rdbtnSinhvien.Name = "rdbtnSinhvien";
            this.rdbtnSinhvien.Size = new System.Drawing.Size(153, 36);
            this.rdbtnSinhvien.TabIndex = 27;
            this.rdbtnSinhvien.TabStop = true;
            this.rdbtnSinhvien.Text = "Sinh viên";
            this.rdbtnSinhvien.UseVisualStyleBackColor = true;
            // 
            // rdbtnGiangvien
            // 
            this.rdbtnGiangvien.AutoSize = true;
            this.rdbtnGiangvien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnGiangvien.Location = new System.Drawing.Point(369, 569);
            this.rdbtnGiangvien.Name = "rdbtnGiangvien";
            this.rdbtnGiangvien.Size = new System.Drawing.Size(172, 36);
            this.rdbtnGiangvien.TabIndex = 28;
            this.rdbtnGiangvien.TabStop = true;
            this.rdbtnGiangvien.Text = "Giảng viên";
            this.rdbtnGiangvien.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(98, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 32);
            this.label5.TabIndex = 29;
            this.label5.Text = "Nhập lại mật khẩu";
            // 
            // btnXNClose
            // 
            this.btnXNClose.Image = ((System.Drawing.Image)(resources.GetObject("btnXNClose.Image")));
            this.btnXNClose.Location = new System.Drawing.Point(623, 454);
            this.btnXNClose.Name = "btnXNClose";
            this.btnXNClose.Size = new System.Drawing.Size(55, 37);
            this.btnXNClose.TabIndex = 32;
            this.btnXNClose.UseVisualStyleBackColor = true;
            this.btnXNClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnXNOpen
            // 
            this.btnXNOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnXNOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnXNOpen.Image")));
            this.btnXNOpen.Location = new System.Drawing.Point(623, 451);
            this.btnXNOpen.Name = "btnXNOpen";
            this.btnXNOpen.Size = new System.Drawing.Size(55, 37);
            this.btnXNOpen.TabIndex = 31;
            this.btnXNOpen.UseVisualStyleBackColor = true;
            this.btnXNOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtXacnhan
            // 
            this.txtXacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacnhan.Location = new System.Drawing.Point(369, 451);
            this.txtXacnhan.Name = "txtXacnhan";
            this.txtXacnhan.PasswordChar = '*';
            this.txtXacnhan.Size = new System.Drawing.Size(309, 38);
            this.txtXacnhan.TabIndex = 30;
            // 
            // fmDangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 767);
            this.Controls.Add(this.btnXNClose);
            this.Controls.Add(this.btnXNOpen);
            this.Controls.Add(this.txtXacnhan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdbtnGiangvien);
            this.Controls.Add(this.rdbtnSinhvien);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.linkDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblQuanLy);
            this.Controls.Add(this.lblUngDung);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmDangKy";
            this.Text = "Đăng ký";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmDangKy_FormClosing);
            this.Load += new System.EventHandler(this.fmDangKy_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmDangKy_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.LinkLabel linkDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQuanLy;
        private System.Windows.Forms.Label lblUngDung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdbtnSinhvien;
        private System.Windows.Forms.RadioButton rdbtnGiangvien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXNClose;
        private System.Windows.Forms.Button btnXNOpen;
        private System.Windows.Forms.TextBox txtXacnhan;
    }
}