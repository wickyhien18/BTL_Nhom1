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
    public partial class fmQuen : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\BTL - Nhóm 1\BTL - Nhóm 1\DeCuong.mdf"";Integrated Security=True");
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
            try
            {
                String query = "SELECT * FROM Users WHERE UserName = '" + username + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
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
            catch
            {
                MessageBox.Show("Lỗi");
            }
            finally
            {
                conn.Close();
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
    }
}
