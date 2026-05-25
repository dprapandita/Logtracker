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
            grpFeedback = new GroupBox();
            lstExistingFeedback = new ListBox();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            grpFeedback.SuspendLayout();
            SuspendLayout();

            lblUserInfo.Text = "Coach";
            lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserInfo.Location = new Point(12, 12);
            lblUserInfo.Size = new Size(760, 30);

            lblPeserta.Text = "Pilih Peserta:";
            lblPeserta.Location = new Point(12, 55);
            lblPeserta.Size = new Size(100, 25);

            cboPeserta.Location = new Point(12, 82);
            cboPeserta.Size = new Size(350, 28);
            cboPeserta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPeserta.SelectedIndexChanged += cboPeserta_SelectedIndexChanged;

            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(370, 80);
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Click += btnRefresh_Click;

            btnLaporan.Text = "Laporan";
            btnLaporan.Location = new Point(466, 80);
            btnLaporan.Size = new Size(90, 30);
            btnLaporan.Click += btnLaporan_Click;

            dgvAktivitas.Location = new Point(12, 118);
            dgvAktivitas.Size = new Size(760, 200);
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;
            dgvAktivitas.SelectionChanged += dgvAktivitas_SelectionChanged;

            lblNoData.Text = "Belum ada peserta yang memilih Anda sebagai coach.";
            lblNoData.Location = new Point(12, 200);
            lblNoData.Size = new Size(760, 25);
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Visible = false;

            grpFeedback.Text = "Feedback";
            grpFeedback.Location = new Point(12, 326);
            grpFeedback.Size = new Size(760, 230);

            lstExistingFeedback.Location = new Point(10, 25);
            lstExistingFeedback.Size = new Size(740, 80);
            lstExistingFeedback.Font = new Font("Segoe UI", 9F);
            lstExistingFeedback.HorizontalScrollbar = true;

            lblStatus.Text = "Status:";
            lblStatus.Location = new Point(10, 115);
            lblStatus.Size = new Size(60, 25);

            cboStatus.Location = new Point(10, 142);
            cboStatus.Size = new Size(160, 28);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            

            lblFeedbackBaru.Text = "Tambah Feedback Baru:";
            lblFeedbackBaru.Location = new Point(190, 115);
            lblFeedbackBaru.Size = new Size(160, 25);

            txtFeedbackBaru.Location = new Point(190, 142);
            txtFeedbackBaru.Size = new Size(400, 27);
            txtFeedbackBaru.Multiline = true;
            txtFeedbackBaru.Height = 50;

            btnSimpan.Text = "Simpan";
            btnSimpan.Location = new Point(610, 142);
            btnSimpan.Size = new Size(140, 50);
            btnSimpan.Click += btnSimpan_Click;

            grpFeedback.Controls.Add(lstExistingFeedback);
            grpFeedback.Controls.Add(lblStatus);
            grpFeedback.Controls.Add(cboStatus);
            grpFeedback.Controls.Add(lblFeedbackBaru);
            grpFeedback.Controls.Add(txtFeedbackBaru);
            grpFeedback.Controls.Add(btnSimpan);

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 570);
            Text = "LOGTRACKER - Dashboard Coach";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(lblUserInfo);
            Controls.Add(lblPeserta);
            Controls.Add(cboPeserta);
            Controls.Add(btnRefresh);
            Controls.Add(btnLaporan);
            Controls.Add(dgvAktivitas);
            Controls.Add(lblNoData);
            Controls.Add(grpFeedback);
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            grpFeedback.ResumeLayout(false);
            grpFeedback.PerformLayout();
            ResumeLayout(false);
        }
    }
}
