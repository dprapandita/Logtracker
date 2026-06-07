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
            using var cmd = new NpgsqlCommand(
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE p.id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public Profile? GetByUserId(int userId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE p.user_id = @uid", conn);
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
                "INSERT INTO profiles (user_id) VALUES (@uid) RETURNING id", conn);
            cmd.Parameters.AddWithValue("uid", profile.UserId);
            return (int)cmd.ExecuteScalar()!;
        }

        public Profile? GetPesertaByKode(string kode)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM peserta_details pd
                  JOIN profiles p ON pd.user_id = p.user_id
                  JOIN users u ON p.user_id = u.id
                  JOIN roles r ON u.role_id = r.id
                  WHERE pd.kode_peserta = @kode AND r.nama = 'peserta'", conn);
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
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN peserta_coach pc ON p.id = pc.peserta_id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE pc.coach_id = @coachId
                  ORDER BY u.nama", conn);
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
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN roles r ON u.role_id = r.id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE r.nama = 'coach'
                  ORDER BY u.nama", conn);
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
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN orang_tua_peserta otp ON p.id = otp.peserta_id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE otp.ortu_id = @ortuId
                  ORDER BY u.nama", conn);
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
