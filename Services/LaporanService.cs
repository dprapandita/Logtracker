using System.Data;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class LaporanService
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
    }
}
