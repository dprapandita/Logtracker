using Logtracker.Models;
using Logtracker.Services;

namespace Logtracker.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService? _authService;
        private readonly List<Role> _roles = [];

        public RegisterForm()
        {
            InitializeComponent();

            var app = Program.GetInstance();
            if (app != null)
            {
                _authService = app.GetAuthService();
                _roles = _authService.GetRoles();
                cboRole.Items.Clear();
                foreach (var r in _roles)
                    cboRole.Items.Add(r.Nama);
                if (cboRole.Items.Count > 0)
                    cboRole.SelectedIndex = 0;
            }

            txtKodePeserta.Visible = false;
            lblKodePeserta.Visible = false;
        }

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

            var username = txtUsername.Text.Trim();
            var nama = txtNama.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var role = cboRole.SelectedItem?.ToString() ?? "";
            var kodePeserta = txtKodePeserta.Visible ? txtKodePeserta.Text.Trim() : null;

            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Pilih role.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, message) = _authService.Register(username, nama, email, password, role, kodePeserta);

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
