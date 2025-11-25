namespace BTL___Nhóm_1.GUI.LopHoc
{
    partial class SuaThongTin
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
            this.btnSuaLop = new System.Windows.Forms.Button();
            this.txtGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.lbTenLop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSuaLop
            // 
            this.btnSuaLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuaLop.Location = new System.Drawing.Point(192, 195);
            this.btnSuaLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSuaLop.Name = "btnSuaLop";
            this.btnSuaLop.Size = new System.Drawing.Size(319, 59);
            this.btnSuaLop.TabIndex = 23;
            this.btnSuaLop.Text = "Sửa thông tin";
            this.btnSuaLop.UseVisualStyleBackColor = true;
            this.btnSuaLop.Click += new System.EventHandler(this.btnSuaLop_Click);
            // 
            // txtGV
            // 
            this.txtGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGV.Location = new System.Drawing.Point(284, 123);
            this.txtGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGV.Name = "txtGV";
            this.txtGV.Size = new System.Drawing.Size(353, 38);
            this.txtGV.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 21;
            this.label1.Text = "Giảng viên phụ trách";
            // 
            // txtTenLop
            // 
            this.txtTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Location = new System.Drawing.Point(284, 45);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(353, 38);
            this.txtTenLop.TabIndex = 20;
            // 
            // lbTenLop
            // 
            this.lbTenLop.AutoSize = true;
            this.lbTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenLop.Location = new System.Drawing.Point(22, 45);
            this.lbTenLop.Name = "lbTenLop";
            this.lbTenLop.Size = new System.Drawing.Size(96, 29);
            this.lbTenLop.TabIndex = 19;
            this.lbTenLop.Text = "Tên lớp";
            // 
            // SuaThongTin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 275);
            this.Controls.Add(this.btnSuaLop);
            this.Controls.Add(this.txtGV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.lbTenLop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SuaThongTin";
            this.Text = "Sửa thông tin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuaLop;
        private System.Windows.Forms.TextBox txtGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label lbTenLop;
    }
}