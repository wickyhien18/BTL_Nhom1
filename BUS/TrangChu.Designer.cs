namespace BTL___Nhóm_1.BUS
{
    partial class TrangChu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTrangChu = new System.Windows.Forms.DataGridView();
            this.btnThemVaoDS = new System.Windows.Forms.Button();
            this.btnThemVaoLopHoc = new System.Windows.Forms.Button();
            this.btnThemVaoDeCuongCuaToi = new System.Windows.Forms.Button();
            this.txtTenDeCuong = new System.Windows.Forms.TextBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.btnTimTen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrangChu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTrangChu
            // 
            this.dgvTrangChu.AllowUserToAddRows = false;
            this.dgvTrangChu.AllowUserToDeleteRows = false;
            this.dgvTrangChu.AllowUserToResizeColumns = false;
            this.dgvTrangChu.AllowUserToResizeRows = false;
            this.dgvTrangChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrangChu.Location = new System.Drawing.Point(17, 106);
            this.dgvTrangChu.Name = "dgvTrangChu";
            this.dgvTrangChu.RowHeadersVisible = false;
            this.dgvTrangChu.RowHeadersWidth = 51;
            this.dgvTrangChu.RowTemplate.Height = 24;
            this.dgvTrangChu.Size = new System.Drawing.Size(739, 287);
            this.dgvTrangChu.TabIndex = 0;
            this.dgvTrangChu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrangChu_CellClick);
            // 
            // btnThemVaoDS
            // 
            this.btnThemVaoDS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoDS.Location = new System.Drawing.Point(788, 108);
            this.btnThemVaoDS.Name = "btnThemVaoDS";
            this.btnThemVaoDS.Size = new System.Drawing.Size(276, 81);
            this.btnThemVaoDS.TabIndex = 1;
            this.btnThemVaoDS.Text = "Thêm vào danh sách";
            this.btnThemVaoDS.UseVisualStyleBackColor = true;
            this.btnThemVaoDS.Click += new System.EventHandler(this.btnThemVaoDS_Click);
            // 
            // btnThemVaoLopHoc
            // 
            this.btnThemVaoLopHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoLopHoc.Location = new System.Drawing.Point(788, 215);
            this.btnThemVaoLopHoc.Name = "btnThemVaoLopHoc";
            this.btnThemVaoLopHoc.Size = new System.Drawing.Size(276, 81);
            this.btnThemVaoLopHoc.TabIndex = 2;
            this.btnThemVaoLopHoc.Text = "Thêm vào lớp học";
            this.btnThemVaoLopHoc.UseVisualStyleBackColor = true;
            this.btnThemVaoLopHoc.Click += new System.EventHandler(this.btnThemVaoLopHoc_Click);
            // 
            // btnThemVaoDeCuongCuaToi
            // 
            this.btnThemVaoDeCuongCuaToi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoDeCuongCuaToi.Location = new System.Drawing.Point(788, 314);
            this.btnThemVaoDeCuongCuaToi.Name = "btnThemVaoDeCuongCuaToi";
            this.btnThemVaoDeCuongCuaToi.Size = new System.Drawing.Size(276, 81);
            this.btnThemVaoDeCuongCuaToi.TabIndex = 3;
            this.btnThemVaoDeCuongCuaToi.Text = "Thêm vào Đề cương của tôi";
            this.btnThemVaoDeCuongCuaToi.UseVisualStyleBackColor = true;
            // 
            // txtTenDeCuong
            // 
            this.txtTenDeCuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDeCuong.ForeColor = System.Drawing.Color.Gray;
            this.txtTenDeCuong.Location = new System.Drawing.Point(17, 62);
            this.txtTenDeCuong.Name = "txtTenDeCuong";
            this.txtTenDeCuong.Size = new System.Drawing.Size(352, 38);
            this.txtTenDeCuong.TabIndex = 4;
            this.txtTenDeCuong.Text = "Tìm kiếm tên đề cương...";
            this.txtTenDeCuong.Enter += new System.EventHandler(this.txtTenDeCuong_Enter);
            this.txtTenDeCuong.Leave += new System.EventHandler(this.txtTenDeCuong_Leave);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMonHoc.Location = new System.Drawing.Point(444, 69);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(123, 28);
            this.lblMonHoc.TabIndex = 6;
            this.lblMonHoc.Text = "Môn học:";
            this.lblMonHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(538, 67);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(200, 33);
            this.cmbMonHoc.TabIndex = 7;
            // 
            // btnTimTen
            // 
            this.btnTimTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimTen.Image = global::BTL___Nhóm_1.Properties.Resources.search_interface_symbol;
            this.btnTimTen.Location = new System.Drawing.Point(375, 59);
            this.btnTimTen.Name = "btnTimTen";
            this.btnTimTen.Size = new System.Drawing.Size(63, 47);
            this.btnTimTen.TabIndex = 5;
            this.btnTimTen.UseVisualStyleBackColor = true;
            this.btnTimTen.Click += new System.EventHandler(this.btnTimTen_Click);
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.btnTimTen);
            this.Controls.Add(this.txtTenDeCuong);
            this.Controls.Add(this.btnThemVaoDeCuongCuaToi);
            this.Controls.Add(this.btnThemVaoLopHoc);
            this.Controls.Add(this.btnThemVaoDS);
            this.Controls.Add(this.dgvTrangChu);
            this.Name = "TrangChu";
            this.Size = new System.Drawing.Size(1080, 662);
            this.Load += new System.EventHandler(this.TrangChu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrangChu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTrangChu;
        private System.Windows.Forms.Button btnThemVaoDS;
        private System.Windows.Forms.Button btnThemVaoLopHoc;
        private System.Windows.Forms.Button btnThemVaoDeCuongCuaToi;
        private System.Windows.Forms.TextBox txtTenDeCuong;
        private System.Windows.Forms.Button btnTimTen;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.ComboBox cmbMonHoc;
    }
}
