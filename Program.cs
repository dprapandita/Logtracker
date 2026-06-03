using Logtracker.Data;
using Logtracker.Forms;
using Logtracker.Repositories;
using Logtracker.Services;

namespace Logtracker
{
    internal static class Program
    {
        private static ProgramInstance? _instance;

        public static string ConnectionString => DatabaseHelper.DefaultConnectionString;

        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ApplicationConfiguration.Initialize();

            var db = new DatabaseHelper();
            InitializeServices(db);

            Application.Run(new LoginForm());
        }

        private static void InitializeServices(DatabaseHelper db)
        {
            var userRepo = new UserRepository(db);
            var profileRepo = new ProfileRepository(db);
            var aktivitasRepo = new AktivitasRepository(db);
            var feedbackRepo = new FeedbackRepository(db);
            var relasiRepo = new RelasiRepository(db);
            var roleRepo = new RoleRepository(db);
            var kategoriRepo = new KategoriRepository(db);
            var statusRepo = new StatusRepository(db);

            _instance = new ProgramInstance
            {
                AuthService = new AuthService(userRepo, profileRepo, relasiRepo, roleRepo),
                AktivitasService = new AktivitasService(aktivitasRepo),
                CoachService = new CoachService(profileRepo, aktivitasRepo, feedbackRepo),
                OrangTuaService = new OrangTuaService(profileRepo, relasiRepo, aktivitasRepo, feedbackRepo),
                LaporanService = new LaporanService(aktivitasRepo),
                KategoriService = new KategoriService(kategoriRepo),
                StatusService = new StatusService(statusRepo)
            };
        }

        public static ProgramInstance? GetInstance() => _instance;
    }

    public class ProgramInstance
    {
        public required AuthService AuthService { get; set; }
        public required AktivitasService AktivitasService { get; set; }
        public required CoachService CoachService { get; set; }
        public required OrangTuaService OrangTuaService { get; set; }
        public required LaporanService LaporanService { get; set; }
        public required KategoriService KategoriService { get; set; }
        public required StatusService StatusService { get; set; }

        public AuthService GetAuthService() => AuthService;
        public AktivitasService GetAktivitasService() => AktivitasService;
        public CoachService GetCoachService() => CoachService;
        public OrangTuaService GetOrangTuaService() => OrangTuaService;
        public LaporanService GetLaporanService() => LaporanService;
        public KategoriService GetKategoriService() => KategoriService;
        public StatusService GetStatusService() => StatusService;
    }
}
