using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class OrangTuaService
    {
        private readonly ProfileRepository _profileRepo;
        private readonly RelasiRepository _relasiRepo;
        private readonly AktivitasRepository _aktivitasRepo;
        private readonly FeedbackRepository _feedbackRepo;

        public OrangTuaService(ProfileRepository profileRepo, RelasiRepository relasiRepo,
            AktivitasRepository aktivitasRepo, FeedbackRepository feedbackRepo)
        {
            _profileRepo = profileRepo;
            _relasiRepo = relasiRepo;
            _aktivitasRepo = aktivitasRepo;
            _feedbackRepo = feedbackRepo;
        }

        public List<Profile> GetDaftarAnak(int ortuId)
            => _profileRepo.GetAnakByOrtu(ortuId);

        public List<Aktivitas> GetAktivitasAnak(int pesertaId)
            => _aktivitasRepo.GetAllByPesertaIdWithName(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackAnak(int pesertaId)
            => _feedbackRepo.GetFeedbackForPeserta(pesertaId);

        public (bool Success, string Message) ConnectAnak(int ortuId, string kodePeserta)
        {
            var peserta = _profileRepo.GetPesertaByKode(kodePeserta.Trim().ToUpper());
            if (peserta == null)
                return (false, "Kode peserta tidak ditemukan.");

            try
            {
                _relasiRepo.ConnectAnak(ortuId, peserta.Id);
                return (true, $"Berhasil terhubung dengan {peserta.Nama}.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }
    }
}
