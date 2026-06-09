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
                @"SELECT a.*, kl.nama_latihan AS nama_kategori, sa.nama AS nama_status
                  FROM aktivitas a
                  JOIN kategori_latihan kl ON a.kategori_id = kl.id
                  JOIN status_aktivitas sa ON a.status_id = sa.id
                  WHERE a.peserta_id = @pid
                  ORDER BY a.tanggal DESC, a.created_at DESC", conn);
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
                @"SELECT a.*, u.nama AS nama_peserta, kl.nama_latihan AS nama_kategori, sa.nama AS nama_status
                  FROM aktivitas a
                  JOIN profiles p ON a.peserta_id = p.id
                  JOIN users u ON p.user_id = u.id
                  JOIN kategori_latihan kl ON a.kategori_id = kl.id
                  JOIN status_aktivitas sa ON a.status_id = sa.id
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
            using var cmd = new NpgsqlCommand(
                @"SELECT a.*, kl.nama_latihan AS nama_kategori, sa.nama AS nama_status
                  FROM aktivitas a
                  JOIN kategori_latihan kl ON a.kategori_id = kl.id
                  JOIN status_aktivitas sa ON a.status_id = sa.id
                  WHERE a.id = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            using var reader = cmd.ExecuteReader();
            return reader.Read() ? Map(reader) : null;
        }

        public void Insert(Aktivitas a)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO aktivitas (peserta_id, nama, kategori_id, durasi, tanggal) VALUES (@pid, @nama, @kid, @durasi, @tanggal)", conn);
            cmd.Parameters.AddWithValue("pid", a.PesertaId);
            cmd.Parameters.AddWithValue("nama", a.Nama);
            cmd.Parameters.AddWithValue("kid", a.KategoriId);
            cmd.Parameters.AddWithValue("durasi", a.Durasi);
            cmd.Parameters.AddWithValue("tanggal", a.Tanggal);
            cmd.ExecuteNonQuery();
        }

        public void Update(Aktivitas a)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "UPDATE aktivitas SET nama=@nama, kategori_id=@kid, durasi=@durasi, tanggal=@tanggal, status_id=1 WHERE id=@id AND status_id IN (1, 3)", conn);
            cmd.Parameters.AddWithValue("id", a.Id);
            cmd.Parameters.AddWithValue("nama", a.Nama);
            cmd.Parameters.AddWithValue("kid", a.KategoriId);
            cmd.Parameters.AddWithValue("durasi", a.Durasi);
            cmd.Parameters.AddWithValue("tanggal", a.Tanggal);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("DELETE FROM aktivitas WHERE id=@id AND status_id IN (1, 3)", conn);
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateStatus(int aktivitasId, int statusId)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand("UPDATE aktivitas SET status_id=@sid WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("id", aktivitasId);
            cmd.Parameters.AddWithValue("sid", statusId);
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
                $@"SELECT a.*, u.nama AS nama_peserta, kl.nama_latihan AS nama_kategori, sa.nama AS nama_status
                   FROM aktivitas a
                   JOIN profiles p ON a.peserta_id = p.id
                   JOIN users u ON p.user_id = u.id
                   JOIN kategori_latihan kl ON a.kategori_id = kl.id
                   JOIN status_aktivitas sa ON a.status_id = sa.id
                   WHERE a.peserta_id IN ({ph})
                   ORDER BY a.tanggal DESC", conn);
            for (int i = 0; i < pesertaIds.Count; i++)
                cmd.Parameters.AddWithValue($"p{i}", pesertaIds[i]);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public DataTable GetTotalDurasiPerKategori(int pesertaId)
            => GetReport(
                @"SELECT kl.nama_latihan AS kategori, SUM(a.durasi) AS total_durasi
                  FROM aktivitas a
                  JOIN kategori_latihan kl ON a.kategori_id = kl.id
                  WHERE a.peserta_id = @pid
                  GROUP BY kl.nama_latihan
                  ORDER BY total_durasi DESC", pesertaId);

        public DataTable GetJumlahAktivitasPerKategori(int pesertaId)
            => GetReport(
                @"SELECT kl.nama_latihan AS kategori, COUNT(*) AS jumlah_aktivitas
                  FROM aktivitas a
                  JOIN kategori_latihan kl ON a.kategori_id = kl.id
                  WHERE a.peserta_id = @pid
                  GROUP BY kl.nama_latihan
                  ORDER BY jumlah_aktivitas DESC", pesertaId);

        public DataTable GetTotalDurasiPerTanggal(int pesertaId)
            => GetReport(
                "SELECT tanggal, SUM(durasi) AS total_durasi FROM aktivitas WHERE peserta_id=@pid GROUP BY tanggal ORDER BY tanggal DESC", pesertaId);

        public DataTable GetStatusCount(int pesertaId)
            => GetReport(
                @"SELECT sa.nama AS status, COUNT(*) AS jumlah
                  FROM aktivitas a
                  JOIN status_aktivitas sa ON a.status_id = sa.id
                  WHERE a.peserta_id = @pid
                  GROUP BY sa.nama
                  ORDER BY sa.nama", pesertaId);

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

        private static bool HasColumn(NpgsqlDataReader reader, string name)
        {
            try { return reader.GetOrdinal(name) >= 0; }
            catch (IndexOutOfRangeException) { return false; }
        }

        private static T? GetColumnOrNull<T>(NpgsqlDataReader reader, string name) where T : class
        {
            return HasColumn(reader, name) && !reader.IsDBNull(reader.GetOrdinal(name))
                ? (T)reader[name]
                : null;
        }

        private static Aktivitas Map(NpgsqlDataReader reader)
        {
            var raw = reader["tanggal"];
            var tanggal = raw is DateOnly d ? d.ToDateTime(TimeOnly.MinValue) : (DateTime)raw;
            var rawCreated = reader["created_at"];
            var rawUpdated = reader["updated_at"];

            return new Aktivitas
            {
                Id = (int)reader["id"],
                PesertaId = (int)reader["peserta_id"],
                KategoriId = (int)reader["kategori_id"],
                NamaKategori = reader["nama_kategori"] as string,
                StatusId = reader["status_id"] is int sid ? sid : 1,
                NamaStatus = reader["nama_status"] as string,
                Nama = (string)reader["nama"],
                Durasi = (int)reader["durasi"],
                Tanggal = tanggal,
                CreatedAt = rawCreated is DateTime ct ? ct : DateTime.Now,
                UpdatedAt = rawUpdated is DateTime ut ? ut : DateTime.Now,
                NamaPeserta = GetColumnOrNull<string>(reader, "nama_peserta")
            };
        }
    }
}
