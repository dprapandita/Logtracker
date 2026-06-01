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
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(183, 160, 135);
            lblTitle.Font = new Font("Magneto", 15.75F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(0, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 34);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REGISTER";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNama
            // 
            lblNama.ForeColor = Color.FromArgb(55, 36, 20);
            lblNama.Location = new Point(35, 59);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(70, 22);
            lblNama.TabIndex = 1;
            lblNama.Text = "Nama:";
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.FromArgb(111, 77, 56);
            txtNama.BorderStyle = BorderStyle.None;
            txtNama.ForeColor = Color.FromArgb(247, 235, 223);
            txtNama.Location = new Point(35, 83);
            txtNama.Margin = new Padding(3, 2, 3, 2);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(280, 17);
            txtNama.TabIndex = 2;
            // 
            // lblUsername
            // 
            lblUsername.ForeColor = Color.FromArgb(55, 36, 20);
            lblUsername.Location = new Point(35, 114);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 22);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(111, 77, 56);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.ForeColor = Color.FromArgb(247, 235, 223);
            txtUsername.Location = new Point(35, 138);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 17);
            txtUsername.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.ForeColor = Color.FromArgb(55, 36, 20);
            lblEmail.Location = new Point(35, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(70, 22);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(111, 77, 56);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.ForeColor = Color.FromArgb(247, 235, 223);
            txtEmail.Location = new Point(35, 193);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 17);
            txtEmail.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.ForeColor = Color.FromArgb(55, 36, 20);
            lblPassword.Location = new Point(35, 226);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 22);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(111, 77, 56);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.FromArgb(247, 235, 223);
            txtPassword.Location = new Point(35, 248);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 17);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            lblRole.ForeColor = Color.FromArgb(55, 36, 20);
            lblRole.Location = new Point(35, 281);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(70, 22);
            lblRole.TabIndex = 9;
            lblRole.Text = "Role:";
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(111, 77, 56);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.ForeColor = Color.FromArgb(247, 235, 223);
            cboRole.Location = new Point(35, 304);
            cboRole.Margin = new Padding(3, 2, 3, 2);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(280, 25);
            cboRole.TabIndex = 10;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // lblKodePeserta
            // 
            lblKodePeserta.ForeColor = Color.FromArgb(55, 36, 20);
            lblKodePeserta.Location = new Point(35, 335);
            lblKodePeserta.Name = "lblKodePeserta";
            lblKodePeserta.Size = new Size(122, 22);
            lblKodePeserta.TabIndex = 11;
            lblKodePeserta.Text = "Kode Peserta Anak:";
            lblKodePeserta.Click += lblKodePeserta_Click;
            // 
            // txtKodePeserta
            // 
            txtKodePeserta.BackColor = Color.FromArgb(111, 77, 56);
            txtKodePeserta.BorderStyle = BorderStyle.None;
            txtKodePeserta.ForeColor = Color.FromArgb(247, 235, 223);
            txtKodePeserta.Location = new Point(35, 358);
            txtKodePeserta.Margin = new Padding(3, 2, 3, 2);
            txtKodePeserta.Name = "txtKodePeserta";
            txtKodePeserta.Size = new Size(280, 17);
            txtKodePeserta.TabIndex = 12;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(213, 184, 147);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(35, 396);
            btnRegister.Margin = new Padding(3, 2, 3, 2);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(131, 29);
            btnRegister.TabIndex = 13;
            btnRegister.Text = "Daftar";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(213, 184, 147);
            btnBatal.FlatStyle = FlatStyle.Flat;
            btnBatal.Location = new Point(184, 396);
            btnBatal.Margin = new Padding(3, 2, 3, 2);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(131, 29);
            btnBatal.TabIndex = 14;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(350, 447);
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
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LOGTRACKER - Register";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
