using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using BTL___Nhóm_1.TrangChu;
using BTL___Nhóm_1.DAL;

namespace BTL___Nhóm_1.BUS
{
    public partial class TrangChu : UserControl
    {
        public TrangChu()
        {
            InitializeComponent();

            // Khi control thay đổi kích thước hoặc layout, cập nhật vị trí/hiển thị nút
            this.Resize += TrangChu_Resize;
            this.Layout += TrangChu_Layout;
            this.dgvTrangChu.SizeChanged += (s, e) => UpdateButtonsByRole();
            dgvTrangChu.AutoGenerateColumns = false;

            // tự động lọc khi người dùng thay đổi môn học (nếu combobox tồn tại)
            if (this.cmbMonHoc != null)
            {
                this.cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;
            }

            // đảm bảo nút "Thêm vào Đề cương của tôi" có handler
            try
            {
                if (this.btnThemVaoDeCuongCuaToi != null)
                {
                    this.btnThemVaoDeCuongCuaToi.Click -= btnThemVaoDeCuongCuaToi_Click;
                    this.btnThemVaoDeCuongCuaToi.Click += btnThemVaoDeCuongCuaToi_Click;
                }
            }
            catch
            {
                // ignore wiring errors
            }
        }
        private void TrangChu_Layout(object sender, LayoutEventArgs e)
        {
            UpdateButtonsByRole();
        }

