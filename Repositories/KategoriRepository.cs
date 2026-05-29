using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class KategoriRepository
    {
        private readonly DatabaseHelper _db;

        public KategoriRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public List<KategoriLatihan> GetAll()
        {
            var list = new List<KategoriLatihan>();
            using var conn = _db.GetConnection();
            conn.Open();
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
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("INSERT INTO kategori_latihan (nama_latihan) VALUES (@nama)", conn);
            cmd.Parameters.AddWithValue("nama", kategori.NamaLatihan);
            cmd.ExecuteNonQuery();
        }

        public void Update(KategoriLatihan kategori)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE kategori_latihan SET nama_latihan = @nama WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", kategori.Id);
            cmd.Parameters.AddWithValue("nama", kategori.NamaLatihan);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM kategori_latihan WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
