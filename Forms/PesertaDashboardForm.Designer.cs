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
        private Button btnDetail;
        private Button btnLaporan;
        private Button btnProfil;
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
            btnDetail = new Button();
            btnLaporan = new Button();
            btnProfil = new Button();
            dgvAktivitas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.BackColor = Color.FromArgb(183, 160, 135);
            lblUserInfo.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.FromArgb(55, 36, 20);
            lblUserInfo.Location = new Point(10, 10);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(665, 25);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Peserta";
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(213, 184, 147);
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.ForeColor = Color.FromArgb(55, 36, 20);
            btnTambah.Location = new Point(10, 46);
            btnTambah.Margin = new Padding(3, 2, 3, 2);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(79, 30);
            btnTambah.TabIndex = 1;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(213, 184, 147);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.FromArgb(55, 36, 20);
            btnEdit.Location = new Point(94, 46);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(79, 30);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(213, 184, 147);
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.ForeColor = Color.FromArgb(55, 36, 20);
            btnHapus.Location = new Point(178, 46);
            btnHapus.Margin = new Padding(3, 2, 3, 2);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(79, 30);
            btnHapus.TabIndex = 3;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(213, 184, 147);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.FromArgb(55, 36, 20);
            btnRefresh.Location = new Point(262, 46);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(79, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPilihCoach
            // 
            btnPilihCoach.BackColor = Color.FromArgb(213, 184, 147);
            btnPilihCoach.FlatStyle = FlatStyle.Flat;
            btnPilihCoach.ForeColor = Color.FromArgb(55, 36, 20);
            btnPilihCoach.Location = new Point(429, 46);
            btnPilihCoach.Margin = new Padding(3, 2, 3, 2);
            btnPilihCoach.Name = "btnPilihCoach";
            btnPilihCoach.Size = new Size(114, 30);
            btnPilihCoach.TabIndex = 5;
            btnPilihCoach.Text = "Pilih Coach";
            btnPilihCoach.UseVisualStyleBackColor = false;
            btnPilihCoach.Click += btnPilihCoach_Click;
            // 
            // btnDetail
            // 
            btnDetail.BackColor = Color.FromArgb(213, 184, 147);
            btnDetail.FlatStyle = FlatStyle.Flat;
            btnDetail.ForeColor = Color.FromArgb(55, 36, 20);
            btnDetail.Location = new Point(558, 46);
            btnDetail.Margin = new Padding(3, 2, 3, 2);
            btnDetail.Name = "btnDetail";
            btnDetail.Size = new Size(88, 30);
            btnDetail.TabIndex = 6;
            btnDetail.Text = "Detail";
            btnDetail.UseVisualStyleBackColor = false;
            btnDetail.Click += btnDetail_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.FromArgb(213, 184, 147);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.ForeColor = Color.FromArgb(55, 36, 20);
            btnLaporan.Location = new Point(662, 46);
            btnLaporan.Margin = new Padding(3, 2, 3, 2);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(96, 30);
            btnLaporan.TabIndex = 7;
            btnLaporan.Text = "Laporan";
            btnLaporan.UseVisualStyleBackColor = false;
            btnLaporan.Click += btnLaporan_Click;
            //
            // btnProfil
            //
            btnProfil.BackColor = Color.FromArgb(213, 184, 147);
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.ForeColor = Color.FromArgb(55, 36, 20);
            btnProfil.Location = new Point(681, 9);
            btnProfil.Margin = new Padding(3, 2, 3, 2);
            btnProfil.Name = "btnProfil";
            btnProfil.Size = new Size(79, 28);
            btnProfil.TabIndex = 9;
            btnProfil.Text = "Profil";
            btnProfil.UseVisualStyleBackColor = false;
            btnProfil.Click += btnProfil_Click;
            //
            // dgvAktivitas
            //
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvAktivitas.ColumnHeadersHeight = 29;
            dgvAktivitas.GridColor = Color.FromArgb(213, 184, 147);
            dgvAktivitas.Location = new Point(10, 80);
            dgvAktivitas.Margin = new Padding(3, 2, 3, 2);
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.Name = "dgvAktivitas";
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.RowHeadersWidth = 51;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.Size = new Size(748, 434);
            dgvAktivitas.TabIndex = 8;
            dgvAktivitas.CellContentClick += dgvAktivitas_CellContentClick;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;
            // 
            // PesertaDashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(770, 525);
            Controls.Add(lblUserInfo);
            Controls.Add(btnTambah);
            Controls.Add(btnEdit);
            Controls.Add(btnHapus);
            Controls.Add(btnRefresh);
            Controls.Add(btnPilihCoach);
            Controls.Add(btnDetail);
            Controls.Add(btnLaporan);
            Controls.Add(btnProfil);
            Controls.Add(dgvAktivitas);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(64, 64, 64);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PesertaDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGTRACKER - Dashboard Peserta";
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            ResumeLayout(false);
        }
    }
}
