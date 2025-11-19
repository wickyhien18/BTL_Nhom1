using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1
{
    public partial class fmDangKy : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-WICKY\SQLEXPRESS01;Initial Catalog=DeCuong;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public fmDangKy()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void fmDangKy_Load(object sender, EventArgs e)
        {
            btnOpen.BringToFront();
            btnXNOpen.BringToFront();
            linkDangNhap.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void linkDangKy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fmLogin login = new fmLogin();
            login.Show();
            this.Hide();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            String username, password, role, confirm;
            username = txtTen.Text;
            password = txtMatKhau.Text;
            confirm = txtXacnhan.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return; 
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtXacnhan.Focus();
                return;
            }

            if (rdbtnSinhvien.Checked) role = "Sinh viên";
            else if (rdbtnGiangvien.Checked) role = "Giảng viên";
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò (Sinh viên/Giảng viên)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                connection.Open();

                    string checkSql = "SELECT COUNT(*) FROM Users WHERE UserName = @user";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@user", username);
                        int exist = (int)checkCmd.ExecuteScalar(); 

                        if (exist > 0)
                        {
                            MessageBox.Show("Tài khoản này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTen.Focus();
                            return;
                        }
                    }

                   
                    string insertSql = "INSERT INTO Users (UserName, UserPassword, UserRole) VALUES (@user, @pass, @role)";
                    using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
                    {
                        
                        insertCmd.Parameters.AddWithValue("@user", username);
                        insertCmd.Parameters.AddWithValue("@pass", password); 
                        insertCmd.Parameters.AddWithValue("@role", role);

                        insertCmd.ExecuteNonQuery(); 
                    }

                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Chuyển form
                    fmLogin login = new fmLogin();
                    login.Show();
                    this.Hide(); 
                
            }
            catch (Exception ex) 
                {
                    MessageBox.Show("Lỗi" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*')
            {
                btnClose.BringToFront();
                btnXNClose.BringToFront();
                txtMatKhau.PasswordChar = '\0';
                txtXacnhan.PasswordChar = '\0';
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0')
            {
                btnOpen.BringToFront();
                btnXNOpen.BringToFront();
                txtMatKhau.PasswordChar = '*';
                txtXacnhan.PasswordChar = '*';
            }
        }

        private void fmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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
