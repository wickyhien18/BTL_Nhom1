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

namespace BTL___Nhóm_1.GUI.LopHoc
{
    public partial class DanhSachSinhVien : Form
    {
        private int classId;
        public DanhSachSinhVien(int classId)
        {
            InitializeComponent();
            this.classId = classId;
            this.StartPosition = FormStartPosition.CenterScreen;
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                this.Load += DanhSachSinhVien_Load;
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Hãy chọn sinh viên cần xóa.");
                return;
            }

            int userId = Convert.ToInt32(dgv.SelectedRows[0].Cells["UserId"].Value);

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này khỏi lớp?",
                "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string delete = @"DELETE FROM Class_User WHERE ClassId = @ClassId AND UserId = @UserId";

                    using (SqlCommand cmd = new SqlCommand(delete, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa sinh viên khỏi lớp.");
                DanhSachSinhVien_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void DanhSachSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT u.UserId, u.UserName AS [Tên tài khoản], u.UserRole AS [Vai trò]
                        FROM Users u
                        INNER JOIN Class_User cu ON u.UserId = cu.UserId
                        WHERE cu.ClassId = @ClassId AND u.UserRole = N'Sinh viên'
                    ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            //Checkbox column
                            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn()
                            {
                                Name = "Select",
                                HeaderText = "",
                                Width = 30
                            };
                            dgv.Columns["Select"].ReadOnly = false;

                            dgv.DataSource = dt;
                            dgv.Columns["UserId"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sinh viên: " + ex.Message);
            }
        }
    }
}
