namespace Logtracker.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel llblRegister;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            llblRegister = new LinkLabel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Magneto", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(0, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(306, 34);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LOGTRACKER";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = Color.FromArgb(55, 36, 20);
            lblUsername.Location = new Point(44, 64);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 19);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(111, 77, 56);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            txtUsername.ForeColor = Color.FromArgb(247, 235, 223);
            txtUsername.Location = new Point(44, 84);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(219, 17);
            txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(55, 36, 20);
            lblPassword.Location = new Point(44, 112);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password:";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(111, 77, 56);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            txtPassword.ForeColor = Color.FromArgb(247, 235, 223);
            txtPassword.Location = new Point(44, 133);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(219, 17);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(213, 184, 147);
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            btnLogin.Location = new Point(44, 197);
            btnLogin.Margin = new Padding(3, 2, 3, 2);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(219, 26);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // llblRegister
            // 
            llblRegister.ActiveLinkColor = Color.SaddleBrown;
            llblRegister.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold | FontStyle.Italic);
            llblRegister.LinkBehavior = LinkBehavior.NeverUnderline;
            llblRegister.LinkColor = Color.FromArgb(55, 36, 20);
            llblRegister.Location = new Point(44, 228);
            llblRegister.Name = "llblRegister";
            llblRegister.Size = new Size(219, 19);
            llblRegister.TabIndex = 6;
            llblRegister.TabStop = true;
            llblRegister.Text = "Belum punya akun? Daftar di sini";
            llblRegister.TextAlign = ContentAlignment.MiddleCenter;
            llblRegister.LinkClicked += llblRegister_LinkClicked;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(306, 295);
            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(llblRegister);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGTRACKER - Login";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
