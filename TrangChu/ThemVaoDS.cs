using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class ThemVaoDS : Form
    {
        // Biến lưu trữ dữ liệu tệp
        string fileData = null;
        string fileType = null;
        string filePath = null;

        // New: allow caller to specify default status and whether to also save to PersonalStorage
        private readonly string _defaultStatus;
        private readonly bool _saveToPersonal;

        // Publicly visible created syllabus id (null if none)
        public int? CreatedSyllabusId { get; private set; }

        public ThemVaoDS() : this("Công khai", false)
        {
        }

        public ThemVaoDS(string defaultStatus, bool saveToPersonal = false)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _defaultStatus = defaultStatus ?? "Công khai";
            _saveToPersonal = saveToPersonal;
        }

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
                    txtFile.Text = ofdDeCuong.FileName;

                    //Đường dẫn lưu tệp ./bin/Debug/KhoDeCuong
                    string folderDeCuong = Path.Combine(Application.StartupPath, "KhoDeCuong");

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
            else
            {
                fileData = null;
                fileType = null;
            }
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
                // copy file first
                File.Copy(ofdDeCuong.FileName, filePath);

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
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

                    //Thêm đề cương vào cơ sở dữ liệu and get inserted id
                    string insert = "INSERT INTO Syllabus (SyllabusName, Author, PostedDate, SubjectId, SyllabusContext, SyllabusType, SyllabusStatus) " +
                                    "OUTPUT INSERTED.SyllabusId " +
                                    "VALUES (@SyllabusName, @Author, @PostedDate, @SubjectId, @SyllabusContext, @SyllabusType, @SyllabusStatus)";
                    int insertedId;
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        command.Parameters.AddWithValue("@SyllabusName", txtTenDeCuong.Text.Trim());
                        command.Parameters.AddWithValue("@Author", txtTacGia.Text.Trim());
                        command.Parameters.AddWithValue("@PostedDate", dtpXuatBan.Value);
                        command.Parameters.AddWithValue("@SubjectId", subjectId);
                        command.Parameters.AddWithValue("@SyllabusContext", filePath);
                        command.Parameters.AddWithValue("@SyllabusType", fileType);
                        command.Parameters.AddWithValue("@SyllabusStatus", _defaultStatus);
                        object scalar = command.ExecuteScalar();
                        insertedId = Convert.ToInt32(scalar);
                    }

                    //add to PersonalStorage for current user
                    if (_saveToPersonal)
                    {
                        int userId = BTL___Nhóm_1.DAL.User.Id;
                        string insertPersonal = "INSERT INTO PersonalStorage (UserId, SyllabusId, SavedDate) VALUES (@userId, @syllabusId, GETDATE())";
                        using (SqlCommand cmd = new SqlCommand(insertPersonal, connection))
                        {
                            cmd.Parameters.AddWithValue("@userId", userId);
                            cmd.Parameters.AddWithValue("@syllabusId", insertedId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // set created id for caller
                    CreatedSyllabusId = insertedId;
                }

                MessageBox.Show("Thêm đề cương thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
        // Load danh sách môn học vào combobox
        private void ThemVaoDS_Load(object sender, EventArgs e)
        {
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
        // Mở form thêm môn học
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
        private void btnFileCauHoi_Click(object sender, EventArgs e)
        {
            if (ofdCauHoi.ShowDialog() == DialogResult.OK)
            {
                txtFileCauHoi.Text = ofdCauHoi.FileName;
            }
        }
    }
}
