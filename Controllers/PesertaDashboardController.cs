using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class PesertaDashboardController
    {
        private readonly AktivitasService _aktivitasService;
        private readonly CoachService _coachService;

        public PesertaDashboardController(AktivitasService aktivitasService, CoachService coachService)
        {
            _aktivitasService = aktivitasService;
            _coachService = coachService;
        }

        public List<Aktivitas> GetAktivitas(int pesertaId)
            => _aktivitasService.GetAllByPesertaId(pesertaId);

        public (bool Success, string Message) AddAktivitas(Aktivitas aktivitas)
            => _aktivitasService.Add(aktivitas);

        public (bool Success, string Message) UpdateAktivitas(Aktivitas aktivitas)
            => _aktivitasService.Update(aktivitas);

        public (bool Success, string Message) DeleteAktivitas(int aktivitasId)
            => _aktivitasService.Delete(aktivitasId);

        public List<Profile> GetCoachList()
            => _coachService.GetCoachList();

        public (bool Success, string Message) PilihCoach(int pesertaId, int coachId)
            => _coachService.AddPeserta(coachId, pesertaId);
    }
}
