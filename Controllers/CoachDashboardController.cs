using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class CoachDashboardController
    {
        private readonly CoachService _coachService;
        private readonly StatusService _statusService;

        public CoachDashboardController(CoachService coachService, StatusService statusService)
        {
            _coachService = coachService;
            _statusService = statusService;
        }

        public List<Profile> GetPesertaList(int coachId)
            => _coachService.GetPesertaList(coachId);

        public List<Aktivitas> GetAktivitasPeserta(int pesertaId)
            => _coachService.GetAktivitasPeserta(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackByAktivitas(int aktivitasId)
            => _coachService.GetFeedbackByAktivitas(aktivitasId);

        public List<StatusAktivitas> GetStatusList()
            => _statusService.GetAll();

        // Controller memvalidasi input dari user sebelum melempar ke service.
        public (bool Success, string Message) SaveFeedback(int aktivitasId, int coachId, string feedback)
        {
            if (string.IsNullOrWhiteSpace(feedback))
                return (false, "Feedback tidak boleh kosong.");

            return _coachService.SaveFeedback(aktivitasId, coachId, feedback);
        }

        public (bool Success, string Message) BeriFeedback(int aktivitasId, int coachId, string feedback, int statusId)
        {
            if (string.IsNullOrWhiteSpace(feedback))
                return (false, "Feedback tidak boleh kosong.");
            if (statusId <= 0)
                return (false, "Pilih status.");

            return _coachService.BeriFeedback(aktivitasId, coachId, feedback, statusId);
        }

        public (bool Success, string Message) UpdateStatus(int aktivitasId, int statusId)
        {
            if (statusId <= 0)
                return (false, "Pilih status.");

            return _coachService.UpdateStatus(aktivitasId, statusId);
        }
    }
}
