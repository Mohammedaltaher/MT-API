using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IOccupationFemaleRepository : IBaseRepository<OccupationFemale>
    {
        /// Add other interface here
    }

    #region Implementation
    public class OccupationFemaleRepository : BaseRepository<OccupationFemale>, IOccupationFemaleRepository
    {
        public OccupationFemaleRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
