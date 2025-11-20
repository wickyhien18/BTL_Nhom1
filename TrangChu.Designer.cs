namespace BTL___Nhóm_1
{
    partial class fmMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcbAvatar = new System.Windows.Forms.PictureBox();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnLopHoc = new System.Windows.Forms.Button();
            this.btnCaNhan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnCaNhan);
            this.panel1.Controls.Add(this.btnLopHoc);
            this.panel1.Controls.Add(this.btnTrangChu);
            this.panel1.Controls.Add(this.pcbAvatar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 776);
            this.panel1.TabIndex = 0;
            // 
            // pcbAvatar
            // 
            this.pcbAvatar.Image = global::BTL___Nhóm_1.Properties.Resources.UTC;
            this.pcbAvatar.Location = new System.Drawing.Point(44, 25);
            this.pcbAvatar.Name = "pcbAvatar";
            this.pcbAvatar.Size = new System.Drawing.Size(180, 180);
            this.pcbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbAvatar.TabIndex = 0;
            this.pcbAvatar.TabStop = false;
            this.pcbAvatar.Click += new System.EventHandler(this.pcbAvatar_Click);
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrangChu.FlatAppearance.BorderSize = 0;
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrangChu.Location = new System.Drawing.Point(4, 243);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(286, 67);
            this.btnTrangChu.TabIndex = 1;
            this.btnTrangChu.Text = "Trang chủ";
            this.btnTrangChu.UseVisualStyleBackColor = true;
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLopHoc.FlatAppearance.BorderSize = 0;
            this.btnLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLopHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLopHoc.Location = new System.Drawing.Point(3, 316);
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.Size = new System.Drawing.Size(286, 67);
            this.btnLopHoc.TabIndex = 2;
            this.btnLopHoc.Text = "Lớp học ";
            this.btnLopHoc.UseVisualStyleBackColor = true;
            // 
            // btnCaNhan
            // 
            this.btnCaNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaNhan.FlatAppearance.BorderSize = 0;
            this.btnCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaNhan.Location = new System.Drawing.Point(4, 389);
            this.btnCaNhan.Name = "btnCaNhan";
            this.btnCaNhan.Size = new System.Drawing.Size(286, 67);
            this.btnCaNhan.TabIndex = 3;
            this.btnCaNhan.Text = "Lưu trữ cá nhân";
            this.btnCaNhan.UseVisualStyleBackColor = true;
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 776);
            this.Controls.Add(this.panel1);
            this.Name = "fmMain";
            this.Text = "Trang chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmMain_FormClosing);
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcbAvatar;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnCaNhan;
        private System.Windows.Forms.Button btnLopHoc;
    }
}