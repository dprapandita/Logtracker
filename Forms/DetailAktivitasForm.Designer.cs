namespace Logtracker.Forms
{
    partial class DetailAktivitasForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private GroupBox grpInfo;
        private Label lblNamaLabel;
        private Label lblNamaValue;
        private Label lblKategoriLabel;
        private Label lblKategoriValue;
        private Label lblDurasiLabel;
        private Label lblDurasiValue;
        private Label lblTanggalLabel;
        private Label lblTanggalValue;
        private Label lblStatusLabel;
        private Label lblStatusValue;
        private GroupBox grpFeedback;
        private ListBox lstFeedback;
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
            lblNamaLabel = new Label();
            lblNamaValue = new Label();
            lblKategoriLabel = new Label();
            lblKategoriValue = new Label();
            lblDurasiLabel = new Label();
            lblDurasiValue = new Label();
            lblTanggalLabel = new Label();
            lblTanggalValue = new Label();
            lblStatusLabel = new Label();
            lblStatusValue = new Label();
            grpFeedback = new GroupBox();
            lstFeedback = new ListBox();
            btnTutup = new Button();
            grpInfo.SuspendLayout();
            grpFeedback.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(55, 36, 20);
            lblTitle.Location = new Point(14, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(420, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Detail Aktivitas";
            //
            // grpInfo
            //
            grpInfo.Controls.Add(lblNamaLabel);
            grpInfo.Controls.Add(lblNamaValue);
            grpInfo.Controls.Add(lblKategoriLabel);
            grpInfo.Controls.Add(lblKategoriValue);
            grpInfo.Controls.Add(lblDurasiLabel);
            grpInfo.Controls.Add(lblDurasiValue);
            grpInfo.Controls.Add(lblTanggalLabel);
            grpInfo.Controls.Add(lblTanggalValue);
            grpInfo.Controls.Add(lblStatusLabel);
            grpInfo.Controls.Add(lblStatusValue);
            grpInfo.FlatStyle = FlatStyle.Flat;
            grpInfo.ForeColor = Color.FromArgb(55, 36, 20);
            grpInfo.Location = new Point(14, 50);
            grpInfo.Margin = new Padding(3, 2, 3, 2);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(3, 2, 3, 2);
            grpInfo.Size = new Size(420, 150);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Informasi Aktivitas";
            //
            // lblNamaLabel
            //
            lblNamaLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblNamaLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblNamaLabel.Location = new Point(10, 22);
            lblNamaLabel.Name = "lblNamaLabel";
            lblNamaLabel.Size = new Size(100, 20);
            lblNamaLabel.TabIndex = 0;
            lblNamaLabel.Text = "Nama:";
            //
            // lblNamaValue
            //
            lblNamaValue.Font = new Font("Palatino Linotype", 9F);
            lblNamaValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblNamaValue.Location = new Point(110, 22);
            lblNamaValue.Name = "lblNamaValue";
            lblNamaValue.Size = new Size(290, 20);
            lblNamaValue.TabIndex = 1;
            lblNamaValue.Text = "-";
            //
            // lblKategoriLabel
            //
            lblKategoriLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblKategoriLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblKategoriLabel.Location = new Point(10, 47);
            lblKategoriLabel.Name = "lblKategoriLabel";
            lblKategoriLabel.Size = new Size(100, 20);
            lblKategoriLabel.TabIndex = 2;
            lblKategoriLabel.Text = "Kategori:";
            //
            // lblKategoriValue
            //
            lblKategoriValue.Font = new Font("Palatino Linotype", 9F);
            lblKategoriValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblKategoriValue.Location = new Point(110, 47);
            lblKategoriValue.Name = "lblKategoriValue";
            lblKategoriValue.Size = new Size(290, 20);
            lblKategoriValue.TabIndex = 3;
            lblKategoriValue.Text = "-";
            //
            // lblDurasiLabel
            //
            lblDurasiLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblDurasiLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblDurasiLabel.Location = new Point(10, 72);
            lblDurasiLabel.Name = "lblDurasiLabel";
            lblDurasiLabel.Size = new Size(100, 20);
            lblDurasiLabel.TabIndex = 4;
            lblDurasiLabel.Text = "Durasi:";
            //
            // lblDurasiValue
            //
            lblDurasiValue.Font = new Font("Palatino Linotype", 9F);
            lblDurasiValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblDurasiValue.Location = new Point(110, 72);
            lblDurasiValue.Name = "lblDurasiValue";
            lblDurasiValue.Size = new Size(290, 20);
            lblDurasiValue.TabIndex = 5;
            lblDurasiValue.Text = "-";
            //
            // lblTanggalLabel
            //
            lblTanggalLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblTanggalLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblTanggalLabel.Location = new Point(10, 97);
            lblTanggalLabel.Name = "lblTanggalLabel";
            lblTanggalLabel.Size = new Size(100, 20);
            lblTanggalLabel.TabIndex = 6;
            lblTanggalLabel.Text = "Tanggal:";
            //
            // lblTanggalValue
            //
            lblTanggalValue.Font = new Font("Palatino Linotype", 9F);
            lblTanggalValue.ForeColor = Color.FromArgb(30, 30, 30);
            lblTanggalValue.Location = new Point(110, 97);
            lblTanggalValue.Name = "lblTanggalValue";
            lblTanggalValue.Size = new Size(290, 20);
            lblTanggalValue.TabIndex = 7;
            lblTanggalValue.Text = "-";
            //
            // lblStatusLabel
            //
            lblStatusLabel.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblStatusLabel.ForeColor = Color.FromArgb(55, 36, 20);
            lblStatusLabel.Location = new Point(10, 122);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(100, 20);
            lblStatusLabel.TabIndex = 8;
            lblStatusLabel.Text = "Status:";
            //
            // lblStatusValue
            //
            lblStatusValue.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lblStatusValue.ForeColor = Color.FromArgb(55, 36, 20);
            lblStatusValue.Location = new Point(110, 122);
            lblStatusValue.Name = "lblStatusValue";
            lblStatusValue.Size = new Size(290, 20);
            lblStatusValue.TabIndex = 9;
            lblStatusValue.Text = "-";
            //
            // grpFeedback
            //
            grpFeedback.Controls.Add(lstFeedback);
            grpFeedback.FlatStyle = FlatStyle.Flat;
            grpFeedback.ForeColor = Color.FromArgb(55, 36, 20);
            grpFeedback.Location = new Point(14, 210);
            grpFeedback.Margin = new Padding(3, 2, 3, 2);
            grpFeedback.Name = "grpFeedback";
            grpFeedback.Padding = new Padding(3, 2, 3, 2);
            grpFeedback.Size = new Size(420, 160);
            grpFeedback.TabIndex = 2;
            grpFeedback.TabStop = false;
            grpFeedback.Text = "Feedback Coach";
            //
            // lstFeedback
            //
            lstFeedback.BackColor = Color.FromArgb(111, 77, 56);
            lstFeedback.BorderStyle = BorderStyle.None;
            lstFeedback.Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            lstFeedback.ForeColor = Color.FromArgb(247, 235, 223);
            lstFeedback.HorizontalScrollbar = true;
            lstFeedback.Location = new Point(10, 22);
            lstFeedback.Margin = new Padding(3, 2, 3, 2);
            lstFeedback.Name = "lstFeedback";
            lstFeedback.Size = new Size(400, 130);
            lstFeedback.TabIndex = 0;
            //
            // btnTutup
            //
            btnTutup.BackColor = Color.FromArgb(213, 184, 147);
            btnTutup.FlatStyle = FlatStyle.Flat;
            btnTutup.ForeColor = Color.FromArgb(55, 36, 20);
            btnTutup.Location = new Point(355, 380);
            btnTutup.Margin = new Padding(3, 2, 3, 2);
            btnTutup.Name = "btnTutup";
            btnTutup.Size = new Size(79, 29);
            btnTutup.TabIndex = 3;
            btnTutup.Text = "Tutup";
            btnTutup.UseVisualStyleBackColor = false;
            btnTutup.Click += btnTutup_Click;
            //
            // DetailAktivitasForm
            //
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(183, 160, 135);
            ClientSize = new Size(448, 420);
            Controls.Add(lblTitle);
            Controls.Add(grpInfo);
            Controls.Add(grpFeedback);
            Controls.Add(btnTutup);
            Font = new Font("Palatino Linotype", 9F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetailAktivitasForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detail Aktivitas";
            grpInfo.ResumeLayout(false);
            grpFeedback.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
