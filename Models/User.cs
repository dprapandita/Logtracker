namespace Logtracker.Models
{
    // Id-nya nurun dari BaseEntity, di sini tinggal data akunnya.
    public class User : BaseEntity
    {
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

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value == default ? DateTime.Now : value;
        }

        // POLYMORPHISM: override cara User mendeskripsikan dirinya.
        public override string Deskripsi() => $"{Nama} (@{Username})";
    }
}
