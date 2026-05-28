using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class AktivitasForm : Form
    {
        public Aktivitas? Aktivitas { get; private set; }
        public bool IsEdit { get; private set; }

        public AktivitasForm()
        {
            InitializeComponent();
            //cboKategori.SelectedIndex = 0;
            dtpTanggal.Value = DateTime.Today;
            numDurasi.Value = 30;
        }

        public AktivitasForm(Aktivitas aktivitas) : this()
        {
            IsEdit = true;
            Aktivitas = aktivitas;
            txtNama.Text = aktivitas.Nama;
            cboKategori.SelectedItem = aktivitas.Kategori;
            numDurasi.Value = aktivitas.Durasi;
            dtpTanggal.Value = aktivitas.Tanggal;
            btnSimpan.Text = "Simpan";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("Nama aktivitas tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return false;
            }
            if (cboKategori.SelectedItem == null)
            {
                MessageBox.Show("Pilih kategori.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((int)numDurasi.Value <= 0)
            {
                MessageBox.Show("Durasi harus lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Aktivitas = new Aktivitas
            {
                Id = Aktivitas?.Id ?? 0,
                Nama = txtNama.Text.Trim(),
                Kategori = cboKategori.SelectedItem.ToString()!,
                Durasi = (int)numDurasi.Value,
                Tanggal = dtpTanggal.Value
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnBatal_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
