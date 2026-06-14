using Logtracker.Models;

namespace Logtracker.Interfaces
{
    // ABSTRACTION: kontrak akses data tabel status_aktivitas.
    public interface IStatusRepository
    {
        List<StatusAktivitas> GetAll();
    }
}
