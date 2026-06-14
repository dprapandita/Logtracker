namespace Logtracker.Models
{
    // Turunan BaseEntity, Id udah dapet dari sana.
    public class Profile : BaseEntity
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => _userId = value < 0 ? 0 : value;
        }

        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }

        private string? _kodePeserta;
        public string? KodePeserta
        {
            get => _kodePeserta;
            set => _kodePeserta = value?.Trim();
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
    }
}
