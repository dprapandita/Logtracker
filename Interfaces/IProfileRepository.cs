using Npgsql;
using Logtracker.Models;

namespace Logtracker.Interfaces
{
    // ABSTRACTION: kontrak akses data tabel profiles. Service bergantung ke
    // interface ini, bukan ke kelas konkret ProfileRepository (Dependency Inversion).
    public interface IProfileRepository
    {
        Profile? GetById(int id);
        Profile? GetByUserId(int userId);
        ProfileDetail? GetDetailByUserId(int userId);
        int Insert(Profile profile);
        int Insert(Profile profile, NpgsqlConnection conn, NpgsqlTransaction tx);
        Profile? GetPesertaByKode(string kode);
        List<Profile> GetPesertaByCoach(int coachId);
        List<Profile> GetCoachList();
        List<Profile> GetAllPeserta();
        List<Profile> GetAnakByOrtu(int ortuId);
    }
}
