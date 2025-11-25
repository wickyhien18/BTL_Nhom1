using BTL___Nhóm_1.DAL;
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

namespace BTL___Nhóm_1.TrangChu
{
    public partial class CauHoiTuLuyen : Form
    {
        List<Question> questions = new List<Question>();
        public CauHoiTuLuyen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string sql = "SELECT Contentt, Answer, AnswerExplanation FROM QUESTION WHERE SyllabusId = @SyllabusId";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@SyllabusId", BTL___Nhóm_1.DAL.Syllabus.Id);
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                questions.Add(new Question
                                {
                                    Context = r["Contentt"].ToString(),
                                    Answer = r["Answer"].ToString(),
                                    Explain = r["AnswerExplanation"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSanSang_Click(object sender, EventArgs e)
        {
            this.Hide();
            CauHoi cauHoi = new CauHoi(questions);
            cauHoi.ShowDialog();
            this.Show();
        }

        private void CauHoiTuLuyen_Load(object sender, EventArgs e)
        {
            // Ẩn nút chỉnh sửa nếu vai trò là Sinh viên
            if (BTL___Nhóm_1.DAL.User.VaiTro == "Sinh viên")
            {
                btnUpload.Visible = false;
                btnUpload.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Xuất danh sách câu hỏi ra Excel"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            ExcelPackage.License.SetNonCommercialPersonal("Nhom 1");
            using (var package = new ExcelPackage())
            {
                var ws = package.Workbook.Worksheets.Add("CauHoi");

                int row = 1;
                foreach (var q in questions)
                {
                    // Dòng 1: Nội dung câu hỏi
                    ws.Cells[row, 1].Value = q.Context;

                    // Dòng 2: Đáp án
                    var answers = !string.IsNullOrEmpty(q.Answer) ? q.Answer.Split('!') : new string[0];
                    var corrects = !string.IsNullOrEmpty(q.Explain) ? q.Explain.Split('!') : new string[0];

                    if (answers.Length == 0)
                    {
                        // Tự luận: đáp án ở cột A dòng 2
                        ws.Cells[row + 1, 1].Value = q.Explain;
                    }
                    else
                    {
                        for (int i = 0; i < answers.Length && i < 6; i++)
                        {
                            ws.Cells[row + 1, i + 1].Value = answers[i];
                            // Nếu là đáp án đúng, in đậm và tô đỏ
                            if (corrects.Contains(((char)('A' + i)).ToString()))
                            {
                                ws.Cells[row + 1, i + 1].Style.Font.Bold = true;
                                ws.Cells[row + 1, i + 1].Style.Font.Color.SetColor(Color.Red);
                            }
                        }
                    }
                    row += 2;
                }

                ws.Cells.AutoFitColumns();
                File.WriteAllBytes(sfd.FileName, package.GetAsByteArray());
                MessageBox.Show("Tải file câu hỏi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
