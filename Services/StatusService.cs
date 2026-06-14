using Logtracker.Interfaces;
using Logtracker.Models;

namespace Logtracker.Services
{
    // INHERITANCE dari BaseService. Bergantung ke IStatusRepository (ABSTRACTION).
    public class StatusService : BaseService
    {
        private readonly IStatusRepository _repo;

        public StatusService(IStatusRepository repo)
        {
            _repo = repo;
        }

        public List<StatusAktivitas> GetAll() => _repo.GetAll();
    }
}
