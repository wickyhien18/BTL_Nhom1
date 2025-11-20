using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1
{
    public partial class fmMain : Form
    {
        User user = new User();
        public fmMain(User user)
        {
            InitializeComponent();
            this.user = user;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void pcbAvatar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                fmLogin login = new fmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            trangChu1.BringToFront();
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            lopHoc1.BringToFront();
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            caNhan1.BringToFront();
        }
    }
}
