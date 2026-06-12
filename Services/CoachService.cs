using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    // INHERITANCE: mewarisi helper Execute (pola try/catch) dari BaseService.
    public class CoachService : BaseService
    {
        private readonly ProfileRepository _profileRepo;
        private readonly AktivitasRepository _aktivitasRepo;
        private readonly FeedbackRepository _feedbackRepo;
        private readonly RelasiRepository _relasiRepo;

        public CoachService(ProfileRepository profileRepo, AktivitasRepository aktivitasRepo,
            FeedbackRepository feedbackRepo, RelasiRepository relasiRepo)
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

        public List<Aktivitas> GetAktivitasPeserta(int pesertaId)
            => _aktivitasRepo.GetAllByPesertaIdWithName(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackByAktivitas(int aktivitasId)
            => _feedbackRepo.GetByAktivitasId(aktivitasId);

        public (bool Success, string Message) SaveFeedback(int aktivitasId, int coachId, string feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback))
                return (false, "Feedback tidak boleh kosong.");

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
            if (string.IsNullOrWhiteSpace(feedback))
                return (false, "Feedback tidak boleh kosong.");

            return Execute(
                () => _feedbackRepo.BeriFeedbackTransaksional(aktivitasId, coachId, feedback.Trim(), statusId),
                "Feedback & status berhasil disimpan.");
        }

        public (bool Success, string Message) UpdateStatus(int aktivitasId, int statusId)
        {
            if (statusId <= 0)
                return (false, "Pilih status.");

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
