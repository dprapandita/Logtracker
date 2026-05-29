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

            lblTitle.Text = "LOGTRACKER";
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Location = new Point(0, 20);
            lblTitle.Size = new Size(350, 45);

            lblUsername.Text = "Username:";
            lblUsername.Location = new Point(50, 85);
            lblUsername.Size = new Size(80, 25);

            txtUsername.Location = new Point(50, 112);
            txtUsername.Size = new Size(250, 27);

            lblPassword.Text = "Password:";
            lblPassword.Location = new Point(50, 150);
            lblPassword.Size = new Size(80, 25);

            txtPassword.Location = new Point(50, 177);
            txtPassword.Size = new Size(250, 27);
            txtPassword.UseSystemPasswordChar = true;

            btnLogin.Text = "Login";
            btnLogin.Location = new Point(50, 220);
            btnLogin.Size = new Size(250, 35);
            btnLogin.Click += btnLogin_Click;

            llblRegister.Text = "Belum punya akun? Daftar di sini";
            llblRegister.Location = new Point(50, 265);
            llblRegister.Size = new Size(250, 25);
            llblRegister.TextAlign = ContentAlignment.MiddleCenter;
            llblRegister.LinkClicked += llblRegister_LinkClicked;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 310);
            Text = "LOGTRACKER - Login";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Controls.Add(lblTitle);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
            Controls.Add(llblRegister);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
