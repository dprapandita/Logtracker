using System.Security.Cryptography;
using System.Text;
using Logtracker.Models;
using Logtracker.Repositories;

namespace Logtracker.Services
{
    public class LoginResult
    {
        public Profile Profile { get; set; } = null!;
        public string Role { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class AuthService
    {
        private readonly AkunLoginRepository _akunRepo;
        private readonly ProfileRepository _profileRepo;
        private readonly RelasiRepository _relasiRepo;
        private readonly RoleRepository _roleRepo;

        public AuthService(AkunLoginRepository akunRepo, ProfileRepository profileRepo, RelasiRepository relasiRepo, RoleRepository roleRepo)
        {
            _akunRepo = akunRepo;
            _profileRepo = profileRepo;
            _relasiRepo = relasiRepo;
            _roleRepo = roleRepo;
        }

        public LoginResult? Login(string email, string password)
        {
            var akun = _akunRepo.GetByEmail(email);
            if (akun == null) return null;

            var hash = HashPassword(password);
            if (akun.PasswordHash != hash) return null;

            var profile = _profileRepo.GetById(akun.ProfileId);
            if (profile == null) return null;

            return new LoginResult
            {
                Profile = profile,
                Role = akun.RoleName ?? "",
                Email = akun.Email
            };
        }

        public (bool Success, string Message) Register(string nama, string email, string password, string roleName, string? kodePesertaOrtu = null)
        {
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return (false, "Semua field harus diisi.");

            if (_akunRepo.GetByEmail(email) != null)
                return (false, "Email sudah terdaftar.");

            if (roleName == "ortu")
            {
                if (string.IsNullOrWhiteSpace(kodePesertaOrtu))
                    return (false, "Masukkan kode peserta anak.");
                if (_profileRepo.GetPesertaByKode(kodePesertaOrtu.Trim().ToUpper()) == null)
                    return (false, "Kode peserta tidak ditemukan.");
            }

            try
            {
                var profile = new Profile { Nama = nama.Trim() };
                if (roleName == "peserta")
                    profile.KodePeserta = _profileRepo.GenerateKodePeserta();

                var profileId = _profileRepo.Insert(profile);

                var roleId = _roleRepo.GetRoleIdByName(roleName)
                    ?? throw new InvalidOperationException("Role tidak ditemukan di database.");

                var akun = new AkunLogin
                {
                    Email = email.Trim().ToLower(),
                    PasswordHash = HashPassword(password),
                    RoleId = roleId,
                    ProfileId = profileId
                };
                _akunRepo.Insert(akun);

                if (roleName == "ortu" && !string.IsNullOrWhiteSpace(kodePesertaOrtu))
                {
                    var peserta = _profileRepo.GetPesertaByKode(kodePesertaOrtu.Trim().ToUpper());
                    if (peserta != null)
                        _relasiRepo.ConnectAnak(profileId, peserta.Id);
                }

                var msg = roleName == "peserta"
                    ? $"Registrasi berhasil! Kode peserta Anda: {profile.KodePeserta}"
                    : "Registrasi berhasil!";
                return (true, msg);
            }
            catch (Exception ex)
            {
                return (false, $"Gagal mendaftar: {ex.Message}");
            }
        }

        private static string HashPassword(string password)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(bytes).ToLower();
        }
    }
}
