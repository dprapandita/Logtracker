using Logtracker.Models;

namespace Logtracker.Interfaces
{
    // ABSTRACTION: kontrak akses data tabel feedback_aktivitas.
    public interface IFeedbackRepository
    {
        void Insert(FeedbackAktivitas fb);
        void BeriFeedbackTransaksional(int aktivitasId, int coachId, string feedback, int statusId);
        List<FeedbackAktivitas> GetByAktivitasId(int aktivitasId);
        List<FeedbackAktivitas> GetFeedbackForPeserta(int pesertaId);
    }
}
