using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class CoachDashboardForm : Form
    {
        private readonly CoachService _coachService;
        private readonly LaporanService _laporanService;
        private readonly Profile _profile;
        private List<Profile> _pesertaList = [];
        private int _selectedAktivitasId;

        public CoachDashboardForm(CoachService coachService, LaporanService laporanService, Profile profile)
        {
            InitializeComponent();
            _coachService = coachService;
            _laporanService = laporanService;
            _profile = profile;

            lblUserInfo.Text = $"Coach: {_profile.Nama}";
            LoadPeserta();
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
                if (dgvAktivitas.Columns["CreatedAt"] != null) dgvAktivitas.Columns["CreatedAt"].Visible = false;
                if (dgvAktivitas.Columns["Tanggal"] != null)
                    dgvAktivitas.Columns["Tanggal"].DefaultCellStyle.Format = "yyyy-MM-dd";

                ClearFeedbackPanel();
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
            cboStatus.SelectedItem = selected.Status;
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
            if (_selectedAktivitasId == 0)
            {
                MessageBox.Show("Pilih aktivitas terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hasError = false;

            // Update status
            if (cboStatus.SelectedItem != null)
            {
                var status = cboStatus.SelectedItem.ToString()!;
                var (suc1, msg1) = _coachService.UpdateStatus(_selectedAktivitasId, status);
                if (!suc1)
                {
                    MessageBox.Show(msg1, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hasError = true;
                }
            }

            // Save new feedback
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

            // Refresh
            if (cboPeserta.SelectedIndex >= 0 && cboPeserta.SelectedIndex < _pesertaList.Count)
                LoadAktivitas(_pesertaList[cboPeserta.SelectedIndex].Id);
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
    }
}
