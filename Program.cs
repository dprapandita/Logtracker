using Logtracker.Data;
using Logtracker.Forms;
using Logtracker.Repositories;
using Logtracker.Services;

namespace Logtracker
{
    internal static class Program
    {
        // Cukup simpan 1 instance utama
        private static ProgramInstance? _instance;

        public static string ConnectionString => Logtracker.Data.DatabaseHelper.DefaultConnectionString;

        [STAThread]
        static void Main()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ApplicationConfiguration.Initialize();

            // DatabaseHelper sekarang mengurus connection string-nya sendiri
            var db = new DatabaseHelper();

            // Panggil method untuk setup Dependency / Service
            InitializeServices(db);

            Application.Run(new LoginForm());
        }

        private static void InitializeServices(DatabaseHelper db)
        {
            // 1. Inisialisasi Repositories
            var akunRepo = new AkunLoginRepository(db);
            var profileRepo = new ProfileRepository(db);
            var aktivitasRepo = new AktivitasRepository(db);
            var feedbackRepo = new FeedbackRepository(db);
            var relasiRepo = new RelasiRepository(db);
            var roleRepo = new RoleRepository(db);

            // 2. Inisialisasi Services dan simpan ke dalam _instance
            _instance = new ProgramInstance
            {
                AuthService = new AuthService(akunRepo, profileRepo, relasiRepo, roleRepo),
                AktivitasService = new AktivitasService(aktivitasRepo),
                CoachService = new CoachService(profileRepo, aktivitasRepo, feedbackRepo),
                OrangTuaService = new OrangTuaService(profileRepo, relasiRepo, aktivitasRepo, feedbackRepo),
                LaporanService = new LaporanService(aktivitasRepo)
            };
        }

        public static ProgramInstance? GetInstance()
        {
            return _instance;
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