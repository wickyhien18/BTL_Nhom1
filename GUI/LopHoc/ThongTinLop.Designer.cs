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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongTinLop));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnThemSV = new System.Windows.Forms.Button();
            this.btnThemDeCuong = new System.Windows.Forms.Button();
            this.btnDS = new System.Windows.Forms.Button();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtTim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgv, "dgv");
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select});
            this.dgv.GridColor = System.Drawing.Color.White;
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // Select
            // 
            resources.ApplyResources(this.Select, "Select");
            this.Select.Name = "Select";
            // 
            // btnThemSV
            // 
            resources.ApplyResources(this.btnThemSV, "btnThemSV");
            this.btnThemSV.Name = "btnThemSV";
            this.btnThemSV.UseVisualStyleBackColor = true;
            this.btnThemSV.Click += new System.EventHandler(this.btnThemSV_Click);
            // 
            // btnThemDeCuong
            // 
            resources.ApplyResources(this.btnThemDeCuong, "btnThemDeCuong");
            this.btnThemDeCuong.Name = "btnThemDeCuong";
            this.btnThemDeCuong.UseVisualStyleBackColor = true;
            this.btnThemDeCuong.Click += new System.EventHandler(this.btnThemDeCuong_Click);
            // 
            // btnDS
            // 
            resources.ApplyResources(this.btnDS, "btnDS");
            this.btnDS.Name = "btnDS";
            this.btnDS.UseVisualStyleBackColor = true;
            this.btnDS.Click += new System.EventHandler(this.btnDS_Click);
            // 
            // btnTim
            // 
            resources.ApplyResources(this.btnTim, "btnTim");
            this.btnTim.Name = "btnTim";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtTim
            // 
            resources.ApplyResources(this.txtTim, "txtTim");
            this.txtTim.ForeColor = System.Drawing.Color.Gray;
            this.txtTim.Name = "txtTim";
            this.txtTim.Enter += new System.EventHandler(this.txtTim_Enter);
            this.txtTim.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTim_KeyPress);
            this.txtTim.Leave += new System.EventHandler(this.txtTim_Leave);
            // 
            // ThongTinLop
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.btnDS);
            this.Controls.Add(this.btnThemDeCuong);
            this.Controls.Add(this.btnThemSV);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThongTinLop";
            this.Load += new System.EventHandler(this.ThongTinLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.Button btnThemSV;
        private System.Windows.Forms.Button btnThemDeCuong;
        private System.Windows.Forms.Button btnDS;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtTim;
    }
}