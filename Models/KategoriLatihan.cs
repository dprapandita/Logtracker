namespace Logtracker.Models
{
    // Diwarisi dari BaseEntity, isinya tinggal nama kategori latihan.
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
