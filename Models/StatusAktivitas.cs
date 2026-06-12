namespace Logtracker.Models
{
    // INHERITANCE: mewarisi properti Id dari BaseEntity.
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
