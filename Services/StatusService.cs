using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    // INHERITANCE: bagian dari hierarki service yang sama (BaseService).
    public class StatusService : BaseService
    {
        private readonly StatusRepository _repo;

        public StatusService(StatusRepository repo)
        {
            _repo = repo;
        }

        public List<StatusAktivitas> GetAll() => _repo.GetAll();
    }
}
