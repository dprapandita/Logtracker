namespace Logtracker.Services
{
    // ABSTRAKSI + INHERITANCE: kelas dasar abstrak untuk semua service.
    // Menyediakan pola eksekusi (try/catch -> hasil Success/Message) yang seragam
    // agar service turunan tidak menulis ulang blok penanganan error yang sama.
    public abstract class BaseService
    {
        // Bungkus operasi (umumnya pemanggilan repository) dalam try/catch dan
        // kembalikan hasil standar: sukses dengan pesan, atau gagal dengan pesan error.
        protected static (bool Success, string Message) Execute(Action action, string successMessage)
        {
            try
            {
                action();
                return (true, successMessage);
            }
            catch (Exception ex)
            {
                return (false, $"Gagal: {ex.Message}");
            }
        }
    }
}
