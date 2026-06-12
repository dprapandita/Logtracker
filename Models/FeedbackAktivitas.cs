namespace Logtracker.Models
{
    // INHERITANCE: mewarisi properti Id dari BaseEntity.
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

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

        public DateTime? TanggalAktivitas { get; set; }
    }
}
