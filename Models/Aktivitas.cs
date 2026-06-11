namespace Logtracker.Models
{
    public class Aktivitas
    {
        // ENKAPSULASI berkondisi: field privat + setter berlogika (bukan auto-property).
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        private int _pesertaId;
        public int PesertaId
        {
            get => _pesertaId;
            set => _pesertaId = value < 0 ? 0 : value;
        }

        private int _kategoriId;
        public int KategoriId
        {
            get => _kategoriId;
            set => _kategoriId = value < 0 ? 0 : value;
        }

        private string? _namaKategori;
        public string? NamaKategori
        {
            get => _namaKategori;
            set => _namaKategori = value?.Trim();
        }

        private int _statusId;
        public int StatusId
        {
            get => _statusId;
            set => _statusId = value < 0 ? 0 : value;
        }

        private string? _namaStatus;
        public string? NamaStatus
        {
            get => _namaStatus;
            set => _namaStatus = value?.Trim();
        }

        private string _nama = string.Empty;
        public string Nama
        {
            get => _nama;
            set => _nama = value?.Trim() ?? string.Empty;
        }

        private int _durasi;
        public int Durasi
        {
            get => _durasi;
            set => _durasi = value < 0 ? 0 : value;
        }

        public DateTime Tanggal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        private string? _namaPeserta;
        public string? NamaPeserta
        {
            get => _namaPeserta;
            set => _namaPeserta = value?.Trim();
        }
    }
}
