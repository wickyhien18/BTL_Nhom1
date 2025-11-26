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

namespace BTL___Nhóm_1.GUI.LopHoc
{
    public partial class ThemLop : Form
    {
        public ThemLop()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text) ||
                string.IsNullOrWhiteSpace(txtGV.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    //Kiểm tra trùng tên lớp
                    string checkSql = @"SELECT COUNT(*) FROM Class WHERE ClassName = @ClassName";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@ClassName", txtTenLop.Text.Trim());
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Tên lớp đã tồn tại!", "Trùng tên lớp",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string insertClassSql = @"INSERT INTO Class (ClassName, TeacherName) 
                                      VALUES (@ClassName, @TeacherName);
                                      SELECT SCOPE_IDENTITY();";
                        int classId;
                        using (SqlCommand cmd = new SqlCommand(insertClassSql, connection))
                        {
                            cmd.Parameters.AddWithValue("@ClassName", txtTenLop.Text.Trim());
                            cmd.Parameters.AddWithValue("@TeacherName", txtGV.Text.Trim());
                            classId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        int userId = BTL___Nhóm_1.DAL.User.Id;
                        string insertClassUserSql = @"INSERT INTO Class_User (ClassId, UserId) 
                                              VALUES (@ClassId, @UserId);";
                        using (SqlCommand cmd = new SqlCommand(insertClassUserSql, connection))
                        {
                            cmd.Parameters.AddWithValue("@ClassId", classId);
                            cmd.Parameters.AddWithValue("@UserId", userId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Thêm lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void lbTenLop_Click(object sender, EventArgs e)
        {

        }

        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGV_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTenLop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
