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
            txtFile.Text = Path.GetFileName(BTL___Nhóm_1.DAL.Syllabus.Context);
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
                        if (File.Exists(BTL___Nhóm_1.DAL.Syllabus.Context))
                        {
                            File.Delete(BTL___Nhóm_1.DAL.Syllabus.Context);
                        }
                        string delete = "DELETE FROM Syllabus WHERE SyllabusId = @SyllabusId";
                        using (SqlCommand command = new SqlCommand(delete, connection))
                        {
                            command.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xoá đề cương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
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
