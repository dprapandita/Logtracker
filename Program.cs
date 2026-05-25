using Logtracker.Data;
using Logtracker.Forms;
using Logtracker.Repositories;
using Logtracker.Services;

namespace Logtracker
{
    internal static class Program
    {
        private static AuthService? _authService;
        private static AktivitasService? _aktivitasService;
        private static CoachService? _coachService;
        private static OrangTuaService? _orangTuaService;
        private static LaporanService? _laporanService;

        private const string ConnString = "Host=localhost;Port=5400;Username=postgres;Password=123;Database=logtracker";

        public static string ConnectionString => ConnString;

        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ApplicationConfiguration.Initialize();

            var db = new DatabaseHelper(ConnString);

            var akunRepo = new AkunLoginRepository(db);
            var profileRepo = new ProfileRepository(db);
            var aktivitasRepo = new AktivitasRepository(db);
            var feedbackRepo = new FeedbackRepository(db);
            var relasiRepo = new RelasiRepository(db);
            var roleRepo = new RoleRepository(db);

            _authService = new AuthService(akunRepo, profileRepo, relasiRepo, roleRepo);
            _aktivitasService = new AktivitasService(aktivitasRepo);
            _coachService = new CoachService(profileRepo, aktivitasRepo, feedbackRepo);
            _orangTuaService = new OrangTuaService(profileRepo, relasiRepo, aktivitasRepo, feedbackRepo);
            _laporanService = new LaporanService(aktivitasRepo);

            Application.Run(new LoginForm());
        }

        public static ProgramInstance? GetInstance()
        {
            return _authService != null ? new ProgramInstance
            {
                AuthService = _authService!,
                AktivitasService = _aktivitasService!,
                CoachService = _coachService!,
                OrangTuaService = _orangTuaService!,
                LaporanService = _laporanService!
            } : null;
        }
    }

    public class ProgramInstance
    {
        public required AuthService AuthService { get; set; }
        public required AktivitasService AktivitasService { get; set; }
        public required CoachService CoachService { get; set; }
        public required OrangTuaService OrangTuaService { get; set; }
        public required LaporanService LaporanService { get; set; }

        public AuthService GetAuthService() => AuthService;
        public AktivitasService GetAktivitasService() => AktivitasService;
        public CoachService GetCoachService() => CoachService;
        public OrangTuaService GetOrangTuaService() => OrangTuaService;
        public LaporanService GetLaporanService() => LaporanService;
    }
}
