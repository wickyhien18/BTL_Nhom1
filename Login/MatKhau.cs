using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1
{
    public partial class fmMatKhau : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\BTL - Nhóm 1\BTL - Nhóm 1\DeCuong.mdf"";Integrated Security=True");
        String user;
        public fmMatKhau(String username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            user = username;
            btnOpen.BringToFront();
            btnOpenXN.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '\0' && txtXN.PasswordChar == '\0')
            {
                btnOpen.BringToFront();
                btnOpenXN.BringToFront();
                txtMatKhau.PasswordChar = '*';
                txtXN.PasswordChar = '*';
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.PasswordChar == '*' && txtXN.PasswordChar == '*')
            {
                btnClose.BringToFront();
                btnCloseXN.BringToFront();
                txtMatKhau.PasswordChar = '\0';
                txtXN.PasswordChar = '\0';
            }
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            String password, xnpassword;
            password = txtMatKhau.Text;
            xnpassword = txtXN.Text;
            try
            {
                if (!String.IsNullOrEmpty(password) && password == xnpassword)
                {
                    String updateQuery = "UPDATE Users SET UserPassword = '" + password + "' WHERE UserName = '" + user + "'";
                    SqlCommand cmd = new SqlCommand(updateQuery, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fmLogin login = new fmLogin();
                    login.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Mật khẩu không khớp hoặc để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtXN.Clear();
                    txtMatKhau.Focus();
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

        private void fmMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_')
            {
                e.Handled = true;
            }
        }
    }
}
