namespace BTL___Nhóm_1.TrangChu
{
    partial class SuaDeCuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SuaDeCuong));
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpXuatBan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDeCuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdDeCuong = new System.Windows.Forms.OpenFileDialog();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnFileCauHoi = new System.Windows.Forms.Button();
            this.txtFileCauHoi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ofdCauHoi = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnFile
            // 
            this.btnFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFile.Location = new System.Drawing.Point(473, 347);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(124, 38);
            this.btnFile.TabIndex = 23;
            this.btnFile.Text = "Upload";
            this.btnFile.UseVisualStyleBackColor = true;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFile.Location = new System.Drawing.Point(244, 347);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(223, 38);
            this.txtFile.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(43, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "File đề cương";
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(244, 262);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(240, 39);
            this.cmbMonHoc.TabIndex = 20;
            this.cmbMonHoc.Text = "--Chọn môn học--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(43, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 29);
            this.label4.TabIndex = 19;
            this.label4.Text = "Môn học";
            // 
            // dtpXuatBan
            // 
            this.dtpXuatBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpXuatBan.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpXuatBan.Location = new System.Drawing.Point(244, 182);
            this.dtpXuatBan.Name = "dtpXuatBan";
            this.dtpXuatBan.Size = new System.Drawing.Size(193, 38);
            this.dtpXuatBan.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(43, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 29);
            this.label3.TabIndex = 17;
            this.label3.Text = "Ngày xuất bản";
            // 
            // txtTacGia
            // 
            this.txtTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(244, 105);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(353, 38);
            this.txtTacGia.TabIndex = 16;
            this.txtTacGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTacGia_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tác giả";
            // 
            // txtTenDeCuong
            // 
            this.txtTenDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDeCuong.Location = new System.Drawing.Point(244, 34);
            this.txtTenDeCuong.Name = "txtTenDeCuong";
            this.txtTenDeCuong.Size = new System.Drawing.Size(353, 38);
            this.txtTenDeCuong.TabIndex = 14;
            this.txtTenDeCuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenDeCuong_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên đề cương";
            // 
            // btnThemMon
            // 
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(519, 262);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(42, 38);
            this.btnThemMon.TabIndex = 25;
            this.btnThemMon.Text = "+";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(154, 536);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(343, 59);
            this.btnSua.TabIndex = 24;
            this.btnSua.Text = "Sửa thông tin đề cương";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnFileCauHoi
            // 
            this.btnFileCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileCauHoi.Location = new System.Drawing.Point(473, 434);
            this.btnFileCauHoi.Name = "btnFileCauHoi";
            this.btnFileCauHoi.Size = new System.Drawing.Size(124, 38);
            this.btnFileCauHoi.TabIndex = 28;
            this.btnFileCauHoi.Text = "Upload";
            this.btnFileCauHoi.UseVisualStyleBackColor = true;
            this.btnFileCauHoi.Click += new System.EventHandler(this.btnFileCauHoi_Click);
            // 
            // txtFileCauHoi
            // 
            this.txtFileCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileCauHoi.Location = new System.Drawing.Point(244, 434);
            this.txtFileCauHoi.Name = "txtFileCauHoi";
            this.txtFileCauHoi.ReadOnly = true;
            this.txtFileCauHoi.Size = new System.Drawing.Size(223, 38);
            this.txtFileCauHoi.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(43, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 29);
            this.label6.TabIndex = 26;
            this.label6.Text = "File câu hỏi";
            // 
            // ofdCauHoi
            // 
            this.ofdCauHoi.FileName = "openFileDialog1";
            // 
            // SuaDeCuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 646);
            this.Controls.Add(this.btnFileCauHoi);
            this.Controls.Add(this.txtFileCauHoi);
            this.Controls.Add(this.label6);
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
            this.Controls.Add(this.btnThemMon);
            this.Controls.Add(this.btnSua);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SuaDeCuong";
            this.Text = "Sửa đề cương";
            this.Load += new System.EventHandler(this.SuaDeCuong_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpXuatBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDeCuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdDeCuong;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnFileCauHoi;
        private System.Windows.Forms.TextBox txtFileCauHoi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog ofdCauHoi;
    }
}