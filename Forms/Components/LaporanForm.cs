using Logtracker.Controllers;

namespace Logtracker.Forms
{
    public partial class LaporanForm : Form
    {
        private readonly LaporanController _laporanController;
        private readonly int _pesertaId;
        private readonly string _pesertaNama;

        public LaporanForm(LaporanController laporanController, int pesertaId, string pesertaNama)
        {
            InitializeComponent();
            _laporanController = laporanController;
            _pesertaId = pesertaId;
            _pesertaNama = pesertaNama;

            LoadLaporan();
        }

        private void LoadLaporan()
        {
            try
            {
                dgvKategoriDurasi.DataSource = _laporanController.TotalDurasiPerKategori(_pesertaId);
                dgvKategoriJumlah.DataSource = _laporanController.JumlahAktivitasPerKategori(_pesertaId);
                dgvTanggalDurasi.DataSource = _laporanController.TotalDurasiPerTanggal(_pesertaId);
                dgvStatus.DataSource = _laporanController.StatusCount(_pesertaId);

                // Stored function: total durasi disetujui + level keaktifan.
                var total = _laporanController.TotalDurasiDisetujui(_pesertaId);
                var level = _laporanController.LevelKeaktifan(_pesertaId);
                lblPeserta.Text = $"Laporan Aktivitas: {_pesertaNama}  |  Total Durasi Disetujui: {total} menit  |  Keaktifan: {level}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat laporan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            LoadLaporan();
        }

        private void btnTutup_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void grpKategoriDurasi_Enter(object sender, EventArgs e)
        {

        }

        private void dgvKategoriDurasi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
