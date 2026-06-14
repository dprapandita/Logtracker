using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Controllers
{
    public class AuthController
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        public LoginResult? Login(string username, string password)
            => _authService.Login(username, password);

        public List<Role> GetRoles()
            => _authService.GetRoles();

        public (bool Success, string Message) Register(
            string username,
            string nama,
            string? email,
            string password,
            string roleName,
            string? kodePesertaOrtu = null)
            => _authService.Register(username, nama, email, password, roleName, kodePesertaOrtu);
    }
}
