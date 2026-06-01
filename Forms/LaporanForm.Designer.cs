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
            // 
            // lblPeserta
            // 
            lblPeserta.Font = new Font("Dungeon", 15.75F, FontStyle.Bold);
            lblPeserta.ForeColor = Color.FromArgb(55, 36, 20);
            lblPeserta.Location = new Point(10, 10);
            lblPeserta.Name = "lblPeserta";
            lblPeserta.Size = new Size(665, 25);
            lblPeserta.TabIndex = 0;
            lblPeserta.Text = "Laporan Aktivitas";
            // 
            // grpKategoriDurasi
            // 
            grpKategoriDurasi.Controls.Add(dgvKategoriDurasi);
            grpKategoriDurasi.FlatStyle = FlatStyle.Flat;
            grpKategoriDurasi.ForeColor = Color.FromArgb(55, 36, 20);
            grpKategoriDurasi.Location = new Point(10, 43);
            grpKategoriDurasi.Margin = new Padding(3, 2, 3, 2);
            grpKategoriDurasi.Name = "grpKategoriDurasi";
            grpKategoriDurasi.Padding = new Padding(3, 2, 3, 2);
            grpKategoriDurasi.Size = new Size(324, 170);
            grpKategoriDurasi.TabIndex = 1;
            grpKategoriDurasi.TabStop = false;
            grpKategoriDurasi.Text = "Total Durasi per Kategori";
            grpKategoriDurasi.Enter += grpKategoriDurasi_Enter;
            // 
            // dgvKategoriDurasi
            // 
            dgvKategoriDurasi.AllowUserToAddRows = false;
            dgvKategoriDurasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategoriDurasi.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvKategoriDurasi.GridColor = Color.FromArgb(213, 184, 147);
            dgvKategoriDurasi.Location = new Point(9, 22);
            dgvKategoriDurasi.Margin = new Padding(3, 2, 3, 2);
            dgvKategoriDurasi.Name = "dgvKategoriDurasi";
            dgvKategoriDurasi.ReadOnly = true;
            dgvKategoriDurasi.RowHeadersVisible = false;
            dgvKategoriDurasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKategoriDurasi.Size = new Size(306, 141);
            dgvKategoriDurasi.TabIndex = 0;
            dgvKategoriDurasi.CellContentClick += dgvKategoriDurasi_CellContentClick;
            // 
            // grpKategoriJumlah
            // 
            grpKategoriJumlah.Controls.Add(dgvKategoriJumlah);
            grpKategoriJumlah.FlatStyle = FlatStyle.Flat;
            grpKategoriJumlah.ForeColor = Color.FromArgb(55, 36, 20);
            grpKategoriJumlah.Location = new Point(352, 43);
            grpKategoriJumlah.Margin = new Padding(3, 2, 3, 2);
            grpKategoriJumlah.Name = "grpKategoriJumlah";
            grpKategoriJumlah.Padding = new Padding(3, 2, 3, 2);
            grpKategoriJumlah.Size = new Size(324, 170);
            grpKategoriJumlah.TabIndex = 2;
            grpKategoriJumlah.TabStop = false;
            grpKategoriJumlah.Text = "Jumlah per Kategori";
            // 
            // dgvKategoriJumlah
            // 
            dgvKategoriJumlah.AllowUserToAddRows = false;
            dgvKategoriJumlah.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategoriJumlah.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvKategoriJumlah.GridColor = Color.FromArgb(213, 184, 147);
            dgvKategoriJumlah.Location = new Point(9, 22);
            dgvKategoriJumlah.Margin = new Padding(3, 2, 3, 2);
            dgvKategoriJumlah.Name = "dgvKategoriJumlah";
            dgvKategoriJumlah.ReadOnly = true;
            dgvKategoriJumlah.RowHeadersVisible = false;
            dgvKategoriJumlah.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKategoriJumlah.Size = new Size(306, 141);
            dgvKategoriJumlah.TabIndex = 0;
            // 
            // grpTanggalDurasi
            // 
            grpTanggalDurasi.Controls.Add(dgvTanggalDurasi);
            grpTanggalDurasi.FlatStyle = FlatStyle.Flat;
            grpTanggalDurasi.ForeColor = Color.FromArgb(55, 36, 20);
            grpTanggalDurasi.Location = new Point(10, 221);
            grpTanggalDurasi.Margin = new Padding(3, 2, 3, 2);
            grpTanggalDurasi.Name = "grpTanggalDurasi";
            grpTanggalDurasi.Padding = new Padding(3, 2, 3, 2);
            grpTanggalDurasi.Size = new Size(324, 170);
            grpTanggalDurasi.TabIndex = 3;
            grpTanggalDurasi.TabStop = false;
            grpTanggalDurasi.Text = "Total Durasi per Tanggal";
            // 
            // dgvTanggalDurasi
            // 
            dgvTanggalDurasi.AllowUserToAddRows = false;
            dgvTanggalDurasi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTanggalDurasi.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvTanggalDurasi.GridColor = Color.FromArgb(213, 184, 147);
            dgvTanggalDurasi.Location = new Point(9, 22);
            dgvTanggalDurasi.Margin = new Padding(3, 2, 3, 2);
            dgvTanggalDurasi.Name = "dgvTanggalDurasi";
            dgvTanggalDurasi.ReadOnly = true;
            dgvTanggalDurasi.RowHeadersVisible = false;
            dgvTanggalDurasi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTanggalDurasi.Size = new Size(306, 141);
            dgvTanggalDurasi.TabIndex = 0;
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(dgvStatus);
            grpStatus.FlatStyle = FlatStyle.Flat;
            grpStatus.ForeColor = Color.FromArgb(55, 36, 20);
            grpStatus.Location = new Point(352, 221);
            grpStatus.Margin = new Padding(3, 2, 3, 2);
            grpStatus.Name = "grpStatus";
            grpStatus.Padding = new Padding(3, 2, 3, 2);
            grpStatus.Size = new Size(324, 170);
            grpStatus.TabIndex = 4;
            grpStatus.TabStop = false;
            grpStatus.Text = "Status Aktivitas";
            // 
            // dgvStatus
            // 
            dgvStatus.AllowUserToAddRows = false;
            dgvStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatus.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvStatus.GridColor = Color.FromArgb(213, 184, 147);
            dgvStatus.Location = new Point(9, 22);
            dgvStatus.Margin = new Padding(3, 2, 3, 2);
            dgvStatus.Name = "dgvStatus";
            dgvStatus.ReadOnly = true;
            dgvStatus.RowHeadersVisible = false;
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatus.Size = new Size(306, 141);
            dgvStatus.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(213, 184, 147);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.FromArgb(55, 36, 20);
            btnRefresh.Location = new Point(10, 403);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(79, 25);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnTutup
            // 
            btnTutup.BackColor = Color.FromArgb(213, 184, 147);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.ForeColor = Color.FromArgb(55, 36, 20);
            btnTutup.Location = new Point(94, 403);
            btnTutup.Margin = new Padding(3, 2, 3, 2);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(79, 25);
            btnTutup.TabIndex = 6;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += btnTutup_Click;
            // 
            // LaporanForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(686, 442);
            Controls.Add(lblPeserta);
            Controls.Add(grpKategoriDurasi);
            Controls.Add(grpKategoriJumlah);
            Controls.Add(grpTanggalDurasi);
            Controls.Add(grpStatus);
            Controls.Add(btnRefresh);
            Controls.Add(btnTutup);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LaporanForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LOGTRACKER - Laporan";
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
