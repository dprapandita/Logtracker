namespace Logtracker.Forms
{
    partial class EditProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblUsernameLabel;
        private Label lblUsernameValue;
        private Label lblRoleLabel;
        private Label lblRoleValue;
        private Label lblKodeLabel;
        private Label lblKodeValue;
        private GroupBox grpEdit;
        private Label lblNamaLabel;
        private TextBox txtNama;
        private Label lblEmailLabel;
        private TextBox txtEmail;
        private GroupBox grpPassword;
        private Label lblCurrentLabel;
        private TextBox txtCurrentPassword;
        private Label lblNewLabel;
        private TextBox txtNewPassword;
        private Button btnSimpan;
        private Button btnTutup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpInfo = new GroupBox();
            lblUsernameLabel = new Label();
            lblUsernameValue = new Label();
            lblRoleLabel = new Label();
            lblRoleValue = new Label();
            lblKodeLabel = new Label();
            lblKodeValue = new Label();
            grpEdit = new GroupBox();
            lblNamaLabel = new Label();
            txtNama = new TextBox();
            lblEmailLabel = new Label();
            txtEmail = new TextBox();
            grpPassword = new GroupBox();
            lblCurrentLabel = new Label();
            txtCurrentPassword = new TextBox();
            lblNewLabel = new Label();
            txtNewPassword = new TextBox();
            btnSimpan = new Button();
            btnTutup = new Button();
            grpInfo.SuspendLayout();
            grpEdit.SuspendLayout();
            grpPassword.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(14, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(430, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Profil Saya";
            //
            // grpInfo
            //
            grpInfo.Controls.Add(lblUsernameLabel);
            grpInfo.Controls.Add(lblUsernameValue);
            grpInfo.Controls.Add(lblRoleLabel);
            grpInfo.Controls.Add(lblRoleValue);
            grpInfo.Controls.Add(lblKodeLabel);
            grpInfo.Controls.Add(lblKodeValue);
            grpInfo.FlatStyle = FlatStyle.Flat;
            grpInfo.ForeColor = Color.FromArgb(55, 36, 20);
            grpInfo.Location = new Point(14, 50);
            grpInfo.Name = "grpInfo";
            grpInfo.Size = new Size(430, 100);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Informasi Akun";
            //
            // lblUsernameLabel
            //
            lblUsernameLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblUsernameLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblUsernameLabel.Location = new Point(10, 25);
            lblUsernameLabel.Name = "lblUsernameLabel";
            lblUsernameLabel.Size = new Size(110, 20);
            lblUsernameLabel.TabIndex = 0;
            lblUsernameLabel.Text = "Username:";
            //
            // lblUsernameValue
            //
            lblUsernameValue.Font = new Font("Palatino Linotype", 9F);
            lblUsernameValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblUsernameValue.Location = new Point(125, 25);
            lblUsernameValue.Name = "lblUsernameValue";
            lblUsernameValue.Size = new Size(295, 20);
            lblUsernameValue.TabIndex = 1;
            lblUsernameValue.Text = "-";
            //
            // lblRoleLabel
            //
            lblRoleLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblRoleLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblRoleLabel.Location = new Point(10, 50);
            lblRoleLabel.Name = "lblRoleLabel";
            lblRoleLabel.Size = new Size(110, 20);
            lblRoleLabel.TabIndex = 2;
            lblRoleLabel.Text = "Role:";
            //
            // lblRoleValue
            //
            lblRoleValue.Font = new Font("Palatino Linotype", 9F);
            lblRoleValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblRoleValue.Location = new Point(125, 50);
            lblRoleValue.Name = "lblRoleValue";
            lblRoleValue.Size = new Size(295, 20);
            lblRoleValue.TabIndex = 3;
            lblRoleValue.Text = "-";
            //
            // lblKodeLabel
            //
            lblKodeLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblKodeLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblKodeLabel.Location = new Point(10, 75);
            lblKodeLabel.Name = "lblKodeLabel";
            lblKodeLabel.Size = new Size(110, 20);
            lblKodeLabel.TabIndex = 4;
            lblKodeLabel.Text = "Kode Peserta:";
            //
            // lblKodeValue
            //
            lblKodeValue.Font = new Font("Palatino Linotype", 9F);
            lblKodeValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblKodeValue.Location = new Point(125, 75);
            lblKodeValue.Name = "lblKodeValue";
            lblKodeValue.Size = new Size(295, 20);
            lblKodeValue.TabIndex = 5;
            lblKodeValue.Text = "-";
            //
            // grpEdit
            //
            grpEdit.Controls.Add(lblNamaLabel);
            grpEdit.Controls.Add(txtNama);
            grpEdit.Controls.Add(lblEmailLabel);
            grpEdit.Controls.Add(txtEmail);
            grpEdit.FlatStyle = FlatStyle.Flat;
            grpEdit.ForeColor = Color.FromArgb(55, 36, 20);
            grpEdit.Location = new Point(14, 160);
            grpEdit.Name = "grpEdit";
            grpEdit.Size = new Size(430, 95);
            grpEdit.TabIndex = 2;
            grpEdit.TabStop = false;
            grpEdit.Text = "Ubah Data";
            //
            // lblNamaLabel
            //
            lblNamaLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblNamaLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblNamaLabel.Location = new Point(10, 28);
            lblNamaLabel.Name = "lblNamaLabel";
            lblNamaLabel.Size = new Size(110, 20);
            lblNamaLabel.TabIndex = 0;
            lblNamaLabel.Text = "Nama:";
            //
            // txtNama
            //
            txtNama.BackColor = Color.FromArgb(247, 235, 223);
            txtNama.BorderStyle = BorderStyle.FixedSingle;
            txtNama.Font = new Font("Palatino Linotype", 9F);
            txtNama.ForeColor = Color.FromArgb(30, 30, 30);
            txtNama.Location = new Point(125, 25);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(295, 25);
            txtNama.TabIndex = 1;
            //
            // lblEmailLabel
            //
            lblEmailLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblEmailLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblEmailLabel.Location = new Point(10, 60);
            lblEmailLabel.Name = "lblEmailLabel";
            lblEmailLabel.Size = new Size(110, 20);
            lblEmailLabel.TabIndex = 2;
            lblEmailLabel.Text = "Email:";
            //
            // txtEmail
            //
            txtEmail.BackColor = Color.FromArgb(247, 235, 223);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Palatino Linotype", 9F);
            txtEmail.ForeColor = Color.FromArgb(30, 30, 30);
            txtEmail.Location = new Point(125, 57);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(295, 25);
            txtEmail.TabIndex = 3;
            //
            // grpPassword
            //
            grpPassword.Controls.Add(lblCurrentLabel);
            grpPassword.Controls.Add(txtCurrentPassword);
            grpPassword.Controls.Add(lblNewLabel);
            grpPassword.Controls.Add(txtNewPassword);
            grpPassword.FlatStyle = FlatStyle.Flat;
            grpPassword.ForeColor = Color.FromArgb(55, 36, 20);
            grpPassword.Location = new Point(14, 265);
            grpPassword.Name = "grpPassword";
            grpPassword.Size = new Size(430, 95);
            grpPassword.TabIndex = 3;
            grpPassword.TabStop = false;
            grpPassword.Text = "Ganti Password (opsional)";
            //
            // lblCurrentLabel
            //
            lblCurrentLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblCurrentLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblCurrentLabel.Location = new Point(10, 28);
            lblCurrentLabel.Name = "lblCurrentLabel";
            lblCurrentLabel.Size = new Size(125, 20);
            lblCurrentLabel.TabIndex = 0;
            lblCurrentLabel.Text = "Password Lama:";
            //
            // txtCurrentPassword
            //
            txtCurrentPassword.BackColor = Color.FromArgb(247, 235, 223);
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Palatino Linotype", 9F);
            txtCurrentPassword.ForeColor = Color.FromArgb(30, 30, 30);
            txtCurrentPassword.Location = new Point(140, 25);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(280, 25);
            txtCurrentPassword.TabIndex = 1;
            txtCurrentPassword.UseSystemPasswordChar = true;
            //
            // lblNewLabel
            //
            lblNewLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblNewLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblNewLabel.Location = new Point(10, 60);
            lblNewLabel.Name = "lblNewLabel";
            lblNewLabel.Size = new Size(125, 20);
            lblNewLabel.TabIndex = 2;
            lblNewLabel.Text = "Password Baru:";
            //
            // txtNewPassword
            //
            txtNewPassword.BackColor = Color.FromArgb(247, 235, 223);
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Palatino Linotype", 9F);
            txtNewPassword.ForeColor = Color.FromArgb(30, 30, 30);
            txtNewPassword.Location = new Point(140, 57);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(280, 25);
            txtNewPassword.TabIndex = 3;
            txtNewPassword.UseSystemPasswordChar = true;
            //
            // btnSimpan
            //
            btnSimpan.BackColor = Color.FromArgb(213, 184, 147);
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.ForeColor = Color.FromArgb(55, 36, 20);
            btnSimpan.Location = new Point(255, 372);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(90, 30);
            btnSimpan.TabIndex = 4;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            //
            // btnTutup
            //
            btnTutup.BackColor = Color.FromArgb(213, 184, 147);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.ForeColor = Color.FromArgb(55, 36, 20);
            btnTutup.Location = new Point(354, 372);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(90, 30);
            btnTutup.TabIndex = 5;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += btnTutup_Click;
            //
            // EditProfileForm
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(458, 415);
            Controls.Add(lblTitle);
            Controls.Add(grpInfo);
            Controls.Add(grpEdit);
            Controls.Add(grpPassword);
            Controls.Add(btnSimpan);
            Controls.Add(btnTutup);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProfileForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Profil Saya";
            grpInfo.ResumeLayout(false);
            grpEdit.ResumeLayout(false);
            grpEdit.PerformLayout();
            grpPassword.ResumeLayout(false);
            grpPassword.PerformLayout();
            ResumeLayout(false);
        }
    }
}
