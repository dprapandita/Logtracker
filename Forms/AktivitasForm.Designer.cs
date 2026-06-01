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
            lblTitle.Font = new Font("Dungeon", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(18, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(298, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TAMBAH AKTIVITAS";
            lblTitle.Click += lblTitle_Click;
            // 
            // lblNama
            // 
            lblNama.ForeColor = Color.FromArgb(55, 36, 20);
            lblNama.Location = new Point(18, 51);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(105, 22);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama Aktivitas:";
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.FromArgb(111, 77, 56);
            txtNama.BorderStyle = BorderStyle.None;
            txtNama.ForeColor = Color.FromArgb(247, 235, 223);
            txtNama.Location = new Point(18, 74);
            txtNama.Margin = new Padding(3, 2, 3, 2);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(298, 17);
            txtNama.TabIndex = 2;
            // 
            // lblKategori
            // 
            lblKategori.ForeColor = Color.FromArgb(55, 36, 20);
            lblKategori.Location = new Point(18, 107);
            lblKategori.Name = "lblKategori";
            lblKategori.Size = new Size(105, 22);
            lblKategori.TabIndex = 3;
            lblKategori.Text = "Kategori:";
            lblKategori.Click += lblKategori_Click;
            // 
            // cboKategori
            // 
            cboKategori.BackColor = Color.FromArgb(111, 77, 56);
            cboKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKategori.FlatStyle = FlatStyle.Popup;
            cboKategori.ForeColor = Color.FromArgb(247, 235, 223);
            cboKategori.Location = new Point(18, 129);
            cboKategori.Margin = new Padding(3, 2, 3, 2);
            cboKategori.Name = "cboKategori";
            cboKategori.Size = new Size(176, 25);
            cboKategori.TabIndex = 4;
            // 
            // lblDurasi
            // 
            lblDurasi.ForeColor = Color.FromArgb(55, 36, 20);
            lblDurasi.Location = new Point(210, 107);
            lblDurasi.Name = "lblDurasi";
            lblDurasi.Size = new Size(105, 22);
            lblDurasi.TabIndex = 5;
            lblDurasi.Text = "Durasi (menit):";
            // 
            // numDurasi
            // 
            numDurasi.BackColor = Color.FromArgb(111, 77, 56);
            numDurasi.BorderStyle = BorderStyle.None;
            numDurasi.ForeColor = Color.FromArgb(247, 235, 223);
            numDurasi.Location = new Point(210, 129);
            numDurasi.Margin = new Padding(3, 2, 3, 2);
            numDurasi.Maximum = new decimal(new int[] { 1440, 0, 0, 0 });
            numDurasi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDurasi.Name = "numDurasi";
            numDurasi.Size = new Size(105, 20);
            numDurasi.TabIndex = 6;
            numDurasi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblTanggal
            // 
            lblTanggal.ForeColor = Color.FromArgb(55, 36, 20);
            lblTanggal.Location = new Point(18, 161);
            lblTanggal.Name = "lblTanggal";
            lblTanggal.Size = new Size(105, 22);
            lblTanggal.TabIndex = 7;
            lblTanggal.Text = "Tanggal:";
            // 
            // dtpTanggal
            // 
            dtpTanggal.CalendarForeColor = Color.FromArgb(111, 77, 56);
            dtpTanggal.CalendarMonthBackground = Color.FromArgb(111, 77, 56);
            dtpTanggal.CalendarTitleForeColor = Color.FromArgb(247, 235, 223);
            dtpTanggal.Format = DateTimePickerFormat.Short;
            dtpTanggal.Location = new Point(18, 185);
            dtpTanggal.Margin = new Padding(3, 2, 3, 2);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(176, 24);
            dtpTanggal.TabIndex = 8;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(213, 184, 147);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(18, 226);
            btnSimpan.Margin = new Padding(3, 2, 3, 2);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(140, 29);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Tambah";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(213, 184, 147);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Location = new Point(175, 226);
            btnBatal.Margin = new Padding(3, 2, 3, 2);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(140, 29);
            btnBatal.TabIndex = 10;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // AktivitasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(334, 272);
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
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
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
