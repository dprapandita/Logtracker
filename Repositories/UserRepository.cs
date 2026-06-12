using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class UserRepository : BaseRepository
    {
        public UserRepository(DatabaseHelper db) : base(db)
        {
        }

        public User? GetByUsername(string username)
        {
            using var conn = OpenConnection();
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
            using var conn = OpenConnection();
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

        public User? GetById(int id)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT u.*, r.nama AS role_name
                  FROM users u
                  JOIN roles r ON u.role_id = r.id
                  WHERE u.id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;
            return Map(reader);
        }

        public int Insert(User user)
        {
            return (int)ExecuteScalar(InsertSql, p => BindInsert(p, user))!;
        }

        // Versi transaksi: dipakai saat register agar atomik bersama insert lain.
        public int Insert(User user, NpgsqlConnection conn, NpgsqlTransaction tx)
        {
            return (int)ExecuteScalar(conn, tx, InsertSql, p => BindInsert(p, user))!;
        }

        private const string InsertSql =
            "INSERT INTO users (username, email, password_hash, nama, role_id) VALUES (@username, @email, @pass, @nama, @roleId) RETURNING id";

        private static void BindInsert(NpgsqlParameterCollection p, User user)
        {
            p.AddWithValue("username", user.Username);
            p.AddWithValue("email", (object?)user.Email ?? DBNull.Value);
            p.AddWithValue("pass", user.PasswordHash);
            p.AddWithValue("nama", user.Nama);
            p.AddWithValue("roleId", user.RoleId);
        }

        public void UpdateProfile(int userId, string nama, string? email)
        {
            ExecuteNonQuery("UPDATE users SET nama = @nama, email = @email WHERE id = @id", p =>
            {
                p.AddWithValue("id", userId);
                p.AddWithValue("nama", nama);
                p.AddWithValue("email", (object?)email ?? DBNull.Value);
            });
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            ExecuteNonQuery("UPDATE users SET password_hash = @pass WHERE id = @id", p =>
            {
                p.AddWithValue("id", userId);
                p.AddWithValue("pass", newPassword);
            });
        }

        private static User Map(NpgsqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["id"],
                Username = (string)reader["username"],
                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? "" : (string)reader["email"],
                PasswordHash = (string)reader["password_hash"],
                Nama = (string)reader["nama"],
                RoleId = (int)reader["role_id"],
                RoleName = reader["role_name"] as string,
                CreatedAt = reader["created_at"] is DateTime dt ? dt : DateTime.Now
            };
        }
    }
}
