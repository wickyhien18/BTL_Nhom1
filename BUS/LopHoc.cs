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
                string query = @"SELECT c.ClassId, c.ClassName, c.TeacherName
                                 FROM Class c
                                 JOIN Class_User cu ON c.ClassId = cu.ClassId
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
                string query = @"SELECT c.ClassId, c.ClassName, c.TeacherName
                                 FROM Class c
                                 JOIN Class_User cu ON c.ClassId = cu.ClassId
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
            if (dgvLop.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int classId = Convert.ToInt32(dgvLop.CurrentRow.Cells["ClassId"].Value);
            SuaThongTin suaThongTinForm = new SuaThongTin(classId);
            if (suaThongTinForm.ShowDialog() == DialogResult.OK)
            {
                LoadData(); // load lại danh sách lớp sau khi sửa
            }
            try
            {
                int userId = BTL___Nhóm_1.DAL.User.Id;
                string query = @"SELECT c.ClassId, c.ClassName, c.TeacherName
                                 FROM Class c
                                 JOIN Class_User cu ON c.ClassId = cu.ClassId
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
                            dgvLop.DataSource = dt;
                        }
                    }
                    if (dgvLop.Columns["ClassId"] != null)
                        dgvLop.Columns["ClassId"].Visible = false;
                }
                this.BeginInvoke(new Action(() => SetButtonInRole()));
            } catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form sửa thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }         
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLop.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn lớp cần xoá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int classId = Convert.ToInt32(dgvLop.CurrentRow.Cells["ClassId"].Value);
            DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa lớp này không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
            );
            if (result != DialogResult.Yes)
                return;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    conn.Open();
                    //Xoá Class_User có chứa Foreign Key tham chiếu đến Class trước
                    string deleteCU = @"DELETE FROM Class_User WHERE ClassId = @ClassId";
                    using (SqlCommand cmd = new SqlCommand(deleteCU, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.ExecuteNonQuery();
                    }
                    //Xoá Class
                    string deleteClass = @"DELETE FROM Class WHERE ClassId = @ClassId";
                    using (SqlCommand cmd = new SqlCommand(deleteClass, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Xóa lớp thành công!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // refresh bảng
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
