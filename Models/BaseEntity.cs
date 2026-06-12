namespace Logtracker.Models
{
    // ABSTRAKSI + INHERITANCE: kelas dasar abstrak untuk seluruh entitas database.
    // Tidak bisa di-instansiasi langsung; hanya menjadi induk bagi model konkret.
    // Menyatukan properti Id beserta ENKAPSULASI berkondisi (Id tidak boleh negatif)
    // agar tidak ditulis ulang di setiap model.
    public abstract class BaseEntity
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }
    }
}
