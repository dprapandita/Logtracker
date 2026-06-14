namespace Logtracker.Models
{
    // Turunan BaseEntity, nyimpen nama status aktivitas.
    public class StatusAktivitas : BaseEntity
    {
        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }
    }
}
