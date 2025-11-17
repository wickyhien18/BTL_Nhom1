using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1
{
    public partial class fmLogin : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\BTL - Nhóm 1\BTL - Nhóm 1\DeCuong.mdf"";Integrated Security=True");
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

            try
            {
                String query = "SELECT * FROM Users WHERE UserName = '"+username+"' and UserPassword = '"+password+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTen.Clear();
                    txtMatKhau.Clear();
                    txtTen.Focus();
                }

                else if (dt.Rows.Count > 0)
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["UserID"]),
                        TenDN = dt.Rows[0]["UserName"].ToString(),
                        MatKhau = dt.Rows[0]["UserPassword"].ToString(),
                        VaiTro = dt.Rows[0]["UserRole"].ToString()
                    };
                    fmMain main = new fmMain(user);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai","Lỗi đăng nhập",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtTen.Clear();
                    txtMatKhau.Clear();
                    txtTen.Focus();
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
    }
}
