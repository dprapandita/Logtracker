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
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Masukkan username dan password.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var app = Program.GetInstance();
                if (app == null) return;

                var result = app.AuthController.Login(username, password);
                if (result == null)
                {
                    MessageBox.Show("Username atau password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Form dashboard = result.Role switch
                {
                    "peserta" => new PesertaDashboardForm(app.PesertaDashboardController, result.Profile),
                    "coach" => new CoachDashboardForm(app.CoachDashboardController, result.Profile),
                    "ortu" => new OrtuDashboardForm(app.OrtuDashboardController, result.Profile),
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

        private void lblPassword_Click(object sender, EventArgs e)
 
       {
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
