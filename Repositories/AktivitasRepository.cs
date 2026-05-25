using System.Data;
using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class AktivitasRepository
    {
        private readonly DatabaseHelper _db;

        public AktivitasRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public List<Aktivitas> GetAllByPesertaId(int pesertaId)
        {
            var list = new List<Aktivitas>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "SELECT * FROM aktivitas WHERE peserta_id = @pid ORDER BY tanggal DESC, created_at DESC", conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public List<Aktivitas> GetAllByPesertaIdWithName(int pesertaId)
        {
            var list = new List<Aktivitas>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT a.*, p.nama AS nama_peserta
                  FROM aktivitas a
                  JOIN profiles p ON a.peserta_id = p.id
                  WHERE a.peserta_id = @pid
                  ORDER BY a.tanggal DESC, a.created_at DESC", conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public Aktivitas? GetById(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("SELECT * FROM aktivitas WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public void Insert(Aktivitas a)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO aktivitas (peserta_id, nama, kategori, durasi, tanggal) VALUES (@pid, @nama, @kategori, @durasi, @tanggal)", conn);
            cmd.Parameters.AddWithValue("pid", a.PesertaId);
            cmd.Parameters.AddWithValue("nama", a.Nama);
            cmd.Parameters.AddWithValue("kategori", a.Kategori);
            cmd.Parameters.AddWithValue("durasi", a.Durasi);
            cmd.Parameters.AddWithValue("tanggal", a.Tanggal);
            cmd.ExecuteNonQuery();
        }

        public void Update(Aktivitas a)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "UPDATE aktivitas SET nama=@nama, kategori=@kategori, durasi=@durasi, tanggal=@tanggal WHERE id=@id AND status='Menunggu'", conn);
            cmd.Parameters.AddWithValue("id", a.Id);
            cmd.Parameters.AddWithValue("nama", a.Nama);
            cmd.Parameters.AddWithValue("kategori", a.Kategori);
            cmd.Parameters.AddWithValue("durasi", a.Durasi);
            cmd.Parameters.AddWithValue("tanggal", a.Tanggal);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM aktivitas WHERE id=@id AND status='Menunggu'", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStatus(int aktivitasId, string status)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE aktivitas SET status=@status WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", aktivitasId);
            cmd.Parameters.AddWithValue("status", status);
            cmd.ExecuteNonQuery();
        }

        public List<Aktivitas> GetByPesertaIds(List<int> pesertaIds)
        {
            var list = new List<Aktivitas>();
            if (pesertaIds.Count == 0) return list;

            using var conn = _db.GetConnection();
            conn.Open();
            var ph = string.Join(",", pesertaIds.Select((_, i) => $"@p{i}"));
            using var cmd = new NpgsqlCommand(
                $"SELECT a.*, p.nama AS nama_peserta FROM aktivitas a JOIN profiles p ON a.peserta_id = p.id WHERE a.peserta_id IN ({ph}) ORDER BY a.tanggal DESC", conn);
            for (int i = 0; i < pesertaIds.Count; i++)
                cmd.Parameters.AddWithValue($"p{i}", pesertaIds[i]);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public DataTable GetTotalDurasiPerKategori(int pesertaId)
            => GetReport("SELECT kategori, SUM(durasi) AS total_durasi FROM aktivitas WHERE peserta_id=@pid GROUP BY kategori ORDER BY total_durasi DESC", pesertaId);

        public DataTable GetJumlahAktivitasPerKategori(int pesertaId)
            => GetReport("SELECT kategori, COUNT(*) AS jumlah_aktivitas FROM aktivitas WHERE peserta_id=@pid GROUP BY kategori ORDER BY jumlah_aktivitas DESC", pesertaId);

        public DataTable GetTotalDurasiPerTanggal(int pesertaId)
            => GetReport("SELECT tanggal, SUM(durasi) AS total_durasi FROM aktivitas WHERE peserta_id=@pid GROUP BY tanggal ORDER BY tanggal DESC", pesertaId);

        public DataTable GetStatusCount(int pesertaId)
            => GetReport("SELECT status, COUNT(*) AS jumlah FROM aktivitas WHERE peserta_id=@pid GROUP BY status ORDER BY status", pesertaId);

        private DataTable GetReport(string sql, int pesertaId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var adapter = new NpgsqlDataAdapter(cmd);
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        private static Aktivitas Map(NpgsqlDataReader reader)
        {
            var raw = reader["tanggal"];
            var tanggal = raw is DateOnly d ? d.ToDateTime(TimeOnly.MinValue) : (DateTime)raw;

            return new Aktivitas
            {
                Id = (int)reader["id"],
                PesertaId = (int)reader["peserta_id"],
                Nama = (string)reader["nama"],
                Kategori = (string)reader["kategori"],
                Durasi = (int)reader["durasi"],
                Tanggal = tanggal,
                Status = reader["status"] as string ?? "Menunggu",
                CreatedAt = reader["created_at"] is DateTime dt ? dt : DateTime.Now,
                NamaPeserta = reader["nama_peserta"] as string
            };
        }
    }
}
