using Logtracker.Controllers;
using Logtracker.Helpers;
using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class OrtuDashboardForm : Form
    {
        private readonly OrtuDashboardController _controller;
        private readonly Profile _profile;
        private List<Profile> _anakList = [];

        public OrtuDashboardForm(OrtuDashboardController controller, Profile profile)
        {
            InitializeComponent();
            _controller = controller;
            _profile = profile;

            lblUserInfo.Text = $"Orang Tua: {_profile.Nama}";
            LoadAnak();
        }

        private void LoadAnak()
        {
            try
            {
                _anakList = _controller.GetDaftarAnak(_profile.Id);
                cboAnak.Items.Clear();
                foreach (var a in _anakList)
                    cboAnak.Items.Add($"{a.Nama} ({a.KodePeserta})");

                if (cboAnak.Items.Count > 0)
                {
                    cboAnak.SelectedIndex = 0;
                    lblNoData.Visible = false;
                }
                else
                {
                    dgvAktivitas.DataSource = null;
                    lblNoData.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data anak: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAnak_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboAnak.SelectedIndex < 0 || cboAnak.SelectedIndex >= _anakList.Count) return;
            lblNoData.Visible = false;
            LoadAktivitas(_anakList[cboAnak.SelectedIndex].Id);
        }

        private void LoadAktivitas(int pesertaId)
        {
            try
            {
                dgvAktivitas.DataSource = null;
                dgvAktivitas.DataSource = _controller.GetAktivitasAnak(pesertaId);
                dgvAktivitas.HideColumns("PesertaId", "StatusId", "KategoriId", "CreatedAt", "NamaPeserta", "AktivitasId", "Id");
                dgvAktivitas.SetHeader("NamaKategori", "Kategori");
                dgvAktivitas.SetHeader("NamaStatus", "Status");
                dgvAktivitas.SetHeader("UpdatedAt", "Di ubah pada");
                dgvAktivitas.SetDateFormat("Tanggal", "yyyy-MM-dd");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat aktivitas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHubungkan_Click(object? sender, EventArgs e)
        {
            var kode = ShowInputDialog("Masukkan kode peserta anak:", "Hubungkan Anak");
            if (string.IsNullOrWhiteSpace(kode)) return;

            var (success, msg) = _controller.ConnectAnak(_profile.Id, kode.Trim());
            MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            if (success) LoadAnak();
        }

        private void btnProfil_Click(object? sender, EventArgs e)
        {
            var app = Program.GetInstance();
            if (app == null) return;

            var form = new EditProfileForm(app.ProfileController, _profile.UserId);
            if (form.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(form.UpdatedNama))
            {
                _profile.Nama = form.UpdatedNama;
                lblUserInfo.Text = $"Orang Tua: {_profile.Nama}";
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e) => LoadAnak();

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            if (cboAnak.SelectedIndex < 0 || cboAnak.SelectedIndex >= _anakList.Count) return;
            var anak = _anakList[cboAnak.SelectedIndex];
            var app = Program.GetInstance();
            if (app == null) return;

            var form = new LaporanForm(app.LaporanController, anak.Id, anak.Nama);
            form.ShowDialog();
        }

        private void dgvAktivitas_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAktivitas.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                e.CellStyle.Font = new Font(dgvAktivitas.Font, FontStyle.Bold);
                e.CellStyle.ForeColor = e.Value.ToString() switch
                {
                    "Disetujui" => Color.Green,
                    "Revisi" => Color.OrangeRed,
                    _ => Color.Gray
                };
            }
        }

        private static string? ShowInputDialog(string prompt, string title)
        {
            var form = new Form();
            var label = new Label { Text = prompt, Location = new Point(12, 15), Size = new Size(350, 25) };
            var textBox = new TextBox { Location = new Point(12, 45), Size = new Size(350, 27) };
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

        private void dgvAktivitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
