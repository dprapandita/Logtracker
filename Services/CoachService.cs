using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class CoachService
    {
        private readonly ProfileRepository _profileRepo;
        private readonly AktivitasRepository _aktivitasRepo;
        private readonly FeedbackRepository _feedbackRepo;

        public CoachService(ProfileRepository profileRepo, AktivitasRepository aktivitasRepo, FeedbackRepository feedbackRepo)
        {
            _profileRepo = profileRepo;
            _aktivitasRepo = aktivitasRepo;
            _feedbackRepo = feedbackRepo;
        }

        public List<Profile> GetPesertaList(int coachId)
            => _profileRepo.GetPesertaByCoach(coachId);

        public List<Aktivitas> GetAktivitasPeserta(int pesertaId)
            => _aktivitasRepo.GetAllByPesertaIdWithName(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackByAktivitas(int aktivitasId)
            => _feedbackRepo.GetByAktivitasId(aktivitasId);

        public (bool Success, string Message) SaveFeedback(int aktivitasId, int coachId, string feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback))
                return (false, "Feedback tidak boleh kosong.");

            try
            {
                var fb = new FeedbackAktivitas
                {
                    AktivitasId = aktivitasId,
                    CoachId = coachId,
                    Feedback = feedback.Trim()
                };
                _feedbackRepo.Insert(fb);
                return (true, "Feedback berhasil disimpan.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }

        public (bool Success, string Message) UpdateStatus(int aktivitasId, int statusId)
        {
            if (statusId <= 0)
                return (false, "Pilih status.");

            try
            {
                _aktivitasRepo.UpdateStatus(aktivitasId, statusId);
                return (true, "Status berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }
    }
}
