using Logtracker.Controllers;
using Logtracker.Models;

namespace Logtracker.Forms
{
    public partial class DetailAktivitasForm : Form
    {
        private readonly Aktivitas _aktivitas;
        private readonly DetailAktivitasController _controller;

        public DetailAktivitasForm(Aktivitas aktivitas, DetailAktivitasController controller)
        {
            InitializeComponent();
            _aktivitas = aktivitas;
            _controller = controller;
            LoadDetail();
            LoadFeedback();
        }

        private void LoadDetail()
        {
            lblTitle.Text = $"Detail Aktivitas: {_aktivitas.Nama}";
            lblNamaValue.Text = _aktivitas.Nama;
            lblKategoriValue.Text = _aktivitas.NamaKategori ?? "-";
            lblDurasiValue.Text = $"{_aktivitas.Durasi} menit";
            lblTanggalValue.Text = _aktivitas.Tanggal.ToString("yyyy-MM-dd");
            lblStatusValue.Text = _aktivitas.NamaStatus ?? "Menunggu";

            lblStatusValue.ForeColor = _aktivitas.NamaStatus switch
            {
                "Disetujui" => Color.Green,
                "Revisi" => Color.OrangeRed,
                _ => Color.Gray
            };
        }

        private void LoadFeedback()
        {
            try
            {
                lstFeedback.Items.Clear();
                var feedbackList = _controller.GetFeedbackByAktivitas(_aktivitas.Id);
                foreach (var fb in feedbackList)
                {
                    lstFeedback.Items.Add($"[{fb.CreatedAt:dd-MM-yyyy HH:mm}] {fb.NamaCoach}: {fb.Feedback}");
                }

                if (feedbackList.Count == 0)
                {
                    lstFeedback.Items.Add("Belum ada feedback dari coach.");
                }
            }
            catch
            {
                lstFeedback.Items.Clear();
                lstFeedback.Items.Add("Gagal memuat feedback.");
            }
        }

        private void btnTutup_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
