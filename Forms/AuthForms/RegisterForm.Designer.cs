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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
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
            lblTitle.Click += lblTitle_Click;
            // 
            // lblNama
            // 
            lblNama.ForeColor = Color.FromArgb(55, 36, 20);
            lblNama.Location = new Point(54, 59);
            lblNama.Name = "lblNama";
            lblNama.Size = new Size(70, 19);
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
            lblUsername.Location = new Point(54, 102);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(70, 19);
            lblUsername.TabIndex = 3;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(111, 77, 56);
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.ForeColor = Color.FromArgb(247, 235, 223);
            txtUsername.Location = new Point(35, 126);
            txtUsername.Margin = new Padding(3, 2, 3, 2);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(280, 17);
            txtUsername.TabIndex = 4;
            // 
            // lblEmail
            // 
            lblEmail.ForeColor = Color.FromArgb(55, 36, 20);
            lblEmail.Location = new Point(54, 145);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(70, 19);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            lblEmail.Click += lblEmail_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(111, 77, 56);
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.ForeColor = Color.FromArgb(247, 235, 223);
            txtEmail.Location = new Point(35, 169);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 17);
            txtEmail.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.ForeColor = Color.FromArgb(55, 36, 20);
            lblPassword.Location = new Point(54, 188);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 19);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(111, 77, 56);
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.ForeColor = Color.FromArgb(247, 235, 223);
            txtPassword.Location = new Point(35, 212);
            txtPassword.Margin = new Padding(3, 2, 3, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(280, 17);
            txtPassword.TabIndex = 8;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            lblRole.ForeColor = Color.FromArgb(55, 36, 20);
            lblRole.Location = new Point(54, 231);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(70, 19);
            lblRole.TabIndex = 9;
            lblRole.Text = "Role:";
            // 
            // cboRole
            // 
            cboRole.BackColor = Color.FromArgb(111, 77, 56);
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FlatStyle = FlatStyle.Flat;
            cboRole.ForeColor = Color.FromArgb(247, 235, 223);
            cboRole.Location = new Point(35, 255);
            cboRole.Margin = new Padding(3, 2, 3, 2);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(280, 25);
            cboRole.TabIndex = 10;
            cboRole.SelectedIndexChanged += cboRole_SelectedIndexChanged;
            // 
            // lblKodePeserta
            // 
            lblKodePeserta.ForeColor = Color.FromArgb(55, 36, 20);
            lblKodePeserta.Location = new Point(35, 282);
            lblKodePeserta.Name = "lblKodePeserta";
            lblKodePeserta.Size = new Size(122, 19);
            lblKodePeserta.TabIndex = 11;
            lblKodePeserta.Text = "Kode Peserta Anak:";
            lblKodePeserta.Click += lblKodePeserta_Click;
            // 
            // txtKodePeserta
            // 
            txtKodePeserta.BackColor = Color.FromArgb(111, 77, 56);
            txtKodePeserta.BorderStyle = BorderStyle.None;
            txtKodePeserta.ForeColor = Color.FromArgb(247, 235, 223);
            txtKodePeserta.Location = new Point(35, 306);
            txtKodePeserta.Margin = new Padding(3, 2, 3, 2);
            txtKodePeserta.Name = "txtKodePeserta";
            txtKodePeserta.Size = new Size(280, 17);
            txtKodePeserta.TabIndex = 12;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(213, 184, 147);
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Location = new Point(35, 371);
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
            btnBatal.Location = new Point(184, 371);
            btnBatal.Margin = new Padding(3, 2, 3, 2);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(131, 29);
            btnBatal.TabIndex = 14;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            btnBatal.Click += btnBatal_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(35, 59);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(19, 19);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(35, 102);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(19, 19);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(35, 145);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(19, 19);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(35, 188);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(19, 19);
            pictureBox4.TabIndex = 18;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(35, 231);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(19, 19);
            pictureBox5.TabIndex = 19;
            pictureBox5.TabStop = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(350, 409);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
    }
}
