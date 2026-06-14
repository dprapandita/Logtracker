using Npgsql;
using Logtracker.Models;

namespace Logtracker.Interfaces
{
    // ABSTRACTION: kontrak akses relasi peserta-coach dan orang_tua-peserta.
    public interface IRelasiRepository
    {
        PesertaCoach? GetCoachByPeserta(int pesertaId);
        void SetCoach(int pesertaId, int coachId);
        void ConnectAnak(int ortuId, int pesertaId);
        void ConnectAnak(int ortuId, int pesertaId, NpgsqlConnection conn, NpgsqlTransaction tx);
    }
}
