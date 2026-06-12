namespace Logtracker.Models
{
    // INHERITANCE: mewarisi properti Id dari BaseEntity.
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
