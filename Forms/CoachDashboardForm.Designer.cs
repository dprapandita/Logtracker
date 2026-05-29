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
            grpFeedback = new GroupBox();
            lstExistingFeedback = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            grpFeedback.SuspendLayout();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserInfo.Location = new Point(12, 12);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(760, 30);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Coach";
            // 
            // lblPeserta
            // 
            lblPeserta.Location = new Point(12, 55);
            lblPeserta.Name = "lblPeserta";
            lblPeserta.Size = new Size(100, 25);
            lblPeserta.TabIndex = 1;
            lblPeserta.Text = "Pilih Peserta:";
            // 
            // cboPeserta
            // 
            cboPeserta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeserta.Location = new Point(12, 82);
            cboPeserta.Name = "cboPeserta";
            cboPeserta.Size = new Size(350, 28);
            cboPeserta.TabIndex = 2;
            cboPeserta.SelectedIndexChanged += cboPeserta_SelectedIndexChanged;
            // 
            // dgvAktivitas
            // 
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.ColumnHeadersHeight = 29;
            dgvAktivitas.Location = new Point(12, 118);
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.Name = "dgvAktivitas";
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.RowHeadersWidth = 51;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.Size = new Size(760, 200);
            dgvAktivitas.TabIndex = 6;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;
            dgvAktivitas.SelectionChanged += dgvAktivitas_SelectionChanged;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(10, 115);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(60, 25);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Status:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Disetujui", "Revisi" });
            cboStatus.Location = new Point(10, 142);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(160, 28);
            cboStatus.TabIndex = 2;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // lblFeedbackBaru
            // 
            lblFeedbackBaru.Location = new Point(190, 115);
            lblFeedbackBaru.Name = "lblFeedbackBaru";
            lblFeedbackBaru.Size = new Size(160, 25);
            lblFeedbackBaru.TabIndex = 3;
            lblFeedbackBaru.Text = "Tambah Feedback Baru:";
            // 
            // txtFeedbackBaru
            // 
            txtFeedbackBaru.Location = new Point(190, 142);
            txtFeedbackBaru.Multiline = true;
            txtFeedbackBaru.Name = "txtFeedbackBaru";
            txtFeedbackBaru.Size = new Size(400, 50);
            txtFeedbackBaru.TabIndex = 4;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(610, 142);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(140, 50);
            btnSimpan.TabIndex = 5;
            btnSimpan.Text = "Simpan";
            btnSimpan.Click += btnSimpan_Click;
            // 
            // lblNoData
            // 
            lblNoData.Location = new Point(12, 200);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(760, 25);
            lblNoData.TabIndex = 7;
            lblNoData.Text = "Belum ada peserta yang memilih Anda sebagai coach.";
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(370, 80);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.Location = new Point(466, 80);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(90, 30);
            btnLaporan.TabIndex = 4;
            btnLaporan.Text = "Laporan";
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnKelolaKategori
            // 
            btnKelolaKategori.Location = new Point(562, 80);
            btnKelolaKategori.Name = "btnKelolaKategori";
            btnKelolaKategori.Size = new Size(120, 30);
            btnKelolaKategori.TabIndex = 5;
            btnKelolaKategori.Text = "Kelola Kategori";
            btnKelolaKategori.Click += btnKelolaKategori_Click;
            // 
            // grpFeedback
            // 
            grpFeedback.Controls.Add(lstExistingFeedback);
            grpFeedback.Controls.Add(lblStatus);
            grpFeedback.Controls.Add(cboStatus);
            grpFeedback.Controls.Add(lblFeedbackBaru);
            grpFeedback.Controls.Add(txtFeedbackBaru);
            grpFeedback.Controls.Add(btnSimpan);
            grpFeedback.Location = new Point(12, 326);
            grpFeedback.Name = "grpFeedback";
            grpFeedback.Size = new Size(760, 230);
            grpFeedback.TabIndex = 8;
            grpFeedback.TabStop = false;
            grpFeedback.Text = "Feedback";
            // 
            // lstExistingFeedback
            // 
            lstExistingFeedback.Font = new Font("Segoe UI", 9F);
            lstExistingFeedback.HorizontalScrollbar = true;
            lstExistingFeedback.Location = new Point(10, 25);
            lstExistingFeedback.Name = "lstExistingFeedback";
            lstExistingFeedback.Size = new Size(740, 64);
            lstExistingFeedback.TabIndex = 0;
            lstExistingFeedback.SelectedIndexChanged += lstExistingFeedback_SelectedIndexChanged;
            // 
            // CoachDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 570);
            Controls.Add(lblUserInfo);
            Controls.Add(lblPeserta);
            Controls.Add(cboPeserta);
            Controls.Add(btnRefresh);
            Controls.Add(btnLaporan);
            Controls.Add(btnKelolaKategori);
            Controls.Add(dgvAktivitas);
            Controls.Add(lblNoData);
            Controls.Add(grpFeedback);
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
