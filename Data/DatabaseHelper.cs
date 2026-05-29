using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Logtracker.Data
{
    public class DatabaseHelper
    {
        public static string DefaultConnectionString { get; private set; }
            = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=logtracker_db";

        private readonly string _connectionString;

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
            }
            catch
            {
                // fallback ke default
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
