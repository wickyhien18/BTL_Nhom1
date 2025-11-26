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
            try
            {
                if (this.txtTim != null)
                {
                    this.txtTim.Enter -= txtTim_Enter;
                    this.txtTim.Leave -= txtTim_Leave;
                    this.txtTim.Enter += txtTim_Enter;
                    this.txtTim.Leave += txtTim_Leave;
                }
            }
            catch
            {
            }
            this.StartPosition = FormStartPosition.CenterParent;
        }
        private void ThongTinLop_Load(object sender, EventArgs e)
        {
            LoadSyllabus();
            LoadSubjects();
            UpdateButtonsByRole();
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
                string query = @"SELECT s.SyllabusId, s.SyllabusName, s.Author, s.PostedDate, s.SyllabusType, s.SyllabusStatus, sub.SubjectName, s.SyllabusContext
                                 FROM Syllabus s JOIN Class_Syllabus cs ON s.SyllabusId = cs.SyllabusId JOIN Subject sub ON s.SubjectId = sub.SubjectId
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

        private void LoadSubjects()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
                {
                    connection.Open();
                    string selectSubjectId = "SELECT SubjectName FROM Subject";
                    using (SqlCommand command = new SqlCommand(selectSubjectId, connection))
                    {
                        cmbMonHoc.Items.Clear();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cmbMonHoc.Items.Add(reader["SubjectName"].ToString());
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
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
                        LoadSubjects();
                    }));
                }
                else
                {
                    LoadSyllabus();
                    LoadSubjects();
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

        private void UpdateButtonsByRole()
        {
            string role = BTL___Nhóm_1.DAL.User.VaiTro;
            if (role == "Sinh viên")
            {
                btnThemSV.Enabled = false;
            }
            else
            {
                btnThemSV.Enabled = true;
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            BTL___Nhóm_1.DAL.Syllabus.Id = Convert.ToInt32(row.Cells["SyllabusId"].Value);
            BTL___Nhóm_1.DAL.Syllabus.Name = row.Cells["SyllabusName"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Author = row.Cells["Author"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Date = Convert.ToDateTime(row.Cells["PostedDate"].Value);
            BTL___Nhóm_1.DAL.Syllabus.SubjectName = row.Cells["SubjectName"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Context = row.Cells["SyllabusContext"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Type = row.Cells["SyllabusType"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Status = row.Cells["SyllabusStatus"].Value.ToString();

            ThongTinDeCuong thongTinForm = new ThongTinDeCuong();
            thongTinForm.ShowDialog();
            ThongTinLop_Load(sender, e);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            DanhSachSinhVien danhSachSinhVienform = new DanhSachSinhVien(classId);
            danhSachSinhVienform.ShowDialog();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                string selectBase = "SELECT SyllabusId, SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType, SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                var conditions = new List<string>();

                // always filter to public
                conditions.Add("SyllabusStatus = @status");

                if (!string.IsNullOrEmpty(txtTim.Text.Trim()) && txtTim.Text != "Tìm kiếm tên đề cương...")
                {
                    conditions.Add("SyllabusName LIKE @search");
                }

                if (cmbMonHoc != null && cmbMonHoc.SelectedItem != null && cmbMonHoc.SelectedItem.ToString() != "Tất cả")
                {
                    conditions.Add("Subject.SubjectName = @subject");
                }

                string finalSelect = selectBase;
                if (conditions.Count > 0)
                {
                    finalSelect += " WHERE " + string.Join(" AND ", conditions);
                }

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(finalSelect, connection))
                    {
                        command.Parameters.AddWithValue("@status", "Công khai");
                        if (conditions.Contains("SyllabusName LIKE @search"))
                        {
                            command.Parameters.AddWithValue("@search", "%" + txtTim.Text.Trim() + "%");
                        }
                        if (conditions.Contains("Subject.SubjectName = @subject"))
                        {
                            command.Parameters.AddWithValue("@subject", cmbMonHoc.SelectedItem.ToString());
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgv.DataSource = dataTable;
                        }
                    }
                }

                this.BeginInvoke(new Action(() => UpdateButtonsByRole()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
