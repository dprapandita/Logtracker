using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class DetailAktivitasController
    {
        private readonly CoachService _coachService;

        public DetailAktivitasController(CoachService coachService)
        {
            _coachService = coachService;
        }

        public List<FeedbackAktivitas> GetFeedbackByAktivitas(int aktivitasId)
            => _coachService.GetFeedbackByAktivitas(aktivitasId);
    }
}
