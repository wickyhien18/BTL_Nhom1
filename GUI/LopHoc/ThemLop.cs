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
            this.btnThem.Click += new EventHandler(btnThem_Click);
            this.Load += new EventHandler(ThemLop_Load);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenLop.Text) ||
                string.IsNullOrWhiteSpace(txtGV.Text) ||
                cmbMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn tệp đính kèm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
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

                    string insertClassUser = @"INSERT INTO Class_User (ClassId, UserId) VALUES (@ClassId, @UserId)";
                    using (SqlCommand cmd = new SqlCommand(insertClassUser, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.Parameters.AddWithValue("@UserId", BTL___Nhóm_1.DAL.User.Id); // user hiện tại
                        cmd.ExecuteNonQuery();
                    }

                    int subjectId = 0;
                    string selectSubjectId = "SELECT SubjectId FROM Subject WHERE SubjectName = @SubjectName";
                    using (SqlCommand command = new SqlCommand(selectSubjectId, connection))
                    {
                        command.Parameters.AddWithValue("@SubjectName", cmbMonHoc.SelectedItem.ToString());
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            subjectId = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Môn học không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    List<int> syllabusIds = new List<int>();
                    string selectSyllabusSql = "SELECT SyllabusId FROM Syllabus WHERE SubjectId = @SubjectId";
                    using (SqlCommand cmd = new SqlCommand(selectSyllabusSql, connection))
                    {
                        cmd.Parameters.AddWithValue("@SubjectId", subjectId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                syllabusIds.Add(reader.GetInt32(0));
                            }
                        }
                    }

                    foreach (int syllabusId in syllabusIds)
                    {
                        string insertClassSyllabus = "INSERT INTO Class_Syllabus (ClassId, SyllabusId) VALUES (@ClassId, @SyllabusId)";
                        using (SqlCommand cmd = new SqlCommand(insertClassSyllabus, connection))
                        {
                            cmd.Parameters.AddWithValue("@ClassId", classId);
                            cmd.Parameters.AddWithValue("@SyllabusId", syllabusId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Thêm lớp thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            ThemMon themMonForm = new ThemMon();
            themMonForm.ShowDialog();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string selectSubjectId = "SELECT SubjectName FROM Subject";
                    using (SqlCommand command = new SqlCommand(selectSubjectId, connection))
                    {
                        cmbMonHoc.Items.Clear();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbMonHoc.Items.Add(reader["SubjectName"].ToString());
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtTenLop_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThemLop_Load(object sender, EventArgs e)
        {
            //Thêm môn học vào combobox
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string selectSubjectId = "SELECT SubjectName FROM Subject";
                    using (SqlCommand command = new SqlCommand(selectSubjectId, connection))
                    {
                        cmbMonHoc.Items.Clear();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbMonHoc.Items.Add(reader["SubjectName"].ToString());
                            }
                        }
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
