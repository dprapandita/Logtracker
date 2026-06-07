using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class PesertaDetailRepository
    {
        private readonly DatabaseHelper _db;

        public PesertaDetailRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public void Insert(PesertaDetail pd)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO peserta_details (user_id, kode_peserta) VALUES (@uid, @kode)", conn);
            cmd.Parameters.AddWithValue("uid", pd.UserId);
            cmd.Parameters.AddWithValue("kode", pd.KodePeserta);
            cmd.ExecuteNonQuery();
        }

        public PesertaDetail? GetByUserId(int userId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT user_id, kode_peserta FROM peserta_details WHERE user_id = @uid", conn);
            cmd.Parameters.AddWithValue("uid", userId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public PesertaDetail? GetByKode(string kode)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT user_id, kode_peserta FROM peserta_details WHERE kode_peserta = @kode", conn);
            cmd.Parameters.AddWithValue("kode", kode);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public string GenerateKodePeserta()
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT COALESCE(MAX(CAST(SUBSTRING(kode_peserta FROM 5) AS INTEGER)), 0) + 1 FROM peserta_details", conn);
            var next = (int)cmd.ExecuteScalar()!;
            return $"PST-{next:D4}";
        }

        private static PesertaDetail Map(NpgsqlDataReader reader)
        {
            return new PesertaDetail
            {
                UserId = (int)reader["user_id"],
                KodePeserta = (string)reader["kode_peserta"]
            };
        }
    }
}
