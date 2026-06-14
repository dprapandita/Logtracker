using Npgsql;
using Logtracker.Data;
using Logtracker.Models;
using Logtracker.Interfaces;

namespace Logtracker.Repositories
{
    // Akses data tabel profiles. INHERITANCE dari BaseRepository, dan memenuhi
    // kontrak IProfileRepository (ABSTRACTION).
    public class ProfileRepository : BaseRepository, IProfileRepository
    {
        public ProfileRepository(DatabaseHelper db) : base(db)
        {
        }

        public Profile? GetById(int id)
        {
            using var conn = OpenConnection();
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
            var profile = Map(reader);
            EnsurePesertaKode(profile);
            return profile;
        }

        public Profile? GetByUserId(int userId)
        {
            using var conn = OpenConnection();
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
            var profile = Map(reader);
            EnsurePesertaKode(profile);
            return profile;
        }

        // Ambil detail profil dari join users + roles + peserta_details.
        public ProfileDetail? GetDetailByUserId(int userId)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT u.id AS user_id, u.username, u.nama, u.email,
                         r.nama AS role,
                         pd.kode_peserta
                  FROM users u
                  JOIN roles r ON u.role_id = r.id
                  LEFT JOIN peserta_details pd ON u.id = pd.user_id
                  WHERE u.id = @uid", conn);
            cmd.Parameters.AddWithValue("uid", userId);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return MapDetail(reader);
        }

        public int Insert(Profile profile)
        {
            return (int)ExecuteScalar(InsertSql, p => p.AddWithValue("uid", profile.UserId))!;
        }

        // Versi transaksi: dipakai saat register agar atomik bersama insert lain.
        public int Insert(Profile profile, NpgsqlConnection conn, NpgsqlTransaction tx)
        {
            return (int)ExecuteScalar(conn, tx, InsertSql, p => p.AddWithValue("uid", profile.UserId))!;
        }

        private const string InsertSql = "INSERT INTO profiles (user_id) VALUES (@uid) RETURNING id";

        public Profile? GetPesertaByKode(string kode)
        {
            using var conn = OpenConnection();
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
            using var conn = OpenConnection();
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
            using var conn = OpenConnection();
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

        public List<Profile> GetAllPeserta()
        {
            var list = new List<Profile>();
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.id, p.user_id, p.created_at, p.updated_at,
                         u.nama,
                         pd.kode_peserta
                  FROM profiles p
                  JOIN users u ON p.user_id = u.id
                  JOIN roles r ON u.role_id = r.id
                  LEFT JOIN peserta_details pd ON p.user_id = pd.user_id
                  WHERE r.nama = 'peserta'
                  ORDER BY u.nama", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public List<Profile> GetAnakByOrtu(int ortuId)
        {
            var list = new List<Profile>();
            using var conn = OpenConnection();
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

        private void EnsurePesertaKode(Profile profile)
        {
            if (profile.KodePeserta != null) return;

            try
            {
                using var conn = OpenConnection();

                using var roleCmd = new NpgsqlCommand(
                    @"SELECT r.nama FROM users u
                      JOIN roles r ON u.role_id = r.id
                      WHERE u.id = @uid", conn);
                roleCmd.Parameters.AddWithValue("uid", profile.UserId);
                var role = roleCmd.ExecuteScalar() as string;

                if (role != "peserta") return;

                using var genCmd = new NpgsqlCommand(
                    "SELECT COALESCE(MAX(CAST(SUBSTRING(kode_peserta FROM 5) AS INTEGER)), 0) + 1 FROM peserta_details", conn);
                var next = (int)genCmd.ExecuteScalar()!;
                var kode = $"PST-{next:D4}";

                using var insCmd = new NpgsqlCommand(
                    "INSERT INTO peserta_details (user_id, kode_peserta) VALUES (@uid, @kode) ON CONFLICT (user_id) DO NOTHING", conn);
                insCmd.Parameters.AddWithValue("uid", profile.UserId);
                insCmd.Parameters.AddWithValue("kode", kode);
                insCmd.ExecuteNonQuery();

                profile.KodePeserta = kode;
            }
            catch
            {
                // Silently ignore; KodePeserta stays null
            }
        }

        private static ProfileDetail MapDetail(NpgsqlDataReader reader)
        {
            // Normalisasi (null/trim/default) ditangani setter ProfileDetail.
            return new ProfileDetail
            {
                UserId = reader["user_id"] is int uid ? uid : 0,
                Username = reader["username"] as string ?? string.Empty,
                Nama = reader["nama"] as string ?? string.Empty,
                Email = reader["email"] as string,
                Role = reader["role"] as string ?? string.Empty,
                KodePeserta = reader["kode_peserta"] as string
            };
        }

        private static Profile Map(NpgsqlDataReader reader)
        {
            return new Profile
            {
                Id = (int)reader["id"],
                UserId = reader["user_id"] is int uid ? uid : 0,
                Nama = reader["nama"] as string ?? string.Empty,
                KodePeserta = reader["kode_peserta"] as string,
                CreatedAt = reader["created_at"] is DateTime ct ? ct : DateTime.Now,
                UpdatedAt = reader["updated_at"] is DateTime ut ? ut : DateTime.Now
            };
        }
    }
}
