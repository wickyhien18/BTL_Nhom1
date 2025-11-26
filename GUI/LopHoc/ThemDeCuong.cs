using BTL___Nhóm_1.DAL;
using BTL___Nhóm_1.TrangChu;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.GUI.LopHoc
{
    public partial class ThemDeCuong : Form
    {
        private int classId;
        // Biến lưu trữ dữ liệu tệp
        string fileData = null;
        string fileType = null;
        string filePath = null;

        private List<Question> _excelQuestions;
        // New: allow caller to specify default status and whether to also save to PersonalStorage
        private readonly string _defaultStatus;
        private readonly bool _saveToPersonal;

        // Publicly visible created syllabus id (null if none)
        public int? CreatedSyllabusId { get; private set; }
        public ThemDeCuong(int classId, string defaultStatus, bool saveToPersonal) : this(defaultStatus, saveToPersonal) 
        {
            this.classId = classId; 
        }

        public ThemDeCuong(string defaultStatus, bool saveToPersonal)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _defaultStatus = defaultStatus;
            _saveToPersonal = saveToPersonal;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDeCuong.Text) ||
                string.IsNullOrWhiteSpace(txtTacGia.Text) ||
                fileData == null || cmbMonHoc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn tệp đính kèm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                File.Copy(ofdDeCuong.FileName, filePath);
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
                    //Thêm đề cương vào cơ sở dữ liệu
                    int newSyllabusId;
                    string insert = "INSERT INTO Syllabus (SyllabusName, Author, PostedDate, SubjectId, SyllabusContext, SyllabusType, SyllabusStatus) " +
                                    "OUTPUT Inserted.SyllabusId " +
                                    "VALUES (@SyllabusName, @Author, @PostedDate, @SubjectId, @SyllabusContext, @SyllabusType, @SyllabusStatus)";
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        command.Parameters.AddWithValue("@SyllabusName", txtTenDeCuong.Text.Trim());
                        command.Parameters.AddWithValue("@Author", txtTacGia.Text.Trim());
                        command.Parameters.AddWithValue("@PostedDate", dtpXuatBan.Text);
                        command.Parameters.AddWithValue("@SubjectId", subjectId);
                        command.Parameters.AddWithValue("@SyllabusContext", filePath);
                        command.Parameters.AddWithValue("@SyllabusType", fileType);
                        command.Parameters.AddWithValue("@SyllabusStatus", _defaultStatus);
                        newSyllabusId = Convert.ToInt32(command.ExecuteScalar());
                    }

                    string insertClass = @"INSERT INTO Class_Syllabus (ClassId, SyllabusId) VALUES (@ClassId, @SyllId)";
                    using (SqlCommand cmd = new SqlCommand(insertClass, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        cmd.Parameters.AddWithValue("@SyllId", newSyllabusId);
                        cmd.ExecuteNonQuery();
                    }

                    if (_excelQuestions != null && _excelQuestions.Count > 0)
                    {
                        string insertQuestion = "INSERT INTO QUESTION (Contentt, Answer, AnswerExplanation, SyllabusId) " +
                                                "VALUES (@Contentt, @Answer, @AnswerExplanation, @SyllabusId)";
                        using (SqlCommand qCmd = new SqlCommand(insertQuestion, connection))
                        {
                            qCmd.Parameters.Add("@Contentt", System.Data.SqlDbType.NVarChar);
                            qCmd.Parameters.Add("@Answer", System.Data.SqlDbType.NVarChar);
                            qCmd.Parameters.Add("@AnswerExplanation", System.Data.SqlDbType.NVarChar);
                            qCmd.Parameters.Add("@SyllabusId", System.Data.SqlDbType.Int);

                            foreach (var q in _excelQuestions)
                            {
                                qCmd.Parameters["@Contentt"].Value = (object)q.Context ?? DBNull.Value;
                                qCmd.Parameters["@Answer"].Value = (object)q.Answer ?? DBNull.Value;
                                qCmd.Parameters["@AnswerExplanation"].Value = (object)q.Explain ?? DBNull.Value;
                                qCmd.Parameters["@SyllabusId"].Value = newSyllabusId;
                                qCmd.ExecuteNonQuery();
                            }
                        }
                    }

                   
                        int userId = BTL___Nhóm_1.DAL.User.Id;
                        string insertPersonal = "INSERT INTO PersonalStorage (UserId, SyllabusId, SavedDate) VALUES (@userId, @syllabusId, GETDATE())";
                        using (SqlCommand cmd = new SqlCommand(insertPersonal, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@syllabusId", newSyllabusId);
                            cmd.ExecuteNonQuery();
                        }
                    

                    // set created id for caller
                    CreatedSyllabusId = newSyllabusId;
                }
                MessageBox.Show("Thêm đề cương thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại chọn tệp
            ofdDeCuong.Filter = "De Cuong(WORD,EXCEL)|*.doc;*.docx;*.xls;*.xlsx";
            if (ofdDeCuong.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileData = Path.GetFileName(ofdDeCuong.FileName);
                    fileType = Path.GetExtension(ofdDeCuong.FileName).ToLower();
                    txtFile.Text = Path.GetFileName(ofdDeCuong.FileName);
                    //Lưu file vào đường dẫn ./ Project_Name / KhoDeCuong
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


                    if (!Directory.Exists(folderDeCuong))
                    {
                        Directory.CreateDirectory(folderDeCuong);
                    }

                    string newFile = fileData + "_" + DateTime.Now.Ticks.ToString();
                    filePath = Path.Combine(folderDeCuong, newFile + fileType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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

        private void ThemDeCuong_Load(object sender, EventArgs e)
        {
            //Load danh sách môn học vào combobox
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

        private void txtTenDeCuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtTacGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }

        private void btnFileCauHoi_Click(object sender, EventArgs e)
        {
            string note = "Chức năng này yêu cầu file câu hỏi định dạng EXCEL có cấu trúc như sau:\n\n" +
                          "Dòng đầu: Nội dung câu hỏi\n" +
                          "Dòng thứ hai: Nếu là câu hỏi trắc nghiệm thì tương ứng cột A là nội dung đáp án A, cột B là nội dung đáp án B, đáp án của câu hỏi đó in đậm hoặc bôi đỏ. " +
                          "Còn nếu là câu hỏi tự luận, trả lời ngắn thì dòng thứ 2 ở cột A sẽ là nội dung đáp án\n\n" +
                          "Hệ thống sẽ chỉ check đúng sai câu hỏi trắc nhiệm, không check đúng sai câu trả lời ngắn hay tự luận, không hỗ trợ kí hiệu phức tạp\n\n" +
                          "Vui lòng đảm bảo rằng file EXCEL của bạn tuân thủ đúng cấu trúc này để tránh lỗi khi nhập dữ liệu.";
            if (MessageBox.Show(note, "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Mở hộp thoại chọn tệp
                ofdCauHoi.Filter = "Cau Hoi (EXCEL)|*.xls;*.xlsx";
                if (ofdCauHoi.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        txtFileCauHoi.Text = Path.GetFileName(ofdCauHoi.FileName);
                        _excelQuestions = DocFileExcel(ofdCauHoi.FileName);
                        MessageBox.Show("Đã đọc " + _excelQuestions.Count + " câu hỏi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không đọc được file câu hỏi do + " + ex);
                        this.Hide();
                    }
                }
            }
        }
        public List<Question> DocFileExcel(string filePath)
        {
            var danhSachCauHoi = new List<Question>();

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) return danhSachCauHoi;

            ExcelPackage.License.SetNonCommercialPersonal("Nhom 1");

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;

                for (int row = 1; row < rowCount; row += 2)
                {
                    var cauHoi = new Question();
                    cauHoi.Context = worksheet.Cells[row, 1].Text;

                    var checkCotB = worksheet.Cells[row + 1, 2].Text;

                    if (string.IsNullOrEmpty(checkCotB))
                    {
                        // --- TỰ LUẬN ---
                        cauHoi.Explain = worksheet.Cells[row + 1, 1].Text;
                    }
                    else
                    {
                        // --- TRẮC NGHIỆM ---

                        List<string> tempDapAnDung = new List<string>();
                        List<string> tempDapAn = new List<string>();

                        for (int col = 1; col <= 6; col++)
                        {
                            var cell = worksheet.Cells[row + 1, col];
                            string textDapAn = cell.Text.Trim();
                            if (string.IsNullOrEmpty(textDapAn)) break;

                            tempDapAn.Add(textDapAn);

                            // Kiểm tra in đậm hoặc đỏ
                            bool isBold = cell.Style.Font.Bold;
                            var colorRgb = cell.Style.Font.Color.Rgb;
                            bool isRed = !string.IsNullOrEmpty(colorRgb) && (colorRgb.Contains("FF0000") || colorRgb.Contains("Red"));

                            if (isBold || isRed)
                            {
                                if (textDapAn.ToUpper().StartsWith("A") ||
                                    textDapAn.ToUpper().StartsWith("B") ||
                                    textDapAn.ToUpper().StartsWith("C") ||
                                    textDapAn.ToUpper().StartsWith("D") ||
                                    textDapAn.ToUpper().StartsWith("E") ||
                                    textDapAn.ToUpper().StartsWith("F"))
                                {
                                    tempDapAnDung.Add(textDapAn[0].ToString());
                                }
                            }
                        }

                        //Nối các đáp án đúng bằng dấu chấm than "!"
                        cauHoi.Answer = string.Join("!", tempDapAn);
                        cauHoi.Explain = string.Join("!", tempDapAnDung);
                    }

                    danhSachCauHoi.Add(cauHoi);
                }
            }
            return danhSachCauHoi;
        }
    }
}
