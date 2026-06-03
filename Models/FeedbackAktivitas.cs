namespace Logtracker.Models
{
    public class FeedbackAktivitas
    {
        public int Id { get; set; }
        public int AktivitasId { get; set; }
        public int CoachId { get; set; }
        public string Feedback { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? NamaCoach { get; set; }
        public string? NamaAktivitas { get; set; }
        public DateTime? TanggalAktivitas { get; set; }
    }
}
