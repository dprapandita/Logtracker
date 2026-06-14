using Npgsql;
using Logtracker.Data;
using Logtracker.Models;
using Logtracker.Interfaces;

namespace Logtracker.Repositories
{
    // INHERITANCE dari BaseRepository, memenuhi kontrak IStatusRepository (ABSTRACTION).
    public class StatusRepository : BaseRepository, IStatusRepository
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
