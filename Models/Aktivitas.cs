namespace Logtracker.Models
{
    // Ngambil Id dari BaseEntity. Ini data log latihan tiap peserta.
    public class Aktivitas : BaseEntity
    {
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

        private DateTime _tanggal;
        public DateTime Tanggal
        {
            get => _tanggal;
            set => _tanggal = value == default ? DateTime.Now : value;
        }

        private DateTime _createdAt;
        public DateTime CreatedAt
        {
            get => _createdAt;
            set => _createdAt = value == default ? DateTime.Now : value;
        }

        private DateTime _updatedAt;
        public DateTime UpdatedAt
        {
            get => _updatedAt;
            set => _updatedAt = value == default ? DateTime.Now : value;
        }

        private string? _namaPeserta;
        public string? NamaPeserta
        {
            get => _namaPeserta;
            set => _namaPeserta = value?.Trim();
        }

        // POLYMORPHISM: override cara Aktivitas mendeskripsikan dirinya.
        public override string Deskripsi() => $"{Nama} - {Durasi} menit";
    }
}
