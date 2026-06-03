using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class ProfileRepository
    {
        private readonly DatabaseHelper _db;

        public ProfileRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public Profile? GetById(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM profiles WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public Profile? GetByUserId(int userId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM profiles WHERE user_id = @uid", conn);
            cmd.Parameters.AddWithValue("uid", userId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public int Insert(Profile profile)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO profiles (user_id, nama, kode_peserta) VALUES (@uid, @nama, @kode) RETURNING id", conn);
            cmd.Parameters.AddWithValue("uid", profile.UserId);
            cmd.Parameters.AddWithValue("nama", profile.Nama);
            cmd.Parameters.AddWithValue("kode", profile.KodePeserta is null ? DBNull.Value : profile.KodePeserta);
            return (int)cmd.ExecuteScalar()!;
        }

        public string GenerateKodePeserta()
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT COALESCE(MAX(CAST(SUBSTRING(kode_peserta FROM 5) AS INTEGER)), 0) + 1 FROM profiles WHERE kode_peserta IS NOT NULL", conn);
            var next = (int)cmd.ExecuteScalar()!;
            return $"PST-{next:D4}";
        }

        public Profile? GetPesertaByKode(string kode)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.* FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN roles r ON u.role_id = r.id
                  WHERE p.kode_peserta = @kode AND r.nama = 'peserta'", conn);
            cmd.Parameters.AddWithValue("kode", kode);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public List<Profile> GetPesertaByCoach(int coachId)
        {
            var list = new List<Profile>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.* FROM profiles p
                  JOIN peserta_coach pc ON p.id = pc.peserta_id
                  WHERE pc.coach_id = @coachId
                  ORDER BY p.nama", conn);
            cmd.Parameters.AddWithValue("coachId", coachId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public List<Profile> GetCoachList()
        {
            var list = new List<Profile>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.* FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN roles r ON u.role_id = r.id
                  WHERE r.nama = 'coach'
                  ORDER BY p.nama", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public List<Profile> GetAnakByOrtu(int ortuId)
        {
            var list = new List<Profile>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.* FROM profiles p
                  JOIN orang_tua_peserta otp ON p.id = otp.peserta_id
                  WHERE otp.ortu_id = @ortuId
                  ORDER BY p.nama", conn);
            cmd.Parameters.AddWithValue("ortuId", ortuId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        private static Profile Map(NpgsqlDataReader reader)
        {
            return new Profile
            {
                Id = (int)reader["id"],
                UserId = reader["user_id"] is int uid ? uid : 0,
                Nama = (string)reader["nama"],
                KodePeserta = reader["kode_peserta"] as string,
                CreatedAt = reader["created_at"] is DateTime ct ? ct : DateTime.Now,
                UpdatedAt = reader["updated_at"] is DateTime ut ? ut : DateTime.Now
            };
        }
    }
}
