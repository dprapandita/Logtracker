namespace Logtracker.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblNama;
        private TextBox txtNama;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblRole;
        private ComboBox cboRole;
        private Label lblKodePeserta;
        private TextBox txtKodePeserta;
        private Button btnRegister;
        private Button btnBatal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblNama = new Label();
            txtNama = new TextBox();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblRole = new Label();
            cboRole = new ComboBox();
            lblKodePeserta = new Label();
            txtKodePeserta = new TextBox();
            btnRegister = new Button();
            btnBatal = new Button();
            SuspendLayout();

            lblTitle.Text = "Daftar Akun Baru";
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(0, 15);
            lblTitle.Size = new Size(400, 40);

            lblNama.Text = "Nama Lengkap:";
            lblNama.Location = new Point(40, 65);
            lblNama.Size = new Size(100, 25);

            txtNama.Location = new Point(40, 92);
            txtNama.Size = new Size(320, 27);

            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(40, 130);
            lblUsername.Size = new Size(80, 25);

            txtUsername.Location = new Point(40, 157);
            txtUsername.Size = new Size(320, 27);

            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(40, 195);
            lblEmail.Size = new Size(80, 25);

            txtEmail.Location = new Point(40, 222);
            txtEmail.Size = new Size(320, 27);

            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(40, 260);
            lblPassword.Size = new Size(80, 25);

            txtPassword.Location = new Point(40, 287);
            txtPassword.Size = new Size(320, 27);
            txtPassword.UseSystemPasswordChar = true;

            lblRole.Text = "Role:";
            lblRole.Location = new Point(40, 325);
            lblRole.Size = new Size(80, 25);

            cboRole.Location = new Point(40, 352);
            cboRole.Size = new Size(320, 28);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;

            lblKodePeserta.Text = "Kode Peserta Anak:";
            lblKodePeserta.Location = new Point(40, 390);
            lblKodePeserta.Size = new Size(140, 25);

            txtKodePeserta.Location = new Point(40, 417);
            txtKodePeserta.Size = new Size(320, 27);

            btnRegister.Text = "Daftar";
            btnRegister.Location = new Point(40, 460);
            btnRegister.Size = new Size(150, 35);
            btnRegister.Click += btnRegister_Click;

            btnBatal.Text = "Batal";
            btnBatal.Location = new Point(210, 460);
            btnBatal.Size = new Size(150, 35);
            btnBatal.Click += btnBatal_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 515);
            Text = "LOGTRACKER - Register";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(lblTitle);
            Controls.Add(lblNama);
            Controls.Add(txtNama);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(lblRole);
            Controls.Add(cboRole);
            Controls.Add(lblKodePeserta);
            Controls.Add(txtKodePeserta);
            Controls.Add(btnRegister);
            Controls.Add(btnBatal);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
