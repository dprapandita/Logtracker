namespace Logtracker.Models
{
    // INHERITANCE: mewarisi properti Id dari BaseEntity.
    public class PesertaCoach : BaseEntity
    {
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
