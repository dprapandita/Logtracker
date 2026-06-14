using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class OrtuDashboardController
    {
        private readonly OrangTuaService _orangTuaService;

        public OrtuDashboardController(OrangTuaService orangTuaService)
        {
            _orangTuaService = orangTuaService;
        }

        public List<Profile> GetDaftarAnak(int ortuId)
            => _orangTuaService.GetDaftarAnak(ortuId);

        public List<Aktivitas> GetAktivitasAnak(int pesertaId)
            => _orangTuaService.GetAktivitasAnak(pesertaId);

        public List<FeedbackAktivitas> GetFeedbackAnak(int pesertaId)
            => _orangTuaService.GetFeedbackAnak(pesertaId);

        public (bool Success, string Message) ConnectAnak(int ortuId, string kodePeserta)
            => _orangTuaService.ConnectAnak(ortuId, kodePeserta);
    }
}
