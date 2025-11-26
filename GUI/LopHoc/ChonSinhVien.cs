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
    public partial class ChonSinhVien : Form
    {
        private List<int> selectedIds = new List<int>();
        public IReadOnlyList<int> SelectedUserIds => selectedIds;
        public ChonSinhVien()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode !=
                System.ComponentModel.LicenseUsageMode.Designtime)
            {
                this.Load += ChonSinhVien_Load;
            }
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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ChonSinhVien_Load(object sender, EventArgs e)
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    string query = @"
                        SELECT UserId, UserName AS [Tên tài khoản], UserRole AS [Vai trò]
                        FROM Users
                        WHERE UserRole = N'Sinh viên'
                    ";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgv.Columns.Clear();

                        // Checkbox column
                        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn()
                        {
                            Name = "Select",
                            HeaderText = "",
                            Width = 30
                        };
                        dgv.Columns.Add(chk);

                        dgv.DataSource = dt;

                        // Hide ID
                        if (dgv.Columns["UserId"] != null)
                            dgv.Columns["UserId"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sinh viên: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            selectedIds.Clear();

            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    bool isChecked = false;
                    var cell = row.Cells["Select"];

                    if (cell.Value != null && bool.TryParse(cell.Value.ToString(), out bool val))
                        isChecked = val;

                    if (isChecked)
                    {
                        if (row.Cells["UserId"].Value != null &&
                            int.TryParse(row.Cells["UserId"].Value.ToString(), out int id))
                        {
                            selectedIds.Add(id);
                        }
                    }
                }

                if (selectedIds.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một sinh viên.",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn sinh viên: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtTim_Enter(object sender, EventArgs e)
        {
            if (txtTim.Text == "Tìm kiếm tài khoản...")
            {
                txtTim.Text = "";
                txtTim.ForeColor = Color.Black;
            }
            
        }
        private void txtTim_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
            {
                txtTim.Text = "Tìm kiếm tài khoản...";
                txtTim.ForeColor = Color.Gray;
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string selectBase = "SELECT UserId, UserName As 'Tên tài khoản', UserRole As 'Vai trò' FROM Users " +
                                "WHERE UserRole = N'Sinh viên'";
            var conditions = new List<string>();
            string finalSelect = selectBase;
            if (!string.IsNullOrEmpty(txtTim.Text.Trim()) && txtTim.Text != "Tìm kiếm tài khoản...")
            {
                conditions.Add("UserName LIKE @search");
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
                        command.Parameters.AddWithValue("@status", "Công khai");
                        if (conditions.Contains("UserName LIKE @search"))
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
