using AggriPortal.API.Domain.Models;

namespace  AggriPortal.API.Persistence.Repository
{
    public interface IOccupationMaleRepository : IBaseRepository<OccupationMale>
    {
        /// Add other interface here
    }

    #region Implementation
    public class OccupationMaleRepository: BaseRepository<OccupationMale>, IOccupationMaleRepository
    {
        public OccupationMaleRepository(AppDbContext context)
            : base(context)
        {

        }
    }
    #endregion
}
