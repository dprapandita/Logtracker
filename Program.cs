using Logtracker.Data;
using Logtracker.Controllers;
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

            if (DatabaseHelper.ConfigLoadError != null)
                MessageBox.Show(DatabaseHelper.ConfigLoadError, "Config Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var db = new DatabaseHelper();
            InitializeServices(db);

            Application.Run(new LoginForm());
        }

        private static void InitializeServices(DatabaseHelper db)
        {
            var userRepo = new UserRepository(db);
            var profileRepo = new ProfileRepository(db);
            var pesertaDetailRepo = new PesertaDetailRepository(db);
            var aktivitasRepo = new AktivitasRepository(db);
            var feedbackRepo = new FeedbackRepository(db);
            var relasiRepo = new RelasiRepository(db);
            var roleRepo = new RoleRepository(db);
            var kategoriRepo = new KategoriRepository(db);
            var statusRepo = new StatusRepository(db);

            var authService = new AuthService(db, userRepo, profileRepo, pesertaDetailRepo, relasiRepo, roleRepo);
            var aktivitasService = new AktivitasService(aktivitasRepo);
            var coachService = new CoachService(profileRepo, aktivitasRepo, feedbackRepo, relasiRepo);
            var orangTuaService = new OrangTuaService(profileRepo, relasiRepo, aktivitasRepo, feedbackRepo);
            var laporanService = new LaporanService(aktivitasRepo);
            var kategoriService = new KategoriService(kategoriRepo);
            var statusService = new StatusService(statusRepo);
            var profileService = new ProfileService(userRepo, profileRepo);

            _instance = new ProgramInstance
            {
                AuthService = authService,
                AktivitasService = aktivitasService,
                CoachService = coachService,
                OrangTuaService = orangTuaService,
                LaporanService = laporanService,
                KategoriService = kategoriService,
                StatusService = statusService,
                ProfileService = profileService,
                AuthController = new AuthController(authService),
                PesertaDashboardController = new PesertaDashboardController(aktivitasService, coachService),
                CoachDashboardController = new CoachDashboardController(coachService, statusService),
                OrtuDashboardController = new OrtuDashboardController(orangTuaService),
                DetailAktivitasController = new DetailAktivitasController(coachService),
                LaporanController = new LaporanController(laporanService),
                KategoriController = new KategoriController(kategoriService),
                ProfileController = new ProfileController(profileService)
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
        public required ProfileService ProfileService { get; set; }
        public required AuthController AuthController { get; set; }
        public required PesertaDashboardController PesertaDashboardController { get; set; }
        public required CoachDashboardController CoachDashboardController { get; set; }
        public required OrtuDashboardController OrtuDashboardController { get; set; }
        public required DetailAktivitasController DetailAktivitasController { get; set; }
        public required LaporanController LaporanController { get; set; }
        public required KategoriController KategoriController { get; set; }
        public required ProfileController ProfileController { get; set; }
    }
}
