using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class ThongTinDeCuong : Form
    {
        public ThongTinDeCuong()
        {
            InitializeComponent();
            //Ban đầu form ở giữa màn hình
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        //Load thông tin đề cương lên form
        private void ThongTinDeCuong_Load(object sender, EventArgs e)
        {
            // Ẩn nút sửa, xoá nếu vai trò là Sinh viên
            if (BTL___Nhóm_1.DAL.User.VaiTro == "Sinh viên")
            {
                btnSua.Visible = false;
                btnXoa.Visible = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            txtTenDeCuong.Text = BTL___Nhóm_1.DAL.Syllabus.Name;
            txtTacGia.Text = BTL___Nhóm_1.DAL.Syllabus.Author;
            txtNgayXuatBan.Text = BTL___Nhóm_1.DAL.Syllabus.Date.ToString("dd/MM/yyyy");
            txtMonHoc.Text = BTL___Nhóm_1.DAL.Syllabus.SubjectName;
            txtFile.Text = BTL___Nhóm_1.DAL.Syllabus.Context;
            txtLoaiDeCuong.Text = BTL___Nhóm_1.DAL.Syllabus.Type;
            txtTrangThai.Text = BTL___Nhóm_1.DAL.Syllabus.Status;
        }
        //Tải tệp đề cương xuống máy người dùng
        private void btnTaiXuong_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show("Tệp không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sfdDeCuong.FileName = Path.GetFileName(txtFile.Text);
            //CHỉ định rõ loại file được phép lưu
            sfdDeCuong.Filter = "De Cuong(WORD,PDF,EXCEL)|*.pdf;*.docx;*.xls;*.xlsx";
            //Không cho phép ghi đè file
            sfdDeCuong.OverwritePrompt = false;
            if (sfdDeCuong.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string destinationPath = sfdDeCuong.FileName;
                    //Kiểm tra nếu tệp đã tồn tại, tạo tên tệp mới để tránh ghi đè
                    destinationPath = GetUniqueFileName(destinationPath);
                    File.Copy(txtFile.Text, destinationPath, true);
                    if (MessageBox.Show("Tải xuống thành công! Bạn có muốn mở tệp không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(destinationPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        //Tạo tên tệp duy nhất để tránh ghi đè
        private string GetUniqueFileName(string originalFileName)
        {
            if (!File.Exists(originalFileName)) return originalFileName;
            string folder = Path.GetDirectoryName(originalFileName);
            string fileName = Path.GetFileNameWithoutExtension(originalFileName);
            string ext = Path.GetExtension(originalFileName);
            int count = 1;
            string newPath = originalFileName;
            //Nếu có tệp trùng tên thì thêm (1),(2)... vào tên tệp
            while (File.Exists(originalFileName)) 
            { 
                newPath = Path.Combine(folder, $"{fileName}({count++}){ext}");
            }
            return newPath;
        }
        //Mở form câu hỏi tự luyện
        private void btnTuLuyen_Click(object sender, EventArgs e)
        {
            int questionCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM QUESTION WHERE SyllabusId = @SyllabusId", connection))
                    {
                        cmd.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            questionCount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (questionCount <= 0)
            {
                MessageBox.Show("Đề cương chưa có câu hỏi để tự luyện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.Hide();
            CauHoiTuLuyen cauHoiTuLuyen = new CauHoiTuLuyen();
            cauHoiTuLuyen.ShowDialog();
            this.Show();
        }
        //Mở form sửa đề cương
        private void btnSua_Click(object sender, EventArgs e)
        {
            this.Hide();
            SuaDeCuong suaDeCuong = new SuaDeCuong();
            suaDeCuong.ShowDialog();
            ThongTinDeCuong_Load(sender, e);
            this.Show();
        }
        //Xoá đề cương
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muôn xoá thông tin đề cương này", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
                    {
                        connection.Open();
                        using (SqlTransaction tran = connection.BeginTransaction())
                        {
                            try
                            {
                                // Xóa toàn bộ câu hỏi thuộc syllabus
                                string deleteQuestions = "DELETE FROM QUESTION WHERE SyllabusId = @SyllabusId";
                                using (SqlCommand delQ = new SqlCommand(deleteQuestions, connection, tran))
                                {
                                    delQ.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                                    delQ.ExecuteNonQuery();
                                }

                                // Xóa syllabus
                                string deleteSyllabus = "DELETE FROM Syllabus WHERE SyllabusId = @SyllabusId";
                                int rowsAffected;
                                using (SqlCommand delS = new SqlCommand(deleteSyllabus, connection, tran))
                                {
                                    delS.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                                    rowsAffected = delS.ExecuteNonQuery();
                                }

                                tran.Commit();

                                // Xóa tệp sau khi DB đã commit
                                if (File.Exists(BTL___Nhóm_1.DAL.Syllabus.Context))
                                {
                                    try { File.Delete(BTL___Nhóm_1.DAL.Syllabus.Context); } catch { /* ignore IO errors */ }
                                }

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Xoá đề cương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                            catch
                            {
                                tran.Rollback();
                                throw;
                            }
                        }
                    }
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
    }
}
