using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class StatusRepository
    {
        private readonly DatabaseHelper _db;

        public StatusRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public List<StatusAktivitas> GetAll()
        {
            var list = new List<StatusAktivitas>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM status_aktivitas ORDER BY id", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new StatusAktivitas
                {
                    Id = (int)reader["id"],
                    Nama = (string)reader["nama"]
                });
            }
            return list;
        }
    }
}
