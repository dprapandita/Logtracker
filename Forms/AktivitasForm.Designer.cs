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
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(25, 19);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(425, 38);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Aktivitas";
            // 
            // lblNama
            // 
            lblNama.Location = new Point(25, 75);
            lblNama.Margin = new Padding(4, 0, 4, 0);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(150, 31);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Aktivitas:";
            // 
            // txtNama
            // 
            txtNama.Location = new Point(25, 109);
            txtNama.Margin = new Padding(4, 4, 4, 4);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(424, 31);
            txtNama.TabIndex = 2;
            // 
            // lblKategori
            // 
            lblKategori.Location = new Point(25, 156);
            lblKategori.Margin = new Padding(4, 0, 4, 0);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(150, 31);
            lblKategori.TabIndex = 3;
            lblKategori.Text = "Kategori:";
            // 
            // cboKategori
            // 
            cboKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKategori.Location = new Point(25, 190);
            cboKategori.Margin = new Padding(4, 4, 4, 4);
            cboKategori.Name = "cboKategori";
            cboKategori.Size = new Size(249, 33);
            cboKategori.TabIndex = 4;
            // 
            // lblDurasi
            // 
            lblDurasi.Location = new Point(300, 156);
            lblDurasi.Margin = new Padding(4, 0, 4, 0);
            lblDurasi.Name = "lblDurasi";
            lblDurasi.Size = new Size(150, 31);
            lblDurasi.TabIndex = 5;
            lblDurasi.Text = "Durasi (menit):";
            // 
            // numDurasi
            // 
            numDurasi.Location = new Point(300, 190);
            numDurasi.Margin = new Padding(4, 4, 4, 4);
            numDurasi.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numDurasi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDurasi.Name = "numDurasi";
            numDurasi.Size = new Size(150, 31);
            numDurasi.TabIndex = 6;
            numDurasi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblTanggal
            // 
            lblTanggal.Location = new Point(25, 238);
            lblTanggal.Margin = new Padding(4, 0, 4, 0);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(150, 31);
            lblTanggal.TabIndex = 7;
            lblTanggal.Text = "Tanggal:";
            // 
            // dtpTanggal
            // 
            dtpTanggal.Format = DateTimePickerFormat.Short;
            dtpTanggal.Location = new Point(25, 271);
            dtpTanggal.Margin = new Padding(4, 4, 4, 4);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(249, 31);
            dtpTanggal.TabIndex = 8;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(25, 331);
            btnSimpan.Margin = new Padding(4, 4, 4, 4);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(200, 44);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Tambah";
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnBatal
            // 
            btnBatal.Location = new Point(250, 331);
            btnBatal.Margin = new Padding(4, 4, 4, 4);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(200, 44);
            btnBatal.TabIndex = 10;
            btnBatal.Text = "Batal";
            btnBatal.Click += btnBatal_Click;
            // 
            // AktivitasForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 400);
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
            Margin = new Padding(4, 4, 4, 4);
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
