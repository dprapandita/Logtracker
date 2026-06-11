namespace Logtracker.Models
{
    public class KategoriLatihan
    {
        // ENKAPSULASI berkondisi: field privat + setter berlogika (bukan auto-property).
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        private string _namaLatihan = string.Empty;
        public string NamaLatihan
        {
            get => _namaLatihan;
            set => _namaLatihan = value?.Trim() ?? string.Empty;
        }
    }
}
