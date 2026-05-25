using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            cboRole.SelectedIndex = 0;
            txtKodePeserta.Visible = false;
            lblKodePeserta.Visible = false;

            var app = Program.GetInstance();
            if (app != null)
                _authService = app.GetAuthService();
        }

        private readonly AuthService? _authService;

        private void cboRole_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var isOrtu = cboRole.SelectedItem?.ToString() == "ortu";
            txtKodePeserta.Visible = isOrtu;
            lblKodePeserta.Visible = isOrtu;
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (_authService == null)
            {
                MessageBox.Show("Service tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var nama = txtNama.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var role = cboRole.SelectedItem?.ToString() ?? "peserta";
            var kodePeserta = txtKodePeserta.Visible ? txtKodePeserta.Text.Trim() : null;

            var (success, message) = _authService.Register(nama, email, password, role, kodePeserta);

            if (success)
            {
                MessageBox.Show(message, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBatal_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
