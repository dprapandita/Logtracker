namespace Logtracker.Models
{
    // Kelas induk buat semua model
    public abstract class BaseEntity
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        // Default : deskripsi sederhana pakai Id. Turunan bisa override untuk info lebih spesifik.
        public virtual string Deskripsi() => $"#{Id}";
    }
}
