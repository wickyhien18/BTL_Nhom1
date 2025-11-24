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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDapAn = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblCauHoi
            // 
            this.lblCauHoi.AutoSize = true;
            this.lblCauHoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCauHoi.Location = new System.Drawing.Point(32, 31);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(152, 36);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(495, 22);
            this.textBox1.TabIndex = 2;
            // 
            // rdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoA.Location = new System.Drawing.Point(37, 172);
            this.rdoA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoA.Name = "rdoA";
            this.rdoA.Size = new System.Drawing.Size(115, 29);
            this.rdoA.TabIndex = 3;
            this.rdoA.TabStop = true;
            this.rdoA.Text = "Đáp án A";
            this.rdoA.UseVisualStyleBackColor = true;
            // 
            // rdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoB.Location = new System.Drawing.Point(37, 225);
            this.rdoB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoB.Name = "rdoB";
            this.rdoB.Size = new System.Drawing.Size(114, 29);
            this.rdoB.TabIndex = 3;
            this.rdoB.TabStop = true;
            this.rdoB.Text = "Đáp án B";
            this.rdoB.UseVisualStyleBackColor = true;
            // 
            // rdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoC.Location = new System.Drawing.Point(37, 272);
            this.rdoC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoC.Name = "rdoC";
            this.rdoC.Size = new System.Drawing.Size(116, 29);
            this.rdoC.TabIndex = 3;
            this.rdoC.TabStop = true;
            this.rdoC.Text = "Đáp án C";
            this.rdoC.UseVisualStyleBackColor = true;
            // 
            // rdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rdoD.Location = new System.Drawing.Point(37, 319);
            this.rdoD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdoD.Name = "rdoD";
            this.rdoD.Size = new System.Drawing.Size(115, 29);
            this.rdoD.TabIndex = 3;
            this.rdoD.TabStop = true;
            this.rdoD.Text = "Đáp án D";
            this.rdoD.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCheck.Location = new System.Drawing.Point(239, 412);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(208, 59);
            this.btnCheck.TabIndex = 4;
            this.btnCheck.Text = "Kiểm tra đáp án";
            this.btnCheck.UseVisualStyleBackColor = true;
            // 
            // txtDapAn
            // 
            this.txtDapAn.Enabled = false;
            this.txtDapAn.Location = new System.Drawing.Point(37, 372);
            this.txtDapAn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.Size = new System.Drawing.Size(609, 22);
            this.txtDapAn.TabIndex = 5;
            this.txtDapAn.Visible = false;
            // 
            // CauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 486);
            this.Controls.Add(this.txtDapAn);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rdoB);
            this.Controls.Add(this.rdoD);
            this.Controls.Add(this.rdoC);
            this.Controls.Add(this.rdoA);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblCauHoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CauHoi";
            this.Text = "Câu hỏi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CauHoi_FormClosing);
            this.Load += new System.EventHandler(this.CauHoi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCauHoi;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoD;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDapAn;
    }
}