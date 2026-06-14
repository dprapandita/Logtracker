using System.Data;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class LaporanController
    {
        private readonly LaporanService _laporanService;

        public LaporanController(LaporanService laporanService)
        {
            _laporanService = laporanService;
        }

        public DataTable TotalDurasiPerKategori(int pesertaId)
            => _laporanService.TotalDurasiPerKategori(pesertaId);

        public DataTable JumlahAktivitasPerKategori(int pesertaId)
            => _laporanService.JumlahAktivitasPerKategori(pesertaId);

        public DataTable TotalDurasiPerTanggal(int pesertaId)
            => _laporanService.TotalDurasiPerTanggal(pesertaId);

        public DataTable StatusCount(int pesertaId)
            => _laporanService.StatusCount(pesertaId);

        public int TotalDurasiDisetujui(int pesertaId)
            => _laporanService.TotalDurasiDisetujui(pesertaId);

        public string LevelKeaktifan(int pesertaId)
            => _laporanService.LevelKeaktifan(pesertaId);
    }
}
