using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    // Logika profil: ambil detail & update nama/email/password.
    public class ProfileService : BaseService
    {
        private readonly UserRepository _userRepo;
        private readonly ProfileRepository _profileRepo;

        public ProfileService(UserRepository userRepo, ProfileRepository profileRepo)
        {
            _userRepo = userRepo;
            _profileRepo = profileRepo;
        }

        // Ambil detail profil gabungan.
        public ProfileDetail? GetDetail(int userId) => _profileRepo.GetDetailByUserId(userId);

        // Update profil; password opsional (kosong = tidak diganti).
        public (bool Success, string Message) UpdateProfile(
            int userId, string nama, string? email, string? currentPassword, string? newPassword)
        {
            if (string.IsNullOrWhiteSpace(nama))
                return (false, "Nama tidak boleh kosong.");

            var user = _userRepo.GetById(userId);
            if (user == null)
                return (false, "Data pengguna tidak ditemukan.");

            // Email kosong dianggap null.
            var normalizedEmail = string.IsNullOrWhiteSpace(email) ? null : email.Trim().ToLower();
            if (normalizedEmail != null)
            {
                var pemilikEmail = _userRepo.GetByEmail(normalizedEmail);
                if (pemilikEmail != null && pemilikEmail.Id != userId)
                    return (false, "Email sudah digunakan pengguna lain.");
            }

            // Cek apakah password diganti.
            var gantiPassword = !string.IsNullOrWhiteSpace(newPassword);
            if (gantiPassword)
            {
                if (string.IsNullOrWhiteSpace(currentPassword))
                    return (false, "Masukkan password lama untuk mengganti password.");
                if (user.PasswordHash != currentPassword)
                    return (false, "Password lama salah.");
                if (newPassword!.Length < 4)
                    return (false, "Password baru minimal 4 karakter.");
            }

            return Execute(() =>
            {
                _userRepo.UpdateProfile(userId, nama.Trim(), normalizedEmail);
                if (gantiPassword)
                    _userRepo.UpdatePassword(userId, newPassword!);
            }, gantiPassword ? "Profil & password berhasil diperbarui." : "Profil berhasil diperbarui.");
        }
    }
}
