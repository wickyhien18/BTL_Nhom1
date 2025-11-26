using BTL___Nhóm_1.TrangChu;
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

namespace BTL___Nhóm_1.GUI.TrangChu
{
    public partial class ChonLopHoc : Form
    {
        public int? SelectedClassId { get; private set; }
        public List<int> SelectedSyllabusIds { get; private set; } = new List<int>();
        public ChonLopHoc()
        {
            InitializeComponent();
            try
            {
                if (this.txtTim != null)
                {
                    this.txtTim.Enter -= txtTim_Enter;
                    this.txtTim.Leave -= txtTim_Leave;
                    this.txtTim.Enter += txtTim_Enter;
                    this.txtTim.Leave += txtTim_Leave;
                }
            }
            catch
            {
            }
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm tên lớp...")
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;
            }

        }
        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Tìm kiếm tên lớp...";
                txtTim.ForeColor = Color.Gray;
            }
        }

        private void ChonLopHoc_Load(object sender, EventArgs e)
        {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Lấy ID của lớp từ DataGridView
            int classId = Convert.ToInt32(dgvLop.Rows[e.RowIndex].Cells["ClassId"].Value);
            SelectedClassId = classId;

            // Mở form chọn đề cương
            using (var frm = new SelectSyllabiForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Lưu danh sách ID để form gọi ra có thể lấy lại
                    SelectedSyllabusIds = frm.SelectedSyllabusIds.ToList();
                }
                else
                {
                    SelectedSyllabusIds = new List<int>();
                }
            }

            // Đóng form và trả kết quả về form gọi
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string selectBase = "SELECT ClassId, ClassName, TeacherName FROM Class";
            var conditions = new List<string>();
            string finalSelect = selectBase;
            if (!string.IsNullOrEmpty(txtTim.Text.Trim()) && txtTim.Text != "Tìm kiếm lớp...")
            {
                conditions.Add("ClassName LIKE @search");
            }
            if (conditions.Count > 0)
            {
                finalSelect += " WHERE " + string.Join(" AND ", conditions);
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(finalSelect, connection))
                    {
                        command.Parameters.AddWithValue("@status", "Công khai");
                        if (conditions.Contains("ClassName LIKE @search"))
                        {
                            command.Parameters.AddWithValue("@search", "%" + txtTim.Text.Trim() + "%");
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvLop.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
