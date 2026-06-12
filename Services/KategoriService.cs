using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    // INHERITANCE: mewarisi helper Execute (pola try/catch) dari BaseService.
    public class KategoriService : BaseService
    {
        private readonly KategoriRepository _repo;

        public KategoriService(KategoriRepository repo)
        {
            _repo = repo;
        }

        public List<KategoriLatihan> GetAll() => _repo.GetAll();

        public (bool Success, string Message) Add(string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                return (false, "Nama kategori tidak boleh kosong.");
            return Execute(() => _repo.Insert(new KategoriLatihan { NamaLatihan = nama.Trim() }),
                "Kategori berhasil ditambahkan.");
        }

        public (bool Success, string Message) Update(int id, string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                return (false, "Nama kategori tidak boleh kosong.");
            return Execute(() => _repo.Update(new KategoriLatihan { Id = id, NamaLatihan = nama.Trim() }),
                "Kategori berhasil diperbarui.");
        }

        public (bool Success, string Message) Delete(int id)
        {
            return Execute(() => _repo.Delete(id), "Kategori berhasil dihapus.");
        }
    }
}
