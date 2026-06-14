namespace Logtracker.Services
{
    // Induk abstract buat semua service
    public abstract class BaseService
    {
        // Mengembalikan sukses + pesan, atau gagal + pesan error.
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
