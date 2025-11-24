using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class CauHoiTuLuyen : Form
    {
        public CauHoiTuLuyen()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSanSang_Click(object sender, EventArgs e)
        {
            this.Hide();
            CauHoi cauHoi = new CauHoi();
            cauHoi.ShowDialog();
            this.Show();
        }

        private void CauHoiTuLuyen_Load(object sender, EventArgs e)
        {
            // Ẩn nút chỉnh sửa nếu vai trò là Sinh viên
            if (BTL___Nhóm_1.DAL.User.VaiTro == "Sinh viên")
            {
                btnUpload.Visible = false;
                btnUpload.Enabled = false;
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            ofdCauHoi.Filter = "Cau Hoi (EXCEL)|*.xls;*.xlsx";
            if (ofdCauHoi.ShowDialog() == DialogResult.OK)
            {
                //Cho code vào đây LONG
            }
        }
    }
}
