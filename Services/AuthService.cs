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
        public string Username { get; set; } = string.Empty;
    }

    public class AuthService
    {
        private readonly UserRepository _userRepo;
        private readonly ProfileRepository _profileRepo;
        private readonly PesertaDetailRepository _pesertaDetailRepo;
        private readonly RelasiRepository _relasiRepo;
        private readonly RoleRepository _roleRepo;

        public AuthService(
            UserRepository userRepo,
            ProfileRepository profileRepo,
            PesertaDetailRepository pesertaDetailRepo,
            RelasiRepository relasiRepo,
            RoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _profileRepo = profileRepo;
            _pesertaDetailRepo = pesertaDetailRepo;
            _relasiRepo = relasiRepo;
            _roleRepo = roleRepo;
        }

        public LoginResult? Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null) return null;

            var hash = HashPassword(password);
            if (user.PasswordHash != hash) return null;

            var profile = _profileRepo.GetByUserId(user.Id);
            if (profile == null) return null;

            return new LoginResult
            {
                Profile = profile,
                Role = user.RoleName ?? "",
                Username = user.Username
            };
        }

        public List<Role> GetRoles()
        {
            return _roleRepo.GetAll();
        }

        public (bool Success, string Message) Register(string username, string nama, string? email, string password, string roleName, string? kodePesertaOrtu = null)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(password))
                return (false, "Semua field harus diisi.");

            if (_userRepo.GetByUsername(username) != null)
                return (false, "Username sudah digunakan.");

            if (_userRepo.GetByEmail(email) != null)
                return (false, "Email sudah terdaftar.");

            Profile? anakProfile = null;
            if (roleName == "ortu")
            {
                if (string.IsNullOrWhiteSpace(kodePesertaOrtu))
                    return (false, "Masukkan kode peserta anak.");
                anakProfile = _profileRepo.GetPesertaByKode(kodePesertaOrtu.Trim().ToUpper());
                if (anakProfile == null)
                    return (false, "Kode peserta tidak ditemukan.");
            }

            try
            {
                var roleId = _roleRepo.GetRoleIdByName(roleName)
                    ?? throw new InvalidOperationException("Role tidak ditemukan di database.");

                var user = new User
                {
                    Username = username.Trim().ToLower(),
                    Email = string.IsNullOrWhiteSpace(email) ? null : email.Trim().ToLower(),
                    PasswordHash = HashPassword(password),
                    Nama = nama.Trim(),
                    RoleId = roleId
                };
                var userId = _userRepo.Insert(user);

                var profile = new Profile
                {
                    UserId = userId
                };
                var profileId = _profileRepo.Insert(profile);

                string? kodePeserta = null;
                if (roleName == "peserta")
                {
                    kodePeserta = _pesertaDetailRepo.GenerateKodePeserta();
                    _pesertaDetailRepo.Insert(new PesertaDetail
                    {
                        UserId = userId,
                        KodePeserta = kodePeserta
                    });
                }

                if (roleName == "ortu" && anakProfile != null)
                {
                    _relasiRepo.ConnectAnak(profileId, anakProfile.Id);
                }

                var msg = roleName == "peserta"
                    ? $"Registrasi berhasil! Kode peserta Anda: {kodePeserta}"
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
