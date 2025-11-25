namespace BTL___Nhóm_1
{
    partial class fmQuen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmQuen));
            this.label3 = new System.Windows.Forms.Label();
            this.btnDoi = new System.Windows.Forms.Button();
            this.linkDangNhap = new System.Windows.Forms.LinkLabel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuanLy = new System.Windows.Forms.Label();
            this.lblUngDung = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(193, 320);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(387, 40);
            this.label3.TabIndex = 37;
            this.label3.Text = "NHẬP LẠI TÊN ĐĂNG NHẬP";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnDoi
            // 
            this.btnDoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoi.Location = new System.Drawing.Point(252, 550);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(235, 70);
            this.btnDoi.TabIndex = 34;
            this.btnDoi.Text = "Đổi mật khẩu";
            this.btnDoi.UseVisualStyleBackColor = true;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // linkDangNhap
            // 
            this.linkDangNhap.AutoSize = true;
            this.linkDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkDangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkDangNhap.LinkColor = System.Drawing.Color.DarkBlue;
            this.linkDangNhap.Location = new System.Drawing.Point(525, 474);
            this.linkDangNhap.Name = "linkDangNhap";
            this.linkDangNhap.Size = new System.Drawing.Size(153, 32);
            this.linkDangNhap.TabIndex = 33;
            this.linkDangNhap.TabStop = true;
            this.linkDangNhap.Text = "Đăng nhập";
            this.linkDangNhap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDangNhap_LinkClicked);
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(360, 393);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(309, 38);
            this.txtTen.TabIndex = 31;
            this.txtTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTen_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(122, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 32);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tên đăng nhập";
            // 
            // lblQuanLy
            // 
            this.lblQuanLy.AutoSize = true;
            this.lblQuanLy.Font = new System.Drawing.Font("Cascadia Mono SemiLight", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuanLy.Location = new System.Drawing.Point(133, 83);
            this.lblQuanLy.Name = "lblQuanLy";
            this.lblQuanLy.Size = new System.Drawing.Size(475, 44);
            this.lblQuanLy.TabIndex = 27;
            this.lblQuanLy.Text = "Quản lý đề cương môn học";
            this.lblQuanLy.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUngDung
            // 
            this.lblUngDung.AutoSize = true;
            this.lblUngDung.Font = new System.Drawing.Font("Calibri", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUngDung.Location = new System.Drawing.Point(283, 42);
            this.lblUngDung.Name = "lblUngDung";
            this.lblUngDung.Size = new System.Drawing.Size(178, 40);
            this.lblUngDung.TabIndex = 26;
            this.lblUngDung.Text = "ỨNG DỤNG";
            this.lblUngDung.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(290, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // fmQuen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 672);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.linkDangNhap);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblQuanLy);
            this.Controls.Add(this.lblUngDung);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmQuen";
            this.Text = "Quên mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmQuen_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmQuen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDoi;
        private System.Windows.Forms.LinkLabel linkDangNhap;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblQuanLy;
        private System.Windows.Forms.Label lblUngDung;
    }
}