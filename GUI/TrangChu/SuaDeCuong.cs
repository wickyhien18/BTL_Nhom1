        using BTL___Nhóm_1.DAL;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
            if (MessageBox.Show("Bạn có chắc muốn thay đổi thông tin đề cương?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                            command.Parameters.AddWithValue("@PostedDate", dtpXuatBan.Value);
                            command.Parameters.AddWithValue("@SubjectId", subjectId);
                            if (txtFile.Text != BTL___Nhóm_1.DAL.Syllabus.Context)
                            {
                                command.Parameters.AddWithValue("@SyllabusContext", filePath);
                                command.Parameters.AddWithValue("@SyllabusType", fileType);
                            }
                            command.Parameters.AddWithValue("@SyllabusStatus", "Công khai");
                            command.ExecuteNonQuery();
                        }

                        // Nếu người dùng chọn file câu hỏi mới thì xóa hết câu hỏi cũ và thay bằng câu hỏi mới
                        if (!string.IsNullOrWhiteSpace(txtFileCauHoi.Text) && File.Exists(ofdCauHoi.FileName))
                        {
                            // Đọc file excel câu hỏi
                            List<Question> excelQuestions = DocFileExcel(ofdCauHoi.FileName);

                            // Xóa câu hỏi cũ của syllabus
                            string deleteQuestions = "DELETE FROM QUESTION WHERE SyllabusId = @SyllabusId";
                            using (SqlCommand delCmd = new SqlCommand(deleteQuestions, connection))
                            {
                                delCmd.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                                delCmd.ExecuteNonQuery();
                            }

                            // Thêm câu hỏi mới
                            if (excelQuestions != null && excelQuestions.Count > 0)
                            {
                                string insertQuestion = "INSERT INTO QUESTION (Contentt, Answer, AnswerExplanation, SyllabusId) " +
                                                        "VALUES (@Contentt, @Answer, @AnswerExplanation, @SyllabusId)";
                                using (SqlCommand qCmd = new SqlCommand(insertQuestion, connection))
                                {
                                    qCmd.Parameters.Add("@Contentt", SqlDbType.NVarChar);
                                    qCmd.Parameters.Add("@Answer", SqlDbType.NVarChar);
                                    qCmd.Parameters.Add("@AnswerExplanation", SqlDbType.NVarChar);
                                    qCmd.Parameters.Add("@SyllabusId", SqlDbType.Int);

                                    foreach (Question q in excelQuestions)
                                    {
                                        qCmd.Parameters["@Contentt"].Value = (object)q.Context ?? DBNull.Value;
                                        qCmd.Parameters["@Answer"].Value = (object)q.Answer ?? DBNull.Value;
                                        qCmd.Parameters["@AnswerExplanation"].Value = (object)q.Explain ?? DBNull.Value;
                                        qCmd.Parameters["@SyllabusId"].Value = BTL___Nhóm_1.DAL.Syllabus.Id;
                                        qCmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }

                    MessageBox.Show("Sửa đề cương thành công!");
                    BTL___Nhóm_1.DAL.Syllabus.Name = txtTenDeCuong.Text;
                    BTL___Nhóm_1.DAL.Syllabus.Author = txtTacGia.Text;
                    BTL___Nhóm_1.DAL.Syllabus.Date = dtpXuatBan.Value;
                    BTL___Nhóm_1.DAL.Syllabus.SubjectName = cmbMonHoc.SelectedItem.ToString();
                    if (txtFile.Text != Path.GetFileName(BTL___Nhóm_1.DAL.Syllabus.Context))
                    {
                        BTL___Nhóm_1.DAL.Syllabus.Context = filePath;
                    }
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

        private List<Question> DocFileExcel(string excelPath)
        {
            List<Question> danhSachCauHoi = new List<Question>();
            FileInfo fileInfo = new FileInfo(excelPath);
            if (!fileInfo.Exists) return danhSachCauHoi;

            ExcelPackage.License.SetNonCommercialPersonal("Nhom 1");
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 1; row < rowCount; row += 2)
                {
                    Question cauHoi = new Question();
                    cauHoi.Context = worksheet.Cells[row, 1].Text;
                    string checkCotB = worksheet.Cells[row + 1, 2].Text;

                    if (string.IsNullOrEmpty(checkCotB))
                    {
                        // Tự luận: lưu đáp án vào Explain
                        cauHoi.Explain = worksheet.Cells[row + 1, 1].Text;
                    }
                    else
                    {
                        List<string> tempDapAnDung = new List<string>();
                        List<string> tempDapAn = new List<string>();
                        for (int col = 1; col <= 10; col++)
                        {
                            var cell = worksheet.Cells[row + 1, col];
                            string textDapAn = cell.Text;
                            if (string.IsNullOrEmpty(textDapAn)) break;

                            tempDapAn.Add(textDapAn);

                            bool isBold = cell.Style.Font.Bold;
                            string colorRgb = cell.Style.Font.Color.Rgb;
                            bool isRed = !string.IsNullOrEmpty(colorRgb) && (colorRgb.Contains("FF0000") || colorRgb.Contains("Red"));

                            if (isBold || isRed)
                            {
                                tempDapAnDung.Add(textDapAn);
                            }
                        }
                        cauHoi.Answer = string.Join("!", tempDapAn);           // tất cả lựa chọn
                        cauHoi.Explain = string.Join("!", tempDapAnDung);      // đáp án đúng
                    }

                    danhSachCauHoi.Add(cauHoi);
                }
            }
            return danhSachCauHoi;
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
        // Chọn tệp câu hỏi
        private void btnFileCauHoi_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            ofdCauHoi.Filter = "Cau Hoi (EXCEL)|*.xls;*.xlsx";
            if (ofdCauHoi.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtFileCauHoi.Text = Path.GetFileName(ofdCauHoi.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
