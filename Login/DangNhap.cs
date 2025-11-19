using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Globalization;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1
{
    public partial class fmLogin : Form
    {
        
        public fmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview =  true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkQuenMK.LinkBehavior = LinkBehavior.NeverUnderline;
            linkDangKy.LinkBehavior = LinkBehavior.NeverUnderline;
            btnOpen.BringToFront();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                btnClose.BringToFront();
                txtMatKhau.PasswordChar = '\0';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                btnOpen.BringToFront();
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String username, password;

            username = txtTen.Text;
            password = txtMatKhau.Text;

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Clear();
                txtMatKhau.Clear();
                txtTen.Focus();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-WICKY\SQLEXPRESS01;Initial Catalog=DeCuong;Integrated Security=True;Encrypt=True;TrustServerCertificate=True")) {
                    connection.Open();
                    string select = "SELECT * FROM Users WHERE UserName = @username AND UserPassword = @password";
                    using (SqlCommand cmd = new SqlCommand(select, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                User user = new User
                                {
                                    Id = Convert.ToInt32(reader["UserId"]),
                                    TenDN = reader["UserName"].ToString(),
                                    MatKhau = reader["UserPassword"].ToString(),
                                    VaiTro = reader["UserRole"].ToString()
                                };
                                fmMain main = new fmMain(user);
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtTen.Clear();
                                txtMatKhau.Clear();
                                txtTen.Focus();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmQuen quen = new fmQuen();
            quen.Show();
            this.Hide();
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmDangKy dangKy = new fmDangKy();
            dangKy.Show();
            this.Hide();
        }

        private void fmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && (e.KeyChar != '_'))
            {
                e.Handled = true;
            }
        }

        private void fmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}
