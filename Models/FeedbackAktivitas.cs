namespace Logtracker.Models
{
    // Turunan BaseEntity. Catatan/feedback coach untuk sebuah aktivitas.
    public class FeedbackAktivitas : BaseEntity
    {
        private int _aktivitasId;
        public int AktivitasId
        {
            get => _aktivitasId;
            set => _aktivitasId = value < 0 ? 0 : value;
        }

        private int _coachId;
        public int CoachId
        {
            get => _coachId;
            set => _coachId = value < 0 ? 0 : value;
        }

        private string _feedback = string.Empty;
        public string Feedback
        {
            get => _feedback;
            set => _feedback = value?.Trim() ?? string.Empty;
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value == default ? DateTime.Now : value;
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value == default ? DateTime.Now : value;
        }

        private string? _namaCoach;
        public string? NamaCoach
        {
            get => _namaCoach;
            set => _namaCoach = value?.Trim();
        }

        private string? _namaAktivitas;
        public string? NamaAktivitas
        {
            get => _namaAktivitas;
            set => _namaAktivitas = value?.Trim();
        }

        private DateTime? _tanggalAktivitas;
        public DateTime? TanggalAktivitas
        {
            get => _tanggalAktivitas;
            set => _tanggalAktivitas = value;
        }
    }
}
