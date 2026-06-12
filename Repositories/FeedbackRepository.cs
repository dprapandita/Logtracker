using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    // INHERITANCE: mewarisi DatabaseHelper dan helper koneksi dari BaseRepository.
    public class FeedbackRepository : BaseRepository
    {
        public FeedbackRepository(DatabaseHelper db) : base(db)
        {
        }

        public void Insert(FeedbackAktivitas fb)
        {
            ExecuteNonQuery(
                "INSERT INTO feedback_aktivitas (aktivitas_id, coach_id, feedback) VALUES (@aid, @cid, @fb)", p =>
                {
                    p.AddWithValue("aid", fb.AktivitasId);
                    p.AddWithValue("cid", fb.CoachId);
                    p.AddWithValue("fb", fb.Feedback);
                });
        }

        // Memanggil stored procedure sp_beri_feedback: menyimpan feedback DAN
        // mengubah status aktivitas dalam satu transaksi (COMMIT/ROLLBACK di DB).
        // Tidak dibungkus NpgsqlTransaction agar COMMIT/ROLLBACK dalam prosedur berjalan.
        public void BeriFeedbackTransaksional(int aktivitasId, int coachId, string feedback, int statusId)
        {
            ExecuteNonQuery("CALL sp_beri_feedback(@aid, @cid, @fb, @sid)", p =>
            {
                p.AddWithValue("aid", aktivitasId);
                p.AddWithValue("cid", coachId);
                p.AddWithValue("fb", feedback);
                p.AddWithValue("sid", statusId);
            });
        }

        public List<FeedbackAktivitas> GetByAktivitasId(int aktivitasId)
        {
            var list = new List<FeedbackAktivitas>();
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT f.*, u.nama AS nama_coach
                  FROM feedback_aktivitas f
                  JOIN profiles p ON f.coach_id = p.id
                  JOIN users u ON p.user_id = u.id
                  WHERE f.aktivitas_id = @aid
                  ORDER BY f.created_at DESC", conn);
            cmd.Parameters.AddWithValue("aid", aktivitasId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        public List<FeedbackAktivitas> GetFeedbackForPeserta(int pesertaId)
        {
            var list = new List<FeedbackAktivitas>();
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(
                @"SELECT f.*, u.nama AS nama_coach, a.nama AS nama_aktivitas, a.tanggal AS tanggal_aktivitas
                  FROM feedback_aktivitas f
                  JOIN profiles p ON f.coach_id = p.id
                  JOIN users u ON p.user_id = u.id
                  JOIN aktivitas a ON f.aktivitas_id = a.id
                  WHERE a.peserta_id = @pid
                  ORDER BY f.created_at DESC", conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        private static bool HasColumn(NpgsqlDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
                if (string.Equals(reader.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static FeedbackAktivitas Map(NpgsqlDataReader reader)
        {
            DateTime? tglAktivitas = null;
            if (HasColumn(reader, "tanggal_aktivitas"))
            {
                var rawTgl = reader["tanggal_aktivitas"];
                if (rawTgl != DBNull.Value)
                    tglAktivitas = rawTgl is DateOnly d ? d.ToDateTime(TimeOnly.MinValue) : (DateTime)rawTgl;
            }

            return new FeedbackAktivitas
            {
                Id = (int)reader["id"],
                AktivitasId = (int)reader["aktivitas_id"],
                CoachId = (int)reader["coach_id"],
                Feedback = (string)reader["feedback"],
                CreatedAt = reader["created_at"] is DateTime ct ? ct : DateTime.Now,
                UpdatedAt = reader["updated_at"] is DateTime ut ? ut : DateTime.Now,
                NamaCoach = reader["nama_coach"] as string,
                NamaAktivitas = HasColumn(reader, "nama_aktivitas") ? reader["nama_aktivitas"] as string : null,
                TanggalAktivitas = tglAktivitas
            };
        }
    }
}
