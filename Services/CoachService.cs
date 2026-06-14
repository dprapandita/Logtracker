using Logtracker.Interfaces;
using Logtracker.Models;

namespace Logtracker.Services
{
    // INHERITANCE dari BaseService (helper Execute).
    // Bergantung ke interface repository (ABSTRACTION), bukan kelas konkret.
    public class CoachService : BaseService
    {
        private readonly IProfileRepository _profileRepo;
        private readonly IAktivitasRepository _aktivitasRepo;
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly IRelasiRepository _relasiRepo;

        public CoachService(IProfileRepository profileRepo, IAktivitasRepository aktivitasRepo,
            IFeedbackRepository feedbackRepo, IRelasiRepository relasiRepo)
        {
            _profileRepo = profileRepo;
            _aktivitasRepo = aktivitasRepo;
            _feedbackRepo = feedbackRepo;
            _relasiRepo = relasiRepo;
        }

        public List<Profile> GetPesertaList(int coachId)
            => _profileRepo.GetPesertaByCoach(coachId);

        public List<Profile> GetAllPeserta()
            => _profileRepo.GetAllPeserta();

        public List<Profile> GetCoachList()
            => _profileRepo.GetCoachList();

        public List<Aktivitas> GetAktivitasPeserta(int pesertaId)
            => _aktivitasRepo.GetAllByPesertaIdWithName(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackByAktivitas(int aktivitasId)
            => _feedbackRepo.GetByAktivitasId(aktivitasId);

        // Validasi input (feedback kosong / status belum dipilih) sekarang ditangani
        // di CoachDashboardController. Service fokus ke business rule + persistensi.
        public (bool Success, string Message) SaveFeedback(int aktivitasId, int coachId, string feedback)
        {
            return Execute(() => _feedbackRepo.Insert(new FeedbackAktivitas
            {
                AktivitasId = aktivitasId,
                CoachId = coachId,
                Feedback = feedback.Trim()
            }), "Feedback berhasil disimpan.");
        }

        // Jalur transaksional: feedback + keputusan status (Disetujui/Revisi) sekaligus,
        // lewat stored procedure sp_beri_feedback.
        public (bool Success, string Message) BeriFeedback(int aktivitasId, int coachId, string feedback, int statusId)
        {
            return Execute(
                () => _feedbackRepo.BeriFeedbackTransaksional(aktivitasId, coachId, feedback.Trim(), statusId),
                "Feedback & status berhasil disimpan.");
        }

        public (bool Success, string Message) UpdateStatus(int aktivitasId, int statusId)
        {
            return Execute(() => _aktivitasRepo.UpdateStatus(aktivitasId, statusId),
                "Status berhasil diperbarui.");
        }

        public (bool Success, string Message) AddPeserta(int coachId, int pesertaId)
        {
            return Execute(() => _relasiRepo.SetCoach(pesertaId, coachId),
                "Peserta berhasil ditambahkan.");
        }
    }
}
