using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class AktivitasService
    {
        private readonly AktivitasRepository _repo;

        public AktivitasService(AktivitasRepository repo)
        {
            _repo = repo;
        }

        public List<Aktivitas> GetAllByPesertaId(int pesertaId)
            => _repo.GetAllByPesertaId(pesertaId);

        public Aktivitas? GetById(int id)
            => _repo.GetById(id);

        private static (bool Valid, string Message) Validate(Aktivitas a)
        {
            if (string.IsNullOrWhiteSpace(a.Nama))
                return (false, "Nama aktivitas tidak boleh kosong.");
            if (a.KategoriId <= 0)
                return (false, "Pilih kategori.");
            if (a.Durasi <= 0)
                return (false, "Durasi harus lebih dari 0.");
            return (true, "");
        }

        public (bool Success, string Message) Add(Aktivitas a)
        {
            var (valid, msg) = Validate(a);
            if (!valid) return (false, msg);
            try { _repo.Insert(a); return (true, "Aktivitas berhasil ditambahkan."); }
            catch (Exception ex) { return (false, $"Gagal: {ex.Message}"); }
        }

        public (bool Success, string Message) Update(Aktivitas a)
        {
            var existing = _repo.GetById(a.Id);
            if (existing == null) return (false, "Data tidak ditemukan.");
            if (existing.StatusId != 1) return (false, $"Aktivitas berstatus \"{existing.NamaStatus}\" tidak dapat diedit.");

            var (valid, msg) = Validate(a);
            if (!valid) return (false, msg);
            try { _repo.Update(a); return (true, "Aktivitas berhasil diperbarui."); }
            catch (Exception ex) { return (false, $"Gagal: {ex.Message}"); }
        }

        public (bool Success, string Message) Delete(int id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return (false, "Data tidak ditemukan.");
            if (existing.StatusId != 1) return (false, $"Aktivitas berstatus \"{existing.NamaStatus}\" tidak dapat dihapus.");

            try { _repo.Delete(id); return (true, "Aktivitas berhasil dihapus."); }
            catch (Exception ex) { return (false, $"Gagal: {ex.Message}"); }
        }
    }
}
