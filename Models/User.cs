namespace Logtracker.Models
{
    public class User
    {
        // ENKAPSULASI berkondisi: field privat + setter berlogika (bukan auto-property).
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        private string _username = string.Empty;
        public string Username
        {
            get => _username;
            set => _username = value?.Trim() ?? string.Empty;
        }

        private string? _email = string.Empty;
        public string? Email
        {
            get => _email;
            set => _email = value?.Trim();
        }

        private string _passwordHash = string.Empty;
        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value ?? string.Empty;
        }

        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }

        private int _roleId;
        public int RoleId
        {
            get => _roleId;
            set => _roleId = value < 0 ? 0 : value;
        }

        private string? _roleName;
        public string? RoleName
        {
            get => _roleName;
            set => _roleName = value?.Trim();
        }

        public DateTime CreatedAt { get; set; }
    }
}
