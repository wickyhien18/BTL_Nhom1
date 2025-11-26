namespace BTL___Nhóm_1.GUI.LopHoc
{
    partial class ThongTinLop
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnThemSV = new System.Windows.Forms.Button();
            this.btnThemDeCuong = new System.Windows.Forms.Button();
            this.btnDS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeight = 29;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(774, 427);
            this.dgv.TabIndex = 3;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Select
            // 
            this.Select.HeaderText = "";
            this.Select.MinimumWidth = 6;
            this.Select.Name = "Select";
            // 
            // btnThemSV
            // 
            this.btnThemSV.Location = new System.Drawing.Point(12, 448);
            this.btnThemSV.Name = "btnThemSV";
            this.btnThemSV.Size = new System.Drawing.Size(125, 44);
            this.btnThemSV.TabIndex = 4;
            this.btnThemSV.Text = "Thêm sinh viên";
            this.btnThemSV.UseVisualStyleBackColor = true;
            this.btnThemSV.Click += new System.EventHandler(this.btnThemSV_Click);
            // 
            // btnThemDeCuong
            // 
            this.btnThemDeCuong.Location = new System.Drawing.Point(143, 448);
            this.btnThemDeCuong.Name = "btnThemDeCuong";
            this.btnThemDeCuong.Size = new System.Drawing.Size(125, 44);
            this.btnThemDeCuong.TabIndex = 5;
            this.btnThemDeCuong.Text = "Thêm đề cương";
            this.btnThemDeCuong.UseVisualStyleBackColor = true;
            this.btnThemDeCuong.Click += new System.EventHandler(this.btnThemDeCuong_Click);
            // 
            // btnDS
            // 
            this.btnDS.Location = new System.Drawing.Point(274, 448);
            this.btnDS.Name = "btnDS";
            this.btnDS.Size = new System.Drawing.Size(125, 44);
            this.btnDS.TabIndex = 6;
            this.btnDS.Text = "Danh sách sinh viên";
            this.btnDS.UseVisualStyleBackColor = true;
            this.btnDS.Click += new System.EventHandler(this.btnDS_Click);
            // 
            // ThongTinLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 501);
            this.Controls.Add(this.btnDS);
            this.Controls.Add(this.btnThemDeCuong);
            this.Controls.Add(this.btnThemSV);
            this.Controls.Add(this.dgv);
            this.Name = "ThongTinLop";
            this.Text = "ThongTinLop";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button btnThemSV;
        private System.Windows.Forms.Button btnThemDeCuong;
        private System.Windows.Forms.Button btnDS;
    }
}