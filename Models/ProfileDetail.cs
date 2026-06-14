namespace Logtracker.Models
{
    // Gabungan data user + profil buat ditampilin di form.
    public class ProfileDetail
    {
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => _userId = value < 0 ? 0 : value;
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => _username = value?.Trim() ?? string.Empty;
        }

        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set => _email = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        private string _role = string.Empty;
        public string Role
        {
            get => _role;
            set => _role = string.IsNullOrWhiteSpace(value) ? "-" : value.Trim();
        }

        private string? _kodePeserta;
        public string? KodePeserta
        {
            get => _kodePeserta;
            set => _kodePeserta = value?.Trim();
        }
    }
}
