using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class AkunLoginRepository
    {
        private readonly DatabaseHelper _db;

        public AkunLoginRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public AkunLogin? GetByEmail(string email)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT a.*, r.nama AS role_name
                  FROM akun_login a
                  JOIN roles r ON a.role_id = r.id
                  WHERE a.email = @email", conn);
            cmd.Parameters.AddWithValue("email", email);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            return new AkunLogin
            {
                Id = (int)reader["id"],
                Email = (string)reader["email"],
                PasswordHash = (string)reader["password_hash"],
                RoleId = (int)reader["role_id"],
                ProfileId = (int)reader["profile_id"],
                RoleName = (string)reader["role_name"]
            };
        }

        public void Insert(AkunLogin akun)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO akun_login (email, password_hash, role_id, profile_id) VALUES (@email, @pass, @roleId, @profileId)", conn);
            cmd.Parameters.AddWithValue("email", akun.Email);
            cmd.Parameters.AddWithValue("pass", akun.PasswordHash);
            cmd.Parameters.AddWithValue("roleId", akun.RoleId);
            cmd.Parameters.AddWithValue("profileId", akun.ProfileId);
            cmd.ExecuteNonQuery();
        }
    }
}
