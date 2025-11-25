namespace BTL___Nhóm_1.GUI.LopHoc
{
    partial class ThemLop
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
            this.lbTenLop = new System.Windows.Forms.Label();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.txtGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemLop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTenLop
            // 
            this.lbTenLop.AutoSize = true;
            this.lbTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenLop.Location = new System.Drawing.Point(22, 42);
            this.lbTenLop.Name = "lbTenLop";
            this.lbTenLop.Size = new System.Drawing.Size(96, 29);
            this.lbTenLop.TabIndex = 1;
            this.lbTenLop.Text = "Tên lớp";
            this.lbTenLop.Click += new System.EventHandler(this.lbTenLop_Click);
            // 
            // txtTenLop
            // 
            this.txtTenLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenLop.Location = new System.Drawing.Point(284, 42);
            this.txtTenLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(353, 38);
            this.txtTenLop.TabIndex = 2;
            this.txtTenLop.TextChanged += new System.EventHandler(this.txtTenLop_TextChanged);
            // 
            // txtGV
            // 
            this.txtGV.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGV.Location = new System.Drawing.Point(284, 120);
            this.txtGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGV.Name = "txtGV";
            this.txtGV.Size = new System.Drawing.Size(353, 38);
            this.txtGV.TabIndex = 17;
            this.txtGV.TextChanged += new System.EventHandler(this.txtGV_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "Giảng viên phụ trách";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnThemLop
            // 
            this.btnThemLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemLop.Location = new System.Drawing.Point(192, 192);
            this.btnThemLop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(319, 59);
            this.btnThemLop.TabIndex = 18;
            this.btnThemLop.Text = "Thêm lớp";
            this.btnThemLop.UseVisualStyleBackColor = true;
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // ThemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 282);
            this.Controls.Add(this.btnThemLop);
            this.Controls.Add(this.txtGV);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenLop);
            this.Controls.Add(this.lbTenLop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ThemLop";
            this.Text = "Thêm lớp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTenLop;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemLop;
    }
}