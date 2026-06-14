namespace Logtracker.Models
{
    // Tabel relasi ortu-peserta. Id-nya nurun dari BaseEntity.
    public class OrangTuaPeserta : BaseEntity
    {
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
