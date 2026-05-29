namespace Logtracker.Models
{
    public class AkunLogin
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public int ProfileId { get; set; }
        public string? RoleName { get; set; }
    }
}
