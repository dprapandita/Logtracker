using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class RoleRepository
    {
        private readonly DatabaseHelper _db;

        public RoleRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public int? GetRoleIdByName(string nama)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT id FROM roles WHERE nama = @nama", conn);
            cmd.Parameters.AddWithValue("nama", nama);
            return cmd.ExecuteScalar() as int?;
        }

        public List<string> GetAllRoleNames()
        {
            var roles = new List<string>();

            using var conn = _db.GetConnection();
            conn.Open();

            // Menggunakan nama tabel 'roles' dan nama kolom 'nama' sesuai database Anda
            using var cmd = new NpgsqlCommand("SELECT nama FROM roles", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                roles.Add(reader.GetString(0));
            }

            return roles;
        }
    }
}
