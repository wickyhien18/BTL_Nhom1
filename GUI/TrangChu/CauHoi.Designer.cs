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
            this.sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            this.txtCauHoi = new System.Windows.Forms.TextBox();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDapAn = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.rdoE = new System.Windows.Forms.RadioButton();
            this.txtE = new System.Windows.Forms.TextBox();
            this.txtF = new System.Windows.Forms.TextBox();
            this.rdoF = new System.Windows.Forms.RadioButton();
            this.ckA = new System.Windows.Forms.CheckBox();
            this.ckB = new System.Windows.Forms.CheckBox();
            this.ckC = new System.Windows.Forms.CheckBox();
            this.ckD = new System.Windows.Forms.CheckBox();
            this.ckE = new System.Windows.Forms.CheckBox();
            this.ckF = new System.Windows.Forms.CheckBox();
            this.txtDapAnTL = new System.Windows.Forms.TextBox();
            this.labelDapAn = new System.Windows.Forms.Label();
            this.btnTiep = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHoi.Location = new System.Drawing.Point(32, 11);
            this.lblCauHoi.Name = "lblCauHoi";
            this.lblCauHoi.Size = new System.Drawing.Size(95, 29);
            this.lblCauHoi.TabIndex = 0;
            this.lblCauHoi.Text = "Câu hỏi";
            // 
            // sqlCommand1
            // 
            this.sqlCommand1.CommandTimeout = 30;
            this.sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // txtCauHoi
            // 
            this.txtCauHoi.BackColor = System.Drawing.SystemColors.Window;
            this.txtCauHoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCauHoi.Location = new System.Drawing.Point(37, 44);
            this.txtCauHoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCauHoi.Multiline = true;
            this.txtCauHoi.Name = "txtCauHoi";
            this.txtCauHoi.ReadOnly = true;
            this.txtCauHoi.Size = new System.Drawing.Size(625, 101);
            this.txtCauHoi.TabIndex = 2;
            // 
            // rdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoA.Location = new System.Drawing.Point(36, 162);
            this.rdoA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(17, 16);
            this.rdoA.TabIndex = 3;
            this.rdoA.TabStop = true;
            this.rdoA.UseVisualStyleBackColor = true;
            // 
            // rdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoB.Location = new System.Drawing.Point(36, 213);
            this.rdoB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(17, 16);
            this.rdoB.TabIndex = 3;
            this.rdoB.TabStop = true;
            this.rdoB.UseVisualStyleBackColor = true;
            // 
            // rdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoC.Location = new System.Drawing.Point(36, 262);
            this.rdoC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(17, 16);
            this.rdoC.TabIndex = 3;
            this.rdoC.TabStop = true;
            this.rdoC.UseVisualStyleBackColor = true;
            // 
            // rdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoD.Location = new System.Drawing.Point(35, 313);
            this.rdoD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoD.Name = "rdoD";
            this.rdoD.Size = new System.Drawing.Size(17, 16);
            this.rdoD.TabIndex = 3;
            this.rdoD.TabStop = true;
            this.rdoD.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCheck.Location = new System.Drawing.Point(243, 503);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(208, 59);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Kiểm tra đáp án";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtDapAn
            // 
            this.txtDapAn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDapAn.Enabled = false;
            this.txtDapAn.Location = new System.Drawing.Point(37, 471);
            this.txtDapAn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.ReadOnly = true;
            this.txtDapAn.Size = new System.Drawing.Size(625, 15);
            this.txtDapAn.TabIndex = 5;
            this.txtDapAn.Visible = false;
            // 
            // txtA
            // 
            this.txtA.BackColor = System.Drawing.SystemColors.Window;
            this.txtA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtA.Location = new System.Drawing.Point(65, 162);
            this.txtA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA.Multiline = true;
            this.txtA.Name = "txtA";
            this.txtA.ReadOnly = true;
            this.txtA.Size = new System.Drawing.Size(599, 41);
            this.txtA.TabIndex = 6;
            // 
            // txtB
            // 
            this.txtB.BackColor = System.Drawing.SystemColors.Window;
            this.txtB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtB.Location = new System.Drawing.Point(64, 214);
            this.txtB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.ReadOnly = true;
            this.txtB.Size = new System.Drawing.Size(599, 41);
            this.txtB.TabIndex = 6;
            // 
            // txtC
            // 
            this.txtC.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtC.Location = new System.Drawing.Point(64, 262);
            this.txtC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.ReadOnly = true;
            this.txtC.Size = new System.Drawing.Size(599, 41);
            this.txtC.TabIndex = 6;
            // 
            // txtD
            // 
            this.txtD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtD.Location = new System.Drawing.Point(64, 314);
            this.txtD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.ReadOnly = true;
            this.txtD.Size = new System.Drawing.Size(599, 41);
            this.txtD.TabIndex = 6;
            // 
            // rdoE
            // 
            this.rdoE.AutoSize = true;
            this.rdoE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoE.Location = new System.Drawing.Point(35, 366);
            this.rdoE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoE.Name = "rdoE";
            this.rdoE.Size = new System.Drawing.Size(17, 16);
            this.rdoE.TabIndex = 3;
            this.rdoE.TabStop = true;
            this.rdoE.UseVisualStyleBackColor = true;
            // 
            // txtE
            // 
            this.txtE.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtE.Location = new System.Drawing.Point(64, 367);
            this.txtE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtE.Multiline = true;
            this.txtE.Name = "txtE";
            this.txtE.ReadOnly = true;
            this.txtE.Size = new System.Drawing.Size(599, 41);
            this.txtE.TabIndex = 6;
            // 
            // txtF
            // 
            this.txtF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtF.Location = new System.Drawing.Point(64, 418);
            this.txtF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtF.Multiline = true;
            this.txtF.Name = "txtF";
            this.txtF.ReadOnly = true;
            this.txtF.Size = new System.Drawing.Size(599, 41);
            this.txtF.TabIndex = 6;
            // 
            // rdoF
            // 
            this.rdoF.AutoSize = true;
            this.rdoF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoF.Location = new System.Drawing.Point(33, 417);
            this.rdoF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoF.Name = "rdoF";
            this.rdoF.Size = new System.Drawing.Size(17, 16);
            this.rdoF.TabIndex = 3;
            this.rdoF.TabStop = true;
            this.rdoF.UseVisualStyleBackColor = true;
            // 
            // ckA
            // 
            this.ckA.AutoSize = true;
            this.ckA.Location = new System.Drawing.Point(36, 162);
            this.ckA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckA.Name = "ckA";
            this.ckA.Size = new System.Drawing.Size(18, 17);
            this.ckA.TabIndex = 7;
            this.ckA.UseVisualStyleBackColor = true;
            // 
            // ckB
            // 
            this.ckB.AutoSize = true;
            this.ckB.Location = new System.Drawing.Point(36, 212);
            this.ckB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckB.Name = "ckB";
            this.ckB.Size = new System.Drawing.Size(18, 17);
            this.ckB.TabIndex = 7;
            this.ckB.UseVisualStyleBackColor = true;
            // 
            // ckC
            // 
            this.ckC.AutoSize = true;
            this.ckC.Location = new System.Drawing.Point(35, 261);
            this.ckC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckC.Name = "ckC";
            this.ckC.Size = new System.Drawing.Size(18, 17);
            this.ckC.TabIndex = 7;
            this.ckC.UseVisualStyleBackColor = true;
            // 
            // ckD
            // 
            this.ckD.AutoSize = true;
            this.ckD.Location = new System.Drawing.Point(35, 311);
            this.ckD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckD.Name = "ckD";
            this.ckD.Size = new System.Drawing.Size(18, 17);
            this.ckD.TabIndex = 7;
            this.ckD.UseVisualStyleBackColor = true;
            // 
            // ckE
            // 
            this.ckE.AutoSize = true;
            this.ckE.Location = new System.Drawing.Point(33, 364);
            this.ckE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckE.Name = "ckE";
            this.ckE.Size = new System.Drawing.Size(18, 17);
            this.ckE.TabIndex = 7;
            this.ckE.UseVisualStyleBackColor = true;
            // 
            // ckF
            // 
            this.ckF.AutoSize = true;
            this.ckF.Location = new System.Drawing.Point(33, 416);
            this.ckF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ckF.Name = "ckF";
            this.ckF.Size = new System.Drawing.Size(18, 17);
            this.ckF.TabIndex = 7;
            this.ckF.UseVisualStyleBackColor = true;
            // 
            // txtDapAnTL
            // 
            this.txtDapAnTL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDapAnTL.Location = new System.Drawing.Point(33, 187);
            this.txtDapAnTL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDapAnTL.Multiline = true;
            this.txtDapAnTL.Name = "txtDapAnTL";
            this.txtDapAnTL.ReadOnly = true;
            this.txtDapAnTL.Size = new System.Drawing.Size(625, 286);
            this.txtDapAnTL.TabIndex = 8;
            // 
            // labelDapAn
            // 
            this.labelDapAn.AutoSize = true;
            this.labelDapAn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.labelDapAn.Location = new System.Drawing.Point(32, 154);
            this.labelDapAn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDapAn.Name = "labelDapAn";
            this.labelDapAn.Size = new System.Drawing.Size(91, 29);
            this.labelDapAn.TabIndex = 9;
            this.labelDapAn.Text = "Đáp Án";
            // 
            // btnTiep
            // 
            this.btnTiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnTiep.Location = new System.Drawing.Point(243, 503);
            this.btnTiep.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTiep.Name = "btnTiep";
            this.btnTiep.Size = new System.Drawing.Size(208, 59);
            this.btnTiep.TabIndex = 4;
            this.btnTiep.Text = "Câu tiếp";
            this.btnTiep.UseVisualStyleBackColor = true;
            this.btnTiep.Click += new System.EventHandler(this.btnTiep_Click);
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 574);
            this.Controls.Add(this.labelDapAn);
            this.Controls.Add(this.txtDapAnTL);
            this.Controls.Add(this.ckF);
            this.Controls.Add(this.ckE);
            this.Controls.Add(this.ckD);
            this.Controls.Add(this.ckC);
            this.Controls.Add(this.ckB);
            this.Controls.Add(this.ckA);
            this.Controls.Add(this.txtF);
            this.Controls.Add(this.txtE);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.txtDapAn);
            this.Controls.Add(this.btnTiep);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rdoB);
            this.Controls.Add(this.rdoF);
            this.Controls.Add(this.rdoE);
            this.Controls.Add(this.rdoD);
            this.Controls.Add(this.rdoC);
            this.Controls.Add(this.rdoA);
            this.Controls.Add(this.txtCauHoi);
            this.Controls.Add(this.lblCauHoi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "CauHoi";
            this.Text = "Câu hỏi";
            this.Load += new System.EventHandler(this.CauHoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCauHoi;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.TextBox txtCauHoi;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoD;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDapAn;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.RadioButton rdoE;
        private System.Windows.Forms.TextBox txtE;
        private System.Windows.Forms.TextBox txtF;
        private System.Windows.Forms.RadioButton rdoF;
        private System.Windows.Forms.CheckBox ckA;
        private System.Windows.Forms.CheckBox ckB;
        private System.Windows.Forms.CheckBox ckC;
        private System.Windows.Forms.CheckBox ckD;
        private System.Windows.Forms.CheckBox ckE;
        private System.Windows.Forms.CheckBox ckF;
        private System.Windows.Forms.TextBox txtDapAnTL;
        private System.Windows.Forms.Label labelDapAn;
        private System.Windows.Forms.Button btnTiep;
    }
}