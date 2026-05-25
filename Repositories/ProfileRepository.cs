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

            return new Profile
            {
                Id = (int)reader["id"],
                Nama = (string)reader["nama"],
                KodePeserta = reader["kode_peserta"] as string
            };
        }

        public int Insert(Profile profile)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO profiles (nama, kode_peserta) VALUES (@nama, @kode) RETURNING id", conn);
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
                "SELECT p.* FROM profiles p JOIN akun_login a ON p.id = a.profile_id JOIN roles r ON a.role_id = r.id WHERE p.kode_peserta = @kode AND r.nama = 'peserta'", conn);
            cmd.Parameters.AddWithValue("kode", kode);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new Profile
            {
                Id = (int)reader["id"],
                Nama = (string)reader["nama"],
                KodePeserta = (string)reader["kode_peserta"]
            };
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
            {
                list.Add(new Profile
                {
                    Id = (int)reader["id"],
                    Nama = (string)reader["nama"],
                    KodePeserta = reader["kode_peserta"] as string
                });
            }
            return list;
        }

        public List<Profile> GetCoachList()
        {
            var list = new List<Profile>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT p.* FROM profiles p
                  JOIN akun_login a ON p.id = a.profile_id
                  JOIN roles r ON a.role_id = r.id
                  WHERE r.nama = 'coach'
                  ORDER BY p.nama", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Profile
                {
                    Id = (int)reader["id"],
                    Nama = (string)reader["nama"]
                });
            }
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
            {
                list.Add(new Profile
                {
                    Id = (int)reader["id"],
                    Nama = (string)reader["nama"],
                    KodePeserta = reader["kode_peserta"] as string
                });
            }
            return list;
        }
    }
}
