using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class KategoriController
    {
        private readonly KategoriService _kategoriService;

        public KategoriController(KategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        public List<KategoriLatihan> GetAll()
            => _kategoriService.GetAll();

        public (bool Success, string Message) Add(string nama)
            => _kategoriService.Add(nama);

        public (bool Success, string Message) Update(int id, string nama)
            => _kategoriService.Update(id, nama);

        public (bool Success, string Message) Delete(int id)
            => _kategoriService.Delete(id);
    }
}
