using Logtracker.Controllers;
using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class AktivitasForm : Form
    {
        public Aktivitas? Aktivitas { get; private set; }
        public bool IsEdit { get; private set; }
        private readonly KategoriController? _kategoriController;

        public AktivitasForm() : this(Program.GetInstance()?.KategoriController)
        {
        }

        public AktivitasForm(KategoriController? kategoriController)
        {
            InitializeComponent();
            _kategoriController = kategoriController;
            LoadKategori();
            dtpTanggal.Value = DateTime.Today;
            numDurasi.Value = 30;
        }

        public AktivitasForm(Aktivitas aktivitas) : this(Program.GetInstance()?.KategoriController, aktivitas)
        {
        }

        public AktivitasForm(Aktivitas aktivitas, KategoriController kategoriController) : this(kategoriController, aktivitas)
        {
        }

        private AktivitasForm(KategoriController? kategoriController, Aktivitas aktivitas) : this(kategoriController)
        {
            IsEdit = true;
            Aktivitas = aktivitas;
            txtNama.Text = aktivitas.Nama;

            var target = aktivitas.NamaKategori?.Trim() ?? "";
            var matchedIndex = -1;
            for (int i = 0; i < cboKategori.Items.Count; i++)
            {
                if (cboKategori.Items[i] is KategoriLatihan k &&
                    string.Equals(k.NamaLatihan?.Trim(), target, StringComparison.OrdinalIgnoreCase))
                {
                    matchedIndex = i;
                    break;
                }
            }
            cboKategori.SelectedIndex = matchedIndex;

            numDurasi.Value = aktivitas.Durasi;
            dtpTanggal.Value = aktivitas.Tanggal;
            btnSimpan.Text = "Simpan";
        }

        private void LoadKategori()
        {
            try
            {
                if (_kategoriController == null)
                {
                    MessageBox.Show("Controller tidak tersedia.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var list = _kategoriController.GetAll();
                cboKategori.Items.Clear();
                cboKategori.DisplayMember = "NamaLatihan";
                foreach (var k in list)
                    cboKategori.Items.Add(k);

                if (cboKategori.Items.Count > 0)
                    cboKategori.SelectedIndex = 0;
                else
                {
                    MessageBox.Show("Belum ada kategori. Tambahkan kategori terlebih dahulu.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat kategori: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                numDurasi.Focus();
                return false;
            }
            return true;
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var selectedKategori = cboKategori.SelectedItem as KategoriLatihan;
            Aktivitas = new Aktivitas
            {
                Id = Aktivitas?.Id ?? 0,
                Nama = txtNama.Text.Trim(),
                KategoriId = selectedKategori?.Id ?? 0,
                NamaKategori = selectedKategori?.NamaLatihan ?? "",
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

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblKategori_Click(object sender, EventArgs e)
        {

        }
    }
}
