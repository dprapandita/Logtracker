namespace Logtracker.Models
{
    // INHERITANCE: mewarisi properti Id dari BaseEntity.
    public class KategoriLatihan : BaseEntity
    {
        private string _namaLatihan = string.Empty;
        public string NamaLatihan
        {
            get => _namaLatihan;
            set => _namaLatihan = value?.Trim() ?? string.Empty;
        }
    }
}
