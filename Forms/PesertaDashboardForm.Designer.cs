namespace Logtracker.Forms
{
    partial class PesertaDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUserInfo;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnRefresh;
        private Button btnPilihCoach;
        private Button btnFeedback;
        private Button btnLaporan;
        private DataGridView dgvAktivitas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUserInfo = new Label();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnRefresh = new Button();
            btnPilihCoach = new Button();
            btnFeedback = new Button();
            btnLaporan = new Button();
            dgvAktivitas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            SuspendLayout();

            lblUserInfo.Text = "Peserta";
            lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserInfo.Location = new Point(12, 12);
            lblUserInfo.Size = new Size(760, 30);

            btnTambah.Text = "Tambah";
            btnTambah.Location = new Point(12, 55);
            btnTambah.Size = new Size(90, 30);
            btnTambah.Click += btnTambah_Click;

            btnEdit.Text = "Edit";
            btnEdit.Location = new Point(108, 55);
            btnEdit.Size = new Size(90, 30);
            btnEdit.Click += btnEdit_Click;

            btnHapus.Text = "Hapus";
            btnHapus.Location = new Point(204, 55);
            btnHapus.Size = new Size(90, 30);
            btnHapus.Click += btnHapus_Click;

            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(300, 55);
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Click += btnRefresh_Click;

            btnPilihCoach.Text = "Pilih Coach";
            btnPilihCoach.Location = new Point(420, 55);
            btnPilihCoach.Size = new Size(130, 30);
            btnPilihCoach.Click += btnPilihCoach_Click;

            btnFeedback.Text = "Feedback";
            btnFeedback.Location = new Point(556, 55);
            btnFeedback.Size = new Size(100, 30);
            btnFeedback.Click += btnFeedback_Click;

            btnLaporan.Text = "Laporan";
            btnLaporan.Location = new Point(662, 55);
            btnLaporan.Size = new Size(110, 30);
            btnLaporan.Click += btnLaporan_Click;

            dgvAktivitas.Location = new Point(12, 95);
            dgvAktivitas.Size = new Size(760, 430);
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 540);
            Text = "LOGTRACKER - Dashboard Peserta";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(lblUserInfo);
            Controls.Add(btnTambah);
            Controls.Add(btnEdit);
            Controls.Add(btnHapus);
            Controls.Add(btnRefresh);
            Controls.Add(btnPilihCoach);
            Controls.Add(btnFeedback);
            Controls.Add(btnLaporan);
            Controls.Add(dgvAktivitas);
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            ResumeLayout(false);
        }
    }
}
