using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class PesertaDetailRepository : BaseRepository
    {
        public PesertaDetailRepository(DatabaseHelper db) : base(db)
        {
        }

        public void Insert(PesertaDetail pd)
        {
            ExecuteNonQuery(InsertSql, p => BindInsert(p, pd));
        }

        // Versi transaksi: dipakai saat register agar atomik bersama insert lain.
        public void Insert(PesertaDetail pd, NpgsqlConnection conn, NpgsqlTransaction tx)
        {
            ExecuteNonQuery(conn, tx, InsertSql, p => BindInsert(p, pd));
        }

        private const string InsertSql = "INSERT INTO peserta_details (user_id, kode_peserta) VALUES (@uid, @kode)";

        private static void BindInsert(NpgsqlParameterCollection p, PesertaDetail pd)
        {
            p.AddWithValue("uid", pd.UserId);
            p.AddWithValue("kode", pd.KodePeserta);
        }

        public PesertaDetail? GetByUserId(int userId)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                "SELECT user_id, kode_peserta FROM peserta_details WHERE user_id = @uid", conn);
            cmd.Parameters.AddWithValue("uid", userId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public PesertaDetail? GetByKode(string kode)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                "SELECT user_id, kode_peserta FROM peserta_details WHERE kode_peserta = @kode", conn);
            cmd.Parameters.AddWithValue("kode", kode);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public string GenerateKodePeserta()
        {
            var next = (int)ExecuteScalar(NextKodeSql)!;
            return $"PST-{next:D4}";
        }

        // Versi transaksi: hitung kode berikutnya di dalam transaksi yang sama.
        public string GenerateKodePeserta(NpgsqlConnection conn, NpgsqlTransaction tx)
        {
            var next = (int)ExecuteScalar(conn, tx, NextKodeSql)!;
            return $"PST-{next:D4}";
        }

        private const string NextKodeSql =
            "SELECT COALESCE(MAX(CAST(SUBSTRING(kode_peserta FROM 5) AS INTEGER)), 0) + 1 FROM peserta_details";

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
