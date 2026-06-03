using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseHelper _db;

        public UserRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public User? GetByUsername(string username)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT u.*, r.nama AS role_name
                  FROM users u
                  JOIN roles r ON u.role_id = r.id
                  WHERE u.username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public User? GetByEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT u.*, r.nama AS role_name
                  FROM users u
                  JOIN roles r ON u.role_id = r.id
                  WHERE u.email = @email", conn);
            cmd.Parameters.AddWithValue("email", email);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public int Insert(User user)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO users (username, email, password_hash, nama, role_id) VALUES (@username, @email, @pass, @nama, @roleId) RETURNING id", conn);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("pass", user.PasswordHash);
            cmd.Parameters.AddWithValue("nama", user.Nama);
            cmd.Parameters.AddWithValue("roleId", user.RoleId);
            return (int)cmd.ExecuteScalar()!;
        }

        private static User Map(NpgsqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["id"],
                Username = (string)reader["username"],
                Email = (string)reader["email"],
                PasswordHash = (string)reader["password_hash"],
                Nama = (string)reader["nama"],
                RoleId = (int)reader["role_id"],
                RoleName = reader["role_name"] as string,
                CreatedAt = reader["created_at"] is DateTime dt ? dt : DateTime.Now
            };
        }
    }
}
