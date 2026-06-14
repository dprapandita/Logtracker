using Logtracker.Controllers;
using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtKodePeserta.Visible = false;
            lblKodePeserta.Visible = false;

            var app = Program.GetInstance();
            if (app != null)
            {
                _authController = app.AuthController;
                if (_authController != null)
                    LoadRoles();
            }
        }

        private readonly AuthController? _authController;

        private void cboRole_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var role = cboRole.SelectedItem as Role;
            var isOrtu = role?.Nama == "ortu";
            txtKodePeserta.Visible = isOrtu;
            lblKodePeserta.Visible = isOrtu;
        }

        private void btnRegister_Click(object? sender, EventArgs e)
        {
            if (_authController == null)
            {
                MessageBox.Show("Controller tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var username = txtUsername.Text.Trim();
            var nama = txtNama.Text.Trim();
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var role = (cboRole.SelectedItem as Role)?.Nama ?? "peserta";
            var kodePeserta = txtKodePeserta.Visible ? txtKodePeserta.Text.Trim() : null;

            var (success, message) = _authController.Register(username, nama, email, password, role, kodePeserta);

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

        private void LoadRoles()
        {
            if (_authController == null) return;
            var roles = _authController.GetRoles();
            cboRole.DataSource = roles;
            cboRole.DisplayMember = "Nama";
            cboRole.ValueMember = "Nama";
        }

        private void lblKodePeserta_Click(object sender, EventArgs e)
        {

        }
    }
}
