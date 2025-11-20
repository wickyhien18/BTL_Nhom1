using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using BTL___Nhóm_1.TrangChu;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1.BUS
{
    public partial class TrangChu : UserControl
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string select = "SELECT SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusType as 'Loại file đề cương'FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                    using (SqlCommand command = new SqlCommand(select, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            ThemVaoDS themVaoDSForm = new ThemVaoDS();
            themVaoDSForm.ShowDialog();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string select = "SELECT SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusType as 'Loại file đề cương'FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemVaoLopHoc_Click(object sender, EventArgs e)
        {
            
        }

        private void txtTenDeCuong_Enter(object sender, EventArgs e)
        {
            if (txtTenDeCuong.Text == "Tìm kiếm tên đề cương...")
            {
                txtTenDeCuong.Text = "";
                txtTenDeCuong.ForeColor = Color.Black;
            }
        }

        private void txtTenDeCuong_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDeCuong.Text))
            {
                txtTenDeCuong.Text = "Tìm kiếm tên đề cương...";
                txtTenDeCuong.ForeColor = Color.Gray;
            }
        }

        private void btnTimTen_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    string select = "";
                    connection.Open();
                    if (!string.IsNullOrEmpty(txtTenDeCuong.Text.Trim()) && txtTenDeCuong.Text != "Tìm kiếm tên đề cương...")  
                        select = "SELECT SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusType as 'Loại file đề cương' " +
                            "FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId WHERE SyllabusName LIKE @search";
                    else 
                        select = "SELECT SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusType as 'Loại file đề cương' " +
                            "FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        if (!string.IsNullOrEmpty(txtTenDeCuong.Text.Trim()))  
                            command.Parameters.AddWithValue("@search", "%" + txtTenDeCuong.Text.Trim() + "%");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                             DataTable dataTable = new DataTable();
                             dataTable.Load(reader);
                             dgvTrangChu.DataSource = dataTable;
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
