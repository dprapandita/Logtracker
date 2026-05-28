using Npgsql;

namespace Logtracker.Data
{
    public class DatabaseHelper
    {
        // Pindahkan Connection String ke sini sebagai konstanta default
        public const string DefaultConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=12345;Database=logtracker";

        private readonly string _connectionString;

        // Gunakan default parameter agar bisa di-override jika diperlukan nanti (misal untuk testing)
        public DatabaseHelper(string connectionString = DefaultConnectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        // Opsional: Expose connection string jika dibutuhkan oleh bagian program lain
        public string ConnectionString => _connectionString;
    }
}