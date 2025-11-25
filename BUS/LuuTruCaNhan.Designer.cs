namespace BTL___Nhóm_1.BUS
{
    partial class LuuTruCaNhan
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvLuuTru = new System.Windows.Forms.DataGridView();
            this.SyllabusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyllabusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyllabusContext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyllabusType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SyllabusStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.cmbMonHoc = new System.Windows.Forms.ComboBox();
            this.lblMonHoc = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTaiXuong = new System.Windows.Forms.Button();
            this.btnTuLuyen = new System.Windows.Forms.Button();
            this.sfđDeCuong = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuuTru)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLuuTru
            // 
            this.dgvLuuTru.AllowUserToAddRows = false;
            this.dgvLuuTru.AllowUserToDeleteRows = false;
            this.dgvLuuTru.AllowUserToResizeColumns = false;
            this.dgvLuuTru.AllowUserToResizeRows = false;
            this.dgvLuuTru.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLuuTru.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvLuuTru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuuTru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SyllabusId,
            this.PersonalId,
            this.SyllabusName,
            this.Author,
            this.PostedDate,
            this.SubjectName,
            this.SyllabusContext,
            this.SyllabusType,
            this.SyllabusStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLuuTru.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLuuTru.EnableHeadersVisualStyles = false;
            this.dgvLuuTru.GridColor = System.Drawing.Color.White;
            this.dgvLuuTru.Location = new System.Drawing.Point(3, 53);
            this.dgvLuuTru.Name = "dgvLuuTru";
            this.dgvLuuTru.ReadOnly = true;
            this.dgvLuuTru.RowHeadersVisible = false;
            this.dgvLuuTru.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgvLuuTru.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLuuTru.RowTemplate.Height = 24;
            this.dgvLuuTru.Size = new System.Drawing.Size(942, 300);
            this.dgvLuuTru.TabIndex = 0;
            this.dgvLuuTru.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuuTru_CellContentClick);
            // 
            // SyllabusId
            // 
            this.SyllabusId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SyllabusId.DataPropertyName = "SyllabusId";
            this.SyllabusId.HeaderText = "SyllabusId";
            this.SyllabusId.MinimumWidth = 6;
            this.SyllabusId.Name = "SyllabusId";
            this.SyllabusId.ReadOnly = true;
            this.SyllabusId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SyllabusId.Visible = false;
            // 
            // PersonalId
            // 
            this.PersonalId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PersonalId.DataPropertyName = "PersonalId";
            this.PersonalId.HeaderText = "PersonalId";
            this.PersonalId.MinimumWidth = 6;
            this.PersonalId.Name = "PersonalId";
            this.PersonalId.ReadOnly = true;
            this.PersonalId.Visible = false;
            // 
            // SyllabusName
            // 
            this.SyllabusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SyllabusName.DataPropertyName = "Tên đề cương";
            this.SyllabusName.HeaderText = "Tên đề cương";
            this.SyllabusName.MinimumWidth = 6;
            this.SyllabusName.Name = "SyllabusName";
            this.SyllabusName.ReadOnly = true;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Author.DataPropertyName = "Tác giả";
            this.Author.HeaderText = "Tác giả";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // PostedDate
            // 
            this.PostedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PostedDate.DataPropertyName = "Ngày xuất bản";
            this.PostedDate.HeaderText = "Ngày xuất bản";
            this.PostedDate.MinimumWidth = 6;
            this.PostedDate.Name = "PostedDate";
            this.PostedDate.ReadOnly = true;
            // 
            // SubjectName
            // 
            this.SubjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectName.DataPropertyName = "Tên môn học";
            this.SubjectName.HeaderText = "Tên môn học";
            this.SubjectName.MinimumWidth = 6;
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            // 
            // SyllabusContext
            // 
            this.SyllabusContext.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SyllabusContext.DataPropertyName = "SyllabusContext";
            this.SyllabusContext.HeaderText = "SyllabusContext";
            this.SyllabusContext.MinimumWidth = 6;
            this.SyllabusContext.Name = "SyllabusContext";
            this.SyllabusContext.ReadOnly = true;
            this.SyllabusContext.Visible = false;
            // 
            // SyllabusType
            // 
            this.SyllabusType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SyllabusType.DataPropertyName = "Loại file đề cương";
            this.SyllabusType.HeaderText = "Loại đề cương";
            this.SyllabusType.MinimumWidth = 6;
            this.SyllabusType.Name = "SyllabusType";
            this.SyllabusType.ReadOnly = true;
            // 
            // SyllabusStatus
            // 
            this.SyllabusStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SyllabusStatus.DataPropertyName = "Trạng thái";
            this.SyllabusStatus.HeaderText = "Trạng thái";
            this.SyllabusStatus.MinimumWidth = 6;
            this.SyllabusStatus.Name = "SyllabusStatus";
            this.SyllabusStatus.ReadOnly = true;
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.txtTen.ForeColor = System.Drawing.Color.Gray;
            this.txtTen.Location = new System.Drawing.Point(3, 3);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(352, 38);
            this.txtTen.TabIndex = 1;
            this.txtTen.Text = "Tìm kiếm tên đề cương...";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F);
            this.btnTim.Image = global::BTL___Nhóm_1.Properties.Resources.search_interface_symbol;
            this.btnTim.Location = new System.Drawing.Point(363, 3);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(60, 40);
            this.btnTim.TabIndex = 2;
            this.btnTim.UseVisualStyleBackColor = true;
            // 
            // cmbMonHoc
            // 
            this.cmbMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cmbMonHoc.FormattingEnabled = true;
            this.cmbMonHoc.Location = new System.Drawing.Point(549, 7);
            this.cmbMonHoc.Name = "cmbMonHoc";
            this.cmbMonHoc.Size = new System.Drawing.Size(200, 33);
            this.cmbMonHoc.TabIndex = 3;
            // 
            // lblMonHoc
            // 
            this.lblMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMonHoc.Location = new System.Drawing.Point(433, 10);
            this.lblMonHoc.Name = "lblMonHoc";
            this.lblMonHoc.Size = new System.Drawing.Size(100, 28);
            this.lblMonHoc.TabIndex = 1;
            this.lblMonHoc.Text = "Môn học:";
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnXoa.Location = new System.Drawing.Point(3, 381);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(200, 60);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xóa khỏi Đề cương của tôi";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click_1);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnThemMoi.Location = new System.Drawing.Point(215, 381);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(200, 60);
            this.btnThemMoi.TabIndex = 5;
            this.btnThemMoi.Text = "Thêm đề cương";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSua.Location = new System.Drawing.Point(427, 381);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(200, 60);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sửa đề cương";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTaiXuong
            // 
            this.btnTaiXuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiXuong.Location = new System.Drawing.Point(649, 384);
            this.btnTaiXuong.Name = "btnTaiXuong";
            this.btnTaiXuong.Size = new System.Drawing.Size(141, 57);
            this.btnTaiXuong.TabIndex = 35;
            this.btnTaiXuong.Text = "Tải xuống";
            this.btnTaiXuong.UseVisualStyleBackColor = true;
            this.btnTaiXuong.Click += new System.EventHandler(this.btnTaiXuong_Click);
            // 
            // btnTuLuyen
            // 
            this.btnTuLuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTuLuyen.Location = new System.Drawing.Point(804, 384);
            this.btnTuLuyen.Name = "btnTuLuyen";
            this.btnTuLuyen.Size = new System.Drawing.Size(141, 57);
            this.btnTuLuyen.TabIndex = 36;
            this.btnTuLuyen.Text = "Tự luyện";
            this.btnTuLuyen.UseVisualStyleBackColor = true;
            this.btnTuLuyen.Click += new System.EventHandler(this.btnTuLuyen_Click);
            // 
            // LuuTruCaNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTuLuyen);
            this.Controls.Add(this.btnTaiXuong);
            this.Controls.Add(this.cmbMonHoc);
            this.Controls.Add(this.lblMonHoc);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvLuuTru);
            this.Name = "LuuTruCaNhan";
            this.Size = new System.Drawing.Size(1000, 650);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuuTru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvLuuTru;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.ComboBox cmbMonHoc;
        private System.Windows.Forms.Label lblMonHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllaBusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AuthorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostedDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusContextCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusTypeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusStatusCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusContext;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SyllabusStatus;
        private System.Windows.Forms.Button btnTaiXuong;
        private System.Windows.Forms.Button btnTuLuyen;
        private System.Windows.Forms.SaveFileDialog sfđDeCuong;
    }
}
#endregion