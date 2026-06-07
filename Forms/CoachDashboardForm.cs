using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class CoachDashboardForm : Form
    {
        private readonly CoachService _coachService;
        private readonly LaporanService _laporanService;
        private readonly StatusService _statusService;
        private readonly Profile _profile;
        private List<Profile> _pesertaList = [];
        private List<StatusAktivitas> _statusList = [];
        private int _selectedAktivitasId;

        public CoachDashboardForm(CoachService coachService, LaporanService laporanService, StatusService statusService, Profile profile)
        {
            InitializeComponent();
            _coachService = coachService;
            _laporanService = laporanService;
            _statusService = statusService;
            _profile = profile;

            lblUserInfo.Text = $"Coach: {_profile.Nama}";
            LoadStatusList();
            LoadPeserta();
        }

        private void LoadStatusList()
        {
            _statusList = _statusService.GetAll();
            cboStatus.Items.Clear();
            foreach (var s in _statusList)
                cboStatus.Items.Add(s);
            cboStatus.DisplayMember = nameof(StatusAktivitas.Nama);
        }

        private void LoadPeserta()
        {
            try
            {
                _pesertaList = _coachService.GetPesertaList(_profile.Id);
                cboPeserta.Items.Clear();
                foreach (var p in _pesertaList)
                    cboPeserta.Items.Add($"{p.Nama} ({p.KodePeserta})");

                if (cboPeserta.Items.Count > 0)
                {
                    cboPeserta.SelectedIndex = 0;
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
                MessageBox.Show($"Gagal memuat peserta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboPeserta_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cboPeserta.SelectedIndex < 0 || cboPeserta.SelectedIndex >= _pesertaList.Count) return;
            lblNoData.Visible = false;
            LoadAktivitas(_pesertaList[cboPeserta.SelectedIndex].Id);
        }

        private void LoadAktivitas(int pesertaId)
        {
            try
            {
                dgvAktivitas.DataSource = null;
                dgvAktivitas.DataSource = _coachService.GetAktivitasPeserta(pesertaId);
                if (dgvAktivitas.Columns["PesertaId"] != null) dgvAktivitas.Columns["PesertaId"].Visible = false;
                if (dgvAktivitas.Columns["KategoriId"] != null) dgvAktivitas.Columns["KategoriId"].Visible = false;
                if (dgvAktivitas.Columns["StatusId"] != null) dgvAktivitas.Columns["StatusId"].Visible = false;
                if (dgvAktivitas.Columns["CreatedAt"] != null) dgvAktivitas.Columns["CreatedAt"].Visible = false;
                if (dgvAktivitas.Columns["UpdatedAt"] != null) dgvAktivitas.Columns["UpdatedAt"].Visible = false;
                if (dgvAktivitas.Columns["NamaPeserta"] != null) dgvAktivitas.Columns["NamaPeserta"].Visible = false;
                if (dgvAktivitas.Columns["Tanggal"] != null)
                    dgvAktivitas.Columns["Tanggal"].DefaultCellStyle.Format = "yyyy-MM-dd";

                ClearFeedbackPanel();

                if (dgvAktivitas.Rows.Count > 0)
                {
                    dgvAktivitas.CurrentCell = dgvAktivitas.Rows[0].Cells[0];
                    dgvAktivitas.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat aktivitas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFeedbackPanel()
        {
            _selectedAktivitasId = 0;
            cboStatus.SelectedIndex = -1;
            txtFeedbackBaru.Clear();
            lstExistingFeedback.Items.Clear();
        }

        private void dgvAktivitas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvAktivitas.CurrentRow == null) return;

            var selected = dgvAktivitas.CurrentRow.DataBoundItem as Aktivitas;
            if (selected == null) return;

            _selectedAktivitasId = selected.Id;
            cboStatus.SelectedItem = _statusList.FirstOrDefault(s => s.Id == selected.StatusId);
            LoadExistingFeedback(selected.Id);
        }

        private void LoadExistingFeedback(int aktivitasId)
        {
            lstExistingFeedback.Items.Clear();
            try
            {
                var feedbackList = _coachService.GetFeedbackByAktivitas(aktivitasId);
                foreach (var fb in feedbackList)
                {
                    lstExistingFeedback.Items.Add($"[{fb.CreatedAt:dd-MM-yyyy HH:mm}] {fb.NamaCoach}: {fb.Feedback}");
                }
            }
            catch
            {
                // silently ignore feedback load errors
            }
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (_selectedAktivitasId == 0 && dgvAktivitas.CurrentRow?.DataBoundItem is Aktivitas current)
            {
                _selectedAktivitasId = current.Id;
            }

            if (_selectedAktivitasId == 0)
            {
                MessageBox.Show("Pilih aktivitas terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hasError = false;

            if (cboStatus.SelectedItem is StatusAktivitas selectedStatus)
            {
                var (suc1, msg1) = _coachService.UpdateStatus(_selectedAktivitasId, selectedStatus.Id);
                if (!suc1)
                {
                    MessageBox.Show(msg1, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasError = true;
                }
            }

            var feedbackText = txtFeedbackBaru.Text.Trim();
            if (!string.IsNullOrWhiteSpace(feedbackText))
            {
                var (suc2, msg2) = _coachService.SaveFeedback(_selectedAktivitasId, _profile.Id, feedbackText);
                if (!suc2)
                {
                    MessageBox.Show(msg2, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasError = true;
                }
                else
                {
                    txtFeedbackBaru.Clear();
                }
            }

            if (!hasError)
                MessageBox.Show("Status dan feedback berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (cboPeserta.SelectedIndex >= 0 && cboPeserta.SelectedIndex < _pesertaList.Count)
                LoadAktivitas(_pesertaList[cboPeserta.SelectedIndex].Id);
        }

        private void btnKelolaKategori_Click(object? sender, EventArgs e)
        {
            var app = Program.GetInstance();
            if (app == null) return;
            var form = new KelolaKategoriForm(app.GetKategoriService());
            form.ShowDialog();
        }

        private void btnPilihPeserta_Click(object? sender, EventArgs e)
        {
            try
            {
                var allPeserta = _coachService.GetAllPeserta();
                if (allPeserta.Count == 0)
                {
                    MessageBox.Show("Belum ada peserta terdaftar.", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var labels = allPeserta
                    .Select(p => string.IsNullOrEmpty(p.KodePeserta)
                        ? p.Nama
                        : $"{p.Nama} ({p.KodePeserta})")
                    .ToArray();

                var selected = ShowInputComboBox("Pilih Peserta",
                    "Pilih peserta yang ingin Anda bimbing:", labels);
                if (selected < 0) return;

                var peserta = allPeserta[selected];
                var (success, msg) = _coachService.AddPeserta(_profile.Id, peserta.Id);
                MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                    MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (success) LoadPeserta();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static int ShowInputComboBox(string title, string prompt, string[] items)
        {
            var form = new Form();
            var label = new Label { Text = prompt, Location = new Point(12, 15), Size = new Size(350, 25) };
            var combo = new ComboBox
            {
                Location = new Point(12, 45),
                Size = new Size(350, 28),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
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

        private void btnRefresh_Click(object? sender, EventArgs e) => LoadPeserta();

        private void btnLaporan_Click(object? sender, EventArgs e)
        {
            if (cboPeserta.SelectedIndex < 0 || cboPeserta.SelectedIndex >= _pesertaList.Count) return;
            var peserta = _pesertaList[cboPeserta.SelectedIndex];
            var form = new LaporanForm(_laporanService, peserta.Id, peserta.Nama);
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
                    _ => Color.Gray
                };
            }
        }

        private void lstExistingFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
