using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class ThongTinDeCuong : Form
    {
        public ThongTinDeCuong()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ThongTinDeCuong_Load(object sender, EventArgs e)
        {
            txtTenDeCuong.Text = BTL___Nhóm_1.DAL.Syllabus.Name;
            txtTacGia.Text = BTL___Nhóm_1.DAL.Syllabus.Author;
            txtNgayXuatBan.Text = BTL___Nhóm_1.DAL.Syllabus.Date.ToString("dd/MM/yyyy");
            txtMonHoc.Text = BTL___Nhóm_1.DAL.Syllabus.SubjectName;
            txtFile.Text = BTL___Nhóm_1.DAL.Syllabus.Context;
            txtLoaiDeCuong.Text = BTL___Nhóm_1.DAL.Syllabus.Type;
            txtTrangThai.Text = BTL___Nhóm_1.DAL.Syllabus.Status;
        }
    }
}
