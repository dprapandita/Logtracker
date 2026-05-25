using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Masukkan email dan password.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var app = Program.GetInstance();
                if (app == null) return;

                var result = app.GetAuthService().Login(email, password);
                if (result == null)
                {
                    MessageBox.Show("Email atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Form dashboard = result.Role switch
                {
                    "peserta" => new PesertaDashboardForm(app.GetAktivitasService(), app.GetCoachService(), app.GetLaporanService(), result.Profile),
                    "coach" => new CoachDashboardForm(app.GetCoachService(), app.GetLaporanService(), result.Profile),
                    "ortu" => new OrtuDashboardForm(app.GetOrangTuaService(), app.GetLaporanService(), result.Profile),
                    _ => throw new InvalidOperationException("Role tidak dikenal.")
                };

                Hide();
                dashboard.ShowDialog();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Terjadi kesalahan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblRegister_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }
    }
}
