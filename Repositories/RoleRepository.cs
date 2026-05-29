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

        public List<Role> GetAll()
        {
            var roles = new List<Role>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT id, nama FROM roles ORDER BY nama", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                roles.Add(new Role
                {
                    Id = reader.GetInt32(0),
                    Nama = reader.GetString(1)
                });
            }
            return roles;
        }

        public List<string> GetAllRoleNames()
        {
            return GetAll().Select(r => r.Nama).ToList();
        }

        public int? GetRoleIdByName(string nama)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT id FROM roles WHERE nama = @nama", conn);
            cmd.Parameters.AddWithValue("nama", nama);
            return cmd.ExecuteScalar() as int?;
        }
    }
}
