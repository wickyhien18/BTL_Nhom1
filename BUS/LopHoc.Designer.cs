using BTL___Nhóm_1.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        string connectionString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
        private int _userId;
        private string _role;
        public LopHoc(int userId, string role) 
        {
            InitializeComponent();
            _userId = userId;
            _role = role;
            this.Load += new System.EventHandler(this.Form1_Load);

        }
        private void LoadLop(int userId, string role)
        {
            string query = "";

            if (role == "GiangVien")
            {
                // Giảng viên xem lớp mà họ quản lý
                query = @"SELECT ClassId, ClassName, TeacherName 
                  FROM Class 
                  WHERE UserId = @UserId";
            }
            else
            {
                // Sinh viên xem lớp mà họ tham gia
                query = @"SELECT c.ClassId, c.ClassName, c.TeacherName
                  FROM Class c
                  INNER JOIN Users_Class uc ON c.ClassId = uc.ClassId
                  WHERE uc.UserId = @UserId";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvLop.DataSource = dt;

                if (dgvLop.Columns.Contains("ClassId"))
                {
                    dgvLop.Columns["ClassId"].Visible = false;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadLop(_userId, _role);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            // 
            // LopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LopHoc";
            this.Size = new System.Drawing.Size(1080, 776);
            this.ResumeLayout(false);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
