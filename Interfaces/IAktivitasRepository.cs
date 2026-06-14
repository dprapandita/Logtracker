using System.Data;
using Logtracker.Models;

namespace Logtracker.Interfaces
{
    // ABSTRACTION: kontrak akses data tabel aktivitas.
    public interface IAktivitasRepository
    {
        List<Aktivitas> GetAllByPesertaId(int pesertaId);
        List<Aktivitas> GetAllByPesertaIdWithName(int pesertaId);
        Aktivitas? GetById(int id);
        void Insert(Aktivitas a);
        void Update(Aktivitas a);
        void Delete(int id);
        void UpdateStatus(int aktivitasId, int statusId);
        List<Aktivitas> GetByPesertaIds(List<int> pesertaIds);
        DataTable GetTotalDurasiPerKategori(int pesertaId);
        DataTable GetJumlahAktivitasPerKategori(int pesertaId);
        DataTable GetTotalDurasiPerTanggal(int pesertaId);
        DataTable GetStatusCount(int pesertaId);
        int GetTotalDurasiDisetujui(int pesertaId);
        string GetLevelKeaktifan(int pesertaId);
    }
}
