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
            String username, password;
            username = txtTen.Text;
            password = txtMatKhau.Text;
            try
            {
                String query = "SELECT * FROM Users WHERE UserName = '" + username + "' and UserPassword = '" + password + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tài khoản đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTen.Clear();
                    txtMatKhau.Clear();
                    txtTen.Focus();
                }
                else
                {
                    String insertQuery = "INSERT INTO Users (UserName, UserPassword) VALUES ('" + username + "', '" + password + "')";
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

        private void fmDangKy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
