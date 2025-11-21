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

            // tự động lọc khi người dùng thay đổi môn học (nếu combobox tồn tại)
            if (this.cmbMonHoc != null)
            {
                this.cmbMonHoc.SelectedIndexChanged += cmbMonHoc_SelectedIndexChanged;
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
                    string select = "SELECT SyllabusId ,SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusContext, SyllabusType as 'Loại file đề cương' , SyllabusStatus as 'Trạng thái' FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
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

                // compute column X that is always adjacent to dgv (try dgv.Right + margin, but clamp to client area)
                int columnX = dgvRight + margin;
                int maxX = clientW - margin - btnThemVaoDS.Width; // use btnThemVaoDS width as representative for clamp
                if (columnX > maxX) columnX = maxX;
                if (columnX < margin) columnX = margin;

                // vertical placement
                int gap = 20;

                if (isGiangVien)
                {
                    // three buttons in a column, aligned to same X (adjacent to grid)
                    int top = dgvTop;
                    btnThemVaoDS.Location = new Point(columnX, top);
                    btnThemVaoLopHoc.Location = new Point(columnX, top + btnThemVaoDS.Height + gap);
                    btnThemVaoDeCuongCuaToi.Location = new Point(columnX, top + (btnThemVaoDS.Height + gap) * 2);
                }
                else
                {
                    // student: single button should sit at the same column (adjacent to grid)
                    int x = columnX;

                    // center vertically relative to DataGridView but clamp inside client area
                    int y = dgvTop + (dgvHeight - btnThemVaoDeCuongCuaToi.Height) / 2;
                    y = Math.Max(margin, Math.Min(y, clientH - margin - btnThemVaoDeCuongCuaToi.Height));

                    // if columnX would place button overlapping the DataGridView (rare), shift it slightly to the right but keep adjacent
                    if (x <= dgvRight && x + btnThemVaoDeCuongCuaToi.Width > dgvRight)
                    {
                        x = dgvRight + margin;
                        int maxX2 = clientW - margin - btnThemVaoDeCuongCuaToi.Width;
                        if (x > maxX2) x = maxX2;
                    }

                    btnThemVaoDeCuongCuaToi.Location = new Point(x, y);
                }
            }
            catch
            {
                // ignore layout errors to avoid breaking UI
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
                    string select = "SELECT SyllabusId ,SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusContext, SyllabusType as 'Loại file đề cương' , SyllabusStatus as 'Trạng thái' FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
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
            // tự động áp filter khi người dùng chọn môn (chỉ khi combobox đã populated)
            if (cmbMonHoc == null || cmbMonHoc.SelectedItem == null) return;

            // tránh gọi khi giá trị "Tất cả" và không có tên tìm kiếm => vẫn cần hiển thị toàn bộ
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            try
            {
                string selectBase = "SELECT SyllabusId ,SyllabusName as 'Tên đề cương', Author as 'Tác giả', PostedDate as 'Ngày xuất bản', SubjectName as 'Tên môn học' , SyllabusContext, SyllabusType as 'Loại file đề cương' , SyllabusStatus as 'Trạng thái' " +
                                    "FROM Syllabus JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId";
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
                        //Tìm kiếm đề cương theo tên đề cương
                        if (conditions.Contains("SyllabusName LIKE @search"))
                        {
                            command.Parameters.AddWithValue("@search", "%" + txtTenDeCuong.Text.Trim() + "%");
                        }
                        //Lọc đề cương theo môn học
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
                        if (dgvTrangChu.Columns["SyllabusId"] != null)
                        {
                            dgvTrangChu.Columns["SyllabusId"].Visible = false; // Ẩn cột SyllabusId
                        }
                        if (dgvTrangChu.Columns["SyllabusContext"] != null)
                        {
                            dgvTrangChu.Columns["SyllabusContext"].Visible = false; // Ẩn cột SyllabusContext
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
            BTL___Nhóm_1.DAL.Syllabus.Name = row.Cells["Tên đề cương"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Author = row.Cells["Tác giả"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Date = Convert.ToDateTime(row.Cells["Ngày xuất bản"].Value);
            BTL___Nhóm_1.DAL.Syllabus.SubjectName = row.Cells["Tên môn học"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Context = row.Cells["SyllabusContext"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Type = row.Cells["Loại file đề cương"].Value.ToString();
            BTL___Nhóm_1.DAL.Syllabus.Status = row.Cells["Trạng thái"].Value.ToString();

            ThongTinDeCuong thongTinForm = new ThongTinDeCuong();
            thongTinForm.ShowDialog();
        }
    }
}
