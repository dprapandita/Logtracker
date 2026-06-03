using Npgsql;
using Logtracker.Data;
using Logtracker.Models;

namespace Logtracker.Repositories
{
    public class FeedbackRepository
    {
        private readonly DatabaseHelper _db;

        public FeedbackRepository(DatabaseHelper db)
        {
            _db = db;
        }

        public void Insert(FeedbackAktivitas fb)
        {
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                "INSERT INTO feedback_aktivitas (aktivitas_id, coach_id, feedback) VALUES (@aid, @cid, @fb)", conn);
            cmd.Parameters.AddWithValue("aid", fb.AktivitasId);
            cmd.Parameters.AddWithValue("cid", fb.CoachId);
            cmd.Parameters.AddWithValue("fb", fb.Feedback);
            cmd.ExecuteNonQuery();
        }

        public List<FeedbackAktivitas> GetByAktivitasId(int aktivitasId)
        {
            var list = new List<FeedbackAktivitas>();
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT f.*, p.nama AS nama_coach
                  FROM feedback_aktivitas f
                  JOIN profiles p ON f.coach_id = p.id
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
            using var conn = _db.GetConnection();
            conn.Open();
            using var cmd = new NpgsqlCommand(
                @"SELECT f.*, p.nama AS nama_coach, a.nama AS nama_aktivitas, a.tanggal AS tanggal_aktivitas
                  FROM feedback_aktivitas f
                  JOIN profiles p ON f.coach_id = p.id
                  JOIN aktivitas a ON f.aktivitas_id = a.id
                  WHERE a.peserta_id = @pid
                  ORDER BY f.created_at DESC", conn);
            cmd.Parameters.AddWithValue("pid", pesertaId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Map(reader));
            return list;
        }

        private static FeedbackAktivitas Map(NpgsqlDataReader reader)
        {
            var rawTgl = reader["tanggal_aktivitas"];
            DateTime? tglAktivitas = null;
            if (rawTgl != DBNull.Value)
                tglAktivitas = rawTgl is DateOnly d ? d.ToDateTime(TimeOnly.MinValue) : (DateTime)rawTgl;

            return new FeedbackAktivitas
            {
                Id = (int)reader["id"],
                AktivitasId = (int)reader["aktivitas_id"],
                CoachId = (int)reader["coach_id"],
                Feedback = (string)reader["feedback"],
                CreatedAt = reader["created_at"] is DateTime ct ? ct : DateTime.Now,
                UpdatedAt = reader["updated_at"] is DateTime ut ? ut : DateTime.Now,
                NamaCoach = reader["nama_coach"] as string,
                NamaAktivitas = reader["nama_aktivitas"] as string,
                TanggalAktivitas = tglAktivitas
            };
        }
    }
}
