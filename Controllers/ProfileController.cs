using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class ProfileController
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        public ProfileDetail? GetDetail(int userId)
            => _profileService.GetDetail(userId);

        public (bool Success, string Message) UpdateProfile(
            int userId,
            string nama,
            string? email,
            string? currentPassword,
            string? newPassword)
            => _profileService.UpdateProfile(userId, nama, email, currentPassword, newPassword);
    }
}
