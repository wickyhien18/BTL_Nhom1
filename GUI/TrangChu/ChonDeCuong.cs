using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;

namespace BTL___Nhóm_1.TrangChu
{
    public partial class ChonDeCuong : Form
    {
        private List<int> selectedIds = new List<int>();

        public IReadOnlyList<int> SelectedSyllabusIds => selectedIds;

        public ChonDeCuong()
        {
            InitializeComponent();

            // Do not attempt DB access at design time
            if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.Load += SelectSyllabiForm_Load;
            }
        }

        private void SelectSyllabiForm_Load(object sender, EventArgs e)
        {
            LoadSyllabi();
        }

        private void LoadSyllabi()
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (var connection = new SqlConnection(conn))
                {
                    connection.Open();
                    string sql = @"SELECT SyllabusId, SyllabusName AS [Tên đề cương], Author AS [Tác giả], PostedDate AS [Ngày xuất bản], 
                                           SubjectName AS [Tên môn học], SyllabusType AS [Loại file], SyllabusStatus AS [Trạng thái], SyllabusContext
                                   FROM Syllabus
                                   JOIN Subject ON Syllabus.SubjectId = Subject.SubjectId
                                   WHERE SyllabusStatus = 'Công khai'";
                    using (var cmd = new SqlCommand(sql, connection))
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);

                        dgv.Columns.Clear();
                        var chk = new DataGridViewCheckBoxColumn { Name = "Select", HeaderText = "", Width = 30 };
                        dgv.Columns.Add(chk);

                        dgv.DataSource = dt;

                        if (dgv.Columns["SyllabusId"] != null)
                            dgv.Columns["SyllabusId"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đề cương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            selectedIds.Clear();
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;
                    var cell = row.Cells["Select"];
                    bool isChecked = false;
                    if (cell.Value != null && bool.TryParse(cell.Value.ToString(), out bool val))
                        isChecked = val;
                    if (isChecked)
                    {
                        if (row.Cells["SyllabusId"].Value != null && int.TryParse(row.Cells["SyllabusId"].Value.ToString(), out int id))
                        {
                            selectedIds.Add(id);
                        }
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một đề cương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn đề cương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}