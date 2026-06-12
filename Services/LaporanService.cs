using System.Data;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    // INHERITANCE: bagian dari hierarki service yang sama (BaseService).
    public class LaporanService : BaseService
    {
        private readonly AktivitasRepository _aktivitasRepo;

        public LaporanService(AktivitasRepository aktivitasRepo)
        {
            _aktivitasRepo = aktivitasRepo;
        }

        public DataTable TotalDurasiPerKategori(int pesertaId)
            => _aktivitasRepo.GetTotalDurasiPerKategori(pesertaId);

        public DataTable JumlahAktivitasPerKategori(int pesertaId)
            => _aktivitasRepo.GetJumlahAktivitasPerKategori(pesertaId);

        public DataTable TotalDurasiPerTanggal(int pesertaId)
            => _aktivitasRepo.GetTotalDurasiPerTanggal(pesertaId);

        public DataTable StatusCount(int pesertaId)
            => _aktivitasRepo.GetStatusCount(pesertaId);

        // Stored function hitung_total_durasi(): total durasi latihan 'Disetujui'.
        public int TotalDurasiDisetujui(int pesertaId)
            => _aktivitasRepo.GetTotalDurasiDisetujui(pesertaId);

        // Stored function level_keaktifan(): klasifikasi keaktifan peserta.
        public string LevelKeaktifan(int pesertaId)
            => _aktivitasRepo.GetLevelKeaktifan(pesertaId);
    }
}
