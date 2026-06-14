namespace Logtracker.Forms
{
    partial class OrtuDashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblUserInfo;
        private Label lblAnak;
        private ComboBox cboAnak;
        private DataGridView dgvAktivitas;
        private Button btnHubungkan;
        private Label lblNoData;
        private Button btnRefresh;
        private Button btnLaporan;
        private Button btnProfil;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUserInfo = new Label();
            lblAnak = new Label();
            cboAnak = new ComboBox();
            dgvAktivitas = new DataGridView();
            btnHubungkan = new Button();
            lblNoData = new Label();
            btnRefresh = new Button();
            btnLaporan = new Button();
            btnProfil = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            SuspendLayout();
            // 
            // lblUserInfo
            // 
            lblUserInfo.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            lblUserInfo.ForeColor = Color.FromArgb(55, 36, 20);
            lblUserInfo.Location = new Point(10, 10);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(565, 36);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Orang Tua";
            // 
            // lblAnak
            // 
            lblAnak.ForeColor = Color.FromArgb(55, 36, 20);
            lblAnak.Location = new Point(10, 46);
            lblAnak.Name = "lblAnak";
            lblAnak.Size = new Size(88, 22);
            lblAnak.TabIndex = 1;
            lblAnak.Text = "Pilih Anak:";
            // 
            // cboAnak
            // 
            cboAnak.BackColor = Color.FromArgb(111, 77, 56);
            cboAnak.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAnak.FlatStyle = FlatStyle.Flat;
            cboAnak.ForeColor = Color.FromArgb(247, 235, 223);
            cboAnak.Location = new Point(10, 70);
            cboAnak.Margin = new Padding(3, 2, 3, 2);
            cboAnak.Name = "cboAnak";
            cboAnak.Size = new Size(307, 29);
            cboAnak.TabIndex = 2;
            cboAnak.SelectedIndexChanged += cboAnak_SelectedIndexChanged;
            // 
            // dgvAktivitas
            // 
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvAktivitas.ColumnHeadersHeight = 29;
            dgvAktivitas.GridColor = Color.FromArgb(213, 184, 147);
            dgvAktivitas.Location = new Point(10, 102);
            dgvAktivitas.Margin = new Padding(3, 2, 3, 2);
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.Name = "dgvAktivitas";
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.RowHeadersWidth = 51;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.Size = new Size(665, 331);
            dgvAktivitas.TabIndex = 6;
            dgvAktivitas.CellContentClick += dgvAktivitas_CellContentClick;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;
            // 
            // btnHubungkan
            // 
            btnHubungkan.BackColor = Color.FromArgb(213, 184, 147);
            btnHubungkan.FlatStyle = FlatStyle.Flat;
            btnHubungkan.ForeColor = Color.FromArgb(55, 36, 20);
            btnHubungkan.Location = new Point(324, 68);
            btnHubungkan.Margin = new Padding(3, 2, 3, 2);
            btnHubungkan.Name = "btnHubungkan";
            btnHubungkan.Size = new Size(114, 27);
            btnHubungkan.TabIndex = 3;
            btnHubungkan.Text = "Hubungkan Anak";
            btnHubungkan.UseVisualStyleBackColor = false;
            btnHubungkan.Click += btnHubungkan_Click;
            // 
            // lblNoData
            // 
            lblNoData.Location = new Point(10, 255);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(665, 22);
            lblNoData.TabIndex = 7;
            lblNoData.Text = "Belum ada anak terhubung. Klik 'Hubungkan Anak' untuk menghubungkan.";
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(213, 184, 147);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.ForeColor = Color.FromArgb(55, 36, 20);
            btnRefresh.Location = new Point(443, 68);
            btnRefresh.Margin = new Padding(3, 2, 3, 2);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(79, 27);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.FromArgb(213, 184, 147);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.ForeColor = Color.FromArgb(55, 36, 20);
            btnLaporan.Location = new Point(527, 68);
            btnLaporan.Margin = new Padding(3, 2, 3, 2);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(79, 27);
            btnLaporan.TabIndex = 5;
            btnLaporan.Text = "Laporan";
            btnLaporan.UseVisualStyleBackColor = false;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnProfil
            // 
            btnProfil.BackColor = Color.FromArgb(213, 184, 147);
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.ForeColor = Color.FromArgb(55, 36, 20);
            btnProfil.Location = new Point(581, 11);
            btnProfil.Margin = new Padding(3, 2, 3, 2);
            btnProfil.Name = "btnProfil";
            btnProfil.Size = new Size(95, 30);
            btnProfil.TabIndex = 8;
            btnProfil.Text = "Profil";
            btnProfil.UseVisualStyleBackColor = false;
            btnProfil.Click += btnProfil_Click;
            // 
            // OrtuDashboardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(686, 447);
            Controls.Add(lblUserInfo);
            Controls.Add(lblAnak);
            Controls.Add(cboAnak);
            Controls.Add(btnHubungkan);
            Controls.Add(btnRefresh);
            Controls.Add(btnLaporan);
            Controls.Add(btnProfil);
            Controls.Add(dgvAktivitas);
            Controls.Add(lblNoData);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(64, 64, 64);
            Margin = new Padding(3, 2, 3, 2);
            Name = "OrtuDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGTRACKER - Dashboard Orang Tua";
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            ResumeLayout(false);
        }
    }
}
