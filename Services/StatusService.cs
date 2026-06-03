using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class StatusService
    {
        private readonly StatusRepository _repo;

        public StatusService(StatusRepository repo)
        {
            _repo = repo;
        }

        public List<StatusAktivitas> GetAll() => _repo.GetAll();
    }
}
