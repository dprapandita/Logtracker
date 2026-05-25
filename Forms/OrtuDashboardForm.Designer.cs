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
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).BeginInit();
            SuspendLayout();

            lblUserInfo.Text = "Orang Tua";
            lblUserInfo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblUserInfo.Location = new Point(12, 12);
            lblUserInfo.Size = new Size(760, 30);

            lblAnak.Text = "Pilih Anak:";
            lblAnak.Location = new Point(12, 55);
            lblAnak.Size = new Size(100, 25);

            cboAnak.Location = new Point(12, 82);
            cboAnak.Size = new Size(350, 28);
            cboAnak.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAnak.SelectedIndexChanged += cboAnak_SelectedIndexChanged;

            btnHubungkan.Text = "Hubungkan Anak";
            btnHubungkan.Location = new Point(370, 80);
            btnHubungkan.Size = new Size(130, 30);
            btnHubungkan.Click += btnHubungkan_Click;

            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(506, 80);
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.Click += btnRefresh_Click;

            btnLaporan.Text = "Laporan";
            btnLaporan.Location = new Point(602, 80);
            btnLaporan.Size = new Size(90, 30);
            btnLaporan.Click += btnLaporan_Click;

            dgvAktivitas.Location = new Point(12, 120);
            dgvAktivitas.Size = new Size(760, 390);
            dgvAktivitas.ReadOnly = true;
            dgvAktivitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAktivitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAktivitas.AllowUserToAddRows = false;
            dgvAktivitas.RowHeadersVisible = false;
            dgvAktivitas.MultiSelect = false;
            dgvAktivitas.CellFormatting += dgvAktivitas_CellFormatting;

            lblNoData.Text = "Belum ada anak terhubung. Klik 'Hubungkan Anak' untuk menghubungkan.";
            lblNoData.Location = new Point(12, 300);
            lblNoData.Size = new Size(760, 25);
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Visible = false;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 525);
            Text = "LOGTRACKER - Dashboard Orang Tua";
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(lblUserInfo);
            Controls.Add(lblAnak);
            Controls.Add(cboAnak);
            Controls.Add(btnHubungkan);
            Controls.Add(btnRefresh);
            Controls.Add(btnLaporan);
            Controls.Add(dgvAktivitas);
            Controls.Add(lblNoData);
            ((System.ComponentModel.ISupportInitialize)dgvAktivitas).EndInit();
            ResumeLayout(false);
        }
    }
}
