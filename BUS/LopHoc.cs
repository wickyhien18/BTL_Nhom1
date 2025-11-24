using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.BUS
{
    public partial class LopHoc : UserControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvLop;
        private Label lbLop;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    public LopHoc()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvLop = new System.Windows.Forms.DataGridView();
            this.lbLop = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLop
            // 
            this.dgvLop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLop.Location = new System.Drawing.Point(12, 134);
            this.dgvLop.Name = "dgvLop";
            this.dgvLop.RowHeadersWidth = 51;
            this.dgvLop.RowTemplate.Height = 24;
            this.dgvLop.Size = new System.Drawing.Size(665, 278);
            this.dgvLop.TabIndex = 0;
            this.dgvLop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbLop
            // 
            this.lbLop.AutoSize = true;
            this.lbLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F);
            this.lbLop.Location = new System.Drawing.Point(271, 16);
            this.lbLop.Name = "lbLop";
            this.lbLop.Size = new System.Drawing.Size(288, 38);
            this.lbLop.TabIndex = 2;
            this.lbLop.Text = "Danh sách lớp học";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 57);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm lớp";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(309, 66);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sửa thông tin";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(713, 331);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(309, 60);
            this.button3.TabIndex = 5;
            this.button3.Text = "Xoá lớp";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 38);
            this.button4.TabIndex = 6;
            this.button4.Text = "Quay lại";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // LopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbLop);
            this.Controls.Add(this.dgvLop);
            this.Name = "LopHoc";
            this.Size = new System.Drawing.Size(1052, 544);
            this.Load += new System.EventHandler(this.LopHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LopHoc_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
