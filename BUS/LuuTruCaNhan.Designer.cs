namespace BTL___Nhóm_1.BUS
{
    partial class LuuTruCaNhan
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
            this.dgvLuuTru = new System.Windows.Forms.DataGridView();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuuTru)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLuuTru
            // 
            this.dgvLuuTru.AllowUserToAddRows = false;
            this.dgvLuuTru.AllowUserToDeleteRows = false;
            this.dgvLuuTru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuuTru.Location = new System.Drawing.Point(20, 100);
            this.dgvLuuTru.Name = "dgvLuuTru";
            this.dgvLuuTru.ReadOnly = true;
            this.dgvLuuTru.RowHeadersVisible = false;
            this.dgvLuuTru.RowHeadersWidth = 51;
            this.dgvLuuTru.RowTemplate.Height = 24;
            this.dgvLuuTru.Size = new System.Drawing.Size(942, 300);
            this.dgvLuuTru.TabIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.txtTen.ForeColor = System.Drawing.Color.Gray;
            this.txtTen.Location = new System.Drawing.Point(20, 50);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(352, 38);
            this.txtTen.TabIndex = 1;
            this.txtTen.Text = "Tìm kiếm tên đề cương...";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnTim.Image = global::BTL___Nhóm_1.Properties.Resources.search_interface_symbol;
            this.btnTim.Location = new System.Drawing.Point(380, 50);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(60, 40);
            this.btnTim.TabIndex = 2;
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(566, 54);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(200, 33);
            this.cmbMonHoc.TabIndex = 3;
            this.cmbMonHoc.SelectedIndexChanged += new System.EventHandler(this.cmbMonHoc_SelectedIndexChanged_1);
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMonHoc.Location = new System.Drawing.Point(450, 57);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(100, 28);
            this.lblMonHoc.TabIndex = 1;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(20, 428);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(200, 60);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa khỏi Đề cương của tôi";
            // 
            // LuuTruCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.dgvLuuTru);
            this.Name = "LuuTruCaNhan";
            this.Size = new System.Drawing.Size(1000, 650);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuuTru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLuuTru;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.Button btnXoa;
    }
}
