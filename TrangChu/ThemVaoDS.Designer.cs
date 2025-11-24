namespace BTL___Nhóm_1.TrangChu
{
    partial class ThemVaoDS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemVaoDS));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenDeCuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpXuatBan = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.ofdDeCuong = new System.Windows.Forms.OpenFileDialog();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFileCauHoi = new System.Windows.Forms.TextBox();
            this.btnFileCauHoi = new System.Windows.Forms.Button();
            this.ofdCauHoi = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đề cương";
            // 
            // txtTenDeCuong
            // 
            this.txtTenDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDeCuong.Location = new System.Drawing.Point(170, 31);
            this.txtTenDeCuong.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenDeCuong.Name = "txtTenDeCuong";
            this.txtTenDeCuong.Size = new System.Drawing.Size(266, 32);
            this.txtTenDeCuong.TabIndex = 1;
            this.txtTenDeCuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDeCuong_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tác giả";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(170, 89);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(266, 32);
            this.txtTacGia.TabIndex = 3;
            this.txtTacGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTacGia_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày xuất bản";
            // 
            // dtpXuatBan
            // 
            this.dtpXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpXuatBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpXuatBan.Location = new System.Drawing.Point(170, 151);
            this.dtpXuatBan.Margin = new System.Windows.Forms.Padding(2);
            this.dtpXuatBan.Name = "dtpXuatBan";
            this.dtpXuatBan.Size = new System.Drawing.Size(112, 26);
            this.dtpXuatBan.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 216);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Môn học";
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(170, 216);
            this.cmbMonHoc.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(181, 34);
            this.cmbMonHoc.TabIndex = 7;
            this.cmbMonHoc.Text = "--Chọn môn học--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "File đề cương";
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(170, 285);
            this.txtFile.Margin = new System.Windows.Forms.Padding(2);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(168, 32);
            this.txtFile.TabIndex = 9;
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(341, 285);
            this.btnFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(93, 31);
            this.btnFile.TabIndex = 10;
            this.btnFile.Text = "Upload";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(118, 429);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(239, 48);
            this.btnThem.TabIndex = 11;
            this.btnThem.Text = "Thêm vào danh sách";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(376, 216);
            this.btnThemMon.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(32, 31);
            this.btnThemMon.TabIndex = 12;
            this.btnThemMon.Text = "+";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 361);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "File câu hỏi";
            // 
            // txtFileCauHoi
            // 
            this.txtFileCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileCauHoi.Location = new System.Drawing.Point(170, 361);
            this.txtFileCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.txtFileCauHoi.Name = "txtFileCauHoi";
            this.txtFileCauHoi.ReadOnly = true;
            this.txtFileCauHoi.Size = new System.Drawing.Size(168, 32);
            this.txtFileCauHoi.TabIndex = 14;
            // 
            // btnFileCauHoi
            // 
            this.btnFileCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileCauHoi.Location = new System.Drawing.Point(341, 361);
            this.btnFileCauHoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnFileCauHoi.Name = "btnFileCauHoi";
            this.btnFileCauHoi.Size = new System.Drawing.Size(93, 31);
            this.btnFileCauHoi.TabIndex = 15;
            this.btnFileCauHoi.Text = "Upload";
            this.btnFileCauHoi.UseVisualStyleBackColor = true;
            this.btnFileCauHoi.Click += new System.EventHandler(this.btnFileCauHoi_Click);
            // 
            // ofdCauHoi
            // 
            this.ofdCauHoi.FileName = "openFileDialog1";
            // 
            // ThemVaoDS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 505);
            this.Controls.Add(this.btnFileCauHoi);
            this.Controls.Add(this.txtFileCauHoi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpXuatBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTenDeCuong);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThemVaoDS";
            this.Text = "Thêm vào danh sách";
            this.Load += new System.EventHandler(this.ThemVaoDS_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenDeCuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpXuatBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.OpenFileDialog ofdDeCuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFileCauHoi;
        private System.Windows.Forms.Button btnFileCauHoi;
        private System.Windows.Forms.OpenFileDialog ofdCauHoi;
    }
}