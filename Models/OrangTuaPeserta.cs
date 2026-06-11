namespace Logtracker.Models
{
    public class OrangTuaPeserta
    {
        // ENKAPSULASI berkondisi: field privat + setter berlogika (bukan auto-property).
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        private int _ortuId;
        public int OrtuId
        {
            get => _ortuId;
            set => _ortuId = value < 0 ? 0 : value;
        }

        private int _pesertaId;
        public int PesertaId
        {
            get => _pesertaId;
            set => _pesertaId = value < 0 ? 0 : value;
        }
    }
}
