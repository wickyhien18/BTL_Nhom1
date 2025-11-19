using BTL___Nhóm_1.DAL;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1
{
    public partial class fmQuen : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-WICKY\SQLEXPRESS01;Initial Catalog=DeCuong;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public fmQuen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            linkDangNhap.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            String username;
            username = txtTen.Text;
            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Clear();
                txtTen.Focus();
                return;
            }

            try
            {
                connection.Open();
                string select = "SELECT COUNT(*) FROM Users WHERE UserName = @username";
                using (SqlCommand cmd = new SqlCommand(select, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            fmMatKhau matkhau = new fmMatKhau(username);
                            matkhau.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản đăng nhập không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTen.Clear();
                            txtTen.Focus();
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                connection.Close();
            }
        }

        private void fmQuen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void linkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmLogin login = new fmLogin();
            login.Show();
            this.Hide();
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }
    }
}
