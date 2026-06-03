namespace Logtracker.Models
{
    public class Aktivitas
    {
        public int Id { get; set; }
        public int PesertaId { get; set; }
        public int KategoriId { get; set; }
        public string? NamaKategori { get; set; }
        public int StatusId { get; set; }
        public string? NamaStatus { get; set; }
        public string Nama { get; set; } = string.Empty;
        public int Durasi { get; set; }
        public DateTime Tanggal { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? NamaPeserta { get; set; }
    }
}
