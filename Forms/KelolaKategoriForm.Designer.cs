namespace Logtracker.Forms
{
    partial class KelolaKategoriForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtNama;
        private Button btnTambah;
        private Button btnEdit;
        private Button btnHapus;
        private Button btnTutup;
        private DataGridView dgvKategori;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtNama = new TextBox();
            btnTambah = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnTutup = new Button();
            dgvKategori = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvKategori).BeginInit();
            SuspendLayout();

            lblTitle.Text = "Kelola Kategori Latihan";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 12);
            lblTitle.Size = new Size(460, 30);

            txtNama.Location = new Point(12, 50);
            txtNama.Size = new Size(280, 27);

            btnTambah.Text = "Tambah";
            btnTambah.Location = new Point(298, 48);
            btnTambah.Size = new Size(80, 30);
            btnTambah.Click += btnTambah_Click;

            dgvKategori.Location = new Point(12, 90);
            dgvKategori.Size = new Size(460, 250);
            dgvKategori.ReadOnly = true;
            dgvKategori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategori.AllowUserToAddRows = false;
            dgvKategori.RowHeadersVisible = false;
            dgvKategori.MultiSelect = false;

            btnEdit.Text = "Edit";
            btnEdit.Location = new Point(12, 350);
            btnEdit.Size = new Size(90, 30);
            btnEdit.Click += btnEdit_Click;

            btnHapus.Text = "Hapus";
            btnHapus.Location = new Point(108, 350);
            btnHapus.Size = new Size(90, 30);
            btnHapus.Click += btnHapus_Click;

            btnTutup.Text = "Tutup";
            btnTutup.Location = new Point(382, 350);
            btnTutup.Size = new Size(90, 30);
            btnTutup.Click += btnTutup_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 395);
            Text = "Kelola Kategori Latihan";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            Controls.Add(lblTitle);
            Controls.Add(txtNama);
            Controls.Add(btnTambah);
            Controls.Add(dgvKategori);
            Controls.Add(btnEdit);
            Controls.Add(btnHapus);
            Controls.Add(btnTutup);
            ((System.ComponentModel.ISupportInitialize)dgvKategori).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
