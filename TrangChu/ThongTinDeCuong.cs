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
using System.IO;

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

        private void btnTaiXuong_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txtFile.Text))
            {
                MessageBox.Show("Tệp không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            sfdDeCuong.FileName = Path.GetFileName(txtFile.Text);
            sfdDeCuong.Filter = "De Cuong(WORD,PDF,EXCEL)|*.pdf;*.docx;*.xls;*.xlsx";
            sfdDeCuong.OverwritePrompt = false;
            if (sfdDeCuong.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string destinationPath = sfdDeCuong.FileName;
                    destinationPath = GetUniqueFileName(destinationPath);
                    File.Copy(txtFile.Text, destinationPath, true);
                    if (MessageBox.Show("Tải xuống thành công! Bạn có muốn mở tệp không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(destinationPath);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private string GetUniqueFileName(string originalFileName)
        {
            if (!File.Exists(originalFileName)) return originalFileName;
            string folder = Path.GetDirectoryName(originalFileName);
            string fileName = Path.GetFileNameWithoutExtension(originalFileName);
            string ext = Path.GetExtension(originalFileName);
            int count = 1;
            string newPath = originalFileName;

            while (File.Exists(originalFileName)) 
            { 
                newPath = Path.Combine(folder, $"{fileName}({count++}){ext}");
            }
            return newPath;
        }

        private void btnTuLuyen_Click(object sender, EventArgs e)
        {
            this.Hide();
            CauHoiTuLuyen cauHoiTuLuyen = new CauHoiTuLuyen();
            cauHoiTuLuyen.ShowDialog();
            this.Show();
        }
    }
}
