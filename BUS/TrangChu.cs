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
                    string select = "SELECT SyllabusId ,SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType, SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
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
                    string select = "SELECT SyllabusId ,SyllabusName, Author, PostedDate, SubjectName, SyllabusContext, SyllabusType , SyllabusStatus FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            dgvTrangChu.DataSource = dataTable;
                        }
                    }
                    if (dgvTrangChu.Columns["SyllabusId"] != null)
                    {
                        dgvTrangChu.Columns["SyllabusId"].Visible = false; // Ẩn cột SyllabusId
                    }
                    if (dgvTrangChu.Columns["SyllabusContext"] != null)
                    {
                        dgvTrangChu.Columns["SyllabusContext"].Visible = false; // Ẩn cột SyllabusContext
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
                if (dgvTrangChu == null) return;

                // get selected row
                DataGridViewRow selectedRow = null;
                if (dgvTrangChu.SelectedRows != null && dgvTrangChu.SelectedRows.Count > 0)
                {
                    selectedRow = dgvTrangChu.SelectedRows[0];
                }
                else if (dgvTrangChu.CurrentRow != null)
                {
                    selectedRow = dgvTrangChu.CurrentRow;
                }

                if (selectedRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một đề cương trước khi thêm.");
                    return;
                }

                if (selectedRow.Cells["SyllabusId"].Value == null)
                {
                    MessageBox.Show("Không xác định được đề cương đã chọn.");
                    return;
                }

                int syllabusId = Convert.ToInt32(selectedRow.Cells["SyllabusId"].Value);

                // confirm
                var dr = MessageBox.Show("Bạn có muốn thêm đề cương này vào 'Đề cương của tôi' không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;

                int userId = BTL___Nhóm_1.DAL.User.Id;

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString))
                {
                    connection.Open();

                    // create table if not exists
                    string createTable = @"IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PersonalStorage')
BEGIN
    CREATE TABLE PersonalStorage (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        UserId INT NOT NULL,
        SyllabusId INT NOT NULL,
        SavedDate DATETIME NOT NULL DEFAULT(GETDATE())
    );
END";
                    using (SqlCommand cmdCreate = new SqlCommand(createTable, connection))
                    {
                        cmdCreate.ExecuteNonQuery();
                    }

                    // check duplicate
                    string checkDup = "SELECT COUNT(1) FROM PersonalStorage WHERE UserId = @userId AND SyllabusId = @syllabusId";
                    using (SqlCommand cmdCheck = new SqlCommand(checkDup, connection))
                    {
                        cmdCheck.Parameters.AddWithValue("@userId", userId);
                        cmdCheck.Parameters.AddWithValue("@syllabusId", syllabusId);
                        int exists = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (exists > 0)
                        {
                            MessageBox.Show("Đề cương này đã có trong 'Đề cương của tôi'.");
                            return;
                        }
                    }

                    string insert = "INSERT INTO PersonalStorage (UserId, SyllabusId, SavedDate) VALUES (@userId, @syllabusId, GETDATE())";
                    using (SqlCommand cmdInsert = new SqlCommand(insert, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("@userId", userId);
                        cmdInsert.Parameters.AddWithValue("@syllabusId", syllabusId);
                        cmdInsert.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Đã thêm vào 'Đề cương của tôi'.");

                try
                {
                    var mainForm = Application.OpenForms.Cast<Form>().FirstOrDefault(f => f.GetType().Name == "fmMain");
                    if (mainForm != null)
                    {
                        
                        var deCuongCtrls = mainForm.Controls.Find("deCuongCuaToi1", true);
                        bool refreshed = false;
                        if (deCuongCtrls != null && deCuongCtrls.Length > 0)
                        {
                            foreach (var c in deCuongCtrls)
                            {
                                var container = c as DeCuongCuaToi;
                                if (container != null)
                                {
                                    var luu = container.Controls.OfType<LuuTruCaNhan>().FirstOrDefault();
                                    if (luu != null)
                                    {
                                        luu.RefreshData();
                                        refreshed = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (!refreshed)
                        {
                            // fallback: search by type anywhere under mainForm
                            var containers = mainForm.Controls.OfType<DeCuongCuaToi>().ToList();
                            foreach (var container in containers)
                            {
                                var luu = container.Controls.OfType<LuuTruCaNhan>().FirstOrDefault();
                                if (luu != null)
                                {
                                    luu.RefreshData();
                                    break;
                                }
                            }
                        }
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào 'Đề cương của tôi': " + ex.Message);
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
    }
}
