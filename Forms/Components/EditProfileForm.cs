using Logtracker.Controllers;

namespace Logtracker.Forms
{
    public partial class EditProfileForm : Form
    {
        private readonly ProfileController _profileController;
        private readonly int _userId;

        // Nama terbaru setelah berhasil disimpan; dipakai dashboard untuk refresh header.
        public string? UpdatedNama { get; private set; }

        public EditProfileForm(ProfileController profileController, int userId)
        {
            InitializeComponent();
            _profileController = profileController;
            _userId = userId;
            LoadDetail();
        }

        private void LoadDetail()
        {
            var detail = _profileController.GetDetail(_userId);
            if (detail == null)
            {
                MessageBox.Show("Data profil tidak ditemukan.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblUsernameValue.Text = detail.Username;
            lblRoleValue.Text = detail.Role;
            txtNama.Text = detail.Nama;
            txtEmail.Text = detail.Email ?? string.Empty;

            if (string.IsNullOrEmpty(detail.KodePeserta))
            {
                lblKodeLabel.Visible = false;
                lblKodeValue.Visible = false;
            }
            else
            {
                lblKodeValue.Text = detail.KodePeserta;
            }
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            var (success, msg) = _profileController.UpdateProfile(
                _userId,
                txtNama.Text.Trim(),
                txtEmail.Text.Trim(),
                txtCurrentPassword.Text,
                txtNewPassword.Text);

            MessageBox.Show(msg, success ? "Sukses" : "Gagal",
                MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            if (success)
            {
                UpdatedNama = txtNama.Text.Trim();
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnTutup_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
