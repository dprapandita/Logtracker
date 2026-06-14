namespace Logtracker.Models
{
    // Cuma nyimpen nama peran, Id-nya udah diwarisi dari BaseEntity.
    public class Role : BaseEntity
    {
        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }
    }
}
