namespace Logtracker.Models
{
    public class PesertaCoach
    {
        // ENKAPSULASI berkondisi: field privat + setter berlogika (bukan auto-property).
        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value < 0 ? 0 : value;
        }

        private int _pesertaId;
        public int PesertaId
        {
            get => _pesertaId;
            set => _pesertaId = value < 0 ? 0 : value;
        }

        private int _coachId;
        public int CoachId
        {
            get => _coachId;
            set => _coachId = value < 0 ? 0 : value;
        }
    }
}
