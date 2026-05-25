using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class RelasiRepository
    {
        private readonly DatabaseHelper _db;

        public RelasiRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public PesertaCoach? GetCoachByPeserta(int pesertaId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
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
            using var conn = _db.GetConnection();
            conn.Open();
            var existing = GetCoachByPeserta(pesertaId);
            if (existing != null)
            {
                using var cmd = new NpgsqlCommand("UPDATE peserta_coach SET coach_id = @cid WHERE peserta_id = @pid", conn);
                cmd.Parameters.AddWithValue("pid", pesertaId);
                cmd.Parameters.AddWithValue("cid", coachId);
                cmd.ExecuteNonQuery();
            }
            else
            {
                using var cmd = new NpgsqlCommand("INSERT INTO peserta_coach (peserta_id, coach_id) VALUES (@pid, @cid)", conn);
                cmd.Parameters.AddWithValue("pid", pesertaId);
                cmd.Parameters.AddWithValue("cid", coachId);
                cmd.ExecuteNonQuery();
            }
        }

        public void ConnectAnak(int ortuId, int pesertaId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO orang_tua_peserta (ortu_id, peserta_id) VALUES (@oid, @pid) ON CONFLICT DO NOTHING", conn);
            cmd.Parameters.AddWithValue("oid", ortuId);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            cmd.ExecuteNonQuery();
        }
    }
}
