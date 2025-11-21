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

        // Collapse state
        private int panel1Width;
        private bool isCollapsed = false;
        private string textTrangChu;
        private string textLopHoc;
        private string textCaNhan;

        public fmMain(User user)
        {
            InitializeComponent();
            this.user = user;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Save original state
            panel1Width = panel1.Width;
            isCollapsed = false;
            textTrangChu = btnTrangChu.Text;
            textLopHoc = btnLopHoc.Text;
            textCaNhan = btnCaNhan.Text;

            // Set username and role display on top-right
            if (!string.IsNullOrEmpty(this.user?.TenDN))
            {
                lblUsername.Text = $"{this.user.TenDN} - {this.user.VaiTro}";
            }
            else
            {
                lblUsername.Text = "Tài khoản - Vai trò";
            }

            // Ensure logout popup is hidden by default
            btnLogoutPopup.Visible = false;

            // Ensure toggle shows hamburger and stays on top-left
            btnToggle.Text = "☰";
            btnToggle.BringToFront();
        }

        private void fmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {

        }

        // Left avatar is now decorative — no click handler.

        private void pcbUserAvatar_Click(object sender, EventArgs e)
        {
            // Toggle visibility of the logout popup button
            btnLogoutPopup.Visible = !btnLogoutPopup.Visible;
        }

        private void btnLogoutPopup_Click(object sender, EventArgs e)
        {
            // Ask confirmation when user clicks the popup logout button
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fmLogin login = new fmLogin();
                login.Show();
                this.Hide();
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            // Hide logout popup when clicking on main content
            if (btnLogoutPopup.Visible)
                btnLogoutPopup.Visible = false;
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            trangChu1.BringToFront();
        }

        private void btnLopHoc_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();

            var ucLopHoc = new BTL___Nhóm_1.BUS.LopHoc(user.Id, user.VaiTro);
            panel2.Controls.Add(ucLopHoc);
            ucLopHoc.Dock = DockStyle.Fill;
        }

        private void btnCaNhan_Click(object sender, EventArgs e)
        {
            caNhan1.BringToFront();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Toggle collapse / expand by hiding/showing the left panel.
            if (!isCollapsed)
            {
                // hide the menu
                panel1.Visible = false;
                // panel2 is Dock=Fill so it will expand automatically
                isCollapsed = true;
            }
            else
            {
                // show the menu
                panel1.Visible = true;
                panel1.Width = panel1Width;
                isCollapsed = false;
            }
            // Ensure the hamburger stays on top
            btnToggle.BringToFront();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
