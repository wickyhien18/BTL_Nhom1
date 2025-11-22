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
    public partial class CauHoi : Form
    {
        List<Question> ds = new List<Question>();
        int index = 0;
        public CauHoi()
        {
            InitializeComponent();
            btnNop.BringToFront();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void CauHoi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát bài tự luyện", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Hide();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void CauHoi_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string select = "SELECT Contentt, Answer, AnswerExplanation " +
                        "FROM QUESTION WHERE SyllabusId = @SyllabusId";
                    using (SqlCommand command = new SqlCommand(select,connection))
                    {
                        command.Parameters.AddWithValue("@SyllabusId",BTL___Nhóm_1.DAL.Syllabus.Id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) 
                            {
                                ds.Add(new Question
                                {
                                    Context = reader["Contentt"].ToString(),
                                    Answer = reader["Answer"].ToString(),
                                    Explain = reader["AnswerExplanation"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message);
            }
            HienThiCauHoi();
        }
        private void HienThiCauHoi()
        {
            if (index >= ds.Count())
            {
                MessageBox.Show("Bạn đã hoàn thành bài tự luyện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                return;
            }
            lblCauHoi.Text = "Câu hỏi: " + ds[index].Context;
            lblDapAn.Visible = false;
            lblDapAn.Enabled = false;
            txtGiaiThichDapAn.Visible = false;
            txtGiaiThichDapAn.Enabled = false;
        }

        private void btnNop_Click(object sender, EventArgs e)
        {
            txtDienDapAn.Enabled = false;
            txtDienDapAn.ReadOnly = true;
            lblDapAn.Visible = true;
            lblDapAn.Enabled = true;
            txtGiaiThichDapAn.Visible = true;
            txtGiaiThichDapAn.Enabled = true;
            lblDapAn.Text = "Đáp án đúng: ";
            if (txtDienDapAn.Text.Trim().Equals(ds[index].Answer.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                lblDapAn.ForeColor = Color.Green;
                lblDapAn.Text += ds[index].Answer;
            }
            else
            {
                lblDapAn.ForeColor = Color.Red;
                lblDapAn.Text += ds[index].Answer;
            }
            txtGiaiThichDapAn.Text = ds[index].Explain;
            btnTiep.BringToFront();
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            index++;
            HienThiCauHoi();
            btnNop.BringToFront();
        }
    }
}
