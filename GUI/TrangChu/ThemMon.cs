using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class ThemMon : Form
    {
        public ThemMon()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        // Chỉ cho phép nhập chữ, số, khoảng trắng và dấu gạch dưới
        private void txtMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }
        // Thêm môn học vào cơ sở dữ liệu
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string insert = "INSERT INTO Subject (SubjectName) VALUES (@SubjectName)";
                    using (SqlCommand command = new SqlCommand(insert,connection))
                    {
                        command.Parameters.AddWithValue("@SubjectName",txtMon.Text);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm môn học thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
