using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class KelolaKategoriForm : Form
    {
        private readonly KategoriService _service;

        public KelolaKategoriForm(KategoriService service)
        {
            InitializeComponent();
            _service = service;
            dgvKategori.DataBindingComplete += DgvKategori_DataBindingComplete;
            LoadData();
        }

        private void DgvKategori_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvKategori.Columns["Id"] != null)
            {
                dgvKategori.Columns["Id"].Width = 50;
                dgvKategori.Columns["NamaLatihan"].HeaderText = "Nama Latihan";
            }
        }

        private void LoadData()
        {
            dgvKategori.DataSource = null;
            dgvKategori.DataSource = _service.GetAll();
        }

        private void btnTambah_Click(object? sender, EventArgs e)
        {
            var nama = txtNama.Text.Trim();
            if (string.IsNullOrWhiteSpace(nama))
            {
                MessageBox.Show("Masukkan nama kategori.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var (success, msg) = _service.Add(nama);
            MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (success)
            {
                txtNama.Clear();
                txtNama.Focus();
                LoadData();
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvKategori.CurrentRow == null)
            {
                MessageBox.Show("Pilih kategori yang akan diedit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvKategori.CurrentRow.DataBoundItem as KategoriLatihan;
            if (selected == null) return;

            var result = ShowInputDialog("Edit nama kategori:", "Edit Kategori", selected.NamaLatihan);
            if (result == null) return;

            var (success, msg) = _service.Update(selected.Id, result);
            MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (success) LoadData();
        }

        private void btnHapus_Click(object? sender, EventArgs e)
        {
            if (dgvKategori.CurrentRow == null)
            {
                MessageBox.Show("Pilih kategori yang akan dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvKategori.CurrentRow.DataBoundItem as KategoriLatihan;
            if (selected == null) return;

            var confirm = MessageBox.Show($"Hapus kategori \"{selected.NamaLatihan}\"?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            var (success, msg) = _service.Delete(selected.Id);
            MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (success) LoadData();
        }

        private void btnTutup_Click(object? sender, EventArgs e) => Close();

        private static string? ShowInputDialog(string prompt, string title, string defaultValue = "")
        {
            var form = new Form();
            var label = new Label { Text = prompt, Location = new Point(12, 15), Size = new Size(350, 25) };
            var textBox = new TextBox { Location = new Point(12, 45), Size = new Size(350, 27), Text = defaultValue };
            var btnOk = new Button { Text = "OK", Location = new Point(12, 85), Size = new Size(160, 30), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Batal", Location = new Point(202, 85), Size = new Size(160, 30), DialogResult = DialogResult.Cancel };

            form.Text = title;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ClientSize = new Size(374, 130);
            form.Controls.AddRange([label, textBox, btnOk, btnCancel]);
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? textBox.Text.Trim() : null;
        }

        private void txtNama_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvKategori_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
