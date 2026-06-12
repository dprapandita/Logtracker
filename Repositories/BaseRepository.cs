using Npgsql;
using Logtracker.Data;

namespace Logtracker.Repositories
{
    // ABSTRAKSI + INHERITANCE: kelas dasar abstrak untuk semua repository.
    // Menyimpan dependensi DatabaseHelper dan menyembunyikan detail pembukaan
    // koneksi serta eksekusi perintah, sehingga repository turunan cukup fokus
    // pada query-nya masing-masing.
    public abstract class BaseRepository
    {
        protected readonly DatabaseHelper _db;

        protected BaseRepository(DatabaseHelper db)
        {
            _db = db;
        }

        // Membuka koneksi baru yang sudah siap dipakai (sudah Open()).
        protected NpgsqlConnection OpenConnection()
        {
            var conn = _db.GetConnection();
            conn.Open();
            return conn;
        }

        // Helper perintah non-query (INSERT/UPDATE/DELETE/CALL): kembalikan jumlah baris terdampak.
        protected int ExecuteNonQuery(string sql, Action<NpgsqlParameterCollection>? bind = null)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            bind?.Invoke(cmd.Parameters);
            return cmd.ExecuteNonQuery();
        }

        // Helper perintah scalar: kembalikan satu nilai dari baris/kolom pertama.
        protected object? ExecuteScalar(string sql, Action<NpgsqlParameterCollection>? bind = null)
        {
            using var conn = OpenConnection();
            using var cmd = new NpgsqlCommand(sql, conn);
            bind?.Invoke(cmd.Parameters);
            return cmd.ExecuteScalar();
        }

        // Versi transaksi: pakai koneksi + transaksi yang sudah dibuka pemanggil.
        protected static int ExecuteNonQuery(NpgsqlConnection conn, NpgsqlTransaction tx, string sql, Action<NpgsqlParameterCollection>? bind = null)
        {
            using var cmd = new NpgsqlCommand(sql, conn, tx);
            bind?.Invoke(cmd.Parameters);
            return cmd.ExecuteNonQuery();
        }

        protected static object? ExecuteScalar(NpgsqlConnection conn, NpgsqlTransaction tx, string sql, Action<NpgsqlParameterCollection>? bind = null)
        {
            using var cmd = new NpgsqlCommand(sql, conn, tx);
            bind?.Invoke(cmd.Parameters);
            return cmd.ExecuteScalar();
        }
    }
}
