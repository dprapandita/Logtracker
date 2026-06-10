using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class LaporanForm : Form
    {
        private readonly LaporanService _laporanService;
        private readonly int _pesertaId;
        private readonly string _pesertaNama;

        public LaporanForm(LaporanService laporanService, int pesertaId, string pesertaNama)
        {
            InitializeComponent();
            _laporanService = laporanService;
            _pesertaId = pesertaId;
            _pesertaNama = pesertaNama;

            LoadLaporan();
        }

        private void LoadLaporan()
        {
            try
            {
                dgvKategoriDurasi.DataSource = _laporanService.TotalDurasiPerKategori(_pesertaId);
                dgvKategoriJumlah.DataSource = _laporanService.JumlahAktivitasPerKategori(_pesertaId);
                dgvTanggalDurasi.DataSource = _laporanService.TotalDurasiPerTanggal(_pesertaId);
                dgvStatus.DataSource = _laporanService.StatusCount(_pesertaId);

                // Stored function: total durasi disetujui + level keaktifan.
                var total = _laporanService.TotalDurasiDisetujui(_pesertaId);
                var level = _laporanService.LevelKeaktifan(_pesertaId);
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
