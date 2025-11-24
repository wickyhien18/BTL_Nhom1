using BTL___Nhóm_1.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class SuaDeCuong : Form
    {
        string fileData = BTL___Nhóm_1.DAL.Syllabus.Context;
        string fileType = BTL___Nhóm_1.DAL.Syllabus.Type;
        string filePath = BTL___Nhóm_1.DAL.Syllabus.Context;
        public SuaDeCuong()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        // Load dữ liệu đề cương hiện tại vào form
        private void SuaDeCuong_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
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
            txtTenDeCuong.Text = BTL___Nhóm_1.DAL.Syllabus.Name;
            txtTacGia.Text = BTL___Nhóm_1.DAL.Syllabus.Author;
            dtpXuatBan.Value = BTL___Nhóm_1.DAL.Syllabus.Date;
            cmbMonHoc.SelectedItem = BTL___Nhóm_1.DAL.Syllabus.SubjectName;
            txtFile.Text = Path.GetFileName(BTL___Nhóm_1.DAL.Syllabus.Context);
        }
        // Chọn tệp đề cương
        private void btnFile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            ofdDeCuong.Filter = "De Cuong(WORD,PDF,EXCEL)|*.pdf;*.docx;*.xls;*.xlsx";
            if (ofdDeCuong.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileData = Path.GetFileName(ofdDeCuong.FileName);
                    fileType = Path.GetExtension(ofdDeCuong.FileName).ToLower();
                    txtFile.Text = Path.GetFileName(ofdDeCuong.FileName);

                    //Đường dẫn lưu tệp ./Project_Name/KhoDeCuong
                    string folderDeCuong;
#if DEBUG
                    try
                    {
                        DirectoryInfo directoryInfo = Directory.GetParent(Application.StartupPath).Parent;

                        folderDeCuong = Path.Combine(directoryInfo.FullName, "KhoDeCuong");
                    }
                    catch (Exception)
                    {
                        folderDeCuong = Path.Combine(Application.StartupPath, "KhoDeCuong");
                    }
#else
                        folderDeCuong = Path.Combine(Application.StartupPath, "KhoDeCuong");
#endif

                    string newFile = fileData + "_" + DateTime.Now.Ticks.ToString();
                    filePath = Path.Combine(folderDeCuong, newFile + fileType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        // Sửa đề cương
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDeCuong.Text) ||
                string.IsNullOrWhiteSpace(txtTacGia.Text) || cmbMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc với những thay đổi cho thông tin đề cương hiện tại?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    //Nếu người dùng chọn tệp mới thì xóa tệp cũ và lưu tệp mới
                    if (txtFile.Text != Path.GetFileName(BTL___Nhóm_1.DAL.Syllabus.Context))
                    {
                        if (File.Exists(BTL___Nhóm_1.DAL.Syllabus.Context))
                        {
                            File.Delete(BTL___Nhóm_1.DAL.Syllabus.Context);
                        }

                        File.Copy(ofdDeCuong.FileName, filePath);
                    }

                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
                    {
                        connection.Open();
                        // Lấy SubjectId từ tên môn học đã chọn
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
                        string update = "";
                        //Thêm đề cương vào cơ sở dữ liệu
                        if (txtFile.Text != BTL___Nhóm_1.DAL.Syllabus.Context)
                        {
                            update = "UPDATE Syllabus SET " +
                                        "SyllabusName = @SyllabusName, " +
                                        "Author = @Author, " +
                                        "PostedDate = @PostedDate, " +
                                        "SubjectId = @SubjectId, " +
                                        "SyllabusContext = @SyllabusContext, " +
                                        "SyllabusType = @SyllabusType, " +
                                        "SyllabusStatus = @SyllabusStatus " +
                                        "WHERE SyllabusId = @SyllabusId";
                        }
                        else
                        {
                            update = "UPDATE Syllabus SET " +
                                        "SyllabusName = @SyllabusName, " +
                                        "Author = @Author, " +
                                        "PostedDate = @PostedDate, " +
                                        "SubjectId = @SubjectId, " +
                                        "SyllabusStatus = @SyllabusStatus " +
                                        "WHERE SyllabusId = @SyllabusId";
                        }
                        using (SqlCommand command = new SqlCommand(update, connection))
                        {
                            command.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                            command.Parameters.AddWithValue("@SyllabusName", txtTenDeCuong.Text.Trim());
                            command.Parameters.AddWithValue("@Author", txtTacGia.Text.Trim());
                            command.Parameters.AddWithValue("@PostedDate", dtpXuatBan.Text);
                            command.Parameters.AddWithValue("@SubjectId", subjectId);
                            if (txtFile.Text != BTL___Nhóm_1.DAL.Syllabus.Context) {
                                command.Parameters.AddWithValue("@SyllabusContext", filePath);
                                command.Parameters.AddWithValue("@SyllabusType", fileType);
                            }
                                command.Parameters.AddWithValue("@SyllabusStatus", "Công khai");
                                command.ExecuteNonQuery();
                            }
                    }
                    MessageBox.Show("Sửa đề cương thành công!");
                    BTL___Nhóm_1.DAL.Syllabus.Name = txtTenDeCuong.Text;
                    BTL___Nhóm_1.DAL.Syllabus.Author = txtTacGia.Text;
                    BTL___Nhóm_1.DAL.Syllabus.Date = dtpXuatBan.Value;
                    BTL___Nhóm_1.DAL.Syllabus.SubjectName = cmbMonHoc.SelectedItem.ToString();
                    BTL___Nhóm_1.DAL.Syllabus.Context = filePath;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
            else
            {
                return;
            }
        }
        // Chỉ cho phép nhập chữ cái, chữ số và dấu gạch dưới
        private void txtTenDeCuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }
        // Chỉ cho phép nhập chữ cái, chữ số và dấu cách
        private void txtTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        // Mở form thêm môn học
        private void btnThemMon_Click(object sender, EventArgs e)
        {
            ThemMon themMonForm = new ThemMon();
            themMonForm.ShowDialog();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
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
