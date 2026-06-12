using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class KategoriRepository : BaseRepository
    {
        public KategoriRepository(DatabaseHelper db) : base(db)
        {
        }

        public List<KategoriLatihan> GetAll()
        {
            var list = new List<KategoriLatihan>();
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand("SELECT * FROM kategori_latihan ORDER BY nama_latihan", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new KategoriLatihan
                {
                    Id = (int)reader["id"],
                    NamaLatihan = (string)reader["nama_latihan"]
                });
            }
            return list;
        }

        public void Insert(KategoriLatihan kategori)
        {
            ExecuteNonQuery("INSERT INTO kategori_latihan (nama_latihan) VALUES (@nama)",
                p => p.AddWithValue("nama", kategori.NamaLatihan));
        }

        public void Update(KategoriLatihan kategori)
        {
            ExecuteNonQuery("UPDATE kategori_latihan SET nama_latihan = @nama WHERE id = @id", p =>
            {
                p.AddWithValue("id", kategori.Id);
                p.AddWithValue("nama", kategori.NamaLatihan);
            });
        }

        public void Delete(int id)
        {
            ExecuteNonQuery("DELETE FROM kategori_latihan WHERE id = @id",
                p => p.AddWithValue("id", id));
        }
    }
}
