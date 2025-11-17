using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\BTL - Nhóm 1\BTL - Nhóm 1\DeCuong.mdf"";Integrated Security=True");
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
            if (rdbtnSinhvien.Checked)
            {
                role = "Sinh viên";
            }
            else if (rdbtnGiangvien.Checked)
            {
                role = "Giảng viên";
            }
            else
            {
                role = null;
            }
            try
                {
                    String query = "SELECT * FROM Users WHERE UserName = '" + username + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng ký", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTen.Clear();
                        txtMatKhau.Clear();
                        txtXacnhan.Clear();
                        txtTen.Focus();
                    }

                    else if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTen.Clear();
                        txtMatKhau.Clear();
                        txtXacnhan.Clear();
                        txtTen.Focus();
                    }
                    else if (password != confirm)
                    {
                        MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtMatKhau.Clear();
                        txtXacnhan.Clear();
                        txtMatKhau.Focus();
                    }
                    else
                    {
                    String insertQuery = "INSERT INTO Users (UserName, UserPassword,UserRole) VALUES ('" + username + "', '" + password + "', N'" + role + "')";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fmLogin login = new fmLogin();
                    login.Show();
                    this.Hide();
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi");
                }
                finally
                {
                    conn.Close();
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
