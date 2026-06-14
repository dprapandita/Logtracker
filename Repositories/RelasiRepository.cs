using Npgsql;
using Logtracker.Data;
using Logtracker.Models;
using Logtracker.Interfaces;

namespace Logtracker.Repositories
{
    // INHERITANCE dari BaseRepository, memenuhi kontrak IRelasiRepository (ABSTRACTION).
    public class RelasiRepository : BaseRepository, IRelasiRepository
    {
        public RelasiRepository(DatabaseHelper db) : base(db)
        {
        }

        public PesertaCoach? GetCoachByPeserta(int pesertaId)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand("SELECT * FROM peserta_coach WHERE peserta_id = @pid", conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return new PesertaCoach
            {
                Id = (int)reader["id"],
                PesertaId = (int)reader["peserta_id"],
                CoachId = (int)reader["coach_id"]
            };
        }

        public void SetCoach(int pesertaId, int coachId)
        {
            var existing = GetCoachByPeserta(pesertaId);
            var sql = existing != null
                ? "UPDATE peserta_coach SET coach_id = @cid WHERE peserta_id = @pid"
                : "INSERT INTO peserta_coach (peserta_id, coach_id) VALUES (@pid, @cid)";
            ExecuteNonQuery(sql, p =>
            {
                p.AddWithValue("pid", pesertaId);
                p.AddWithValue("cid", coachId);
            });
        }

        public void ConnectAnak(int ortuId, int pesertaId)
        {
            ExecuteNonQuery(ConnectAnakSql, p => BindConnectAnak(p, ortuId, pesertaId));
        }

        // Versi transaksi: dipakai saat register ortu agar atomik bersama insert lain.
        public void ConnectAnak(int ortuId, int pesertaId, NpgsqlConnection conn, NpgsqlTransaction tx)
        {
            ExecuteNonQuery(conn, tx, ConnectAnakSql, p => BindConnectAnak(p, ortuId, pesertaId));
        }

        private const string ConnectAnakSql =
            "INSERT INTO orang_tua_peserta (ortu_id, peserta_id) VALUES (@oid, @pid) ON CONFLICT DO NOTHING";

        private static void BindConnectAnak(NpgsqlParameterCollection p, int ortuId, int pesertaId)
        {
            p.AddWithValue("oid", ortuId);
            p.AddWithValue("pid", pesertaId);
        }
    }
}
