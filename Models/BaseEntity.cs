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

        // POLYMORPHISM: method virtual yang bisa dipakai/di-override entity mana pun.
        // Default-nya menampilkan Id; tiap turunan boleh override sesuai datanya.
        public virtual string Deskripsi() => $"#{Id}";
    }
}
