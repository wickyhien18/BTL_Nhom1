using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.GUI.LopHoc
{
    public partial class SuaThongTin : Form
    {
        private int currentClassId;
        public SuaThongTin(int classId)
        {
            InitializeComponent();
            currentClassId = classId;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnSuaLop_Click(object sender, EventArgs e)
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
                    string checkSql = @"SELECT COUNT(*) FROM Class WHERE ClassName = @ClassName AND ClassId <> @ClassId";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@ClassName", txtTenLop.Text.Trim());
                        checkCmd.Parameters.AddWithValue("@ClassId", currentClassId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Tên lớp đã tồn tại!", "Trùng tên lớp",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        string updateClassSql = @"UPDATE Class SET ClassName = @ClassName, TeacherName = @TeacherName
                                                  WHERE ClassId = @ClassId";
                        using (SqlCommand cmd = new SqlCommand(updateClassSql, connection))
                        {
                            cmd.Parameters.AddWithValue("@ClassName", txtTenLop.Text.Trim());
                            cmd.Parameters.AddWithValue("@TeacherName", txtGV.Text.Trim());
                            cmd.Parameters.AddWithValue("@ClassId", currentClassId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
