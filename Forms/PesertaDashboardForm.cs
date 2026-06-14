using Logtracker.Controllers;
using Logtracker.Helpers;
using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class PesertaDashboardForm : Form
    {
        private readonly PesertaDashboardController _controller;
        private readonly Profile _profile;

        public PesertaDashboardForm(PesertaDashboardController controller, Profile profile)
        {
            InitializeComponent();
            _controller = controller;
            _profile = profile;

            RefreshUserInfo();
            LoadData();
        }

        private void RefreshUserInfo()
        {
            var kode = string.IsNullOrEmpty(_profile.KodePeserta) ? "(belum ada)" : _profile.KodePeserta;
            lblUserInfo.Text = $"{_profile.Nama} | Kode: {kode}";
        }

        private void btnProfil_Click(object? sender, EventArgs e)
        {
            var app = Program.GetInstance();
            if (app == null) return;

            var form = new EditProfileForm(app.ProfileController, _profile.UserId);
            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(form.UpdatedNama))
            {
                _profile.Nama = form.UpdatedNama;
                RefreshUserInfo();
            }
        }

        private void LoadData()
        {
            try
            {
                dgvAktivitas.DataSource = null;
                dgvAktivitas.DataSource = _controller.GetAktivitas(_profile.Id);
                dgvAktivitas.HideColumns("PesertaId", "CreatedAt", "UpdatedAt", "KategoriId", "StatusId", "NamaPeserta", "Id");
                dgvAktivitas.SetHeader("NamaKategori", "Kategori");
                dgvAktivitas.SetHeader("NamaStatus", "Status");
                dgvAktivitas.SetDateFormat("Tanggal", "yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambah_Click(object? sender, EventArgs e)
        {
            var app = Program.GetInstance();
            if (app == null) return;

            var form = new AktivitasForm(app.KategoriController);
            if (form.ShowDialog() == DialogResult.OK && form.Aktivitas != null)
            {
                form.Aktivitas.PesertaId = _profile.Id;
                var (success, msg) = _controller.AddAktivitas(form.Aktivitas);
                MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success) LoadData();
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvAktivitas.CurrentRow == null)
            {
                MessageBox.Show("Pilih aktivitas yang akan diedit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvAktivitas.CurrentRow.DataBoundItem as Aktivitas;
            if (selected == null) return;

            if (selected.StatusId == 2)
            {
                MessageBox.Show($"Aktivitas berstatus \"{selected.NamaStatus}\" tidak dapat diedit.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var app = Program.GetInstance();
            if (app == null) return;

            var form = new AktivitasForm(selected, app.KategoriController);
            if (form.ShowDialog() == DialogResult.OK && form.Aktivitas != null)
            {
                form.Aktivitas.Id = selected.Id;
                form.Aktivitas.PesertaId = _profile.Id;
                form.Aktivitas.StatusId = selected.StatusId;
                var (success, msg) = _controller.UpdateAktivitas(form.Aktivitas);
                MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success) LoadData();
            }
        }

        private void btnHapus_Click(object? sender, EventArgs e)
        {
            if (dgvAktivitas.CurrentRow == null)
            {
                MessageBox.Show("Pilih aktivitas yang akan dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvAktivitas.CurrentRow.DataBoundItem as Aktivitas;
            if (selected == null) return;

            if (selected.StatusId == 2)
            {
                MessageBox.Show($"Aktivitas berstatus \"{selected.NamaStatus}\" tidak dapat dihapus.", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Hapus aktivitas \"{selected.Nama}\"?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var (success, msg) = _controller.DeleteAktivitas(selected.Id);
                MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success) LoadData();
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e) => LoadData();

        private void btnPilihCoach_Click(object? sender, EventArgs e)
        {
            var coachList = _controller.GetCoachList();

            if (coachList.Count == 0)
            {
                MessageBox.Show("Belum ada coach terdaftar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var names = coachList.Select(c => c.Nama).ToArray();
            var selected = InputComboBox("Pilih Coach", "Pilih coach Anda:", names);
            if (selected >= 0)
            {
                var (success, msg) = _controller.PilihCoach(_profile.Id, coachList[selected].Id);
                MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }

        private void btnDetail_Click(object? sender, EventArgs e)
        {
            if (dgvAktivitas.CurrentRow == null)
            {
                MessageBox.Show("Pilih aktivitas terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selected = dgvAktivitas.CurrentRow.DataBoundItem as Aktivitas;
            if (selected == null) return;

            var app = Program.GetInstance();
            if (app == null) return;

            var form = new DetailAktivitasForm(selected, app.DetailAktivitasController);
            form.ShowDialog();
        }

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            var app = Program.GetInstance();
            if (app == null) return;

            var form = new LaporanForm(app.LaporanController, _profile.Id, _profile.Nama);
            form.ShowDialog();
        }

        private void dgvAktivitas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAktivitas.Columns[e.ColumnIndex].Name == "NamaStatus" && e.Value != null)
            {
                e.CellStyle.Font = new Font(dgvAktivitas.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = e.Value.ToString() switch
                {
                    "Disetujui" => Color.Green,
                    "Revisi" => Color.OrangeRed,
                    _ => Color.Black
                };
            }
        }

        private static int InputComboBox(string title, string prompt, string[] items)
        {
            var form = new Form();
            var label = new Label { Text = prompt, Location = new Point(12, 15), Size = new Size(350, 25) };
            var combo = new ComboBox { Location = new Point(12, 45), Size = new Size(350, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            combo.Items.AddRange(items);
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            var btnOk = new Button { Text = "OK", Location = new Point(12, 85), Size = new Size(160, 30), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Batal", Location = new Point(202, 85), Size = new Size(160, 30), DialogResult = DialogResult.Cancel };

            form.Text = title;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ClientSize = new Size(374, 130);
            form.Controls.AddRange([label, combo, btnOk, btnCancel]);
            form.AcceptButton = btnOk;
            form.CancelButton = btnCancel;

            return form.ShowDialog() == DialogResult.OK ? combo.SelectedIndex : -1;
        }

        private void dgvAktivitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
