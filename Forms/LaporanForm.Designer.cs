namespace Logtracker.Forms
{
    partial class LaporanForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblPeserta;
        private GroupBox grpKategoriDurasi;
        private DataGridView dgvKategoriDurasi;
        private GroupBox grpKategoriJumlah;
        private DataGridView dgvKategoriJumlah;
        private GroupBox grpTanggalDurasi;
        private DataGridView dgvTanggalDurasi;
        private GroupBox grpStatus;
        private DataGridView dgvStatus;
        private Button btnRefresh;
        private Button btnTutup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblPeserta = new Label();
            grpKategoriDurasi = new GroupBox();
            dgvKategoriDurasi = new DataGridView();
            grpKategoriJumlah = new GroupBox();
            dgvKategoriJumlah = new DataGridView();
            grpTanggalDurasi = new GroupBox();
            dgvTanggalDurasi = new DataGridView();
            grpStatus = new GroupBox();
            dgvStatus = new DataGridView();
            btnRefresh = new Button();
            btnTutup = new Button();
            grpKategoriDurasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategoriDurasi).BeginInit();
            grpKategoriJumlah.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKategoriJumlah).BeginInit();
            grpTanggalDurasi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTanggalDurasi).BeginInit();
            grpStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStatus).BeginInit();
            SuspendLayout();

            lblPeserta.Text = "Laporan Aktivitas";
            lblPeserta.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPeserta.Location = new Point(12, 12);
            lblPeserta.Size = new Size(760, 30);

            grpKategoriDurasi.Text = "Total Durasi per Kategori";
            grpKategoriDurasi.Location = new Point(12, 50);
            grpKategoriDurasi.Size = new Size(370, 200);

            dgvKategoriDurasi.Location = new Point(10, 25);
            dgvKategoriDurasi.Size = new Size(350, 165);
            dgvKategoriDurasi.ReadOnly = true;
            dgvKategoriDurasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategoriDurasi.AllowUserToAddRows = false;
            dgvKategoriDurasi.RowHeadersVisible = false;
            dgvKategoriDurasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grpKategoriJumlah.Text = "Jumlah per Kategori";
            grpKategoriJumlah.Location = new Point(402, 50);
            grpKategoriJumlah.Size = new Size(370, 200);

            dgvKategoriJumlah.Location = new Point(10, 25);
            dgvKategoriJumlah.Size = new Size(350, 165);
            dgvKategoriJumlah.ReadOnly = true;
            dgvKategoriJumlah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategoriJumlah.AllowUserToAddRows = false;
            dgvKategoriJumlah.RowHeadersVisible = false;
            dgvKategoriJumlah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grpTanggalDurasi.Text = "Total Durasi per Tanggal";
            grpTanggalDurasi.Location = new Point(12, 260);
            grpTanggalDurasi.Size = new Size(370, 200);

            dgvTanggalDurasi.Location = new Point(10, 25);
            dgvTanggalDurasi.Size = new Size(350, 165);
            dgvTanggalDurasi.ReadOnly = true;
            dgvTanggalDurasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTanggalDurasi.AllowUserToAddRows = false;
            dgvTanggalDurasi.RowHeadersVisible = false;
            dgvTanggalDurasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            grpStatus.Text = "Status Aktivitas";
            grpStatus.Location = new Point(402, 260);
            grpStatus.Size = new Size(370, 200);

            dgvStatus.Location = new Point(10, 25);
            dgvStatus.Size = new Size(350, 165);
            dgvStatus.ReadOnly = true;
            dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatus.AllowUserToAddRows = false;
            dgvStatus.RowHeadersVisible = false;
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(12, 475);
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Click += btnRefresh_Click;

            btnTutup.Text = "Tutup";
            btnTutup.Location = new Point(108, 475);
            btnTutup.Size = new Size(90, 30);
            btnTutup.Click += btnTutup_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 520);
            Text = "LOGTRACKER - Laporan";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            grpKategoriDurasi.Controls.Add(dgvKategoriDurasi);
            grpKategoriJumlah.Controls.Add(dgvKategoriJumlah);
            grpTanggalDurasi.Controls.Add(dgvTanggalDurasi);
            grpStatus.Controls.Add(dgvStatus);
            Controls.Add(lblPeserta);
            Controls.Add(grpKategoriDurasi);
            Controls.Add(grpKategoriJumlah);
            Controls.Add(grpTanggalDurasi);
            Controls.Add(grpStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnTutup);
            grpKategoriDurasi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKategoriDurasi).EndInit();
            grpKategoriJumlah.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKategoriJumlah).EndInit();
            grpTanggalDurasi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTanggalDurasi).EndInit();
            grpStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvStatus).EndInit();
            ResumeLayout(false);
        }
    }
}
