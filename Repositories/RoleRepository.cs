using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class RoleRepository : BaseRepository
    {
        public RoleRepository(DatabaseHelper db) : base(db)
        {
        }

        public List<Role> GetAll()
        {
            var roles = new List<Role>();
            using var conn = OpenConnection();
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
            return ExecuteScalar("SELECT id FROM roles WHERE nama = @nama",
                p => p.AddWithValue("nama", nama)) as int?;
        }
    }
}
