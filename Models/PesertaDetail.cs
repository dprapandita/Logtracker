namespace Logtracker.Models
{
    public class PesertaDetail
    {
        // Field privat dengan setter yang divalidasi dulu, bukan auto-property.
        private int _userId;
        public int UserId
        {
            get => _userId;
            set => _userId = value < 0 ? 0 : value;
        }

        private string _kodePeserta = string.Empty;
        public string KodePeserta
        {
            get => _kodePeserta;
            set => _kodePeserta = value?.Trim() ?? string.Empty;
        }
    }
}
