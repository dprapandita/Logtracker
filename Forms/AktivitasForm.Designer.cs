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

            lblTitle.Text = "Aktivitas";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(340, 30);

            lblNama.Text = "Nama Aktivitas:";
            lblNama.Location = new Point(20, 60);
            lblNama.Size = new Size(120, 25);

            txtNama.Location = new Point(20, 87);
            txtNama.Size = new Size(340, 27);

            lblKategori.Text = "Kategori:";
            lblKategori.Location = new Point(20, 125);
            lblKategori.Size = new Size(120, 25);

            cboKategori.Location = new Point(20, 152);
            cboKategori.Size = new Size(200, 28);
            cboKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            //cboKategori.Items.AddRange(["Belajar", "Coding", "Olahraga", "Organisasi", "Hiburan", "Lainnya"]);

            lblDurasi.Text = "Durasi (menit):";
            lblDurasi.Location = new Point(240, 125);
            lblDurasi.Size = new Size(120, 25);

            numDurasi.Location = new Point(240, 152);
            numDurasi.Size = new Size(120, 27);
            numDurasi.Minimum = 1;
            numDurasi.Maximum = 1440;

            lblTanggal.Text = "Tanggal:";
            lblTanggal.Location = new Point(20, 190);
            lblTanggal.Size = new Size(120, 25);

            dtpTanggal.Location = new Point(20, 217);
            dtpTanggal.Size = new Size(200, 27);
            dtpTanggal.Format = DateTimePickerFormat.Short;

            btnSimpan.Text = "Tambah";
            btnSimpan.Location = new Point(20, 265);
            btnSimpan.Size = new Size(160, 35);
            btnSimpan.Click += btnSimpan_Click;

            btnBatal.Text = "Batal";
            btnBatal.Location = new Point(200, 265);
            btnBatal.Size = new Size(160, 35);
            btnBatal.Click += btnBatal_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 320);
            Text = "Tambah Aktivitas";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

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
            ((System.ComponentModel.ISupportInitialize)numDurasi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
