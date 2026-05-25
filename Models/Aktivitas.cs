namespace Logtracker.Models
{
    public class Aktivitas
    {
        public int Id { get; set; }
        public int PesertaId { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Kategori { get; set; } = string.Empty;
        public int Durasi { get; set; }
        public DateTime Tanggal { get; set; }
        public string Status { get; set; } = "Menunggu";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string? NamaPeserta { get; set; }
    }
}
