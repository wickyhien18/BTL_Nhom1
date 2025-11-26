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
            this.BeginInvoke(new Action(() => SetButtonInRole()));
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
        private void SetButtonInRole()
        {
            string Role = BTL___Nhóm_1.DAL.User.VaiTro;
            if (Role == "Sinh viên")
            {
                btnThemSV.Visible = false;
                btnThemDeCuong.Visible = false;
                btnDS.Visible = false;
            }
            else
            {
                btnThemSV.Visible = true;
                btnThemDeCuong.Visible = true;
                btnDS.Visible = true;
            }
        }
        private void LoadSyllabus()
        {
            try
            {
                string query = @"SELECT s.SyllabusName as 'Tên đề cương', s.Author as 'Tác giả', s.PostedDate as 'Ngày xuất bản', s.SyllabusType as 'Loại đề cương', s.SyllabusStatus as 'Trạng thái'
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

        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm tên đề cương...")
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;
            }
        }

        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Tìm kiếm tên đề cương...";
                txtTim.ForeColor = Color.Gray;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string selectBase = @"SELECT s.SyllabusName as 'Tên đề cương', s.Author as 'Tác giả', s.PostedDate as 'Ngày xuất bản', s.SyllabusType as 'Loại đề cương', s.SyllabusStatus as 'Trạng thái'
                                 FROM Syllabus s JOIN Class_Syllabus cs ON s.SyllabusId = cs.SyllabusId
                                 WHERE cs.ClassId = @ClassId ";
            var conditions = new List<string>();
            string finalSelect = selectBase;
            if (!string.IsNullOrEmpty(txtTim.Text.Trim()) && txtTim.Text != "Tìm kiếm tên đề cương...")
            {
                conditions.Add("s.SyllabusName LIKE @search");
            }
            if (conditions.Count > 0)
            {
                finalSelect += " AND " + string.Join(" AND ", conditions);
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(finalSelect, connection))
                    {
                        command.Parameters.AddWithValue("@ClassId", classId);
                        if (conditions.Contains("s.SyllabusName LIKE @search"))
                        {
                            command.Parameters.AddWithValue("@search", "%" + txtTim.Text.Trim() + "%");
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgv.DataSource = dataTable;
                        }
                    }
                }

                this.BeginInvoke(new Action(() => SetButtonInRole()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm lớp học: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != '_' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
