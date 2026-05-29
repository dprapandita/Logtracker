using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class KategoriService
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
            try
            {
                _repo.Insert(new KategoriLatihan { NamaLatihan = nama.Trim() });
                return (true, "Kategori berhasil ditambahkan.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }

        public (bool Success, string Message) Update(int id, string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
                return (false, "Nama kategori tidak boleh kosong.");
            try
            {
                _repo.Update(new KategoriLatihan { Id = id, NamaLatihan = nama.Trim() });
                return (true, "Kategori berhasil diperbarui.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }

        public (bool Success, string Message) Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return (true, "Kategori berhasil dihapus.");
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }
    }
}
