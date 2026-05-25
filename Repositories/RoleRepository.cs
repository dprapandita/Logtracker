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
    }
}
