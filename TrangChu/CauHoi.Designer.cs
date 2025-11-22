namespace BTL___Nhóm_1.TrangChu
{
    partial class CauHoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CauHoi));
            this.lblCauHoi = new System.Windows.Forms.Label();
            this.txtDienDapAn = new System.Windows.Forms.TextBox();
            this.lblDapAn = new System.Windows.Forms.Label();
            this.btnNop = new System.Windows.Forms.Button();
            this.btnTiep = new System.Windows.Forms.Button();
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.txtGiaiThichDapAn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHoi.Location = new System.Drawing.Point(32, 33);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(95, 29);
            this.lblCauHoi.TabIndex = 0;
            this.lblCauHoi.Text = "Câu hỏi";
            // 
            // txtDienDapAn
            // 
            this.txtDienDapAn.BackColor = System.Drawing.Color.White;
            this.txtDienDapAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDienDapAn.Location = new System.Drawing.Point(37, 83);
            this.txtDienDapAn.Multiline = true;
            this.txtDienDapAn.Name = "txtDienDapAn";
            this.txtDienDapAn.Size = new System.Drawing.Size(610, 45);
            this.txtDienDapAn.TabIndex = 1;
            this.txtDienDapAn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDapAn
            // 
            this.lblDapAn.AutoSize = true;
            this.lblDapAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDapAn.Location = new System.Drawing.Point(32, 186);
            this.lblDapAn.Name = "lblDapAn";
            this.lblDapAn.Size = new System.Drawing.Size(89, 29);
            this.lblDapAn.TabIndex = 2;
            this.lblDapAn.Text = "Đáp án";
            // 
            // btnNop
            // 
            this.btnNop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNop.Location = new System.Drawing.Point(552, 146);
            this.btnNop.Name = "btnNop";
            this.btnNop.Size = new System.Drawing.Size(95, 45);
            this.btnNop.TabIndex = 3;
            this.btnNop.Text = "Nộp";
            this.btnNop.UseVisualStyleBackColor = true;
            this.btnNop.Click += new System.EventHandler(this.btnNop_Click);
            // 
            // btnTiep
            // 
            this.btnTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiep.Location = new System.Drawing.Point(552, 146);
            this.btnTiep.Name = "btnTiep";
            this.btnTiep.Size = new System.Drawing.Size(95, 45);
            this.btnTiep.TabIndex = 4;
            this.btnTiep.Text = "Tiếp";
            this.btnTiep.UseVisualStyleBackColor = true;
            this.btnTiep.Click += new System.EventHandler(this.btnTiep_Click);
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // txtGiaiThichDapAn
            // 
            this.txtGiaiThichDapAn.BackColor = System.Drawing.Color.White;
            this.txtGiaiThichDapAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaiThichDapAn.Location = new System.Drawing.Point(37, 230);
            this.txtGiaiThichDapAn.Multiline = true;
            this.txtGiaiThichDapAn.Name = "txtGiaiThichDapAn";
            this.txtGiaiThichDapAn.ReadOnly = true;
            this.txtGiaiThichDapAn.Size = new System.Drawing.Size(610, 229);
            this.txtGiaiThichDapAn.TabIndex = 5;
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 515);
            this.Controls.Add(this.txtGiaiThichDapAn);
            this.Controls.Add(this.btnTiep);
            this.Controls.Add(this.btnNop);
            this.Controls.Add(this.lblDapAn);
            this.Controls.Add(this.txtDienDapAn);
            this.Controls.Add(this.lblCauHoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CauHoi";
            this.Text = "Câu hỏi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CauHoi_FormClosing);
            this.Load += new System.EventHandler(this.CauHoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCauHoi;
        private System.Windows.Forms.TextBox txtDienDapAn;
        private System.Windows.Forms.Label lblDapAn;
        private System.Windows.Forms.Button btnNop;
        private System.Windows.Forms.Button btnTiep;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.TextBox txtGiaiThichDapAn;
    }
}