namespace Logtracker.Forms
{
    partial class AktivitasForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblNama;
        private TextBox txtNama;
        private Label lblKategori;
        private ComboBox cboKategori;
        private Label lblDurasi;
        private NumericUpDown numDurasi;
        private Label lblTanggal;
        private DateTimePicker dtpTanggal;
        private Button btnSimpan;
        private Button btnBatal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblNama = new Label();
            txtNama = new TextBox();
            lblKategori = new Label();
            cboKategori = new ComboBox();
            lblDurasi = new Label();
            numDurasi = new NumericUpDown();
            lblTanggal = new Label();
            dtpTanggal = new DateTimePicker();
            btnSimpan = new Button();
            btnBatal = new Button();
            ((System.ComponentModel.ISupportInitialize)numDurasi).BeginInit();
            SuspendLayout();

            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Aktivitas";

            lblNama.Location = new Point(20, 60);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(120, 25);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Aktivitas:";

            txtNama.Location = new Point(20, 87);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(340, 27);
            txtNama.TabIndex = 2;

            lblKategori.Location = new Point(20, 125);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(120, 25);
            lblKategori.TabIndex = 3;
            lblKategori.Text = "Kategori:";

            cboKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKategori.Location = new Point(20, 152);
            cboKategori.Name = "cboKategori";
            cboKategori.Size = new Size(200, 28);
            cboKategori.TabIndex = 4;

            lblDurasi.Location = new Point(240, 125);
            lblDurasi.Name = "lblDurasi";
            lblDurasi.Size = new Size(120, 25);
            lblDurasi.TabIndex = 5;
            lblDurasi.Text = "Durasi (menit):";

            numDurasi.Location = new Point(240, 152);
            numDurasi.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numDurasi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDurasi.Name = "numDurasi";
            numDurasi.Size = new Size(120, 27);
            numDurasi.TabIndex = 6;
            numDurasi.Value = new decimal(new int[] { 30, 0, 0, 0 });

            lblTanggal.Location = new Point(20, 190);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(120, 25);
            lblTanggal.TabIndex = 7;
            lblTanggal.Text = "Tanggal:";

            dtpTanggal.Format = DateTimePickerFormat.Short;
            dtpTanggal.Location = new Point(20, 217);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(200, 27);
            dtpTanggal.TabIndex = 8;

            btnSimpan.Location = new Point(20, 265);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(160, 35);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Tambah";
            btnSimpan.Click += btnSimpan_Click;

            btnBatal.Location = new Point(200, 265);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(160, 35);
            btnBatal.TabIndex = 10;
            btnBatal.Text = "Batal";
            btnBatal.Click += btnBatal_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 320);
            Controls.Add(lblTitle);
            Controls.Add(lblNama);
            Controls.Add(txtNama);
            Controls.Add(lblKategori);
            Controls.Add(cboKategori);
            Controls.Add(lblDurasi);
            Controls.Add(numDurasi);
            Controls.Add(lblTanggal);
            Controls.Add(dtpTanggal);
            Controls.Add(btnSimpan);
            Controls.Add(btnBatal);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AktivitasForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tambah Aktivitas";
            ((System.ComponentModel.ISupportInitialize)numDurasi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
