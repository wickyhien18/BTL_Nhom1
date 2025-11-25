using BTL___Nhóm_1.DAL;
using BTL___Nhóm_1.TrangChu;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL___Nhóm_1.BUS
{
    public partial class LuuTruCaNhan : UserControl
    {
        public LuuTruCaNhan()
        {
            InitializeComponent();
            this.Load += LuuTruCaNhan_Load;
            this.btnTim.Click += btnTim_Click;
            this.btnXoa.Click += btnXoa_Click;
            if (this.cmbMonHoc != null)
                this.cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;

            // wire placeholder Enter/Leave for the search textbox 
            try
            {
                if (this.txtTen != null)
                {
                    this.txtTen.Enter -= txtTen_Enter;
                    this.txtTen.Leave -= txtTen_Leave;
                    this.txtTen.Enter += txtTen_Enter;
                    this.txtTen.Leave += txtTen_Leave;
                }
            }
            catch
            {
            }

        
            try
            {
                if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime && this.Parent == null)
                {
                    var mainForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.GetType().Name == "fmMain");
                    if (mainForm != null)
                    {
                        var panel = mainForm.Controls.Find("panel2", true).FirstOrDefault();
                        if (panel != null)
                        {
                            this.Dock = DockStyle.Fill;
                            panel.Controls.Add(this);
                            this.BringToFront();
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void LuuTruCaNhan_Load(object sender, EventArgs e)
        {
            LoadMonHoc();
            LoadData();
        }

        // Placeholder Enter 
        private void txtTen_Enter(object sender, EventArgs e)
        {
            if (txtTen.Text == "Tìm kiếm tên đề cương...")
            {
                txtTen.Text = "";
                txtTen.ForeColor = Color.Black;
            }
        }

        // Placeholder Leave 
        private void txtTen_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                txtTen.Text = "Tìm kiếm tên đề cương...";
                txtTen.ForeColor = Color.Gray;
            }
        }

        private void LoadMonHoc()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string selectSubjects = "SELECT SubjectName FROM Subject";
                    using (SqlCommand cmd = new SqlCommand(selectSubjects, connection))
                    {
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            cmbMonHoc.Items.Clear();
                            cmbMonHoc.Items.Add("Tất cả");
                            while (r.Read())
                            {
                                cmbMonHoc.Items.Add(r["SubjectName"].ToString());
                            }
                        }
                    }
                    if (cmbMonHoc.Items.Count > 0) cmbMonHoc.SelectedIndex = 0;
                }
            }
            catch
            {
                // ignore
            }
        }

        private void LoadData()
        {
            try
            {
                int userId = BTL___Nhóm_1.DAL.User.Id;
                string query = @"SELECT ps.Id AS PersonalId, s.SyllabusId, s.SyllabusName as 'Tên đề cương', s.Author as 'Tác giả', s.PostedDate as 'Ngày xuất bản', subj.SubjectName as 'Tên môn học', s.SyllabusContext, s.SyllabusType as 'Loại file đề cương', s.SyllabusStatus as 'Trạng thái', ps.SavedDate as 'Ngày lưu' 
FROM PersonalStorage ps
JOIN Syllabus s ON ps.SyllabusId = s.SyllabusId
JOIN Subject subj ON s.SubjectId = subj.SubjectId
WHERE ps.UserId = @userId";

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvLuuTru.DataSource = dt;
                        }
                    }

                    if (dgvLuuTru.Columns["SyllabusId"] != null)
                        dgvLuuTru.Columns["SyllabusId"].Visible = false;
                    if (dgvLuuTru.Columns["SyllabusContext"] != null)
                        dgvLuuTru.Columns["SyllabusContext"].Visible = false;
                    if (dgvLuuTru.Columns["PersonalId"] != null)
                        dgvLuuTru.Columns["PersonalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load lưu trữ: " + ex.Message);
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
                        LoadMonHoc();
                        LoadData();
                    }));
                }
                else
                {
                    LoadMonHoc();
                    LoadData();
                }
            }
            catch
            {

            }
        }

        private void ApplyFilters()
        {
            try
            {
                int userId = BTL___Nhóm_1.DAL.User.Id;
                string selectBase = @"SELECT ps.Id AS PersonalId, s.SyllabusId, s.SyllabusName as 'Tên đề cương', s.Author as 'Tác giả', s.PostedDate as 'Ngày xuất bản', subj.SubjectName as 'Tên môn học', s.SyllabusContext, s.SyllabusType as 'Loại file đề cương', s.SyllabusStatus as 'Trạng thái', ps.SavedDate as 'Ngày lưu' 
FROM PersonalStorage ps
JOIN Syllabus s ON ps.SyllabusId = s.SyllabusId
JOIN Subject subj ON s.SubjectId = subj.SubjectId
WHERE ps.UserId = @userId";

                var conditions = new List<string>();
                if (!string.IsNullOrEmpty(txtTen.Text.Trim()) && txtTen.Text != "Tìm kiếm tên đề cương...")
                {
                    conditions.Add("s.SyllabusName LIKE @search");
                }
                if (cmbMonHoc != null && cmbMonHoc.SelectedItem != null && cmbMonHoc.SelectedItem.ToString() != "Tất cả")
                {
                    conditions.Add("subj.SubjectName = @subject");
                }

                string final = selectBase;
                if (conditions.Count > 0)
                {
                    final += " AND " + string.Join(" AND ", conditions);
                }

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(final, connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", userId);
                        if (conditions.Contains("s.SyllabusName LIKE @search"))
                            cmd.Parameters.AddWithValue("@search", "%" + txtTen.Text.Trim() + "%");
                        if (conditions.Contains("subj.SubjectName = @subject"))
                            cmd.Parameters.AddWithValue("@subject", cmbMonHoc.SelectedItem.ToString());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvLuuTru.DataSource = dt;
                        }
                    }

                    if (dgvLuuTru.Columns["SyllabusId"] != null)
                        dgvLuuTru.Columns["SyllabusId"].Visible = false;
                    if (dgvLuuTru.Columns["SyllabusContext"] != null)
                        dgvLuuTru.Columns["SyllabusContext"].Visible = false;
                    if (dgvLuuTru.Columns["PersonalId"] != null)
                        dgvLuuTru.Columns["PersonalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lọc lưu trữ: " + ex.Message);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLuuTru == null) return;
                DataGridViewRow row = null;
                if (dgvLuuTru.SelectedRows != null && dgvLuuTru.SelectedRows.Count > 0)
                    row = dgvLuuTru.SelectedRows[0];
                else if (dgvLuuTru.CurrentRow != null)
                    row = dgvLuuTru.CurrentRow;

                if (row == null)
                {
                    MessageBox.Show("Vui lòng chọn một đề cương để xóa.");
                    return;
                }

                if (row.Cells["PersonalId"].Value == null)
                {
                    MessageBox.Show("Không xác định được mục lưu trữ.");
                    return;
                }

                int personalId = Convert.ToInt32(row.Cells["PersonalId"].Value);

                var dr = MessageBox.Show("Bạn có chắc muốn xóa đề cương này khỏi Đề cương của tôi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string del = "DELETE FROM PersonalStorage WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(del, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", personalId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã xóa khỏi Đề cương của tôi.");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void cmbMonHoc_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        public void AddNewPrivateSyllabus()
        {
            try
            {
                //request private status and save to PersonalStorage
                using (var dlg = new ThemVaoDS(defaultStatus: "Riêng tư", saveToPersonal: true))
                {
                    dlg.ShowDialog(this);

                    //refresh the LuuTru table
                    if (dlg.CreatedSyllabusId.HasValue)
                    {
                        if (this.IsHandleCreated && this.InvokeRequired)
                            this.BeginInvoke(new Action(RefreshData));
                        else
                            RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đề cương riêng tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            AddNewPrivateSyllabus();
        }

        private string GetCellValue(DataGridViewRow row, string colName)
        {
            try
            {
                var cell = row.Cells[colName];
                return cell?.Value?.ToString() ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLuuTru == null) return;

                DataGridViewRow row = null;
                if (dgvLuuTru.SelectedRows != null && dgvLuuTru.SelectedRows.Count > 0)
                    row = dgvLuuTru.SelectedRows[0];
                else if (dgvLuuTru.CurrentRow != null)
                    row = dgvLuuTru.CurrentRow;

                if (row == null)
                {
                    MessageBox.Show("Vui lòng chọn một đề cương để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string status = GetCellValue(row, "SyllabusStatus");
                if (string.IsNullOrWhiteSpace(status))
                    status = GetCellValue(row, "Trạng thái");

                string role = (BTL___Nhóm_1.DAL.User.VaiTro ?? string.Empty).Trim();

                // If user is student and syllabus is public, disallow editing
                if (role.Equals("Sinh viên", StringComparison.OrdinalIgnoreCase) &&
                    status.Equals("Công khai", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Bạn không được phép sửa đề cương có trạng thái 'Công khai'.", "Không cho phép", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                object idObj = null;
                try { idObj = row.Cells["SyllabusId"].Value; } catch { }
                if (idObj == null)
                {
                    MessageBox.Show("Không xác định được mã đề cương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                BTL___Nhóm_1.DAL.Syllabus.Id = Convert.ToInt32(idObj);
                BTL___Nhóm_1.DAL.Syllabus.Name = GetCellValue(row, "SyllabusName");
                if (string.IsNullOrEmpty(BTL___Nhóm_1.DAL.Syllabus.Name))
                    BTL___Nhóm_1.DAL.Syllabus.Name = GetCellValue(row, "Tên đề cương");

                BTL___Nhóm_1.DAL.Syllabus.Author = GetCellValue(row, "Author");
                if (string.IsNullOrEmpty(BTL___Nhóm_1.DAL.Syllabus.Author))
                    BTL___Nhóm_1.DAL.Syllabus.Author = GetCellValue(row, "Tác giả");

                DateTime dt;
                var posted = GetCellValue(row, "PostedDate");
                if (string.IsNullOrEmpty(posted)) posted = GetCellValue(row, "Ngày xuất bản");
                if (DateTime.TryParse(posted, out dt)) BTL___Nhóm_1.DAL.Syllabus.Date = dt;
                else BTL___Nhóm_1.DAL.Syllabus.Date = DateTime.Now;

                BTL___Nhóm_1.DAL.Syllabus.SubjectName = GetCellValue(row, "SubjectName");
                if (string.IsNullOrEmpty(BTL___Nhóm_1.DAL.Syllabus.SubjectName))
                    BTL___Nhóm_1.DAL.Syllabus.SubjectName = GetCellValue(row, "Tên môn học");

                BTL___Nhóm_1.DAL.Syllabus.Context = GetCellValue(row, "SyllabusContext");
                BTL___Nhóm_1.DAL.Syllabus.Type = GetCellValue(row, "SyllabusType");
                if (string.IsNullOrEmpty(BTL___Nhóm_1.DAL.Syllabus.Type))
                    BTL___Nhóm_1.DAL.Syllabus.Type = GetCellValue(row, "Loại file đề cương");

                BTL___Nhóm_1.DAL.Syllabus.Status = status;

                // Open the edit form (Sửa đề cương)
                using (var editForm = new BTL___Nhóm_1.TrangChu.SuaDeCuong())
                {
                    var result = editForm.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show("Sửa đề cương thành công.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // refresh personal storage list
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở form sửa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLuuTru_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

        }

        private void btnTaiXuong_Click(object sender, EventArgs e)
        {
            // 1. Lấy dòng đang chọn
            if (dgvLuuTru == null) return;
            DataGridViewRow row = null;

            if (dgvLuuTru.SelectedRows != null && dgvLuuTru.SelectedRows.Count > 0)
                row = dgvLuuTru.SelectedRows[0];
            else if (dgvLuuTru.CurrentRow != null)
                row = dgvLuuTru.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("Vui lòng chọn một đề cương để tải xuống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Lấy đường dẫn file NGUỒN từ ô GridView (Không dùng DAL static)
            // "SyllabusContext" là tên cột chứa đường dẫn file trong câu lệnh SQL của bạn
            string relativePath = GetCellValue(row, "SyllabusContext");

            if (string.IsNullOrWhiteSpace(relativePath))
            {
                MessageBox.Show("Đề cương này chưa có file đính kèm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ghép đường dẫn tuyệt đối (Để máy tính hiểu file nằm đâu trong bin/Debug)
            DirectoryInfo directoryInfo = Directory.GetParent(Application.StartupPath).Parent;

            string sourceFilePath = Path.Combine(directoryInfo.FullName, relativePath);

            // 3. Kiểm tra file nguồn có tồn tại thật không
            if (!File.Exists(sourceFilePath))
            {
                MessageBox.Show("File gốc không tồn tại trên ổ cứng! (Đường dẫn hỏng)\n" + sourceFilePath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Cấu hình hộp thoại Lưu
            // Tốt nhất nên tạo mới SaveFileDialog để tránh lưu lại các setting cũ
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = Path.GetFileName(sourceFilePath); // Gợi ý tên file gốc
                sfd.Filter = "De Cuong(WORD,EXCEL)|*.pdf;*.docx;*.xls;*.xlsx";
                sfd.OverwritePrompt = false; // Tắt cảnh báo trùng của Windows để mình tự xử lý

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string destinationPath = sfd.FileName;

                        // 5. Xử lý trùng tên (Gọi hàm đã sửa bên dưới)
                        destinationPath = GetUniqueFileName(destinationPath);

                        // 6. Copy file
                        File.Copy(sourceFilePath, destinationPath, true);

                        if (MessageBox.Show("Tải xuống thành công! Bạn có muốn mở tệp không?", "Thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(destinationPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi tải file: " + ex.Message);
                    }
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
            //Nếu có tệp trùng tên thì thêm (1),(2)... vào tên tệp
            while (File.Exists(originalFileName))
            {
                newPath = Path.Combine(folder, $"{fileName}({count++}){ext}");
            }
            return newPath;
        }

        private void btnTuLuyen_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dgvLuuTru;

            if (dgv == null) return;
            DataGridViewRow row = null;

            if (dgv.SelectedRows != null && dgv.SelectedRows.Count > 0)
                row = dgv.SelectedRows[0];
            else if (dgv.CurrentRow != null)
                row = dgv.CurrentRow;

            if (row == null)
            {
                MessageBox.Show("Vui lòng chọn một đề cương để làm bài.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. LẤY ID TỪ DÒNG ĐANG CHỌN (Quan trọng!)
            // Phải lấy trực tiếp từ ô GridView, không dùng biến DAL static cũ
            object idValue = row.Cells["SyllabusId"].Value;
            if (idValue == null)
            {
                MessageBox.Show("Không tìm thấy mã đề cương.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int selectedSyllabusId = Convert.ToInt32(idValue);

            // 3. Kiểm tra số lượng câu hỏi trong SQL
            int questionCount = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetnoi"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM QUESTION WHERE SyllabusId = @SyllabusId", connection))
                    {
                        // Dùng ID vừa lấy từ GridView để kiểm tra
                        cmd.Parameters.AddWithValue("@SyllabusId", selectedSyllabusId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            questionCount = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra câu hỏi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (questionCount <= 0)
            {
                MessageBox.Show("Đề cương này chưa có câu hỏi nào để luyện tập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 4. CẬP NHẬT BIẾN TOÀN CỤC (Để Form con biết đường mà load)
            // Bây giờ mới gán vào DAL để truyền sang Form CauHoiTuLuyen
            BTL___Nhóm_1.DAL.Syllabus.Id = selectedSyllabusId;

            // Nếu Form con cần hiển thị tên đề cương, cập nhật luôn
            BTL___Nhóm_1.DAL.Syllabus.Name = row.Cells["SyllabusName"].Value?.ToString(); // Hoặc tên cột "Tên đề cương"

            // 5. MỞ FORM (Dùng ShowDialog để chờ)
            // UserControl không có hàm Hide(), ta phải tìm Form cha chứa nó để Hide
            Form parentForm = this.FindForm();
            if (parentForm != null) parentForm.Hide();

            CauHoiTuLuyen cauHoiTuLuyen = new CauHoiTuLuyen();
            cauHoiTuLuyen.ShowDialog(); // Chờ làm bài xong

            // Làm xong thì hiện lại
            if (parentForm != null) parentForm.Show();
        }
    }
}
