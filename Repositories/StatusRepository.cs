using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class StatusRepository : BaseRepository
    {
        public StatusRepository(DatabaseHelper db) : base(db)
        {
        }

        public List<StatusAktivitas> GetAll()
        {
            var list = new List<StatusAktivitas>();
            using var conn = OpenConnection();
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
