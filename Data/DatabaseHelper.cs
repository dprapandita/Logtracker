using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Logtracker.Data
{
    public class DatabaseHelper
    {
        public static string DefaultConnectionString { get; private set; }
            = "Host=localhost;Port=5432;Username=postgres;Password=1234;Database=pbo1";

        private readonly string _connectionString;

        public static string? ConfigLoadError { get; private set; }

        static DatabaseHelper()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .Build();

                var conn = config.GetConnectionString("DefaultConnection");
                if (!string.IsNullOrWhiteSpace(conn))
                    DefaultConnectionString = conn;
                else
                    ConfigLoadError = $"appsettings.json not found or missing DefaultConnection. Base dir: {AppDomain.CurrentDomain.BaseDirectory}";
            }
            catch (Exception ex)
            {
                ConfigLoadError = ex.Message;
            }
        }

        // Parameterless ctor delegates to the main ctor using the static DefaultConnectionString.
        public DatabaseHelper() : this(DefaultConnectionString)
        {
        }

        // Main ctor takes a required string parameter (no compile-time default).
        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public string ConnectionString => _connectionString;
    }
}
