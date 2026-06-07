namespace Logtracker.Forms
{
    partial class CoachDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUserInfo;
        private Label lblPeserta;
        private ComboBox cboPeserta;
        private DataGridView dgvAktivitas;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblFeedbackBaru;
        private TextBox txtFeedbackBaru;
        private Button btnSimpan;
        private Label lblNoData;
        private Button btnRefresh;
        private Button btnLaporan;
        private Button btnKelolaKategori;
        private Button btnPilihPeserta;
        private GroupBox grpFeedback;
        private ListBox lstExistingFeedback;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUserInfo = new Label();
            lblPeserta = new Label();
            cboPeserta = new ComboBox();
            dgvAktivitas = new DataGridView();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblFeedbackBaru = new Label();
            txtFeedbackBaru = new TextBox();
            btnSimpan = new Button();
            lblNoData = new Label();
            btnRefresh = new Button();
            btnLaporan = new Button();
            btnKelolaKategori = new Button();
            btnPilihPeserta = new Button();
            grpFeedback = new GroupBox();
            lstExistingFeedback = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            grpFeedback.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            lblUserInfo.Location = new Point(10, 10);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(665, 36);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Coach";
            // 
            // lblPeserta
            // 
            lblPeserta.Location = new Point(10, 46);
            lblPeserta.Name = "lblPeserta";
            lblPeserta.Size = new Size(88, 22);
            lblPeserta.TabIndex = 1;
            lblPeserta.Text = "Pilih Peserta:";
            // 
            // cboPeserta
            // 
            cboPeserta.BackColor = Color.FromArgb(111, 77, 56);
            cboPeserta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeserta.FlatStyle = FlatStyle.Flat;
            cboPeserta.ForeColor = Color.FromArgb(247, 235, 223);
            cboPeserta.Location = new Point(10, 70);
            cboPeserta.Margin = new Padding(3, 2, 3, 2);
            cboPeserta.Name = "cboPeserta";
            cboPeserta.Size = new Size(307, 29);
            cboPeserta.TabIndex = 2;
            cboPeserta.SelectedIndexChanged += cboPeserta_SelectedIndexChanged;
            // 
            // dgvAktivitas
            // 
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvAktivitas.ColumnHeadersHeight = 29;
            dgvAktivitas.GridColor = Color.FromArgb(213, 184, 147);
            dgvAktivitas.Location = new Point(10, 100);
            dgvAktivitas.Margin = new Padding(3, 2, 3, 2);
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.Name = "dgvAktivitas";
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.RowHeadersWidth = 51;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.Size = new Size(665, 170);
            dgvAktivitas.TabIndex = 6;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;
            dgvAktivitas.SelectionChanged += dgvAktivitas_SelectionChanged;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(9, 97);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(52, 22);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.BackColor = Color.FromArgb(111, 77, 56);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.ForeColor = Color.FromArgb(247, 235, 223);
            cboStatus.Location = new Point(9, 120);
            cboStatus.Margin = new Padding(3, 2, 3, 2);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(140, 29);
            cboStatus.TabIndex = 2;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // lblFeedbackBaru
            // 
            lblFeedbackBaru.Location = new Point(166, 97);
            lblFeedbackBaru.Name = "lblFeedbackBaru";
            lblFeedbackBaru.Size = new Size(140, 22);
            lblFeedbackBaru.TabIndex = 3;
            lblFeedbackBaru.Text = "Tambah Feedback Baru:";
            // 
            // txtFeedbackBaru
            // 
            txtFeedbackBaru.BackColor = Color.FromArgb(111, 77, 56);
            txtFeedbackBaru.BorderStyle = BorderStyle.None;
            txtFeedbackBaru.ForeColor = Color.FromArgb(247, 235, 223);
            txtFeedbackBaru.Location = new Point(166, 120);
            txtFeedbackBaru.Margin = new Padding(3, 2, 3, 2);
            txtFeedbackBaru.Multiline = true;
            txtFeedbackBaru.Name = "txtFeedbackBaru";
            txtFeedbackBaru.Size = new Size(350, 43);
            txtFeedbackBaru.TabIndex = 4;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(213, 184, 147);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(534, 120);
            btnSimpan.Margin = new Padding(3, 2, 3, 2);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(122, 43);
            btnSimpan.TabIndex = 5;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // lblNoData
            // 
            lblNoData.Location = new Point(10, 170);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(665, 22);
            lblNoData.TabIndex = 7;
            lblNoData.Text = "Belum ada peserta yang memilih Anda sebagai coach.";
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(213, 184, 147);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(327, 65);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(79, 31);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.FromArgb(213, 184, 147);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Location = new Point(411, 65);
            btnLaporan.Margin = new Padding(3, 2, 3, 2);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(79, 31);
            btnLaporan.TabIndex = 4;
            btnLaporan.Text = "Laporan";
            btnLaporan.UseVisualStyleBackColor = false;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnKelolaKategori
            // 
            btnKelolaKategori.BackColor = Color.FromArgb(213, 184, 147);
            btnKelolaKategori.FlatStyle = FlatStyle.Flat;
            btnKelolaKategori.Location = new Point(495, 65);
            btnKelolaKategori.Margin = new Padding(3, 2, 3, 2);
            btnKelolaKategori.Name = "btnKelolaKategori";
            btnKelolaKategori.Size = new Size(105, 31);
            btnKelolaKategori.TabIndex = 5;
            btnKelolaKategori.Text = "Kelola Kategori";
            btnKelolaKategori.UseVisualStyleBackColor = false;
            btnKelolaKategori.Click += btnKelolaKategori_Click;
            // 
            // btnPilihPeserta
            // 
            btnPilihPeserta.BackColor = Color.FromArgb(213, 184, 147);
            btnPilihPeserta.FlatStyle = FlatStyle.Flat;
            btnPilihPeserta.Location = new Point(605, 65);
            btnPilihPeserta.Margin = new Padding(3, 2, 3, 2);
            btnPilihPeserta.Name = "btnPilihPeserta";
            btnPilihPeserta.Size = new Size(70, 31);
            btnPilihPeserta.TabIndex = 9;
            btnPilihPeserta.Text = "+ Peserta";
            btnPilihPeserta.UseVisualStyleBackColor = false;
            btnPilihPeserta.Click += btnPilihPeserta_Click;
            // 
            // grpFeedback
            // 
            grpFeedback.Controls.Add(lstExistingFeedback);
            grpFeedback.Controls.Add(lblStatus);
            grpFeedback.Controls.Add(cboStatus);
            grpFeedback.Controls.Add(lblFeedbackBaru);
            grpFeedback.Controls.Add(txtFeedbackBaru);
            grpFeedback.Controls.Add(btnSimpan);
            grpFeedback.Location = new Point(10, 277);
            grpFeedback.Margin = new Padding(3, 2, 3, 2);
            grpFeedback.Name = "grpFeedback";
            grpFeedback.Padding = new Padding(3, 2, 3, 2);
            grpFeedback.Size = new Size(665, 195);
            grpFeedback.TabIndex = 8;
            grpFeedback.TabStop = false;
            grpFeedback.Text = "Feedback";
            // 
            // lstExistingFeedback
            // 
            lstExistingFeedback.BackColor = Color.FromArgb(111, 77, 56);
            lstExistingFeedback.BorderStyle = BorderStyle.None;
            lstExistingFeedback.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lstExistingFeedback.ForeColor = Color.FromArgb(247, 235, 223);
            lstExistingFeedback.HorizontalScrollbar = true;
            lstExistingFeedback.Location = new Point(9, 22);
            lstExistingFeedback.Margin = new Padding(3, 2, 3, 2);
            lstExistingFeedback.Name = "lstExistingFeedback";
            lstExistingFeedback.Size = new Size(648, 21);
            lstExistingFeedback.TabIndex = 0;
            lstExistingFeedback.SelectedIndexChanged += lstExistingFeedback_SelectedIndexChanged;
            // 
            // CoachDashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(686, 485);
            Controls.Add(lblUserInfo);
            Controls.Add(lblPeserta);
            Controls.Add(cboPeserta);
            Controls.Add(btnRefresh);
            Controls.Add(btnLaporan);
            Controls.Add(btnKelolaKategori);
            Controls.Add(btnPilihPeserta);
            Controls.Add(dgvAktivitas);
            Controls.Add(lblNoData);
            Controls.Add(grpFeedback);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(55, 36, 20);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CoachDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGTRACKER - Dashboard Coach";
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            grpFeedback.ResumeLayout(false);
            grpFeedback.PerformLayout();
            ResumeLayout(false);
        }
    }
}
