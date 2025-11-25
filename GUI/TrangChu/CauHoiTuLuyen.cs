using BTL___Nhóm_1.DAL;
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

namespace BTL___Nhóm_1.TrangChu
{
    public partial class CauHoiTuLuyen : Form
    {
        public CauHoiTuLuyen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSanSang_Click(object sender, EventArgs e)
        {
            this.Hide();
            var list = new List<Question>();
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
                                list.Add(new Question
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
            CauHoi cauHoi = new CauHoi(list);
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

    }
}
