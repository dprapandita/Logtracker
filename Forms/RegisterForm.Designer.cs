namespace Logtracker.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblNama;
        private TextBox txtNama;
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

            lblNama.Text = "Nama:";
            lblNama.Location = new Point(40, 70);
            lblNama.Size = new Size(80, 25);

            txtNama.Location = new Point(40, 97);
            txtNama.Size = new Size(320, 27);

            lblEmail.Text = "Email:";
            lblEmail.Location = new Point(40, 135);
            lblEmail.Size = new Size(80, 25);

            txtEmail.Location = new Point(40, 162);
            txtEmail.Size = new Size(320, 27);

            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(40, 200);
            lblPassword.Size = new Size(80, 25);

            txtPassword.Location = new Point(40, 227);
            txtPassword.Size = new Size(320, 27);
            txtPassword.UseSystemPasswordChar = true;

            lblRole.Text = "Role:";
            lblRole.Location = new Point(40, 265);
            lblRole.Size = new Size(80, 25);

            cboRole.Location = new Point(40, 292);
            cboRole.Size = new Size(320, 28);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            //cboRole.Items.AddRange(["peserta", "penga", "ortu"]);
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;

            lblKodePeserta.Text = "Kode Peserta Anak:";
            lblKodePeserta.Location = new Point(40, 330);
            lblKodePeserta.Size = new Size(140, 25);

            txtKodePeserta.Location = new Point(40, 357);
            txtKodePeserta.Size = new Size(320, 27);

            btnRegister.Text = "Daftar";
            btnRegister.Location = new Point(40, 400);
            btnRegister.Size = new Size(150, 35);
            btnRegister.Click += btnRegister_Click;

            btnBatal.Text = "Batal";
            btnBatal.Location = new Point(210, 400);
            btnBatal.Size = new Size(150, 35);
            btnBatal.Click += btnBatal_Click;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 455);
            Text = "LOGTRACKER - Register";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(lblTitle);
            Controls.Add(lblNama);
            Controls.Add(txtNama);
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