        private void TrangChu_Resize(object sender, EventArgs e)
        {
            UpdateButtonsByRole();
        }
        //Hiển thị danh sách đề cương gồm tên đề cương, tác giả, ngày xuất bản, tên môn học, loại file đề cương, trạng thái
        private void TrangChu_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string select = "SELECT SyllabusId ,SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType, SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId WHERE SyllabusStatus = 'Công khai'"; // chỉ tải đề cương công khai
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
                        }
                    }
                    // Nếu có combobox môn học trong Designer, load danh sách ở đây
                    if (this.cmbMonHoc != null)
                    {
                        try
                        {
                            // tránh event SelectedIndexChanged chạy khi populate
                            this.cmbMonHoc.SelectedIndexChanged -= cmbMonHoc_SelectedIndexChanged;

                            string selectSubjects = "SELECT SubjectName FROM Subject";
                            using (SqlCommand cmd = new SqlCommand(selectSubjects, connection))
                            {
                                using (SqlDataReader r2 = cmd.ExecuteReader())
                                {
                                    this.cmbMonHoc.Items.Clear();
                                    this.cmbMonHoc.Items.Add("Tất cả");
                                    while (r2.Read())
                                    {
                                        this.cmbMonHoc.Items.Add(r2["SubjectName"].ToString());
                                    }
                                }
                            }

                            if (this.cmbMonHoc.Items.Count > 0)
                                this.cmbMonHoc.SelectedIndex = 0;

                            this.cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;
                        }
                        catch
                        {
                            // swallow: không muốn phá flow nếu không có subject table
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

            this.BeginInvoke(new Action(() => UpdateButtonsByRole()));
        }
        //Phân quyền hiển thị 
        private void UpdateButtonsByRole()
        {
            try
            {
                if (dgvTrangChu == null || btnThemVaoDeCuongCuaToi == null || btnThemVaoDS == null || btnThemVaoLopHoc == null)
                    return;

                string role = BTL___Nhóm_1.DAL.User.VaiTro ?? string.Empty;
                string roleLower = role.ToLowerInvariant();

                bool isGiangVien = roleLower.Contains("giảng") || roleLower.Contains("giang");

                btnThemVaoDS.Visible = isGiangVien;
                btnThemVaoLopHoc.Visible = isGiangVien;
                btnThemVaoDeCuongCuaToi.Visible = true;

                const int margin = 20;
                int clientW = this.ClientSize.Width;
                int clientH = this.ClientSize.Height;

                // grid metrics
                int dgvLeft = dgvTrangChu.Left;
                int dgvTop = dgvTrangChu.Top;
                int dgvRight = dgvTrangChu.Right;
                int dgvWidth = dgvTrangChu.Width;
                int dgvHeight = dgvTrangChu.Height;

                int columnX = dgvRight + margin;
                int maxX = clientW - margin - btnThemVaoDS.Width; 
                if (columnX > maxX) columnX = maxX;
                if (columnX < margin) columnX = margin;

                // vertical placement gap
                int gap = 20;

                bool canPlaceRight = (dgvRight + margin + btnThemVaoDS.Width) <= (clientW - margin);

                if (isGiangVien)
                {
                    if (canPlaceRight)
                    {
                        int top = dgvTop;
                        btnThemVaoDS.Location = new Point(columnX, top);
                        btnThemVaoLopHoc.Location = new Point(columnX, top + btnThemVaoDS.Height + gap);
                        btnThemVaoDeCuongCuaToi.Location = new Point(columnX, top + (btnThemVaoDS.Height + gap) * 2);
                    }
                    else
                    {
                        // Not enough space on the right -> place the three buttons centered in a row below the DataGridView
                        int totalWidth = btnThemVaoDS.Width + btnThemVaoLopHoc.Width + btnThemVaoDeCuongCuaToi.Width + gap * 2;
                        int startX = dgvLeft + Math.Max(0, (dgvWidth - totalWidth) / 2);
                        startX = Math.Max(margin, Math.Min(startX, clientW - margin - totalWidth));

                        int y = dgvTop + dgvHeight + gap;
                        if (y + btnThemVaoDS.Height > clientH - margin)
                        {
                            y = clientH - margin - btnThemVaoDS.Height;
                        }

                        btnThemVaoDS.Location = new Point(startX, y);
                        btnThemVaoLopHoc.Location = new Point(startX + btnThemVaoDS.Width + gap, y);
                        btnThemVaoDeCuongCuaToi.Location = new Point(startX + btnThemVaoDS.Width + gap + btnThemVaoLopHoc.Width + gap, y);
                    }
                }
                else
                {
                    // student: single button should sit adjacent or below depending on space
                    int x = columnX;
                    int y = dgvTop + (dgvHeight - btnThemVaoDeCuongCuaToi.Height) / 2;
                    y = Math.Max(margin, Math.Min(y, clientH - margin - btnThemVaoDeCuongCuaToi.Height));

                    if (!canPlaceRight)
                    {
                        x = dgvLeft + Math.Max(0, (dgvWidth - btnThemVaoDeCuongCuaToi.Width) / 2);
                        if (x + btnThemVaoDeCuongCuaToi.Width > clientW - margin)
                            x = clientW - margin - btnThemVaoDeCuongCuaToi.Width;
                        y = dgvTop + dgvHeight + gap;
                        if (y + btnThemVaoDeCuongCuaToi.Height > clientH - margin)
                            y = clientH - margin - btnThemVaoDeCuongCuaToi.Height;
                    }

                    btnThemVaoDeCuongCuaToi.Location = new Point(x, y);
                }
            }
            catch
            {
            }
        }
        //Thêm vào danh sách đề cương tại trang chủ
        private void btnThemVaoDS_Click(object sender, EventArgs e)
        {
            ThemVaoDS themVaoDSForm = new ThemVaoDS(); //Mở form thêm vào danh sách đề cương
            themVaoDSForm.ShowDialog();
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();
                    string select = "SELECT SyllabusId ,SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType , SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId WHERE SyllabusStatus = 'Công khai'"; // chỉ tải đề cương công khai
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
                        }
                    }
                }

                // cập nhật layout sau khi thay đổi dữ liệu
                this.BeginInvoke(new Action(() => UpdateButtonsByRole()));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThemVaoLopHoc_Click(object sender, EventArgs e)
        {

        }

        // Thêm vào "Đề cương của tôi" (Lưu trữ cá nhân)
        private void btnThemVaoDeCuongCuaToi_Click(object sender, EventArgs e)
        {
            try
            {
                // loop to allow re-selection when duplicates are found
                while (true)
                {
                    using (var dlg = new BTL___Nhóm_1.TrangChu.SelectSyllabiForm())
                    {
                        if (dlg.ShowDialog(this) != DialogResult.OK)
                            return;

                        var idsToAdd = dlg.SelectedSyllabusIds.ToList();
                        if (idsToAdd.Count == 0)
                        {
                            MessageBox.Show("Vui lòng chọn ít nhất một đề cương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            continue;
                        }

                        int userId = BTL___Nhóm_1.DAL.User.Id;

                        // build parameterized IN clause
                        var paramNames = new List<string>();
                        for (int i = 0; i < idsToAdd.Count; i++)
                            paramNames.Add($"@p{i}");

                        var existing = new List<int>();
                        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                        using (var connection = new System.Data.SqlClient.SqlConnection(connStr))
                        {
                            connection.Open();
                            string sqlCheck = $"SELECT SyllabusId FROM PersonalStorage WHERE UserId = @userId AND SyllabusId IN ({string.Join(",", paramNames)})";
                            using (var cmd = new System.Data.SqlClient.SqlCommand(sqlCheck, connection))
                            {
                                cmd.Parameters.AddWithValue("@userId", userId);
                                for (int i = 0; i < idsToAdd.Count; i++)
                                    cmd.Parameters.AddWithValue(paramNames[i], idsToAdd[i]);

                                using (var reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        existing.Add(Convert.ToInt32(reader["SyllabusId"]));
                                    }
                                }
                            }
                        }

                        if (existing.Count > 0)
                        {
                            MessageBox.Show($"Phát hiện {existing.Count} đề cương đã có trong 'Đề cương của tôi'.\nVui lòng chọn lại đề cương khác (không chọn các đề cương đã tồn tại).", "Đã tồn tại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue; // reopen selection dialog so user can choose non-duplicate items
                        }

                        var confirm = MessageBox.Show($"Bạn có muốn thêm {idsToAdd.Count} đề cương vào 'Đề cương của tôi'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirm != DialogResult.Yes)
                            return;

                        int added = 0;
                        int skipped = 0;

                        using (var connection = new System.Data.SqlClient.SqlConnection(connStr))
                        {
                            connection.Open();
                            using (var transaction = connection.BeginTransaction())
                            {
                                try
                                {
                                    foreach (var syllabusId in idsToAdd)
                                    {
                                        // double-check duplicate inside transaction
                                        using (var checkCmd = new System.Data.SqlClient.SqlCommand("SELECT COUNT(1) FROM PersonalStorage WHERE UserId = @userId AND SyllabusId = @syllabusId", connection, transaction))
                                        {
                                            checkCmd.Parameters.AddWithValue("@userId", userId);
                                            checkCmd.Parameters.AddWithValue("@syllabusId", syllabusId);
                                            int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                                            if (exists > 0)
                                            {
                                                skipped++;
                                                continue;
                                            }
                                        }

                                        using (var insertCmd = new System.Data.SqlClient.SqlCommand("INSERT INTO PersonalStorage (UserId, SyllabusId, SavedDate) VALUES (@userId, @syllabusId, GETDATE())", connection, transaction))
                                        {
                                            insertCmd.Parameters.AddWithValue("@userId", userId);
                                            insertCmd.Parameters.AddWithValue("@syllabusId", syllabusId);
                                            insertCmd.ExecuteNonQuery();
                                            added++;
                                        }
                                    }

                                    transaction.Commit();
                                }
                                catch
                                {
                                    try { transaction.Rollback(); } catch { }
                                    throw;
                                }
                            }
                        }

                        MessageBox.Show($"Hoàn thành. Đã thêm: {added}.", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh LuuTruCaNhan if present
                        try
                        {
                            // Duyệt tất cả các Form đang mở, tìm mọi instance của LuuTruCaNhan và gọi RefreshData()
                            foreach (Form f in Application.OpenForms)
                            {
                                try
                                {
                                    foreach (var luu in FindControlsRecursive<LuuTruCaNhan>(f).ToList())
                                    {
                                        try
                                        {
                                            luu.RefreshData();
                                        }
                                        catch
                                        {
                                            // ignore individual refresh errors
                                        }
                                    }
                                }
                                catch
                                {
                                    // ignore errors per form
                                }
                            }
                        }
                        catch
                        {
                            // ignore global refresh errors
                        }

                        // finished successfully
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào 'Đề cương của tôi': " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Placeholder text box tìm kiếm tên đề cương
        private void txtTenDeCuong_Enter(object sender, EventArgs e)
        {
            if (txtTenDeCuong.Text == "Tìm kiếm tên đề cương...")
            {
                txtTenDeCuong.Text = "";
                txtTenDeCuong.ForeColor = Color.Black;
            }
        }
        //Placeholder text box tìm kiếm tên đề cương
        private void txtTenDeCuong_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenDeCuong.Text))
            {
                txtTenDeCuong.Text = "Tìm kiếm tên đề cương...";
                txtTenDeCuong.ForeColor = Color.Gray;
            }
        }

        private void cmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tự động áp filter khi người dùng chọn môn 
            if (cmbMonHoc == null || cmbMonHoc.SelectedItem == null) return;

            // tránh gọi khi giá trị "Tất cả" và không có tên tìm kiếm => vẫn cần hiển thị toàn bộ
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                string selectBase = "SELECT SyllabusId, SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType, SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                var conditions = new List<string>();

                // always filter to public
                conditions.Add("SyllabusStatus = @status");

                if (!string.IsNullOrEmpty(txtTenDeCuong.Text.Trim()) && txtTenDeCuong.Text != "Tìm kiếm tên đề cương...")
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
                            command.Parameters.AddWithValue("@search", "%" + txtTenDeCuong.Text.Trim() + "%");
                        }
                        if (conditions.Contains("Subject.SubjectName = @subject"))
                        {
                            command.Parameters.AddWithValue("@subject", cmbMonHoc.SelectedItem.ToString());
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
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

        private void btnTimTen_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void dgvTrangChu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            DataGridViewRow row = dgvTrangChu.Rows[e.RowIndex];
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
            TrangChu_Load(sender, e);
        }

        private void btnThemVaoDeCuongCuaToi_Click_1(object sender, EventArgs e)
        {

        }

        private IEnumerable<T> FindControlsRecursive<T>(Control parent) where T : Control
        {
            if (parent == null) yield break;
            foreach (Control c in parent.Controls)
            {
                if (c is T t) yield return t;
                foreach (var child in FindControlsRecursive<T>(c))
                    yield return child;
            }
        }

        private void dgvTrangChu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTenDeCuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenDeCuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) || !char.IsLetterOrDigit(e.KeyChar) || e.KeyChar != '_' || e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
