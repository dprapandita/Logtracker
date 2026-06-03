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
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(402, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Kelola Kategori Latihan";
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.FromArgb(111, 77, 56);
            txtNama.ForeColor = Color.FromArgb(247, 235, 223);
            txtNama.Location = new Point(9, 41);
            txtNama.Margin = new Padding(3, 2, 3, 2);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(246, 28);
            txtNama.TabIndex = 1;
            txtNama.TextChanged += txtNama_TextChanged;
            // 
            // btnTambah
            // 
            btnTambah.BackColor = Color.FromArgb(213, 184, 147);
            btnTambah.FlatStyle = FlatStyle.Flat;
            btnTambah.ForeColor = Color.FromArgb(55, 36, 20);
            btnTambah.Location = new Point(261, 41);
            btnTambah.Margin = new Padding(3, 2, 3, 2);
            btnTambah.Name = "btnTambah";
            btnTambah.Size = new Size(70, 28);
            btnTambah.TabIndex = 2;
            btnTambah.Text = "Tambah";
            btnTambah.UseVisualStyleBackColor = false;
            btnTambah.Click += btnTambah_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(213, 184, 147);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.FromArgb(55, 36, 20);
            btnEdit.Location = new Point(10, 297);
            btnEdit.Margin = new Padding(3, 2, 3, 2);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(79, 32);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnHapus
            // 
            btnHapus.BackColor = Color.FromArgb(213, 184, 147);
            btnHapus.FlatStyle = FlatStyle.Flat;
            btnHapus.ForeColor = Color.FromArgb(55, 36, 20);
            btnHapus.Location = new Point(94, 297);
            btnHapus.Margin = new Padding(3, 2, 3, 2);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(79, 32);
            btnHapus.TabIndex = 5;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = false;
            btnHapus.Click += btnHapus_Click;
            // 
            // btnTutup
            // 
            btnTutup.BackColor = Color.FromArgb(213, 184, 147);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.ForeColor = Color.FromArgb(55, 36, 20);
            btnTutup.Location = new Point(334, 297);
            btnTutup.Margin = new Padding(3, 2, 3, 2);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(79, 32);
            btnTutup.TabIndex = 6;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += btnTutup_Click;
            // 
            // dgvKategori
            // 
            dgvKategori.AllowUserToAddRows = false;
            dgvKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKategori.BackgroundColor = Color.FromArgb(111, 77, 56);
            dgvKategori.ColumnHeadersHeight = 29;
            dgvKategori.GridColor = Color.FromArgb(213, 184, 147);
            dgvKategori.Location = new Point(10, 77);
            dgvKategori.Margin = new Padding(3, 2, 3, 2);
            dgvKategori.MultiSelect = false;
            dgvKategori.Name = "dgvKategori";
            dgvKategori.ReadOnly = true;
            dgvKategori.RowHeadersVisible = false;
            dgvKategori.RowHeadersWidth = 51;
            dgvKategori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKategori.Size = new Size(402, 213);
            dgvKategori.TabIndex = 3;
            dgvKategori.CellContentClick += dgvKategori_CellContentClick;
            // 
            // KelolaKategoriForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(424, 335);
            Controls.Add(lblTitle);
            Controls.Add(txtNama);
            Controls.Add(btnTambah);
            Controls.Add(dgvKategori);
            Controls.Add(btnEdit);
            Controls.Add(btnHapus);
            Controls.Add(btnTutup);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "KelolaKategoriForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Kelola Kategori Latihan";
            ((System.ComponentModel.ISupportInitialize)dgvKategori).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
