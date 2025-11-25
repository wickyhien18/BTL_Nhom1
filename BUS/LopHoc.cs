using BTL___Nhóm_1.DAL;
using BTL___Nhóm_1.GUI.LopHoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.BUS
{
    public partial class LopHoc : UserControl
    {
        public LopHoc()
        {
            InitializeComponent();
            this.Load += LopHoc_Load;
        }
        private void SetButtonInRole()
        {
            string Role = BTL___Nhóm_1.DAL.User.VaiTro;
            if (Role == "Sinh viên")
            {
                btnThem.Visible = false;
                btnSua.Visible = false;
                btnXoa.Visible = false;
            } else
            {
                btnThem.Visible = true;
                btnSua.Visible = true;
                btnXoa.Visible = true;
            }
        }
        private void LoadData()
        {
            try
            {
                int userId = BTL___Nhóm_1.DAL.User.Id;
                string query = @"SELECT c.ClassId, c.ClassName, c.TeacherName, sub.SubjectName
                                 FROM Class c
                                 JOIN Class_User cu ON c.ClassId = cu.ClassId
                                 LEFT JOIN Class_Syllabus cs ON c.ClassId = cs.ClassId
                                 LEFT JOIN Syllabus s ON cs.SyllabusId = s.SyllabusId
                                 LEFT JOIN Subject sub ON s.SubjectId = sub.SubjectId
                                 WHERE cu.UserId = @UserId";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString)){
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvLop.DataSource = dt;
                        }
                    }
                    if (dgvLop.Columns["ClassId"] != null)
                        dgvLop.Columns["ClassId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RefreshData()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        LoadData();
                    }));
                }
                else
                {
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LopHoc_Load(object sender, EventArgs e)
        {
            LoadData();
            SetButtonInRole();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemLop themLopform = new ThemLop();
            themLopform.ShowDialog();
            try
            {
                int userId = BTL___Nhóm_1.DAL.User.Id;
                string query = @"SELECT c.ClassId, c.ClassName, c.TeacherName, sub.SubjectName
                                 FROM Class c
                                 JOIN Class_User cu ON c.ClassId = cu.ClassId
                                 LEFT JOIN Class_Syllabus cs ON c.ClassId = cs.ClassId
                                 LEFT JOIN Syllabus s ON cs.SyllabusId = s.SyllabusId
                                 LEFT JOIN Subject sub ON s.SubjectId = sub.SubjectId
                                 WHERE cu.UserId = @UserId";
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvLop.AutoGenerateColumns = false;
                            dgvLop.DataSource = dt;
                        }
                    }
                    if (dgvLop.Columns["ClassId"] != null)
                        dgvLop.Columns["ClassId"].Visible = false;
                }
                this.BeginInvoke(new Action(() => SetButtonInRole()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
