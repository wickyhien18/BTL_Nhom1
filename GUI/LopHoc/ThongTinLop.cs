using BTL___Nhóm_1.TrangChu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.GUI.LopHoc
{
    public partial class ThongTinLop : Form
    {
        private int classId;
        public ThongTinLop(int classId)
        {
            InitializeComponent();
            this.classId = classId;
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void ThongTinLop_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => LoadSyllabus()));
        }
        private void btnThemSV_Click(object sender, EventArgs e)
        {
            ChonSinhVien frm = new ChonSinhVien();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int userId in frm.SelectedUserIds)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                        {
                            conn.Open();

                            string check = @"SELECT COUNT(*) FROM Class_User WHERE ClassId = @ClassId AND UserId = @UserId";
                            using (SqlCommand cmd = new SqlCommand(check, conn))
                            {
                                cmd.Parameters.AddWithValue("@ClassId", classId);
                                cmd.Parameters.AddWithValue("@UserId", userId);

                                int exists = (int)cmd.ExecuteScalar();
                                if (exists > 0)
                                    continue; // bỏ qua nếu đã có
                            }

                            string insert = @"INSERT INTO Class_User (ClassId, UserId) VALUES (@ClassId, @UserId)";
                            using (SqlCommand cmd = new SqlCommand(insert, conn))
                            {
                                cmd.Parameters.AddWithValue("@ClassId", classId);
                                cmd.Parameters.AddWithValue("@UserId", userId);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sinh viên: " + ex.Message);
                    }
                }

                MessageBox.Show("Đã thêm sinh viên vào lớp!");
            }
        }
        private void LoadSyllabus()
        {
            try
            {
                string query = @"SELECT s.SyllabusId, s.SyllabusName, s.Author, s.PostedDate, s.SyllabusType, s.SyllabusStatus
                                 FROM Syllabus s JOIN Class_Syllabus cs ON s.SyllabusId = cs.SyllabusId
                                 WHERE cs.ClassId = @ClassId";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassId", classId);
                        DataTable dt = new DataTable();
                        using (SqlDataReader read = cmd.ExecuteReader())
                        {
                            dt.Load(read);
                        }
                        dgv.AutoGenerateColumns = true;
                        if (dgv.Columns.Contains("Select"))
                            dgv.Columns.Remove("Select");
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void RefreshData()
        {
            try
            {
                // Keep UI thread safe
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        LoadSyllabus();
                    }));
                }
                else
                {
                    LoadSyllabus();
                }
            }
            catch
            {

            }
        }
        private void btnThemDeCuong_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new ThemDeCuong(classId, defaultStatus: "Riêng tư", saveToPersonal: true))
                {
                    dlg.ShowDialog(this);
                    if (dlg.CreatedSyllabusId.HasValue)
                    {
                        if (this.IsHandleCreated && this.InvokeRequired) 
                            this.BeginInvoke(new Action(RefreshData)); 
                        else RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đề cương riêng tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            DanhSachSinhVien danhSachSinhVienform = new DanhSachSinhVien(classId);
            danhSachSinhVienform.ShowDialog();
        }
    }
}
