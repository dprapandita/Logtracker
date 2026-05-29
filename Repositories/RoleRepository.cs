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

        public List<Role> GetAll()
        {
            var list = new List<Role>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM roles ORDER BY id", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Role
                {
                    Id = (int)reader["id"],
                    Nama = (string)reader["nama"]
                });
            }
            return list;
        }
    }
}
